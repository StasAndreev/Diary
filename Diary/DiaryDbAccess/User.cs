using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryDbAccess
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UID { get; set; }

        [Required, MaxLength(30)]
        public string Login { get; set; }

        [Required, MaxLength(30)]
        public string Password { get; set; }

        public virtual ICollection<TaskType> TaskTypes { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
