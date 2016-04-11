namespace GeneCms.Configuration.FileProvider

module FileProvider = 
    open System.IO
    open FSharp.Data
    open GeneCms.Core

    type PageJsonConfig = JsonProvider<"./pageSample.json">
    //let simple = Simple.Parse(""" { "name":"Tomas", "age":4 } """)
    
    let private getContentElems folderPath =
        let files = Directory.EnumerateFiles(folderPath) 
                    |> Seq.filter (fun x -> not(x.ToLower().EndsWith("\\page.json")))
        //do only html for now
        files |> Seq.map (fun f ->
                            { 
                                HtmlId = Path.GetFileNameWithoutExtension(f)
                                InnerHtml = File.ReadAllText(f)
                                Attributes = [] 
                            }
                        )

    let private mapFolderToPage confFolderPath (folderPath:string) =
        let relativePath = folderPath.Replace(confFolderPath, "").Replace("\\", "/")
        let pageName = Path.GetFileName(folderPath)
        let subFolders = Directory.EnumerateDirectories(folderPath)
        let simple = PageJsonConfig.Parse(""" { "template":"MainTemplate.htm" } """) 
        let contentPage =  { Name = pageName;
                                  Url = (relativePath + ".htm");
                                  Keywords = simple.Keywords;
                                  TemplateName = simple.Template ;
                                  ContentElements = (getContentElems folderPath);
                                  }
        contentPage

    let GetSiteConfiguration confFolderPath =
        let firstLevelFolders = Directory.EnumerateDirectories(confFolderPath) |> Seq.filter (fun x -> not(x.EndsWith("\\Bundles")))
        firstLevelFolders |> Seq.map (mapFolderToPage confFolderPath)