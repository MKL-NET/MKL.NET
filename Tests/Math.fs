[<AutoOpen>]
module Math

open System

let private cof = [| -1.3026537197817094; 6.4196979235649026e-1;
    1.9476473204185836e-2;-9.561514786808631e-3;-9.46595344482036e-4;
    3.66839497852761e-4;4.2523324806907e-5;-2.0278578112534e-5;
    -1.624290004647e-6;1.303655835580e-6;1.5626441722e-8;-8.5238095915e-8;
    6.529054439e-9;5.059343495e-9;-9.91364156e-10;-2.27365122e-10;
    9.6467911e-11; 2.394038e-12;-6.886027e-12;8.94487e-13; 3.13092e-13;
    -1.12708e-13;3.81e-16;7.106e-15;-1.523e-15;-9.4e-17;1.21e-16;-2.8e-17
|]

let private erfccheb x =
    let t = 2.0 / (2.0 + x)
    let ty = 4.0 * t - 2.0
    let mutable d,dd = 0.0,0.0
    for j = cof.Length - 1 downto 1 do
        let tmp = d
        d <- ty*d - dd + cof.[j]
        dd <- tmp
    t * exp(-x*x + 0.5*(cof.[0] + ty*d) - dd)

/// Computes the error function. This function is defined by 2/sqrt(pi) * integral from 0 to x of exp (-t^2) dt
let erf x = if x >= 0.0 then 1.0 - erfccheb x else erfccheb -x - 1.0
/// Computes the complementary error function. This function is defined by 2/sqrt(pi) * integral from x to infinity of exp (-t^2) dt
let erfc x = if x >= 0.0 then erfccheb x else 2.0 - erfccheb -x

let inline private erfcc x =
    let t = 2.0 / (2.0 + abs x)
    t * exp (-x * x - 1.26551223 + t * (1.00002368 + t * (0.37409196 + t * (0.09678418 + t * (-0.18628806 + t * (0.27886807 + t * (-1.13520398 + t * (1.48851587 + t * (-0.82215223 + t * 0.17087277)))))))))
let erfSinglePrecision x =
    if Double.IsNegativeInfinity x then -1.0
    elif Double.IsPositiveInfinity x then 1.0
    elif x >= 0.0 then 1.0 - erfcc x
    else erfcc x - 1.0
let erfcSinglePrecision x =
    if Double.IsNegativeInfinity x then 2.0
    elif Double.IsPositiveInfinity x then 0.0
    elif x >= 0.0 then erfcc x
    else 2.0 - erfcc x

[<Literal>]
let private invnegsqrt2 = -0.707106781186547 // = -1.0 / sqrt 2.0

/// Computes the standard normal cumulative distribution function value
let normcdf t = erfc(t * invnegsqrt2) * 0.5

/// Computes the inverse standard normal cumulative distribution function value
let normcdfinv x =
    let inline acklam p =  // http://home.online.no/~pjacklam/notes/invnorm/
        if p<0.02425 then
            let q = sqrt(-2.0*log p)
            (((((-7.784894002430293e-3*q-3.223964580411365e-1)*q-2.400758277161838)*q-2.549732539343734)*q+4.374664141464968)*q+2.938163982698783)
                / ((((7.784695709041462e-3*q+3.224671290700398e-1)*q+2.445134137142996)*q+3.754408661907416)*q+1.0)
        else
            let q = p-0.5
            let r = q*q
            (((((-3.969683028665376e1*r+2.209460984245205e2)*r-2.759285104469687e2)*r+1.383577518672690e2)*r-3.066479806614716e1)*r+2.506628277459239) * q
                / (((((-5.447609879822406e1*r+1.615858368580409e2)*r-1.556989798598866e2)*r+6.680131188771972e1)*r-1.328068155288572e1)*r+1.0)
    if x>0.5 then -acklam(1.0-x) else acklam x

let erfcinv x = invnegsqrt2 * normcdfinv(x * 0.5)

let erfinv x = invnegsqrt2 * normcdfinv((1.0 - x) * 0.5)

let private lgammacof = [|57.1562356658629235;-59.5979603554754912;
    14.1360979747417471;-0.491913816097620199;0.339946499848118887e-4;
    0.465236289270485756e-4;-0.983744753048795646e-4;0.158088703224912494e-3;
    -0.210264441724104883e-3;0.217439618115212643e-3;-0.164318106536763890e-3;
    0.844182239838527433e-4;-0.261908384015814087e-4;0.368991826595316234e-5
|]

/// Computes the natural logarithm of the gamma function
let lgamma x =
    let mutable y = x;
    let tmp = x + 5.2421875
    let tmp = (x+0.5)*log(tmp)-tmp
    let mutable ser = 0.999999999999997092
    for j = 0 to 13 do
        y <- y + 1.0
        ser <- ser + lgammacof.[j] / y
    tmp + log(2.5066282746310005*ser/x)

/// Computes the gamma function. n! = gamma(n+1)
let gamma x = exp(lgamma x)

[<Literal>]
let private EULER = 0.577215664901533

/// Computes the exponential integral
let expint n x =
    let epsilon = 0.00000000000000001
    let ndbl = float n
    if n = 0 then exp -x / x
    elif x = 0.0 then 1.0/(ndbl - 1.0)
    elif x > 1.0 then
        let nearDoubleMin = 1e-100
        let mutable b = x + ndbl
        let mutable c = 1.0/nearDoubleMin
        let mutable d = 1.0/b
        let mutable h = d
        let mutable i = 1
        let mutable check = true
        while i <= 100 && check do
            let a = -1.0 * (float i)*((ndbl - 1.0) + float i)
            b <- b + 2.0
            d <- 1.0/(a*d + b)
            c <- b + a/c
            let del = c*d
            h <- h*del
            i <- i + 1
            if abs(del - 1.0) < epsilon then check <- false
        h * exp -x
    else
        let mutable factorial = 1.0
        let mutable result = if ndbl - 1.0 <> 0.0 then 1.0/(ndbl - 1.0) else -1.0*log x - EULER
        let mutable i = 1
        let mutable check = true
        while i <= 100 && check do
            factorial <- factorial * -1.0*x/(float i)
            let del =
                if float i <> ndbl - 1.0 then -factorial/(float i - (ndbl - 1.0))
                else
                    let mutable psi = -EULER
                    for ii = 1 to int(floor(ndbl - 1.0)) do
                        psi <- psi + 1.0 / float ii
                    factorial*(-log x + psi)
            result <- result + del
            i <- i + 1
            if abs del < abs result * epsilon then check <- false
        result