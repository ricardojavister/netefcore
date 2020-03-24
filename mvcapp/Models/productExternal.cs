using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcapp.Models
{
    public class productExternal
    {
        [Key]
        public short idproduct { get; set; }
        public string name { get; set; }
        public short idcategory { get; set; }
        public string imageurl { get; set; }
        public decimal price { get; set; }
    }
}
