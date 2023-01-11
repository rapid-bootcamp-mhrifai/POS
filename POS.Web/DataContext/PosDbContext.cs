using Microsoft.EntityFrameworkCore;
using POS.Repository;

namespace POS.Web.DataContext
{
    public class PosDbContext : DbContext
    {
        public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> categoryEntities => Set<CategoryEntity>();
        public DbSet<ProductEntity> productEntities => Set<ProductEntity>();
        public DbSet<SupplierEntity> supplierEntities => Set<SupplierEntity>();
        public DbSet<OrdersEntity> ordersEntities => Set<OrdersEntity>();
        public DbSet<CustomersEntity> customersEntities => Set<CustomersEntity>();
        public DbSet<OrderDetailsEntity> orderDetailsEntities => Set<OrderDetailsEntity>();
        public DbSet<EmployeesEntity> employeesEntities => Set<EmployeesEntity>();
    }
}
