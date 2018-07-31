using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;

namespace file_upload.Controllers
{


    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        private readonly IConfiguration _configuration;
        public AssetController(IConfiguration config)
        {
            _configuration = config;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAssetAsync([FromForm]IFormFile asset)
        {
            CloudStorageAccount storageAccount = null;
            if (CloudStorageAccount.TryParse(_configuration.GetConnectionString("StorageAccount"), out storageAccount))
            {
                var client = storageAccount.CreateCloudBlobClient();
                var container = client.GetContainerReference("fileupload");
                await container.CreateIfNotExistsAsync();

                await container.GetBlockBlobReference(asset.FileName)
                    .UploadFromStreamAsync(asset.OpenReadStream());

            }
            return Ok();

        }
    }
}
