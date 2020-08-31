module GeneralTests

open MKLNET

let all =
    test "General" {
        test "get_version" {
            let v = MKL.General.Version
            Check.equal v.MajorVersion 2020
            Check.equal v.MinorVersion 0
            Check.equal v.UpdateVersion 2
            Check.equal v.ProductStatus "Product"
            Check.equal v.Build "20200624"
            Check.info "%s" v.Processor
            Check.info "%s" v.Platform
        }
        test "get_max_threads" {
            let i = MKL.General.Max_Threads
            Check.info "%i" i
        }
    }