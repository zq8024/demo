
using System;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ClearContent();

        Response.Write("<h1>it is default</h1>");

        Response.End();
    }

    private string ReadRequestContent()
    {
        using (StreamReader sr = new StreamReader(Request.InputStream))
        {
            string content = sr.ReadToEnd();
            return content;
        }
    }
}

