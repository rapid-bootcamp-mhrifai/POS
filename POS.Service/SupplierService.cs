using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class SupplierService
    {
        private readonly ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SupplierEntity> Get()
        {
            return _context.supplierEntities.ToList();
        }

        public void Add(SupplierEntity supplier)
        {
            _context.supplierEntities.Add(supplier);
            _context.SaveChanges();
        }

        public SupplierEntity View(int? id)
        {
            var supplier = _context.supplierEntities.Find(id);
            return supplier;
        }

        public void Update(SupplierEntity supplier)
        {
            _context.supplierEntities.Update(supplier);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var supplier = View(id);
            _context.supplierEntities.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
