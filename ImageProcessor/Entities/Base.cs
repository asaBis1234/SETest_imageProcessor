namespace ImageProcessor.Entities
{
    public class Base
    {
        int id { get; set; }

        DateTime createdDate
        {
            get { return createdDate; }
            set { createdDate = DateTime.Now; }
        }
    }
}
