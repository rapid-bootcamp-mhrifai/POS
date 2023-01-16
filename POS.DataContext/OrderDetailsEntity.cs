using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_order_details")]
    public class OrderDetailsEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_id")]
        public int OrdersId { get; set; }

        [Required]
        public OrdersEntity Orders { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Required]
        public ProductEntity Product { get; set; }

        [Required]
        [Column("unit_price")]
        public double UnitPrice { get; set; }

        [Required]
        [Column("quantity")]
        public long Quantity { get; set; }

        [Required]
        [Column("discount")]
        public double Discount { get; set; }

        public OrderDetailsEntity(POS.ViewModel.OrderDetailModel model)
        {
            OrdersId = model.OrdersId;
            ProductId = model.ProductId;
            UnitPrice= model.UnitPrice;
            Quantity = model.Quantity;
            Discount = model.Discount;

        }

        public OrderDetailsEntity()
        {

        }
    }
}
