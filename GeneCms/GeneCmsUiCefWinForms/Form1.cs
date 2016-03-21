using CefSharp;
using CefSharp.WinForms;
using GeneCms.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneCmsUiCefWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
            private void Form1_Load(object sender, EventArgs e)
        {
            FSharpList
            var contentElems = new[] { new ContentElement("mainContent", "<h1>Hi</h1>", ) };
            var pageInfo = new ContentPage("lo","lo","lo","test",)
            GeneCms.Generator.HtmlGenerator.GeneratePage()
            Cef.Initialize();
            ChromiumWebBrowser myBrowser = new ChromiumWebBrowser("http://www.maps.google.com");
            this.Controls.Add(myBrowser);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

    }
}
