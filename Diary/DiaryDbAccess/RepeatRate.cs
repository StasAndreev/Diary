﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryDbAccess
{
    public class RepeatRate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
