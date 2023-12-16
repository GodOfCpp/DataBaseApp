using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_project.BLL.Entities
{
    [Table("employees")]
    public class Employee
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("position")]
        public string Position { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("school_id")]
        public Guid SchoolId { get; set; }
        
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        
        [Column("salary")]
        public decimal Salary { get; set; }
        
        [Column("email")]
        public string Email { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ICollection<Teacher> Teacher { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual School School { get; set; }

    }
}