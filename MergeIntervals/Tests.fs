module Tests
open Xunit

let  testdata = [(3,4);(6,7)]

[<Fact>]
let ``Original handles a simple case``() =
    Assert.Equal (Original.fmo testdata, 4)

[<Fact>]
let ``Bjorn Einar handles a simple case``() =
    BjornEinar.fmo testdata = 4

[<Fact>]
let ``Einar handles a simple case``() =
    Einar.fmo testdata = 4