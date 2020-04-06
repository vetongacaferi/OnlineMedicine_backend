using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineMedicine_api.Services
{

    public interface IFileUploadService
    {
        string FileUpload(string file);
    }
    public class FileUploadService : IFileUploadService
    {
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };
        private readonly IHostingEnvironment host;
        public FileUploadService(IHostingEnvironment host)
        {
            this.host = host;
        }

        public string FileUpload(string filesData)
        {
            string _filepath = "";
            try
            {
                var uploadFilesPath = Path.Combine(host.WebRootPath, "uploads");
                if (!Directory.Exists(uploadFilesPath))
                    Directory.CreateDirectory(uploadFilesPath);
                var bytess = Convert.FromBase64String(filesData.Split("base64,")[1]);

                //this is a simple white background image
                var myfilename = string.Format(@"{0}", Guid.NewGuid());
                string extension = "png";
                var lowerCase = filesData.Substring(filesData.IndexOf('/') + 1, filesData.IndexOf(";base64"));
                if (lowerCase.IndexOf("png") != -1) extension = "png";
                else if (lowerCase.IndexOf("jpg") != -1 || lowerCase.IndexOf("jpeg") != -1)
                    extension = "jpg";
                else extension = "tiff";
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(myfilename)+ "."+ extension;
                _filepath = Path.Combine(uploadFilesPath, fileName);

                using (var stream = new FileStream(_filepath, FileMode.Create))
                {
                    stream.Write(bytess, 0, bytess.Length);
                    stream.Flush();
                }
            }
            catch(Exception error)
            {
                Console.WriteLine("fileUpload error", error);
            }           

            return _filepath;
        }

    }
}
