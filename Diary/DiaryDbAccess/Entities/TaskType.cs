using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiaryDbAccess
{
    public class TaskType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int? ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? UID { get; set; }

        public int? UserID { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(8)]
        public string Color { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual User User { get; set; }

        public TaskType LightCopy()
        {
            TaskType result = new TaskType();
            result.UID = UID;
            result.Name = Name;
            result.Color = Color;
            result.User = new User { UID = User.UID };
            return result;
        }
    }
}
