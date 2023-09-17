using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("Publisher")]
    public class Publisher
    {
        public int PublisherID { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
