module Tests
open Xunit

let testdata_empty = [] 
let testdata_singleInterval = [(1,1)] 

let testdata_sum_4 = [(3,4);(6,7)]
let testdata_sum_19  = [0, 8; 10,19; 11,19]

[<Fact>]
let ``BjornEinar handles single interval ``() =
    Assert.Equal(BjornEinar.fmo testdata_singleInterval, 1)

[<Fact>]
let ``Original handles single interval ``() =
    Assert.Equal(Original.fmo testdata_singleInterval, 1)

[<Fact>]
let ``Einar handles single interval ``() =
    Assert.Equal(Einar.fmo testdata_singleInterval, 1)

[<Fact>]
let ``BjornEinar handles empty case``() =
    Assert.Equal(BjornEinar.fmo testdata_empty, 0)
   
[<Fact>]
let ``Einar handles empty case``() =
    Assert.Equal(Einar .fmo testdata_empty, 0)

[<Fact>]
let ``Original handles empty case``() =
    Assert.Equal(Original.fmo testdata_empty, 0)

[<Fact>]
let ``Original handles a simple case``() =
    Assert.Equal(Original.fmo testdata_sum_4, 4)

[<Fact>]
let ``Original handles another simple case``() =
    Assert.Equal(Original.fmo testdata_sum_19, 19)

[<Fact>]

let ``Bjorn Einar handles a simple case``() =
    Assert.Equal(BjornEinar.fmo testdata_sum_4, 4)

[<Fact>]
let ``Bjorn Einar handles another simple case``() =
    Assert.Equal(BjornEinar.fmo testdata_sum_19, 19)

[<Fact>]
let ``Einar handles a simple case``() =
    Assert.Equal(Einar.fmo testdata_sum_4, 4)

[<Fact>]
let ``Einar handles another simple case``() =
    Assert.Equal(Einar.fmo testdata_sum_19, 19)