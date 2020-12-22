using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Entities
{
    [Table("Order")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string address { get; set; }

        public bool status { get; set; }

        [ForeignKey("userid")]
        public int userid { get; set; }

        [ForeignKey("orderid")]
        public ICollection<OrderDetail> orderDetails { get; set; }
    }
}
