using API2.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        [Authorize]
        public IActionResult GetPictures()
        {
            var pictures = new List<Picture>()
            {
                new Picture{Id=1,Name="Doğa Resmi", Url="Dogaresmi.jpg"},
                new Picture{Id=1,Name="Uzay Resmi", Url="Uzayresmi.jpg"},
                new Picture{Id=1,Name="Deniz Resmi", Url="Denizresmi.jpg"}
            };
            return Ok(pictures);
        }
    }
}
