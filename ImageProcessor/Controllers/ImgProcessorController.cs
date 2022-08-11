using ImageProcessor.Entities;
using ImageProcessor.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgProcessorController : ControllerBase
    {

        private readonly IImageProcess _imageProcess;
        private readonly ILogger<ImgProcessorController> _logger;
        public ImgProcessorController(IImageProcess imageProcess, ILogger<ImgProcessorController> logger)
        {
            _imageProcess = imageProcess;
            _logger = logger;
        }

        

       

        [HttpPost(Name = "ImageProcessor")]
        public async Task<IActionResult> Post(ProcessImage image)
        {
            try
            {
                var result = await _imageProcess.createImage(image);

                return Ok("success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("server error");
            }
        }
    }


}
