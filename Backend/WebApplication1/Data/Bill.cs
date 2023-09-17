using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        public int BillID { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public float Subtotal { get; set; }
        public int Status { get; set; }
    }
}
