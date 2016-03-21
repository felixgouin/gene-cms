namespace GeneCms.Generator

module HtmlGenerator =
    open HtmlAgilityPack
    open GeneCms.Core
    open System.IO



    let ReplaceContent (itemsToReplace:ContentElement seq) (htmlDoc:HtmlDocument) =
        let doReplaceAttribute (elemToChg:HtmlNode) (attrName:string,attrVal:string) =
            if elemToChg.Attributes.Contains(attrName) then 
                elemToChg.Attributes.Remove(attrName)
            elemToChg.Attributes.Add(attrName, attrVal) |> ignore

        let doReplace itemToReplace  =
            let mutable elemToChg = htmlDoc.GetElementbyId(itemToReplace.HtmlId)
            if itemToReplace.InnerHtml <> "" then
                elemToChg.InnerHtml <- itemToReplace.InnerHtml
            itemToReplace.Attributes |> Seq.iter (doReplaceAttribute elemToChg) |> ignore

        itemsToReplace |> Seq.iter doReplace  |> ignore
        htmlDoc
    
    let GeneratePage (pageInfo:ContentPage) (templates:TemplateDefinition seq)=
        let mutable newDoc = new HtmlDocument()
      
        let templateHtmlContents = templates |> Seq.filter (fun x -> x.Name = pageInfo.TemplateName) |> Seq.map (fun x -> x.Contents) |> Seq.tryHead
        newDoc.LoadHtml( (defaultArg templateHtmlContents "")) |> ignore
        ReplaceContent pageInfo.ContentElements newDoc |> ignore
        //todo handle directories
        newDoc.DocumentNode.OuterHtml

type Class1() = 
    member this.X = "F#"
