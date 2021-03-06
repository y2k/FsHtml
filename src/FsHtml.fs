module FsHtml

open System.Text

type Attr = Attr of string * string
type Element = Element of string * Attr list * Element list | Text of string

let toString (e : Element) : string =
    let sb = StringBuilder()

    let rec toString' indent e =
        let offset = String.replicate (2 * indent) " "
        match e with
        | Text text ->
            sb.Append(text) |> ignore
        | Element (name, attrs, children) ->
            sb.Append(offset).Append("<").Append(name) |> ignore
            attrs
            |> List.iter (fun a ->
                match a with
                | Attr (k, v) -> sb.Append(" ").Append(k).Append("=\"").Append(v).Append("\"")
                |> ignore)
            sb.Append(">") |> ignore
            let hasChildren = List.exists (function Element _ -> true | _ -> false) children
            if hasChildren then sb.AppendLine() |> ignore
            children |> List.iter (toString' (indent + 1))
            if hasChildren then  sb.Append(offset) |> ignore
            sb.Append("</").Append(name).AppendLine(">") |> ignore

    toString' 0 e
    sb.ToString()

let (%=) name value = Attr (name, value)
let (~%) s = [Text s]

let str s = Text s

let inline private element (name : string) (attrs : Attr list) (children : Element list) =
    Element (name, attrs, children)

// Gets from https://www.html-5-tutorial.com/all-html-tags.htm
let a = element "a"
let abbr = element "abbr"
let acronym = element "acronym"
let address = element "address"
let applet = element "applet"
let area = element "area"
let article = element "article"
let aside = element "aside"
let audio = element "audio"
let b = element "b"
let base' = element "base"
let basefont = element "basefont"
let bdi = element "bdi"
let bdo = element "bdo"
let big = element "big"
let blockquote = element "blockquote"
let body = element "body"
let br = element "br"
let button = element "button"
let canvas = element "canvas"
let caption = element "caption"
let center = element "center"
let cite = element "cite"
let code = element "code"
let col = element "col"
let colgroup = element "colgroup"
let command = element "command"
let datalist = element "datalist"
let dd = element "dd"
let del = element "del"
let details = element "details"
let dfn = element "dfn"
let dir = element "dir"
let div = element "div"
let dl = element "dl"
let dt = element "dt"
let em = element "em"
let embed = element "embed"
let fieldset = element "fieldset"
let figcaption = element "figcaption"
let figure = element "figure"
let font = element "font"
let footer = element "footer"
let form = element "form"
let frame = element "frame"
let frameset = element "frameset"
let h1 = element "h1"
let h2 = element "h2"
let h3 = element "h3"
let h4 = element "h4"
let h5 = element "h5"
let h6 = element "h6"
let head = element "head"
let header = element "header"
let hgroup = element "hgroup"
let hr = element "hr"
let html = element "html"
let i = element "i"
let iframe = element "iframe"
let img = element "img"
let input = element "input"
let ins = element "ins"
let kbd = element "kbd"
let keygen = element "keygen"
let label = element "label"
let legend = element "legend"
let li = element "li"
let link = element "link"
let map = element "map"
let mark = element "mark"
let menu = element "menu"
let meta = element "meta"
let meter = element "meter"
let nav = element "nav"
let noframes = element "noframes"
let noscript = element "noscript"
let object = element "object"
let ol = element "ol"
let optgroup = element "optgroup"
let option = element "option"
let output = element "output"
let p = element "p"
let param = element "param"
let pre = element "pre"
let progress = element "progress"
let q = element "q"
let rp = element "rp"
let rt = element "rt"
let ruby = element "ruby"
let s = element "s"
let samp = element "samp"
let script = element "script"
let section = element "section"
let select = element "select"
let small = element "small"
let source = element "source"
let span = element "span"
let strike = element "strike"
let strong = element "strong"
let style = element "style"
let sub = element "sub"
let summary = element "summary"
let sup = element "sup"
let table = element "table"
let tbody = element "tbody"
let td = element "td"
let textarea = element "textarea"
let tfoot = element "tfoot"
let th = element "th"
let thead = element "thead"
let time = element "time"
let title = element "title"
let tr = element "tr"
let track = element "track"
let tt = element "tt"
let u = element "u"
let ul = element "ul"
let var = element "var"
let video = element "video"
let wbr = element "wbr"
