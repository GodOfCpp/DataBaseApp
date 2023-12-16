using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_project.BLL.Entities
{
    [Table("classes")]
    public class Class
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("number")]
        public string Number { get; set; }
        
        [Column("letter")]
        public string Letter { get; set; }
        
        [Column("specialization")]
        public string Specialization { get; set; }
        
        [Column("class_teacher_id")]
        public Guid ClassTeacherId { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Teacher ClassTeacher { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ICollection<Student> Students { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}