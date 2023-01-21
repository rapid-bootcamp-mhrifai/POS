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

        public OrdersEntity Orders { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        public ProductEntity Product { get; set; }

        [Column("unit_price")]
        public double UnitPrice { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("discount")]
        public double Discount { get; set; }

        public OrderDetailsEntity(POS.ViewModel.OrderDetailModel model)
        {
            Id= model.Id;
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
