using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    /*[Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }   
        public string? Description { get; set; }
        [Range(0,double.MaxValue)]
        public double Price { get; set; }
        [Range(0,100)]
        public int Quantity { get; set; }
    }*/

    [Table("Book")]
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public int? CategoryID { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? Quantity { get; set; }
        public int Status { get; set; } 
    }
}
