#load "src/FsHtml.fs"

open FsHtml

module Example1 =
    html [] [
        head [] [
            title [] %"My site"
            style [ "src" %= "/style.css" ] []
            script [ "src" %= "/jquery.js" ] [] ]
        body [] [
            h1 [] [ str "Site header" ]
            div [] [
                div [] [
                    img [ "src" %= "/img1.jpeg" ] []
                    span [] %"Login page" ]
                form [ "action" %= "/add-user" ] [
                    input [ "type" %= "text"; "name" %= "username" ] []
                    input [ "type" %= "text"; "name" %= "password" ] []
                    textarea [ "name" %= "description" ] []
                    button [] %"Login" ] ] ] ]
    |> (toString >> printfn "%s")

module Example2 =
    let private item title =
        tr [] [
            td [] [ img [ "class" %= "round-img"; "src" %= "/img1.jpeg" ] [] ]
            td [] %(sprintf "Item #%s" title) ]

    html [] [
        body [] [
            table [] [
                yield!
                    [1..5]
                    |> List.map (string >> item) ] ] ]
    |> (toString >> printfn "%s")
