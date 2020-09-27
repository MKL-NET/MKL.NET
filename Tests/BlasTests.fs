module BlasTests

open MKLNET
open CsCheck

let ROWS_MAX = 5

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
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let mutable expected = 0.0
            for i = 0 to rows-1 do
                expected <- expected + abs x.[i*cols+ini]
            Blas.asum(rows, x, ini, cols) |> Check.close High expected
        }

        test "asum_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let y = Array.zeroCreate x.Length
            Blas.copy(rows,x,ini,cols,y,ini,cols)
            for i = 0 to rows-1 do
                Check.equal x.[i*cols+ini] y.[i*cols+ini]
        }

        test "copy_i_single" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Double.Array.[rows*cols]
            let! a = Gen.Double
            let expected = Array.mapi (fun i x -> if i % cols = ini then a*x else x) x
            Blas.scal(rows,a,x,ini,cols)
            Check.close High expected x
        }

        test "scal_i_float" {
            let! rows = Gen.Int.[1,ROWS_MAX]
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
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
            let! cols = Gen.Int.[1,3]
            let! ini = Gen.Int.[0,cols-1]
            let! x = Gen.Single.Array.[rows*cols]
            let! y = Gen.Single.Array.[rows*cols]
            let expectedx = Array.mapi2 (fun i x y -> if i % cols = ini then y else x) x y
            let expectedy = Array.mapi2 (fun i x y -> if i % cols = ini then x else y) x y
            Blas.swap(rows,x,ini,cols,y,ini,cols)
            Check.equal expectedx x
            Check.equal expectedy y
        }

        test "isamax" {
            Blas.isamax(3, [| 1.0f; 7.0f; -3.0f |], 1)
            |> Check.equal 1
        }

        test "idamax" {
            Blas.idamax(3, [| 1.0; 7.0; -3.0 |], 1)
            |> Check.equal 1
        }

        test "isamin" {
            Blas.isamin(3, [| 1.0f; 7.0f; -3.0f |], 1)
            |> Check.equal 0
        }

        test "idamin" {
            Blas.idamin(3, [| 1.0; 7.0; -3.0 |], 1)
            |> Check.equal 0
        }
    }

let blas_2 =
    test "2" {

        test "sgemv" {
            let y = Array.zeroCreate 3
            Blas.sgemv(Layout.RowMajor, Transpose.No, 3, 3, -2.0f,
                [| 1.0f; 1.0f; 2.0f; 1.0f; 2.0f; 1.0f; 2.0f; 1.0f; 1.0f |], 3,
                [| 3.0f; -1.0f; 2.0f |],
                1, 2.0f, y, 1)
            Check.equal [| -12.0f; -6.0f; -14.0f |] y
        }

        test "dgemv" {
            let y = Array.zeroCreate 3
            Blas.dgemv(Layout.RowMajor, Transpose.No, 3, 3, -2.0,
                [| 1.0; 1.0; 2.0; 1.0; 2.0; 1.0; 2.0; 1.0; 1.0 |], 3,
                [| 3.0; -1.0; 2.0 |],
                1, 2.0, y, 1)
            Check.equal [| -12.0; -6.0; -14.0 |] y
        }

        test "sgemm" {
            let c = Array.zeroCreate 6
            Blas.sgemm(Layout.RowMajor, Transpose.No, Transpose.No, 3, 2, 3, 1.0f,
                [| 8.0f; 4.0f; 2.0f; 1.0f; 3.0f; -6.0f; -7.0f; 0.0f; 5.0f |], 3,
                [| 5.0f; 2.0f; 3.0f; 1.0f; 4.0f; -1.0f |], 2,
                1.0f, c, 2)
            Check.equal [| 60.0f; 18.0f; -10.0f; 11.0f; -15.0f; -19.0f |] c
        }

        test "dgemm" {
            let c = Array.zeroCreate 6
            Blas.dgemm(Layout.RowMajor, Transpose.No, Transpose.No, 3, 2, 3, 1.0,
                [| 8.0; 4.0; 2.0; 1.0; 3.0; -6.0; -7.0; 0.0; 5.0 |], 3,
                [| 5.0; 2.0; 3.0; 1.0; 4.0; -1.0 |], 2,
                1.0, c, 2)
            Check.equal [| 60.0; 18.0; -10.0; 11.0; -15.0; -19.0 |] c
        }
    }

let all =
    test "blas" {
        blas_1
        blas_2
    }