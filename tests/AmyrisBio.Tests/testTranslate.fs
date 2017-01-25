﻿module TestTranslate
open Amyris.Bio.primercore
open NUnit.Framework
open System

[<TestFixture>]
type TestTranslate() = class     
    do
        ()
    [<Test>]
    /// Test that with just 20 bp of template, the design can walk right up to the edge
    member x.TestTranslateMany() =
        let dna = "ATGTCTATCCCAGAAACTCAAAAAGGTGTTATCTTCTACGAATCCCACGGTAAGTTGGAA
TACAAAGATATTCCAGTTCCAAAGCCAAAGGCCAACGAATTGTTGATCAACGTTAAATAC
TCTGGTGTCTGTCACACTGACTTGCACGCTTGGCACGGTGACTGGCCATTGCCAGTTAAG
CTACCATTAGTCGGTGGTCACGAAGGTGCCGGTGTCGTTGTCGGCATGGGTGAAAACGTT
AAGGGCTGGAAGATCGGTGACTACGCCGGTATCAAATGGTTGAACGGTTCTTGTATGGCC
TGTGAATACTGTGAATTGGGTAACGAATCCAACTGTCCTCACGCTGACTTGTCTGGTTAC
ACCCACGACGGTTCTTTCCAACAATACGCTACCGCTGACGCTGTTCAAGCCGCTCACATT
CCTCAAGGTACCGACTTGGCCCAAGTCGCCCCCATCTTGTGTGCTGGTATCACCGTCTAC
AAGGCTTTGAAGTCTGCTAACTTGATGGCCGGTCACTGGGTTGCTATCTCCGGTGCTGCT
GGTGGTCTAGGTTCTTTGGCTGTTCAATACGCCAAGGCTATGGGTTACAGAGTCTTGGGT
ATTGACGGTGGTGAAGGTAAGGAAGAATTATTCAGATCCATCGGTGGTGAAGTCTTCATT
GACTTCACTAAGGAAAAGGACATTGTCGGTGCTGTTCTAAAGGCCACTGACGGTGGTGCT
CACGGTGTCATCAACGTTTCCGTTTCCGAAGCCGCTATTGAAGCTTCTACCAGATACGTT
AGAGCTAACGGTACCACCGTTTTGGTCGGTATGCCAGCTGGTGCCAAGTGTTGTTCTGAT
GTCTTCAACCAAGTCGTCAAGTCCATCTCTATTGTTGGTTCTTACGTCGGTAACAGAGCT
GACACCAGAGAAGCTTTGGACTTCTTCGCCAGAGGTTTGGTCAAGTCTCCAATCAAGGTT
GTCGGCTTGTCTACCTTGCCAGAAATTTACGAAAAGATGGAAAAGGGTCAAATCGTTGGT
AGATACGTTGTTGACACTTCTAAATAA".Replace("\n","").Replace("\r","")

        let prot = "MSIPETQKGVIFYESHGKLEYKDIPVPKPKANELLINVKYSGVCHTDLHAWHGDWPLPVK
LPLVGGHEGAGVVVGMGENVKGWKIGDYAGIKWLNGSCMACEYCELGNESNCPHADLSGY
THDGSFQQYATADAVQAAHIPQGTDLAQVAPILCAGITVYKALKSANLMAGHWVAISGAA
GGLGSLAVQYAKAMGYRVLGIDGGEGKEELFRSIGGEVFIDFTKEKDIVGAVLKATDGGA
HGVINVSVSEAAIEASTRYVRANGTTVLVGMPAGAKCCSDVFNQVVKSISIVGSYVGNRA
DTREALDFFARGLVKSPIKVVGLSTLPEIYEKMEKGQIVGRYVVDTSK*".Replace("\n","").Replace("\r","")
        let prot2 = Amyris.Bio.biolib.translate (dna.ToCharArray()) |> Amyris.Bio.utils.arr2seq
        Assert.AreEqual(prot,prot2)

    [<Test>]
    /// Test that with just 20 bp of template, the design can walk right up to the edge
    member x.TestTranslatePerformance() =
        let dna = Array.init 3000000 (fun i -> match i%3 with | 0 -> 'A' | 1 -> 'T' | 2 -> 'G' | _ -> failwith "impossible")
        let prot = Array.init 1000000 (fun _ -> 'M')
        let prot2 = Amyris.Bio.biolib.translate dna |> Amyris.Bio.utils.arr2seq
        Assert.AreEqual(prot,prot2)

    [<Test>]
    /// Test that with just 20 bp of template, the design can walk right up to the edge
    member x.TestNon3Multiple() =
        let dna = "ATGC".ToCharArray()
        let prot = [| 'M' |]
        let prot2 = Amyris.Bio.biolib.translate dna |> Amyris.Bio.utils.arr2seq
        Assert.AreEqual(prot,prot2)

    [<Test>]
    /// Test that with just 20 bp of template, the design can walk right up to the edge
    member x.TestNon3Multiple2() =
        let dna = "ATGCG".ToCharArray()
        let prot = [| 'M' |]
        let prot2 = Amyris.Bio.biolib.translate dna |> Amyris.Bio.utils.arr2seq
        Assert.AreEqual(prot,prot2)
end