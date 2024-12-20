﻿using Coursework_EAD.Service.IService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework_EAD.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment) {
            _webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteFile(string fileName)
        {
            bool status = false;
            try {
                var path = $"{_webHostEnvironment.WebRootPath}\\ProjectImages\\{fileName}";
                if (File.Exists(path)) {
                    File.Delete(path);
                    return true;
                }
                return false;
            } 
            catch (Exception e) { throw e; }

        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            try {
                FileInfo fileInfo = new FileInfo(file.Name);
                var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\ProjectImages";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "ProjectImages", fileName);

                var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);

                if (!Directory.Exists(folderDirectory)) {
                    Directory.CreateDirectory(folderDirectory);
                }

                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                    memoryStream.WriteTo(fs);
                }

                var fullPath = $"ProjectImages/{fileName}";

                return fullPath;

            }
            catch(Exception e) {
                throw e;
            }
        }
    }
}
