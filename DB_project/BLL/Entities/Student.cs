using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_project.BLL.Entities
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("class_id")]
        public Guid ClassId { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Class Class { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}