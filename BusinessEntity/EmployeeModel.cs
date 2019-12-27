using System;
using System.ComponentModel.DataAnnotations;
using Vega;

namespace BusinessEntity
{
    [Table(Name = "Employee", NeedsHistory = true, NoUpdatedBy = true, NoUpdatedOn = true)]
    public class EmployeeModel : EntityBase
    {
        [PrimaryKey(true)]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Department { get; set; }
    }

    public class EmployeeDepartment
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }
}
