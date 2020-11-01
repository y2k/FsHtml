module Tests

open System
open Xunit
open FsHtml

[<Fact>]
let ``example test`` () =
    let actual =
        let item title =
            tr [] [
                td [] [ img [ "class" %= "round-img"; "src" %= "/img1.jpeg" ] [] ]
                td [] %(sprintf "Item #%s" title) ]
        html [] [
            body [] [
                h1 [] [ str "Example" ]
                table [] [
                    yield!
                        [1..2]
                        |> List.map (string >> item) ] ] ]
        |> toString
        |> fun x -> Text.RegularExpressions.Regex.Replace (x, "\\s*\\n\\s*", "")

    let exptected =
        """<html><body><h1>Example</h1><table><tr><td><img class="round-img" src="/img1.jpeg"></img></td><td>Item #1</td></tr><tr><td><img class="round-img" src="/img1.jpeg"></img></td><td>Item #2</td></tr></table></body></html>"""

    Assert.Equal (exptected, actual)
