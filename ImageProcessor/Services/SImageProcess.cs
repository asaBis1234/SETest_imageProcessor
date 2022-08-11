using ImageProcessor.Entities;
using ImageProcessor.Interfaces;
using System.Drawing;
using System.IO;

namespace ImageProcessor.Services
{
    public class SImageProcess : IImageProcess
    {
        private readonly ILogger<SImageProcess> _logger;
        public SImageProcess(ILogger<SImageProcess> logger)
        {
            _logger = logger;
        }
        public async Task<int> createImage(ProcessImage image)
        {
            try
            {

          
            //create stream
             FileStream file=new FileStream(image.FilePath, FileMode.Create);

            //read using drawing and change image
            System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(file);
            int imageHeight = imageToBeResized.Height;
            int imageWidth = imageToBeResized.Width;
            int maxHeight = image.Height== 0 ? 400 : image.Height;
            int maxWidth = image.Height== 0 ? 400 : image.Height;
            imageHeight = (imageHeight * maxWidth) / imageWidth;
            imageWidth = maxWidth;

            if (imageHeight > maxHeight)
            {
                imageWidth = (imageWidth * maxHeight) / imageHeight;
                imageHeight = maxHeight;
            }

            //create bitmap and apply changes above did
            Bitmap bitmap = new Bitmap(imageToBeResized, imageWidth, imageHeight);
            System.IO.MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            stream.Position = 0;
            byte[] imasave = new byte[stream.Length + 1];
            stream.Read(imasave, 0, imasave.Length);

            //write file to stream
            await file.WriteAsync(imasave);

            return 1;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return 0;
                
            }
        }


    }
}
