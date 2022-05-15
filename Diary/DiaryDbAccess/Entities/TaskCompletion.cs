using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiaryDbAccess
{
    public class TaskCompletion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int? ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? UID { get; set; }

        [Required]
        public int? TaskId { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public virtual Task Task { get; set; }
    }
}
