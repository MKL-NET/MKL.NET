module BlasTests

open System
open MKLNET
open CsCheck

let ROWS_MAX = 5
let COLS_MAX = 3

let blas_1 =
    test "1" {

        test "asum_double" {
            let! x = Gen.Double.Array.[1,ROWS_MAX]
            let expected = Array.sumBy abs x
            Blas.asum x |> Check.close High expected
        }

        test "asum_single" {
            let! x = Gen.Single.Array.[1,ROWS_MAX]
            let expected = Array.sumBy abs x
            Blas.asum x |> Check.close High expected
        }

        test "asum_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let mutable expected = 0.0
            for i = 0 to rows-1 do
                expected <- expected + abs x.[i*cols+ini]
            Blas.asum(rows, x, ini, cols) |> Check.close High expected
        }

        test "asum_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Array.[rows*cols]
            let mutable expected = 0.0f
            for i = 0 to rows-1 do
                expected <- expected + abs x.[i*cols+ini]
            Blas.asum(rows, x, ini, cols) |> Check.close High expected
        }

        test "axpy_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! a = Gen.Double
            let! x = Gen.Double.Array.[rows]
            let! y = Gen.Double.Array.[rows]
            let expected = Array.map2 (fun x y -> a*x + y) x y
            Blas.axpy(a,x,y)
            Check.close High expected y
        }

        test "axpy_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! a = Gen.Single
            let! x = Gen.Single.NonNegative.Array.[rows]
            let! y = Gen.Single.NonNegative.Array.[rows]
            let expected = Array.map2 (fun x y -> a*x + y) x y
            Blas.axpy(a,x,y)
            Check.close Low expected y
        }

        test "axpy_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! a = Gen.Double
            let! x = Gen.Double.Array.[rows*cols]
            let! y = Gen.Double.Array.[rows*cols]
            let expected = Array.init rows (fun r -> a*x.[r*cols+ini] + y.[r*cols+ini])
            Blas.axpy(rows,a,x,ini,cols,y,ini,cols)
            for i = 0 to rows-1 do
                Check.close High expected.[i] y.[i*cols+ini]
        }

        test "axpy_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! a = Gen.Single
            let! x = Gen.Single.NonNegative.Array.[rows*cols]
            let! y = Gen.Single.NonNegative.Array.[rows*cols]
            let expected = Array.init rows (fun r -> a*x.[r*cols+ini] + y.[r*cols+ini])
            Blas.axpy(rows,a,x,ini,cols,y,ini,cols)
            for i = 0 to rows-1 do
                Check.close Low expected.[i] y.[i*cols+ini]
        }

        test "copy_double" {
            let! x = Gen.Double.Array.[1,ROWS_MAX]
            let y = Array.zeroCreate x.Length
            Blas.copy(x,y)
            Check.equal x y
        }

        test "copy_single" {
            let! x = Gen.Single.Array.[1,ROWS_MAX]
            let y = Array.zeroCreate x.Length
            Blas.copy(x,y)
            Check.equal x y
        }

        test "copy_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let y = Array.zeroCreate x.Length
            Blas.copy(rows,x,ini,cols,y,ini,cols)
            for i = 0 to rows-1 do
                Check.equal x.[i*cols+ini] y.[i*cols+ini]
        }

        test "copy_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Array.[rows*cols]
            let y = Array.zeroCreate x.Length
            Blas.copy(rows,x,ini,cols,y,ini,cols)
            for i = 0 to rows-1 do
                Check.equal x.[i*cols+ini] y.[i*cols+ini]
        }

        test "dot_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Double.NonNegative.Array.[rows]
            let! y = Gen.Double.NonNegative.Array.[rows]
            let expected = Array.fold2 (fun s x y -> s + x*y) 0.0 x y
            Blas.dot(x,y)
            |> Check.close High expected
        }

        test "dot_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Single.NonNegative.Array.[rows]
            let! y = Gen.Single.NonNegative.Array.[rows]
            let expected = Array.fold2 (fun s x y -> s + x*y) 0.0f x y
            Blas.dot(x,y)
            |> Check.close High expected
        }

        test "dot_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.NonNegative.Array.[rows*cols]
            let! y = Gen.Double.NonNegative.Array.[rows*cols]
            let mutable expected = 0.0
            for i = 0 to rows-1 do
                expected <- expected + x.[i*cols+ini]*y.[i*cols+ini]
            Blas.dot(rows,x,ini,cols,y,ini,cols)
            |> Check.close High expected
        }

        test "dot_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.NonNegative.Array.[rows*cols]
            let! y = Gen.Single.NonNegative.Array.[rows*cols]
            let mutable expected = 0.0f
            for i = 0 to rows-1 do
                expected <- expected + x.[i*cols+ini]*y.[i*cols+ini]
            Blas.dot(rows,x,ini,cols,y,ini,cols)
            |> Check.close High expected
        }

        test "sdot" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Single.NonNegative.Array.[rows]
            let! y = Gen.Single.NonNegative.Array.[rows]
            let expected = Array.fold2 (fun s x y -> s + double x * double y) 0.0 x y
            Blas.sdot(x,y)
            |> Check.close High expected
        }

        test "sdot_sb" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! sb = Gen.Single.NonNegative
            let! x = Gen.Single.NonNegative.Array.[rows]
            let! y = Gen.Single.NonNegative.Array.[rows]
            let expected = Array.fold2 (fun s x y -> s + double x * double y) (double sb) x y
            Blas.sdot(sb,x,y)
            |> Check.close High (single expected)
        }

        test "sdot_i" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.NonNegative.Array.[rows*cols]
            let! y = Gen.Single.NonNegative.Array.[rows*cols]
            let mutable expected = 0.0
            for i = 0 to rows-1 do
                expected <- expected + double x.[i*cols+ini] * double y.[i*cols+ini]
            Blas.sdot(rows,x,ini,cols,y,ini,cols)
            |> Check.close High expected
        }

        test "sdot_sb_i" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! sb = Gen.Single.NonNegative
            let! x = Gen.Single.NonNegative.Array.[rows*cols]
            let! y = Gen.Single.NonNegative.Array.[rows*cols]
            let mutable expected = double sb
            for i = 0 to rows-1 do
                expected <- expected + (double x.[i*cols+ini] * double y.[i*cols+ini])
            Blas.sdot(rows,sb,x,ini,cols,y,ini,cols)
            |> Check.close High (single expected)
        }

        test "nrm2_double" {
            let! x = Gen.Double.Array.[1,ROWS_MAX]
            let expected = Array.sumBy (fun x -> x * x) x |> sqrt
            Blas.nrm2 x |> Check.close High expected
        }

        test "nrm2_single" {
            let! x = Gen.Single.Array.[1,ROWS_MAX]
            let expected = Array.sumBy (fun x -> x * x) x |> sqrt
            Blas.nrm2 x |> Check.close High expected
        }

        test "nrm2_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let mutable expected = 0.0
            for i = 0 to rows-1 do
                let x = x.[i*cols+ini]
                expected <- expected + x * x
            Blas.nrm2(rows, x, ini, cols) |> Check.close High (sqrt expected)
        }

        test "nrm2_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Array.[rows*cols]
            let mutable expected = 0.0f
            for i = 0 to rows-1 do
                let x = x.[i*cols+ini]
                expected <- expected + x * x
            Blas.nrm2(rows, x, ini, cols) |> Check.close High (sqrt expected)
        }

        test "rot_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Double.Unit.Array.[rows]
            let! y = Gen.Double.Unit.Array.[rows]
            let! c = Gen.Double.Unit
            let! s = Gen.Double.Unit
            let expectedx = Array.init rows (fun i -> c*x.[i] + s*y.[i])
            let expectedy = Array.init rows (fun i -> c*y.[i] - s*x.[i])
            Blas.rot(x,y,c,s)
            for i = 0 to rows-1 do
                Check.close High expectedx.[i] x.[i]
                Check.close High expectedy.[i] y.[i]
        }

        test "rot_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Single.Unit.Array.[rows]
            let! y = Gen.Single.Unit.Array.[rows]
            let! c = Gen.Single.Unit
            let! s = Gen.Single.Unit
            let expectedx = Array.init rows (fun i -> c*x.[i] + s*y.[i])
            let expectedy = Array.init rows (fun i -> c*y.[i] - s*x.[i])
            Blas.rot(x,y,c,s)
            for i = 0 to rows-1 do
                Check.close Medium expectedx.[i] x.[i]
                Check.close Medium expectedy.[i] y.[i]
        }

        test "rot_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Unit.Array.[rows*cols]
            let! y = Gen.Double.Unit.Array.[rows*cols]
            let! c = Gen.Double.Unit
            let! s = Gen.Double.Unit
            let expectedx = Array.init rows (fun r -> c*x.[r*cols+ini] + s*y.[r*cols+ini])
            let expectedy = Array.init rows (fun r -> c*y.[r*cols+ini] - s*x.[r*cols+ini])
            Blas.rot(rows,x,ini,cols,y,ini,cols,c,s)
            for i = 0 to rows-1 do
                Check.close High expectedx.[i] x.[i*cols+ini]
                Check.close High expectedy.[i] y.[i*cols+ini]
        }

        test "rot_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Unit.Array.[rows*cols]
            let! y = Gen.Single.Unit.Array.[rows*cols]
            let! c = Gen.Single.Unit
            let! s = Gen.Single.Unit
            let expectedx = Array.init rows (fun r -> c*x.[r*cols+ini] + s*y.[r*cols+ini])
            let expectedy = Array.init rows (fun r -> c*y.[r*cols+ini] - s*x.[r*cols+ini])
            Blas.rot(rows,x,ini,cols,y,ini,cols,c,s)
            for i = 0 to rows-1 do
                Check.close Medium expectedx.[i] x.[i*cols+ini]
                Check.close Medium expectedy.[i] y.[i*cols+ini]
        }

        test "rotg_double" {
            let! a = Gen.Double.Unit
            let! b = Gen.Double.Unit
            let mutable r,z,c,s = a,b,0.0,0.0
            Blas.rotg(&r,&z,&c,&s)
            Check.close High r (c*a+s*b)
            Check.close High (c*b) (s*a)
            let expectedz =
                if abs a > abs b then s
                elif c <> 0.0 then 1.0/c
                else 1.0
            Check.close High expectedz z
        }

        test "rotg_single" {
            let! a = Gen.Single.Unit
            let! b = Gen.Single.Unit
            let mutable r,z,c,s = a,b,0.0f,0.0f
            Blas.rotg(&r,&z,&c,&s)
            Check.close High r (c*a+s*b)
            Check.close High (c*b) (s*a)
            let expectedz =
                if abs a > abs b then s
                elif c <> 0.0f then 1.0f/c
                else 1.0f
            Check.close High expectedz z
        }

        test "rotm_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Double.Unit.Array.[rows]
            let! y = Gen.Double.Unit.Array.[rows]
            let! h11 = Gen.Double.Unit
            let! h12 = Gen.Double.Unit
            let! h21 = Gen.Double.Unit
            let! h22 = Gen.Double.Unit
            let xactual = Array.copy x
            let yactual = Array.copy y
            Blas.rotm(xactual,yactual,[|-1.0;h11;h21;h12;h22|])
            for i = 0 to rows-1 do
                Check.close High (h11*x.[i]+h12*y.[i]) xactual.[i]
                Check.close High (h21*x.[i]+h22*y.[i]) yactual.[i]
        }

        test "rotm_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Single.Unit.Array.[rows]
            let! y = Gen.Single.Unit.Array.[rows]
            let! h11 = Gen.Single.Unit
            let! h12 = Gen.Single.Unit
            let! h21 = Gen.Single.Unit
            let! h22 = Gen.Single.Unit
            let xactual = Array.copy x
            let yactual = Array.copy y
            Blas.rotm(xactual,yactual,[|-1.0f;h11;h21;h12;h22|])
            for i = 0 to rows-1 do
                Check.close High (h11*x.[i]+h12*y.[i]) xactual.[i]
                Check.close High (h21*x.[i]+h22*y.[i]) yactual.[i]
        }

        test "rotm_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Unit.Array.[rows*cols]
            let! y = Gen.Double.Unit.Array.[rows*cols]
            let! h11 = Gen.Double.Unit
            let! h12 = Gen.Double.Unit
            let! h21 = Gen.Double.Unit
            let! h22 = Gen.Double.Unit
            let xactual = Array.copy x
            let yactual = Array.copy y
            Blas.rotm(rows,xactual,ini,cols,yactual,ini,cols,[|-1.0;h11;h21;h12;h22|])
            for i = 0 to rows-1 do
                Check.close High (h11*x.[i*cols+ini]+h12*y.[i*cols+ini]) xactual.[i*cols+ini]
                Check.close High (h21*x.[i*cols+ini]+h22*y.[i*cols+ini]) yactual.[i*cols+ini]
        }

        test "rotm_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Unit.Array.[rows*cols]
            let! y = Gen.Single.Unit.Array.[rows*cols]
            let! h11 = Gen.Single.Unit
            let! h12 = Gen.Single.Unit
            let! h21 = Gen.Single.Unit
            let! h22 = Gen.Single.Unit
            let xactual = Array.copy x
            let yactual = Array.copy y
            Blas.rotm(rows,xactual,ini,cols,yactual,ini,cols,[|-1.0f;h11;h21;h12;h22|])
            for i = 0 to rows-1 do
                Check.close High (h11*x.[i*cols+ini]+h12*y.[i*cols+ini]) xactual.[i*cols+ini]
                Check.close High (h21*x.[i*cols+ini]+h22*y.[i*cols+ini]) yactual.[i*cols+ini]
        }

        test "rotmg_double" {
            let! x1 = Gen.Double.Unit
            let! y1 = Gen.Double.Unit
            let! d1 = Gen.Double.Unit
            let! d2 = Gen.Double.Unit
            let mutable d1',d2',x1' = d1,d2,x1
            let param = Array.zeroCreate 5
            Blas.rotmg(&d1',&d2',&x1',y1,param)
            if param.[0] = 0.0 then
                param.[1] <- 1.0
                param.[4] <- 1.0
            elif param.[0] = 1.0 then
                param.[2] <- -1.0
                param.[3] <- 1.0
            elif param.[0] = -2.0 then
                param.[1] <- 1.0
                param.[2] <- 0.0
                param.[3] <- 0.0
                param.[4] <- 1.0
            Check.close High x1' (param.[1]*x1+param.[3]*y1)
            Check.close High (param.[2]*x1) (-param.[4]*y1)
        }

        test "rotmg_float" {
            let! x1 = Gen.Float.Unit
            let! y1 = Gen.Float.Unit
            let! d1 = Gen.Float.Unit
            let! d2 = Gen.Float.Unit
            let mutable d1',d2',x1' = d1,d2,x1
            let param = Array.zeroCreate 5
            Blas.rotmg(&d1',&d2',&x1',y1,param)
            if param.[0] = 0.0f then
                param.[1] <- 1.0f
                param.[4] <- 1.0f
            elif param.[0] = 1.0f then
                param.[2] <- -1.0f
                param.[3] <- 1.0f
            elif param.[0] = -2.0f then
                param.[1] <- 1.0f
                param.[2] <- 0.0f
                param.[3] <- 0.0f
                param.[4] <- 1.0f
            Check.close High x1' (param.[1]*x1+param.[3]*y1)
            Check.close High (param.[2]*x1) (-param.[4]*y1)
        }

        test "scal_double" {
            let! x = Gen.Double.Array.[1,ROWS_MAX]
            let! a = Gen.Double
            let expected = Array.map ((*)a) x
            Blas.scal(a,x)
            Check.close High expected x
        }

        test "scal_float" {
            let! x = Gen.Single.Array.[1,ROWS_MAX]
            let! a = Gen.Single
            let expected = Array.map ((*)a) x
            Blas.scal(a,x)
            Check.close High expected x
        }

        test "scal_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let! a = Gen.Double
            let expected = Array.mapi (fun i x -> if i % cols = ini then a*x else x) x
            Blas.scal(rows,a,x,ini,cols)
            Check.close High expected x
        }

        test "scal_i_float" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Array.[rows*cols]
            let! a = Gen.Single
            let expected = Array.mapi (fun i x -> if i % cols = ini then a*x else x) x
            Blas.scal(rows,a,x,ini,cols)
            Check.close High expected x
        }

        test "swap_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Double.Array.[rows]
            let! y = Gen.Double.Array.[rows]
            let expectedx = Array.copy y
            let expectedy = Array.copy x
            Blas.swap(x,y)
            Check.equal expectedx x
            Check.equal expectedy y
        }

        test "swap_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Single.Array.[rows]
            let! y = Gen.Single.Array.[rows]
            let expectedx = Array.copy y
            let expectedy = Array.copy x
            Blas.swap(x,y)
            Check.equal expectedx x
            Check.equal expectedy y
        }

        test "swap_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let! y = Gen.Double.Array.[rows*cols]
            let expectedx = Array.mapi2 (fun i x y -> if i % cols = ini then y else x) x y
            let expectedy = Array.mapi2 (fun i x y -> if i % cols = ini then x else y) x y
            Blas.swap(rows,x,ini,cols,y,ini,cols)
            Check.equal expectedx x
            Check.equal expectedy y
        }

        test "swap_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Array.[rows*cols]
            let! y = Gen.Single.Array.[rows*cols]
            let expectedx = Array.mapi2 (fun i x y -> if i % cols = ini then y else x) x y
            let expectedy = Array.mapi2 (fun i x y -> if i % cols = ini then x else y) x y
            Blas.swap(rows,x,ini,cols,y,ini,cols)
            Check.equal expectedx x
            Check.equal expectedy y
        }

        test "iamax_double" {
            let! x = Gen.Double.Normal.Array.[1,ROWS_MAX]
            let _,_,expected =
                Array.fold (fun (i,a,j) x -> if abs x > a then i+1,abs x,i else i+1,a,j)
                    (0,-1.0,0) x
            Blas.iamax x
            |> Check.equal expected
        }

        test "iamax_single" {
            let! x = Gen.Single.Normal.Array.[1,ROWS_MAX]
            let _,_,expected =
                Array.fold (fun (i,a,j) x -> if abs x > a then i+1,abs x,i else i+1,a,j)
                    (0,-1.0f,0) x
            Blas.iamax x
            |> Check.equal expected
        }

        test "iamax_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Normal.Array.[rows*cols]
            let _,_,expected =
                Array.fold (fun (i,a,j) x -> if i % cols = ini && abs x > a then i+1,abs x,i/cols else i+1,a,j)
                    (0,-1.0,0) x
            Blas.iamax(rows,x,ini,cols)
            |> Check.equal expected
        }

        test "iamax_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Normal.Array.[rows*cols]
            let _,_,expected =
                Array.fold (fun (i,a,j) x -> if i % cols = ini && abs x > a then i+1,abs x,i/cols else i+1,a,j)
                    (0,-1.0f,0) x
            Blas.iamax(rows,x,ini,cols)
            |> Check.equal expected
        }

        test "iamin_double" {
            let! x = Gen.Double.Normal.Array.[1,ROWS_MAX]
            let _,_,expected =
                Array.fold (fun (i,a,j) x -> if abs x < a then i+1,abs x,i else i+1,a,j)
                    (0,infinity,0) x
            Blas.iamin x
            |> Check.equal expected
        }

        test "iamin_single" {
            let! x = Gen.Single.Normal.Array.[1,ROWS_MAX]
            let _,_,expected =
                Array.fold (fun (i,a,j) x -> if abs x < a then i+1,abs x,i else i+1,a,j)
                    (0,infinityf,0) x
            Blas.iamin x
            |> Check.equal expected
        }

        test "iamin_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Normal.Array.[rows*cols]
            let _,_,expected =
                Array.fold (fun (i,a,j) x -> if i % cols = ini && abs x < a then i+1,abs x,i/cols else i+1,a,j)
                    (0,infinity,0) x
            Blas.iamin(rows,x,ini,cols)
            |> Check.equal expected
        }

        test "iamin_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Normal.Array.[rows*cols]
            let _,_,expected =
                Array.fold (fun (i,a,j) x -> if i % cols = ini && abs x < a then i+1,abs x,i/cols else i+1,a,j)
                    (0,infinityf,0) x
            Blas.iamin(rows,x,ini,cols)
            |> Check.equal expected
        }
    }

let blas_2 =
    test "2" {

        test "gemv_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.Unit.Array.[rows*cols]
            let! x = Gen.Double.Unit.Array.[cols]
            let! y = Gen.Double.Unit.Array.[rows]
            let! alpha = Gen.Double.Unit
            let! beta = Gen.Double.Unit
            let expected = Array.init rows (fun i ->
                let mutable t = 0.0
                for j = 0 to cols-1 do
                    t <- t + A.[j+i*cols] * x.[j]
                alpha * t + beta * y.[i]
            )
            Blas.gemv(Layout.RowMajor, Transpose.No, rows, cols, alpha,
                A, cols, x, 0, 1, beta, y, 0, 1)
            Check.close High expected y
        }

        test "gemv_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.Unit.Array.[rows*cols]
            let! x = Gen.Single.Unit.Array.[cols]
            let! y = Gen.Single.Unit.Array.[rows]
            let! alpha = Gen.Single.Unit
            let! beta = Gen.Single.Unit
            let expected = Array.init rows (fun i ->
                let mutable t = 0.0f
                for j = 0 to cols-1 do
                    t <- t + A.[j+i*cols] * x.[j]
                alpha * t + beta * y.[i]
            )
            Blas.gemv(Layout.RowMajor, Transpose.No, rows, cols, alpha,
                A, cols, x, 0, 1, beta, y, 0, 1)
            Check.close High expected y
        }

        test "ger_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! x = Gen.Double.Unit.Array.[rows]
            let! y = Gen.Double.Unit.Array.[cols]
            let! A = Gen.Double.Unit.Array.[rows*cols]
            let! alpha = Gen.Double.Unit
            let expected = Array.init (rows*cols) (fun ai ->
                alpha * x.[ai/cols] * y.[ai%cols] + A.[ai]
            )
            Blas.ger(Layout.RowMajor, rows, cols, alpha, x, 0, 1, y, 0, 1, A, cols)
            Check.close High expected A
        }

        test "ger_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! x = Gen.Single.Unit.Array.[rows]
            let! y = Gen.Single.Unit.Array.[cols]
            let! A = Gen.Single.Unit.Array.[rows*cols]
            let! alpha = Gen.Single.Unit
            let expected = Array.init (rows*cols) (fun ai ->
                alpha * x.[ai/cols] * y.[ai%cols] + A.[ai]
            )
            Blas.ger(Layout.RowMajor, rows, cols, alpha, x, 0, 1, y, 0, 1, A, cols)
            Check.close High expected A
        }

        test "symv_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Double.Unit.Array.[rows*rows]
            let! x = Gen.Double.Unit.Array.[rows]
            let! y = Gen.Double.Unit.Array.[rows]
            let! alpha = Gen.Double.Unit
            let! beta = Gen.Double.Unit
            let expected = Array.init rows (fun i ->
                let mutable t = 0.0
                for j = 0 to rows-1 do
                    t <- t + A.[if j>i then i+j*rows else j+i*rows] * x.[j]
                alpha * t + beta * y.[i]
            )
            Blas.symv(Layout.RowMajor, UpLoBlas.Lower, rows, alpha, A, rows, x, 0, 1, beta, y, 0, 1)
            Check.close High expected y
        }

        test "symv_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Single.Unit.Array.[rows*rows]
            let! x = Gen.Single.Unit.Array.[rows]
            let! y = Gen.Single.Unit.Array.[rows]
            let! alpha = Gen.Single.Unit
            let! beta = Gen.Single.Unit
            let expected = Array.init rows (fun i ->
                let mutable t = 0.0f
                for j = 0 to rows-1 do
                    t <- t + A.[if j>i then i+j*rows else j+i*rows] * x.[j]
                alpha * t + beta * y.[i]
            )
            Blas.symv(Layout.RowMajor, UpLoBlas.Lower, rows, alpha, A, rows, x, 0, 1, beta, y, 0, 1)
            Check.close High expected y
        }

        test "syr_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Double.Unit.Array.[rows]
            let! A = Gen.Double.Unit.Array.[rows*rows]
            let! alpha = Gen.Double.Unit
            let expected = Array.init (rows*rows) (fun ai ->
                let row, col = Math.DivRem(ai,rows)
                if col > row then A.[ai]
                else alpha * x.[row] * x.[col] + A.[ai]
            )
            Blas.syr(Layout.RowMajor, UpLoBlas.Lower, rows, alpha, x, 0, 1, A, rows)
            Check.close High expected A
        }

        test "syr_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Single.Unit.Array.[rows]
            let! A = Gen.Single.Unit.Array.[rows*rows]
            let! alpha = Gen.Single.Unit
            let expected = Array.init (rows*rows) (fun ai ->
                let row, col = Math.DivRem(ai,rows)
                if col > row then A.[ai]
                else alpha * x.[row] * x.[col] + A.[ai]
            )
            Blas.syr(Layout.RowMajor, UpLoBlas.Lower, rows, alpha, x, 0, 1, A, rows)
            Check.close High expected A
        }

        test "syr2_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Double.Unit.Array.[rows]
            let! y = Gen.Double.Unit.Array.[rows]
            let! A = Gen.Double.Unit.Array.[rows*rows]
            let! alpha = Gen.Double.Unit
            let expected = Array.init (rows*rows) (fun ai ->
                let row, col = Math.DivRem(ai,rows)
                if col > row then A.[ai]
                else alpha * (x.[row] * y.[col] + y.[row] * x.[col]) + A.[ai]
            )
            Blas.syr2(Layout.RowMajor, UpLoBlas.Lower, rows, alpha, x, 0, 1, y, 0, 1, A, rows)
            Check.close High expected A
        }

        test "syr2_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! x = Gen.Single.Unit.Array.[rows]
            let! y = Gen.Single.Unit.Array.[rows]
            let! A = Gen.Single.Unit.Array.[rows*rows]
            let! alpha = Gen.Single.Unit
            let expected = Array.init (rows*rows) (fun ai ->
                let row, col = Math.DivRem(ai,rows)
                if col > row then A.[ai]
                else alpha * (x.[row] * y.[col] + y.[row] * x.[col]) + A.[ai]
            )
            Blas.syr2(Layout.RowMajor, UpLoBlas.Lower, rows, alpha, x, 0, 1, y, 0, 1, A, rows)
            Check.close High expected A
        }

        test "trmv_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Double.Unit.Array.[rows*rows]
            let! x = Gen.Double.Unit.Array.[rows]
            let expected = Array.init rows (fun i ->
                let mutable t = 0.0
                for j = 0 to i do
                    t <- t + A.[j+i*rows] * x.[j]
                t
            )
            Blas.trmv(Layout.RowMajor, UpLoBlas.Lower, Transpose.No, Diag.NonUnit,
                rows, A, rows, x, 0, 1)
            Check.close High expected x
        }

        test "trmv_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Single.Unit.Array.[rows*rows]
            let! x = Gen.Single.Unit.Array.[rows]
            let expected = Array.init rows (fun i ->
                let mutable t = 0.0f
                for j = 0 to i do
                    t <- t + A.[j+i*rows] * x.[j]
                t
            )
            Blas.trmv(Layout.RowMajor, UpLoBlas.Lower, Transpose.No, Diag.NonUnit,
                rows, A, rows, x, 0, 1)
            Check.close High expected x
        }

        test "trsv_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! A = Gen.Double.[1.0,2.0].Array.[rows*rows]
            let! x = Gen.Double.[1.0,2.0].Array.[rows]
            let b = Array.init rows (fun i ->
                let mutable t = 0.0
                for j = 0 to i do
                    t <- t + A.[j+i*rows] * x.[j]
                t
            )
            Blas.trsv(Layout.RowMajor, UpLoBlas.Lower, Transpose.No, Diag.NonUnit,
                rows, A, rows, b, 0, 1)
            Check.close High x b
        }

        test "trsv_single" {
            let rows = 2
            let! A = Gen.Single.[1.0f,2.0f].Array.[rows*rows]
            let! x = Gen.Single.[1.0f,2.0f].Array.[rows]
            let b = Array.init rows (fun i ->
                let mutable t = 0.0f
                for j = 0 to i do
                    t <- t + A.[j+i*rows] * x.[j]
                t
            )
            Blas.trsv(Layout.RowMajor, UpLoBlas.Lower, Transpose.No, Diag.NonUnit,
                rows, A, rows, b, 0, 1)
            Check.close High x b
        }
    }

let blas_3 =
    test "3" {

        test "gemm_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! colsA = Gen.Int.[1,COLS_MAX]
            let! colsB = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.Unit.Array.[rows*colsA]
            let! B = Gen.Double.Unit.Array.[colsA*colsB]
            let! C = Gen.Double.Unit.Array.[rows*colsB]
            let! alpha = Gen.Double.Unit
            let! beta = Gen.Double.Unit
            let expected = Array.init (rows*colsB) (fun ci ->
                let row, col = Math.DivRem(ci,colsB)
                let mutable t = 0.0
                for k = 0 to colsA-1 do
                    t <- t + A.[k+row*colsA] * B.[col+k*colsB]
                alpha * t + beta * C.[ci]
            )
            Blas.gemm(Layout.RowMajor, Transpose.No, Transpose.No, rows, colsB, colsA, alpha,
                A, colsA, B, colsB, beta, C, colsB)
            Check.close High expected C
        }

        test "gemm_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! colsA = Gen.Int.[1,COLS_MAX]
            let! colsB = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.Unit.Array.[rows*colsA]
            let! B = Gen.Single.Unit.Array.[colsA*colsB]
            let! C = Gen.Single.Unit.Array.[rows*colsB]
            let! alpha = Gen.Single.Unit
            let! beta = Gen.Single.Unit
            let expected = Array.init (rows*colsB) (fun ci ->
                let mutable t = 0.0f
                let row, col = Math.DivRem(ci,colsB)
                for k = 0 to colsA-1 do
                    t <- t + A.[k+row*colsA] * B.[col+k*colsB]
                alpha * t + beta * C.[ci]
            )
            Blas.gemm(Layout.RowMajor, Transpose.No, Transpose.No, rows, colsB, colsA, alpha,
                A, colsA, B, colsB, beta, C, colsB)
            Check.close High expected C
        }

        test "symm_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.Unit.Array.[rows*rows]
            let! B = Gen.Double.Unit.Array.[rows*cols]
            let! C = Gen.Double.Unit.Array.[rows*cols]
            let! alpha = Gen.Double.Unit
            let! beta = Gen.Double.Unit
            let expected = Array.init (rows*cols) (fun ci ->
                let row, col = Math.DivRem(ci,cols)
                let mutable t = 0.0
                for k = 0 to rows-1 do
                    t <- t + A.[if k>row then row+k*rows else k+row*rows] * B.[col+k*cols]
                alpha * t + beta * C.[ci]
            )
            Blas.symm(Layout.RowMajor, Side.Left, UpLoBlas.Lower, rows, cols, alpha,
                A, rows, B, cols, beta, C, cols)
            Check.close High expected C
        }

        test "symm_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.Unit.Array.[rows*rows]
            let! B = Gen.Single.Unit.Array.[rows*cols]
            let! C = Gen.Single.Unit.Array.[rows*cols]
            let! alpha = Gen.Single.Unit
            let! beta = Gen.Single.Unit
            let expected = Array.init (rows*cols) (fun ci ->
                let row, col = Math.DivRem(ci,cols)
                let mutable t = 0.0f
                for k = 0 to rows-1 do
                    t <- t + A.[if k>row then row+k*rows else k+row*rows] * B.[col+k*cols]
                alpha * t + beta * C.[ci]
            )
            Blas.symm(Layout.RowMajor, Side.Left, UpLoBlas.Lower, rows, cols, alpha,
                A, rows, B, cols, beta, C, cols)
            Check.close High expected C
        }

        test "syrk_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.Unit.Array.[rows*cols]
            let! C = Gen.Double.Unit.Array.[rows*rows]
            let! alpha = Gen.Double.Unit
            let! beta = Gen.Double.Unit
            let expected = Array.init (rows*rows) (fun ci ->
                let row, col = Math.DivRem(ci,rows)
                if col > row then C.[ci]
                else
                let mutable t = 0.0
                for k = 0 to cols-1 do
                    t <- t + A.[k+row*cols] * A.[k+col*cols]
                alpha * t + beta * C.[ci]
            )
            Blas.syrk(Layout.RowMajor, UpLoBlas.Lower, Transpose.No, rows, cols, alpha,
                A, cols, beta, C, rows)
            Check.close High expected C
        }

        test "syrk_float" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.Unit.Array.[rows*cols]
            let! C = Gen.Single.Unit.Array.[rows*rows]
            let! alpha = Gen.Single.Unit
            let! beta = Gen.Single.Unit
            let expected = Array.init (rows*rows) (fun ci ->
                let row, col = Math.DivRem(ci,rows)
                if col > row then C.[ci]
                else
                let mutable t = 0.0f
                for k = 0 to cols-1 do
                    t <- t + A.[k+row*cols] * A.[k+col*cols]
                alpha * t + beta * C.[ci]
            )
            Blas.syrk(Layout.RowMajor, UpLoBlas.Lower, Transpose.No, rows, cols, alpha,
                A, cols, beta, C, rows)
            Check.close High expected C
        }

        test "syrk2_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.Unit.Array.[rows*cols]
            let! B = Gen.Double.Unit.Array.[rows*cols]
            let! C = Gen.Double.Unit.Array.[rows*rows]
            let! alpha = Gen.Double.Unit
            let! beta = Gen.Double.Unit
            let expected = Array.init (rows*rows) (fun ci ->
                let row, col = Math.DivRem(ci,rows)
                if col > row then C.[ci]
                else
                let mutable t = 0.0
                for k = 0 to cols-1 do
                    t <- t + A.[k+row*cols] * B.[k+col*cols]
                           + B.[k+row*cols] * A.[k+col*cols]
                alpha * t + beta * C.[ci]
            )
            Blas.syr2k(Layout.RowMajor, UpLoBlas.Lower, Transpose.No, rows, cols, alpha,
                A, cols, B, cols, beta, C, rows)
            Check.close High expected C
        }

        test "syrk2_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.Unit.Array.[rows*cols]
            let! B = Gen.Single.Unit.Array.[rows*cols]
            let! C = Gen.Single.Unit.Array.[rows*rows]
            let! alpha = Gen.Single.Unit
            let! beta = Gen.Single.Unit
            let expected = Array.init (rows*rows) (fun ci ->
                let row, col = Math.DivRem(ci,rows)
                if col > row then C.[ci]
                else
                let mutable t = 0.0f
                for k = 0 to cols-1 do
                    t <- t + A.[k+row*cols] * B.[k+col*cols]
                           + B.[k+row*cols] * A.[k+col*cols]
                alpha * t + beta * C.[ci]
            )
            Blas.syr2k(Layout.RowMajor, UpLoBlas.Lower, Transpose.No, rows, cols, alpha,
                A, cols, B, cols, beta, C, rows)
            Check.close High expected C
        }

        test "tymm_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.Unit.Array.[rows*rows]
            let! B = Gen.Double.Unit.Array.[rows*cols]
            let! alpha = Gen.Double.Unit
            let expected = Array.init (rows*cols) (fun ci ->
                let row, col = Math.DivRem(ci,cols)
                let mutable t = 0.0
                for k = 0 to row do
                    t <- t + A.[k+row*rows] * B.[col+k*cols]
                alpha * t
            )
            Blas.trmm(Layout.RowMajor, Side.Left, UpLoBlas.Lower, Transpose.No, Diag.NonUnit,
                rows, cols, alpha, A, rows, B, cols)
            Check.close High expected B
        }

        test "tymm_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.Unit.Array.[rows*rows]
            let! B = Gen.Single.Unit.Array.[rows*cols]
            let! alpha = Gen.Single.Unit
            let expected = Array.init (rows*cols) (fun ci ->
                let row, col = Math.DivRem(ci,cols)
                let mutable t = 0.0f
                for k = 0 to row do
                    t <- t + A.[k+row*rows] * B.[col+k*cols]
                alpha * t
            )
            Blas.trmm(Layout.RowMajor, Side.Left, UpLoBlas.Lower, Transpose.No, Diag.NonUnit,
                rows, cols, alpha, A, rows, B, cols)
            Check.close High expected B
        }

        test "trsm_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Double.[1.0,2.0].Array.[rows*rows]
            let! X = Gen.Double.[1.0,2.0].Array.[rows*cols]
            let! alpha = Gen.Double.[1.0,2.0]
            let B = Array.init (rows*cols) (fun ci ->
                let row, col = Math.DivRem(ci,cols)
                let mutable t = 0.0
                for k = 0 to row do
                    t <- t + A.[k+row*rows] * X.[col+k*cols]
                t / alpha
            )
            Blas.trsm(Layout.RowMajor, Side.Left, UpLoBlas.Lower, Transpose.No, Diag.NonUnit,
                rows, cols, alpha, A, rows, B, cols)
            Check.close High X B
        }

        test "trsm_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! A = Gen.Single.[1.0f,2.0f].Array.[rows*rows]
            let! X = Gen.Single.[1.0f,2.0f].Array.[rows*cols]
            let! alpha = Gen.Single.[1.0f,2.0f]
            let B = Array.init (rows*cols) (fun ci ->
                let row, col = Math.DivRem(ci,cols)
                let mutable t = 0.0f
                for k = 0 to row do
                    t <- t + A.[k+row*rows] * X.[col+k*cols]
                t / alpha
            )
            Blas.trsm(Layout.RowMajor, Side.Left, UpLoBlas.Lower, Transpose.No, Diag.NonUnit,
                rows, cols, alpha, A, rows, B, cols)
            Check.close High X B
        }
    }

let blas_like_64_only =
    test "like_64_only" {
        
        test "axpby_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! a = Gen.Double.Unit
            let! b = Gen.Double.Unit
            let! x = Gen.Double.Unit.Array.[rows]
            let! y = Gen.Double.Unit.Array.[rows]
            let expected = Array.map2 (fun x y -> a*x + b*y) x y
            Blas.axpby(a,x,b,y)
            Check.close High expected y
        }

        test "axpby_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! a = Gen.Single.Unit
            let! b = Gen.Single.Unit
            let! x = Gen.Single.Unit.Array.[rows]
            let! y = Gen.Single.Unit.Array.[rows]
            let expected = Array.map2 (fun x y -> a*x + b*y) x y
            Blas.axpby(a,x,b,y)
            Check.close Low expected y
        }

        test "axpby_i_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! a = Gen.Double.Unit
            let! b = Gen.Double.Unit
            let! x = Gen.Double.Unit.Array.[rows*cols]
            let! y = Gen.Double.Unit.Array.[rows*cols]
            let expected = Array.init rows (fun r -> a*x.[r*cols+ini] + b*y.[r*cols+ini])
            Blas.axpby(rows,a,x,ini,cols,b,y,ini,cols)
            for i = 0 to rows-1 do
                Check.close High expected.[i] y.[i*cols+ini]
        }

        test "axpby_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! ini = Gen.Int.[0,cols-1]
            let! a = Gen.Single.Unit
            let! b = Gen.Single.Unit
            let! x = Gen.Single.Unit.Array.[rows*cols]
            let! y = Gen.Single.Unit.Array.[rows*cols]
            let expected = Array.init rows (fun r -> a*x.[r*cols+ini] + b*y.[r*cols+ini])
            Blas.axpby(rows,a,x,ini,cols,b,y,ini,cols)
            for i = 0 to rows-1 do
                Check.close Low expected.[i] y.[i*cols+ini]
        }
    }

let blas_like =
    test "like" {

        test "imatcopy_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! a = Gen.Double
            let! x = Gen.Double.Array.[rows*cols]
            let expected = Array.init (rows*cols) (fun i ->
                let col, row = Math.DivRem(i,rows)
                a * x.[col+row*cols]
            )
            Blas.imatcopy(Ordering.RowMajor,TransChar.Yes,rows,cols,a,x,cols,rows)
            Check.close High expected x
        }

        test "imatcopy_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! a = Gen.Single
            let! x = Gen.Single.Array.[rows*cols]
            let expected = Array.init (rows*cols) (fun i ->
                let col, row = Math.DivRem(i,rows)
                a * x.[col+row*cols]
            )
            Blas.imatcopy(Ordering.RowMajor,TransChar.Yes,rows,cols,a,x,cols,rows)
            Check.close High expected x
        }

        test "omatcopy_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! a = Gen.Double
            let! x = Gen.Double.Array.[rows*cols]
            let y = Array.zeroCreate (rows*cols)
            let expected = Array.init (rows*cols) (fun i ->
                let col, row = Math.DivRem(i,rows)
                a * x.[col+row*cols]
            )
            Blas.omatcopy(Ordering.RowMajor,TransChar.Yes,rows,cols,a,x,cols,y,rows)
            Check.close High expected y
        }

        test "omatcopy_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! a = Gen.Single
            let! x = Gen.Single.Array.[rows*cols]
            let y = Array.zeroCreate (rows*cols)
            let expected = Array.init (rows*cols) (fun i ->
                let col, row = Math.DivRem(i,rows)
                a * x.[col+row*cols]
            )
            Blas.omatcopy(Ordering.RowMajor,TransChar.Yes,rows,cols,a,x,cols,y,rows)
            Check.close High expected y
        }

        test "omatadd_double" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! alpha = Gen.Double.Unit
            let! beta = Gen.Double.Unit
            let! A = Gen.Double.Unit.Array.[rows*cols]
            let! B = Gen.Double.Unit.Array.[rows*cols]
            let C = Array.zeroCreate (rows*cols)
            let expected = Array.init (rows*cols) (fun i -> alpha * A.[i] + beta * B.[i])
            Blas.omatadd(Ordering.RowMajor,TransChar.No,TransChar.No,rows,cols,alpha,A,cols,beta,B,cols,C,cols)
            Check.close High expected C
        }

        test "omatadd_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,COLS_MAX]
            let! alpha = Gen.Single.Unit
            let! beta = Gen.Single.Unit
            let! A = Gen.Single.Unit.Array.[rows*cols]
            let! B = Gen.Single.Unit.Array.[rows*cols]
            let C = Array.zeroCreate (rows*cols)
            let expected = Array.init (rows*cols) (fun i -> alpha * A.[i] + beta * B.[i])
            Blas.omatadd(Ordering.RowMajor,TransChar.No,TransChar.No,rows,cols,alpha,A,cols,beta,B,cols,C,cols)
            Check.close High expected C
        }
    }

let all =
    test "blas" {
        blas_1
        blas_2
        blas_3
        if Environment.Is64BitProcess then blas_like_64_only else []
        blas_like
    }