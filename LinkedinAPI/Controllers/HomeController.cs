using LinkedinAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Web;

namespace LinkedinAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string clientId = "";
        private readonly string clientSecret = "";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var redirectUrl = "http://localhost:5268/Home/LinkedINAuth";
            var scopes = "r_liteprofile%20r_organization_social%20r_1st_connections_size%20w_member_social%20w_organization_social%20r_emailaddress";
            string authUrl = $"https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id={clientId}&redirect_uri={HttpUtility.HtmlEncode(redirectUrl)}&state=987654321&scope={HttpUtility.HtmlEncode(scopes)}";


            return Redirect(authUrl);
            //return View();
        }

        public async Task<ActionResult> LinkedINAuth(string code, string state)
        {
            try
            {
                var redirectUrl = "http://localhost:5268/Home/LinkedINAuth";
                string authUrl = "https://www.linkedin.com/uas/oauth2/accessToken";

                var sign = @"grant_type=authorization_code&code=" + HttpUtility.UrlEncode(code) + "&redirect_uri=" + HttpUtility.HtmlEncode(redirectUrl) + "&client_id=" + $"{clientId}" + "&client_secret=" + $"{clientSecret}";


                #region OLD_TEST
                //var client = new RestClient(authUrl + "?" + sign);
                //var request = new RestRequest(Method.Post.ToString());
                //request.AddParameter("content-Type", "application/x-www-form-urlencoded");
                //request.AddParameter("grant_type", "authorization_code&");
                //request.AddParameter("code", $"{code}&");
                //request.AddParameter("redirect_uri", "http://localhost:5268/Home/LinkedINAuth&");
                //request.AddParameter("client_id", $"{clientId}&");
                //request.AddParameter("client_secret", $"{clientSecret}");
                //var response = await client.ExecuteAsync(request);
                //var content = response.Content;

                ////Fetch AccessToken

                //LinkedINVM linkedINVM = JsonConvert.DeserializeObject<LinkedINVM>(content);

                ////Get Profile Details
                //client = new RestClient("https://api.linkedin.com/v1/people/~?oauth2_access_token=" + linkedINVM.access_token + "&format=json");
                //request = new RestRequest(Method.Get.ToString());
                //response = await client.ExecuteAsync(request);
                //content = response.Content;

                //LinkedINResVM linkedINResVM = JsonConvert.DeserializeObject<LinkedINResVM>(content);
                #endregion

                //Get Accedd Token


                HttpWebRequest webRequest = WebRequest.Create(authUrl + "?" + sign) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";

                Stream dataStream = webRequest.GetRequestStream();

                String postData = String.Empty;
                byte[] postArray = Encoding.ASCII.GetBytes(postData);

                dataStream.Write(postArray, 0, postArray.Length);
                dataStream.Close();

                WebResponse response1 = webRequest.GetResponse();
                dataStream = response1.GetResponseStream();


                StreamReader responseReader = new StreamReader(dataStream);
                String returnVal = responseReader.ReadToEnd().ToString();
                var linkedINVM = JsonConvert.DeserializeObject<LinkedINVM>(returnVal);
                responseReader.Close();
                dataStream.Close();
                response1.Close();
                return View("Index");

            }
            catch
            {
                throw;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}