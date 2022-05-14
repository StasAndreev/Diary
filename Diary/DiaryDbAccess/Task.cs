using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Required]
        public bool? IsDone { get; set; }

        public virtual User User { get; set;}

        public virtual TaskType TaskType { get; set; }

        public virtual RepeatRate RepeatRate { get; set; }
    }
}
