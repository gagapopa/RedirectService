using System;
using System.Linq;
using System.Web;
using RedirectService.DataService;

namespace RedirectService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string fullUrl;
            var shortUrl = HttpContext.Current.Request.Url.ToString().Split('/').Last();
            using (var service = new DataServiceClient())
            {
                fullUrl = service.IncrementLink(shortUrl);
            }
            HttpContext.Current.Response.Status = "302 Found";
            HttpContext.Current.Response.AddHeader("Location", fullUrl);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}