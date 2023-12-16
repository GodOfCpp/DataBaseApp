using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DB_project.BLL.Entities
{
    [Table("schools")]
    public class School
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("address")]
        public string Address { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ICollection<Employee> Employees { get; set; }
        
    }
}