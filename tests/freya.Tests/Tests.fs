module freya.Tests

open Model
open System.Text.RegularExpressions
open FSharp.RDF

open Xunit
open Swensen.Unquote

[<Fact>]
let ``Matching targets from resource paths`` () =
  let rp = ResourcePath(
    [{Id=Uri.from "http://nice.org.uk/ns/dqxs";Expression=Expression(Regex "qualitystandards")}
     {Id=Uri.from "https://nice.org.uk/ns/dqs";Expression=Expression(Regex "standard_(?<QualityStandardId>.*)")}],
     {
      Id= Uri.from "http://nice.org.uk/ns/fp1"
      Expression= Regex "statement_(?<QualityStatementId>.*).md" |> Expression
      Tools = [Content]
      Represents = Uri.from "http://nice.org.uk/ns/QualityStatement"
      })
  let matchingTarget = {
      Id = Uri.from "http://nice.org.uk/ns/target1"
      Path = Path.from "qualitystandards/standard_1/statement_23.md"
      Content = ""
      }

  let nonMatchingTarget = {
    Id = Uri.from "http://nice.org.uk/ns/target1"
    Path = Path.from "qualitystandards/lol/standard_23.md"
    Content = ""
    }

  test <@ toolsFor rp nonMatchingTarget = None @>
  test <@ toolsFor rp matchingTarget = Some ({
    Target = matchingTarget
    Tools = [Content]
    Captured = [("QualityStandardId","1")
                ("QualityStatementId","23")]
    }) @>

