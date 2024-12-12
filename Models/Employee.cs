using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodefirstDemo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Column("EmployeName", TypeName ="varchar(100)")]
        public string name { get; set; }
        public int age { get; set; }
        public int phone { get; set; }   

        public string email { get; set; }
        //public int phoneNumber { get; set; } = 0;
        public string city { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
        public string city_name { get; set;
    }
        public string country_name { get; set; }
}
    }