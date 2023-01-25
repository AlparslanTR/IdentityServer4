using Client1.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Client1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task <IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var discovery = await client.GetDiscoveryDocumentAsync("https://localhost:7142");
            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();
            clientCredentialsTokenRequest.ClientId = _configuration["Client:ClientId"];
            clientCredentialsTokenRequest.ClientSecret = _configuration["Client:ClientSecret"];
            clientCredentialsTokenRequest.Address = discovery.TokenEndpoint;
            var token= await client.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
            client.SetBearerToken(token.AccessToken);
            var response = await client.GetAsync("https://localhost:7206/api/Product/GetProducts");
            var content = await response.Content.ReadAsStringAsync();
            var product= JsonConvert.DeserializeObject<List<Product>>(content);

            return View(product);
        }
    }
}
