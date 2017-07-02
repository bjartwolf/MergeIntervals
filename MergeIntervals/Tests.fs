module Tests
open Xunit

let testdata_sum_4 = [(3,4);(6,7)]
let testdata_sum_19  = [0, 8; 10,19; 11,19]
[<Fact>]
let ``Original handles a simple case``() =
    Assert.Equal(Original.fmo testdata_sum_4, 4)
    Assert.Equal(Original.fmo testdata_sum_19, 19)

[<Fact>]
let ``Bjorn Einar handles a simple case``() =
    Assert.Equal(BjornEinar.fmo testdata_sum_4, 4)
    Assert.Equal(BjornEinar.fmo testdata_sum_19, 19)

[<Fact>]
let ``Einar handles a simple case``() =
    Assert.Equal(Einar.fmo testdata_sum_4, 4)
    Assert.Equal(Einar.fmo testdata_sum_19, 19)