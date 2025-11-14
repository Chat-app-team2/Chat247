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

        public string UploadImage(string filePath)
        {
            try
            {
                var result = _cloudinary.Upload(new ImageUploadParams()
                {
                    File = new FileDescription(filePath)
                });

                return result.SecureUrl.ToString(); // Trả về URL từ Cloudinary
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
