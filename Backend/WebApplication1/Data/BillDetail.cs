using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("BillDetail")]
    public class BillDetail
    {
        [Key]
        public int Id { get; set; }
        public int BillID { get; set; }
        public int BookID { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
    }
}
