using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_project.BLL.Entities
{
    [Table("teachers")]
    public class Teacher
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("seniority")]
        public string Seniority { get; set; }
        
        [Column("qualification")]
        public string Qualification { get; set; }
        
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Employee Employee { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ICollection<Class> Classes { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ICollection<Subject> Subjects { get; set; }
    }

    //TODO:: сделать везде enum, где возможно
    public enum Qualification
    {
        First = 0,
        Upper = 1
    }
}