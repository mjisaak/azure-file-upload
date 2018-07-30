using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace file_upload.Controllers
{
    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        [HttpPost]
        public IActionResult UploadAsset([FromForm]IFormFile asset)
        {
            return Ok();
        }
    }
}
