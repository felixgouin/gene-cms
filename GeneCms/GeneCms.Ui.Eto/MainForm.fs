namespace GeneCms.Ui.Eto

open System
open Eto.Forms
open Eto.Drawing
open GeneCms.Generator
open GeneCms.Core

type MainForm() as this = 
    inherit Form()


    do 
        let genTestPage evt = 
            let testContent =  { Name = "Lol";
                                  Url = "ju";
                                  Keywords = "";
                                  TemplatePath = "testGen.html" ;
                                  ContentElements = [|
                                                        { HtmlId = "mainContent"
                                                          InnerHtml = "<h1>Hi</hi>"
                                                          Attributes = [] 
                                                          }
                                                      |];
                                  }
            HtmlGenerator.GeneratePage testContent

        base.Title <- "My Eto Form"
        base.ClientSize <- new Size(400, 350)

        let layout = new StackLayout()
        layout.Items.Add(new StackLayoutItem(new Label(Text = "Hello World!")))

        base.Content <- layout

        // create a few commands that can be used for the menu and toolbar
        let clickMe = new Command(MenuText = "Click Me!", ToolBarText = "Click Me!")
        
        clickMe.Executed.Add(genTestPage )

        let quitCommand = new Command(MenuText = "Quit")
        quitCommand.Shortcut <- Application.Instance.CommonModifier ||| Keys.Q
        quitCommand.Executed.Add(fun e -> Application.Instance.Quit())

        let aboutCommand = new Command(MenuText = "About...")
        aboutCommand.Executed.Add(fun e -> ignore(MessageBox.Show(this, "About my app...")))

        base.Menu <- new MenuBar()
        let fileItem = new ButtonMenuItem(Text = "&File")
        ignore(fileItem.Items.Add(clickMe))
        base.Menu.Items.Add(fileItem)

        (* add more menu items to the main menu...
        let editItem = new ButtonMenuItem(Text = "&Edit")
        base.Menu.Items.Add(editItem)
        let viewItem = new ButtonMenuItem(Text = "&View")
        base.Menu.Items.Add(viewItem)
        *)

        base.Menu.ApplicationItems.Add(new ButtonMenuItem(Text = "&Preferences..."))
        base.Menu.QuitItem <- quitCommand.CreateMenuItem()
        base.Menu.AboutItem <- aboutCommand.CreateMenuItem()

        base.ToolBar <- new ToolBar()
        base.ToolBar.Items.Add(clickMe)