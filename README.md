# Examples

### F# DSL
```
let private item title =
    tr [] [
        td [] [ img [ "class" %= "round-img"; "src" %= "/img1.jpeg" ] [] ]
        td [] %(sprintf "Item #%s" title)
    ]

html [] [
    body [] [
        table [] [
            yield! 
                [1..5] 
                |> List.map (string >> item)
        ]
    ]
]
|> (toString >> printfn "%s")
```

### HTML result
```
<html>
  <body>
    <table>
      <tr>
        <td>
          <img class="round-img" src="/img1.jpeg"></img>
        </td>
        <td>Item #1</td>
      </tr>
      <tr>
        <td>
          <img class="round-img" src="/img1.jpeg"></img>
        </td>
        <td>Item #2</td>
      </tr>
      <tr>
        <td>
          <img class="round-img" src="/img1.jpeg"></img>
        </td>
        <td>Item #3</td>
      </tr>
      <tr>
        <td>
          <img class="round-img" src="/img1.jpeg"></img>
        </td>
        <td>Item #4</td>
      </tr>
      <tr>
        <td>
          <img class="round-img" src="/img1.jpeg"></img>
        </td>
        <td>Item #5</td>
      </tr>
    </table>
  </body>
</html>
```