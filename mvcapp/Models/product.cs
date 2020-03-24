using System.ComponentModel.DataAnnotations;

namespace mvcapp.Models
{
    public class product
    {
        [Key]
        public int idproduct { get; set; }
        public string productname { get; set; }
        public decimal price { get; set; }

    }
}