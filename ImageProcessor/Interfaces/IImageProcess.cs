using ImageProcessor.Entities;

namespace ImageProcessor.Interfaces
{
    public interface IImageProcess
    {
        Task<int> createImage(ProcessImage image);
    }
}
