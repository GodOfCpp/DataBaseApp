using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_project.BLL.Entities
{
    [Table("subjects")]
    public class Subject
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("is_obligatory")]
        public bool IsObligatory { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ICollection<Student> Students { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}