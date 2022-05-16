using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DiaryDbAccess
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int? ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? UID { get; set; }

        public int? UserID { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime? StartTime { get; set; }

        [Required]
        public DateTime? EndTime { get; set; }

        [MaxLength(250)]
        public string Note { get; set; }

        public int? TaskTypeID { get; set; }

        public int? RepeatRateID { get; set; }

        public virtual User User { get; set;}

        public virtual TaskType TaskType { get; set; }

        public virtual RepeatRate RepeatRate { get; set; }

        public virtual ICollection<TaskCompletion> TaskCompletions { get; set; }

        public Task LightCopy()
        {
            Task result = new Task();
            result.UID = UID;
            result.Name = Name;
            result.StartTime = StartTime;
            result.EndTime = EndTime;
            result.Note = Note;
            result.User = new User { UID = User.UID };
            result.TaskType = new TaskType { UID = TaskType.UID };
            result.RepeatRate = new RepeatRate { UID = RepeatRate.UID };
            return result;
        }
    }
}
