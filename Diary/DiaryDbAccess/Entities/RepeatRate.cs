using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiaryDbAccess
{
    [Serializable]
    public class RepeatRate
    {
        public static readonly List<string> optionNames = new List<string> { "No repeat", "Daily", "Weekly", "Monthly", "Annual" };

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int? ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? UID { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public RepeatRate LightCopy()
        {
            RepeatRate result = new RepeatRate();
            result.UID = UID;
            result.Name = Name;
            return result;
        }
    }
}
