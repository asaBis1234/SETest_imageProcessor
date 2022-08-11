namespace ImageProcessor.Entities
{
    public class ProcessImage:Base
    {
       public string FilePath { get; set; }
        public string Name { get; set; }

        public string[] Effect { get; set; }

        public int  Width { get; set; }

        public int Height { get; set; }

        public int Radius { get; set; }

    }
}
