using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BookModel
    {
        public int BookModelID { get; set; }
        public string Title { get; set; }
        public int CategoryID { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
    }
}
