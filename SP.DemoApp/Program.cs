using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri siteUri = new Uri("https://tenant.sharepoint.com/<site>");
            string realm = TokenHelper.GetRealmFromTargetUrl(siteUri);

            string accessToken = TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal,
                                                                    siteUri.Authority, realm).AccessToken;

            using (var clientContext = TokenHelper.GetClientContextWithAccessToken(siteUri.ToString(), accessToken))
            {
                Web currentWeb = clientContext.Web;
                clientContext.Load(currentWeb, w => w.Title, w => w.Description);
                clientContext.ExecuteQuery();
                Console.WriteLine(currentWeb.Title);
                Console.WriteLine(currentWeb.Description);

                //WebCreationInformation wci = new WebCreationInformation();
                //wci.Url = "shinyweb";
                //wci.Title = "New shiny web";
                //Web shinyNewWeb = currentWeb.Webs.Add(wci);

                // Create the sub web
                clientContext.ExecuteQuery();
            }

            Console.WriteLine("...");
            Console.ReadLine();
        }
    }
}
