module Tests
open Xunit

let testdata_empty = [] 
let testdata_singleInterval = [(1,1)] 

let testdata_sum_4 = [(3,4);(6,7)]
let testdata_sum_19  = [0, 8; 10,19; 11,19]
let testdata_from_fscheck_sum_5 = [(3, 4); (0, 3); (0, 1)]

[<Fact>]
let ``Readable handles weird fscheckdata``() =
    Assert.Equal(5, Readable.fmo testdata_from_fscheck_sum_5)

[<Fact>]
let ``MutableStack handles weird fscheckdata``() =
    Assert.Equal(5, MutableStack.fmo testdata_from_fscheck_sum_5)

[<Fact>]
let ``Original handles weird fscheckdata``() =
    Assert.Equal(5, Original.fmo testdata_from_fscheck_sum_5)

[<Fact>]
let ``Readable handles empty interval ``() =
    Assert.Equal(0, Readable.fmo testdata_empty)

[<Fact>]
let ``Readable handles single interval ``() =
    Assert.Equal(1, Readable.fmo testdata_singleInterval)

[<Fact>]
let ``Original handles single interval ``() =
    Assert.Equal(1, Original.fmo testdata_singleInterval)

[<Fact>]
let ``MutableStack handles single interval ``() =
    Assert.Equal(MutableStack.fmo testdata_singleInterval, 1)

[<Fact>]
let ``ImmutableStack handles single interval ``() =
    Assert.Equal(ImmutableStack.fmo testdata_singleInterval, 1)

[<Fact>]
let ``MutableStack handles empty case``() =
    Assert.Equal(MutableStack.fmo testdata_empty, 0)
   
[<Fact>]
let ``ImmutableStack handles empty case``() =
    Assert.Equal(ImmutableStack .fmo testdata_empty, 0)

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

let ``MutableStack handles a simple case``() =
    Assert.Equal(MutableStack.fmo testdata_sum_4, 4)

[<Fact>]
let ``MutableStack handles another simple case``() =
    Assert.Equal(MutableStack.fmo testdata_sum_19, 19)

[<Fact>]
let ``ImmutableStack handles a simple case``() =
    Assert.Equal(ImmutableStack.fmo testdata_sum_4, 4)

[<Fact>]
let ``ImmutableStack handles another simple case``() =
    Assert.Equal(ImmutableStack.fmo testdata_sum_19, 19)