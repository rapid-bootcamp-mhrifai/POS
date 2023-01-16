using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_employees")]
    public class EmployeesEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("title_of_courtesy")]
        public string TitleOfCourtesy { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("region")]
        public string Region { get; set; }

        [Column("postal_code")]
        public string PostalCode { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("home_phone")]
        public string HomePhone { get; set; }

        [Column("extension")]
        public string Extension { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("reports_to")]
        public int ReportsTo { get; set; }

        [Column("photo_path")]
        public string PhotoPath { get; set; }

        public ICollection<OrdersEntity> ordersEntities { get; set; }
        public EmployeesEntity(POS.ViewModel.EmployeeModel model)
        {
            LastName = model.LastName;
            FirstName = model.FirstName;
            Title = model.Title;
            TitleOfCourtesy = model.TitleOfCourtesy;
            BirthDate = model.BirthDate;
            HireDate = model.HireDate;
            Address = model.Address;
            City = model.City;
            Region = model.Region;
            PostalCode = model.PostalCode;
            Country = model.Country;
            HomePhone = model.HomePhone;
            Extension = model.Extension;
            Notes = model.Notes;
            ReportsTo = model.ReportsTo;
            PhotoPath = model.PhotoPath;

        }
        public EmployeesEntity()
        {

        }
    }
}