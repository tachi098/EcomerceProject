using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Entities
{
    [Table("Product")]
    public class Product
    {

        public int id { get; set; }
        public string name { get; set; }
        public string  image { get; set; }
        public float price { get; set; }
        public int saleprice { get; set; }
        public int finalprice { get; set; }
        public int status { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }

        [ForeignKey("productid")]
        public ICollection<OrderDetail> orderDetails { get; set; }
    }
}
