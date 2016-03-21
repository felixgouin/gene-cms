namespace GeneCms.Core

type ContentAttribute = string * string

type ContentElement = 
    { HtmlId : string
      InnerHtml : string
      Attributes : ContentAttribute seq }

type TemplateDefinition = {Name: string; Contents:string}
type ContentPage = 
    { Name : string
      Url : string
      Keywords : string
      TemplateName : string 
      ContentElements: ContentElement seq
      }
