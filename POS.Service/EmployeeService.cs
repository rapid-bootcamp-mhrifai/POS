using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _context;
        private EmployeeModel EntityToModel(EmployeesEntity entity)
        {
            EmployeeModel result = new EmployeeModel();
            result.Id = entity.Id;
            result.LastName = entity.LastName;
            result.FirstName = entity.FirstName;
            result.Title = entity.Title;
            result.TitleOfCourtesy = entity.TitleOfCourtesy;
            result.BirthDate = entity.BirthDate;
            result.HireDate = entity.HireDate;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.HomePhone = entity.HomePhone;
            result.Extension = entity.Extension;
            result.Notes = entity.Notes;
            result.ReportsTo = entity.ReportsTo;
            result.PhotoPath = entity.PhotoPath;


            return result;
        }

        private void ModelToEntity(EmployeeModel model, EmployeesEntity entity)
        {
            entity.LastName = model.LastName;
            entity.FirstName = model.FirstName;
            entity.Title = model.Title;
            entity.TitleOfCourtesy = model.TitleOfCourtesy;
            entity.BirthDate = model.BirthDate;
            entity.HireDate = model.HireDate;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.HomePhone = model.HomePhone;
            entity.Extension = model.Extension;
            entity.Notes = model.Notes;
            entity.ReportsTo = model.ReportsTo;
            entity.PhotoPath = model.PhotoPath;
        }

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<EmployeesEntity> Get()
        {
            return _context.employeesEntities.ToList();
        }

        public void Add(EmployeesEntity employees)
        {
            _context.employeesEntities.Add(employees);
            _context.SaveChanges();
        }

        public EmployeeModel View(int? id)
        {
            var employees = _context.employeesEntities.Find(id);
            return EntityToModel(employees);
        }

        public void Update(EmployeeModel employees)
        {
            var entity = _context.employeesEntities.Find(employees.Id);
            ModelToEntity(employees, entity);
            _context.employeesEntities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.employeesEntities.Find(id);
            _context.employeesEntities.Remove(entity);
            _context.SaveChanges();
        }


    }
}