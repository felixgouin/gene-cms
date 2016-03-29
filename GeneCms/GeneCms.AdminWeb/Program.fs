// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Suave
open Suave.Operators

let app =
    choose
        [ Filters.GET >=> choose

            [ 
//                Filters.path "/" >=> (
//                  "My main page"
//                  |> Successful.OK)

              Files.browse @"C:\Users\jptar_000\Source\Repos\gene-cms\GeneCms\GeneCms.AdminWeb\bin\Debug\Generated"
              ] 
        ] // <-- The important part

[<EntryPoint>]
let main x =
    Web.startWebServer Web.defaultConfig app |> ignore
    0
