module GeneralTests

open MKLNET

let all =
    test "General" {
        test "get_version" {
            let v = MKL.get_version()
            Check.equal 2020 v.MajorVersion
            Check.equal 0 v.MinorVersion
            Check.equal 3 v.UpdateVersion
            Check.equal "Product" v.ProductStatus
            Check.equal "20200822" v.Build
            Check.info "%s" v.Processor
            Check.info "%s" v.Platform
        }
        test "get_max_threads" {
            let i = MKL.get_max_threads()
            Check.info "%i" i
        }
    }