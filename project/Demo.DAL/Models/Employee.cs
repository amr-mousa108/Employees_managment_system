using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(50,ErrorMessage ="Max length of Name is 50 chars")]
        [MinLength(5,ErrorMessage ="Min length of Name is 5 chars")]
        public string Name { get; set; }
        [Range(22,30)]
        public int? Age { get; set; }
        public string Address{ get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted{ get; set; }
        public DateTime CreationDate { get; set; }
        public string Image{ get; set; }

        public int? DeptId { get; set; }

        [ForeignKey("DeptId")]
        public Departement? Departement { get; set; }
    }
}
