using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DiaryDbAccess
{
    public class DiaryContext : DbContext
    {
        public DiaryContext() : base("name=DiaryContext")
        {
            Database.SetInitializer<DiaryContext>(new DiaryDbInitializer());
            Database.Initialize(false);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<RepeatRate> RepeatRates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithRequired(t => t.User)
                .HasForeignKey(t => t.UserID);

            modelBuilder.Entity<User>()
                .HasMany(u => u.TaskTypes)
                .WithRequired(tt => tt.User)
                .HasForeignKey(tt => tt.UserID);

            modelBuilder.Entity<TaskType>()
                .HasMany(tt => tt.Tasks)
                .WithOptional(t => t.TaskType)
                .HasForeignKey(t => t.TaskTypeID);

            modelBuilder.Entity<RepeatRate>()
                .HasMany(r => r.Tasks)
                .WithRequired(t => t.RepeatRate)
                .HasForeignKey(t => t.RepeatRateID);
        }
    }
}
