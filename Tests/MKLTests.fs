module MKLTests

open System
open MKLNET

let all =
    test "MKL" {

        test "get_version" {
            let v = MKL.get_version()
            Check.info "%i" v.MajorVersion
            Check.info "%i" v.MinorVersion
            Check.info "%i" v.UpdateVersion
            Check.info "%s" v.ProductStatus
            Check.info "%s" v.Build
            Check.info "%s" v.Processor
            Check.info "%s" v.Platform
        }

        test "get_version_string" {
            let v = MKL.get_version_string()
            Check.info "%s" v
        }

        test "get_max_threads" {
            let i = MKL.get_max_threads()
            Check.info "%i" i
        }

        test "cbwr_get_auto_branch" {
            let v = MKL.cbwr_get_auto_branch()
            Check.info "%s" (Enum.GetName(typeof<MklCBWR> ,v))
        }

        test "get_dynamic" {
            let i = MKL.get_dynamic()
            Check.info "%i" i
        }

        //test "set_threading_layer" {
        //    let i = MKL.set_threading_layer(MklThreading.SEQUENTIAL)
        //    Check.info "%A" i
        //}
    }