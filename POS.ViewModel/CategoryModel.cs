using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
