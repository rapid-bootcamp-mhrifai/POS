using Microsoft.EntityFrameworkCore;
using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CategoryEntity> categoryEntities { get; set; }
    public DbSet<ProductEntity> productEntities { get; set; }
    public DbSet<SupplierEntity> supplierEntities { get; set; }

    public DbSet<OrdersEntity> supplierEntities { get; set; }
}
