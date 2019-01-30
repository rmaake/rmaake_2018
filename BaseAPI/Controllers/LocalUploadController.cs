using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers {
    public class LocalUploadController {

        public static string UploadLocalFile(IFormFile file, IHostingEnvironment _hostingEnvironment) {
            try
            {
                if (file == null) {
                    return null;
                }
                // var file = Request.Form.Files[0];
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
                    // return Json("upload/" + fileName);
                    return "upload/" + fileName;
                }
                // return Json("Uploaded success");
                return "Upload success";
            }
            catch (System.Exception ex)
            {
                // return Json("Upload Failed: " + ex.Message);
                return "Upload Failed: " + ex.Message;
            }
        }
    }
}