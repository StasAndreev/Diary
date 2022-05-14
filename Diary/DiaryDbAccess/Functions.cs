using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryDbAccess
{
    public class Functions
    {
        /// <summary>
        /// Inserts new user (id field is redundant)
        /// </summary>
        /// <param name="user"> User info </param>
        /// <returns> id of this user </returns>
        public static int InsertUser(User user)
        {
            if (user.Login == null || user.Password == null)
            {
                throw new ArgumentException("Some of the required fields are missing");
            }

            int result = 0;
            using (DiaryContext db = new DiaryContext())
            {
                User u = db.Users.Add(user);
                db.SaveChanges();
                result = u.ID.Value;
            }
            return result;
        }

        /// <summary>
        /// Inserts new task (id field is redundant)
        /// </summary>
        /// <param name="task"> Task info </param>
        /// <returns> id of this task </returns>
        public static int InsertTask(Task task)
        {
            if (task.UserID == null || task.Name == null || task.StartTime == null || task.EndTime == null ||
                task.TaskTypeID == null || task.RepeatRateID == null)
            {
                throw new ArgumentException("Some of the required fields are missing");
            }

            int result = 0;
            using (DiaryContext db = new DiaryContext())
            {
                task.IsDone = false;
                Task t = db.Tasks.Add(task);
                db.SaveChanges();
                result = t.ID.Value;
            }
            return result;
        }

        /// <summary>
        /// Inserts new task type (id field is redundant)
        /// </summary>
        /// <param name="type"> Task type info </param>
        /// <returns> id for this task </returns>
        public static int InsertTaskType(TaskType taskType)
        {
            if (taskType.Name == null || taskType.Color == null)
            {
                throw new ArgumentException("Some of the required fields are missing");
            }

            int result = 0;
            using (DiaryContext db = new DiaryContext())
            {
                TaskType tt = db.TaskTypes.Add(taskType);
                db.SaveChanges();
                result = tt.ID.Value;
            }
            return result;
        }

        /// <summary>
        /// Updates existing task found by ID field
        /// </summary>
        /// <param name="type"> Task type info </param>
        public static void UpdateTask(Task task)
        {
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from t in db.Tasks
                    where t.ID == task.ID
                    select t;

                if (query.Count() == 0)
                {
                    throw new ArgumentException("Item for update was not found");
                }
                else
                {
                    Task dbTask = query.First();
                    dbTask.UserID = task.UserID ?? dbTask.UserID;
                    dbTask.Name = task.Name ?? dbTask.Name;
                    dbTask.StartTime = task.StartTime ?? dbTask.StartTime;
                    dbTask.EndTime = task.EndTime ?? dbTask.EndTime;
                    dbTask.Note = task.Note ?? dbTask.Note;
                    dbTask.TaskTypeID = task.TaskTypeID ?? dbTask.TaskTypeID;
                    dbTask.RepeatRateID = task.RepeatRateID ?? dbTask.RepeatRateID;
                    dbTask.IsDone = task.IsDone ?? dbTask.IsDone;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Updates existing task type found by ID field
        /// </summary>
        /// <param name="type"> Task type info </param>
        public static void UpdateTaskType(TaskType taskType)
        {
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from tt in db.TaskTypes
                    where tt.ID == taskType.ID
                    select tt;

                if (query.Count() == 0)
                {
                    throw new ArgumentException("Item for update was not found");
                }
                else
                {
                    TaskType dbTaskType = query.First();
                    dbTaskType.UserID = taskType.UserID ?? dbTaskType.UserID;
                    dbTaskType.Name = taskType.Name ?? dbTaskType.Name;
                    dbTaskType.Color = taskType.Color ?? dbTaskType.Color;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deletes existing task found by ID field
        /// </summary>
        /// <param name="type"> Task type info </param>
        public static void DeleteTask(int taskId)
        {
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from t in db.Tasks
                    where t.ID == taskId
                    select t;

                if (query.Count() == 0)
                {
                    throw new ArgumentException("Item for delete was not found");
                }
                else
                {
                    db.Tasks.Remove(query.First());
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Updates existing task type found by ID field
        /// </summary>
        /// <param name="type"> Task type info </param>
        public static void DeleteType(int taskTypeId)
        {
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from tt in db.TaskTypes
                    where tt.ID == taskTypeId
                    select tt;

                if (query.Count() == 0)
                {
                    throw new ArgumentException("Item for delete was not found");
                }
                else
                {
                    db.TaskTypes.Remove(query.First());
                    db.SaveChanges();
                }
            }
        }

        public static int SelectUser(string login, string password)
        {
            return 0;
        }

        public static List<int> SelectTasks(int userId)
        {
            return new List<int>();
        }

        public static Task SelectTask(int taskId)
        {
            return new Task();
        }

        public static List<int> SelectTaskTypes(int userId)
        {
            return new List<int>();
        }

        public static TaskType SelectTaskType(int typeId)
        {
            return new TaskType();
        }

        public static List<string> SelectRepeatTypes()
        {
            return new List<string>();
        }

        public static Dictionary<Type, int> SelectWeeklyStatistics()
        {
            return new Dictionary<Type, int>();
        }
    }
}
