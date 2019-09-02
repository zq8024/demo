

using System.Web;

namespace SvcHandler
{
    /// <summary>
    /// SvcGetHandler 的摘要说明
    /// </summary>
    public class SvcGetHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write(System.DateTime.Now);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}