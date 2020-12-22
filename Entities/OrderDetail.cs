using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Entities
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }

        [ForeignKey("orderid")]
        public int orderid { get; set; }

        [ForeignKey("productid")]
        public int productid { get; set; }
    }
}
