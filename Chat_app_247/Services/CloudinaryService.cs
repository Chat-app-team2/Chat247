using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Chat_app_247.Config;
using CloudinaryDotNet.Actions;
namespace Chat_app_247.Services
{
    public class CloudinaryService
    {
        private Cloudinary _cloudinary;
        private CloudinaryConfigFile _config;

        public CloudinaryService()
        {
            _config = new CloudinaryConfigFile();

            Account account = new Account(_config.Cloud_name, _config.ApiKey, _config.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }

        public string UploadFile(string filePath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                string ext = fileInfo.Extension.ToLower();

                // đuôi file ảnh 
                string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
                // đuôi file âm thanh
                string[] audioExtensions = { ".wav", ".mp3", ".m4a", ".aac" };
                bool isImage = Array.Exists(imageExtensions, e => e == ext);
                bool isAudio = Array.Exists(audioExtensions, e => e == ext);

                RawUploadResult result;

                if (isImage)
                {
                    // Upload ảnh
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(filePath),
                        Folder = "chat_app247/images"
                    };
                    result = _cloudinary.Upload(uploadParams);
                }
                else if (isAudio)
                {
                    // Upload âm thanh
                    var uploadParams = new VideoUploadParams()
                    {
                        File = new FileDescription(filePath),
                        Folder = "chat_app247/voice_messages"
                    };
                    result = _cloudinary.Upload(uploadParams);
                }
                else
                {
                    // Upload file
                    var uploadParams = new RawUploadParams()
                    {
                        File = new FileDescription(filePath),
                        Folder = "chat_app247/files"
                    };
                    result = _cloudinary.Upload(uploadParams);
                }

                return result.SecureUrl.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
