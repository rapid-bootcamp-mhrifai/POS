using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CustomersEntity> Get()
        {
            return _context.customersEntities.ToList();
        }

        public void Add(CustomersEntity customers)
        {
            _context.customersEntities.Add(customers);
            _context.SaveChanges();
        }

        public CustomersEntity View(int? id)
        {
            var customers = _context.customersEntities.Find(id);
            return customers;
        }

        public void Update(CustomersEntity customers)
        {
            _context.customersEntities.Update(customers);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var customers = View(id);

            _context.customersEntities.Remove(customers); 
            _context.SaveChanges();
        }


    }
}
