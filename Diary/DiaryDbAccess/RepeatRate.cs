﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryDbAccess
{
    public enum RepeatRateOptions { NO_REPEAT, DAILY, WEEKLY, MONTHLY, ANNUAL }

    public class RepeatRate
    {
        public static List<string> optionNames = new List<string> { "No repeat", "Daily", "Weekly", "Monthly", "Annual" };

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int? ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? UID { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
