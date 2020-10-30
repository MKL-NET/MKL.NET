module MKLTests

open System
open MKLNET

let all =
    test "MKL" {

        test "get_version" {
            let v = MKL.get_version()
            Check.equal 2020 v.MajorVersion
            Check.equal 0 v.MinorVersion
            Check.equal 4 v.UpdateVersion
            Check.equal "Product" v.ProductStatus
            Check.equal "20200917" v.Build
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
    }