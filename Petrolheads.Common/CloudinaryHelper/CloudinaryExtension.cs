namespace Petrolheads.Common.CloudinaryHelper
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryExtension
    {
        public static async Task<List<string>> UploadAsync(Cloudinary cloudinary, ICollection<IFormFile> files)
        {
            List<string> imageUrls = new List<string>();

            foreach (var file in files)
            {
                byte[] destinationImage;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                using (var destinationStream = new MemoryStream(destinationImage))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, destinationStream),
                    };

                    var result = await cloudinary.UploadAsync(uploadParams);

                    imageUrls.Add(result.Uri.AbsoluteUri);
                }
            }

            return imageUrls;
        }

        public static async Task<string> UploadFileAsync(Cloudinary cloudinary, IFormFile file)
        {
            string imageUrl = "";

            byte[] destinationImage;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            using (var destinationStream = new MemoryStream(destinationImage))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, destinationStream),
                };

                var result = await cloudinary.UploadAsync(uploadParams);

                imageUrl = result.Uri.AbsoluteUri;
            }

            return imageUrl;
        }
    }
}
