using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_category")]
    public class CategoryEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("category_name")]
        public string CategoryName { get; set; }
        [Column("description")]
        public string Description { get; set; }

        public ICollection<ProductEntity> productEntities { get; set; }

    }
}