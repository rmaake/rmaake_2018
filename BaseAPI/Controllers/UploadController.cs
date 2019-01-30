using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers
{
    [Route("api/[controller]"), DisableRequestSizeLimit]
    [EnableCors("AllowAnyOrigin")]
    [Authorize]
    //[Authorize(Roles = "Instructor, Admin")]
    public class UploadController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Json("upload/" + fileName);
                }
                return Json("Uploaded success");
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
        }
        [HttpPost("{id}")]
        public ActionResult UploadFile(string id)
        {
            return (Json(LocalUploadController.UploadLocalFile(Request.Form.Files[0], _hostingEnvironment)));
            // if ()
            // try
            // {
            //     var file = Request.Form.Files[0];
            //     string folderName = "Upload";
            //     string webRootPath = _hostingEnvironment.WebRootPath;
            //     string newPath = Path.Combine(webRootPath, folderName);
            //     if (!Directory.Exists(newPath))
            //     {
            //         Directory.CreateDirectory(newPath);
            //     }
            //     if (file.Length > 0)
            //     {
            //         string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //         string fullPath = Path.Combine(newPath, fileName);
            //         using (var stream = new FileStream(fullPath, FileMode.Create))
            //         {
            //             file.CopyTo(stream);
            //         }
            //         System.IO.File.Delete(Path.Combine(newPath, id));
            //         return Json("upload/" + fileName);
            //     }
            //     return Json("Uploaded success");
            // }
            // catch (System.Exception ex)
            // {
            //     return Json("Upload Failed: " + ex.Message);
            // }
        }
        [HttpGet("download")]
        public IActionResult GetBlobDownload([FromQuery] string link)
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData(link);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = "something.bin";
            return File(content, contentType, fileName);
        }

    }
}
