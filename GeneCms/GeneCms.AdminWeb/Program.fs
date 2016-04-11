// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Suave
open Suave.Operators
open System.IO

let app baseFolder =
    choose
        [ Filters.GET >=> choose

            [ 
//                Filters.path "/" >=> (
//                  "My main page"
//                  |> Successful.OK)

              Files.browse baseFolder // @"C:\Users\jptar_000\Source\Repos\gene-cms\GeneCms\GeneCms.AdminWeb\bin\Debug\Generated"
              ] 
        ] // <-- The important part

[<EntryPoint>]
let main x =
    let baseFolder = Path.GetFullPath(x.[0])
    Web.startWebServer Web.defaultConfig (app baseFolder) |> ignore
    0
