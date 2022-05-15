using System;
using System.Collections.Generic;
using System.Linq;

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
            if (user == null)
            {
                throw new ArgumentNullException();
            }

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
            if (task == null)
            {
                throw new ArgumentNullException();
            }

            if (task.UserID == null || task.Name == null || task.StartTime == null || task.EndTime == null ||
                task.TaskTypeID == null || task.RepeatRateID == null)
            {
                throw new ArgumentException("Some of the required fields are missing");
            }

            int result = 0;
            using (DiaryContext db = new DiaryContext())
            {
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
            if (taskType == null)
            {
                throw new ArgumentNullException();
            }

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
            if (task == null)
            {
                throw new ArgumentNullException();
            }

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
            if (taskType == null)
            {
                throw new ArgumentNullException();
            }

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
        /// Deletes existing task type found by ID field
        /// </summary>
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

        /// <summary>
        /// Select user with given login and password
        /// </summary>
        /// <returns> User id or 0 if not found </returns>
        public static int SelectUserId(string login, string password)
        {
            int result = 0;
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from u in db.Users
                    where u.Login == login && u.Password == password
                    select u;

                if (query.Count() > 0)
                {
                    result = query.First().ID.Value;
                }
            }
            return result;
        }

        /// <summary>
        /// Select all tasks of given user
        /// </summary>
        /// <returns> List of given user's tasks </returns>
        public static List<Task> SelectAllTasks(int userId)
        {
            List<Task> result = new List<Task>();
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from t in db.Tasks
                    where t.UserID == userId
                    select t;

                foreach (Task t in query)
                {
                    result.Add(t);
                }
            }
            return result;
        }

        /// <summary>
        /// Select no repeat tasks of given user for the week
        /// </summary>
        /// <returns> List of given user's tasks </returns>
        public static List<Task> SelectRelevantNoRepeatTasks(int userId, DateTime weekStart)
        {
            List<Task> result = new List<Task>();
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from t in db.Tasks
                    where t.UserID == userId && t.Name == RepeatRate.optionNames[(int)RepeatRateOptions.NO_REPEAT] &&
                          t.StartTime > weekStart && t.EndTime < weekStart.AddDays(7)
                    select t;

                foreach (Task t in query)
                {
                    result.Add(t);
                }
            }
            return result;
        }

        /// <summary>
        /// Select daily tasks of given user
        /// </summary>
        /// <returns> List of given user's tasks </returns>
        public static List<Task> SelectDailyTasks(int userId)
        {
            List<Task> result = new List<Task>();
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from t in db.Tasks
                    where t.UserID == userId && t.Name == RepeatRate.optionNames[(int)RepeatRateOptions.DAILY]
                    select t;

                foreach (Task t in query)
                {
                    result.Add(t);
                }
            }
            return result;
        }

        /// <summary>
        /// Select weekly tasks of given user
        /// </summary>
        /// <returns> List of given user's tasks </returns>
        public static List<Task> SelectWeeklyTasks(int userId)
        {
            List<Task> result = new List<Task>();
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from t in db.Tasks
                    where t.UserID == userId && t.Name == RepeatRate.optionNames[(int)RepeatRateOptions.WEEKLY]
                    select t;

                foreach (Task t in query)
                {
                    result.Add(t);
                }
            }
            return result;
        }

        /// <summary>
        /// Select monthly tasks of given user for the week
        /// </summary>
        /// <returns> List of given user's tasks </returns>
        public static List<Task> SelectRelevantMonthlyTasks(int userId, DateTime weekStart)
        {
            List<Task> result = new List<Task>();
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from t in db.Tasks
                    where t.UserID == userId && t.Name == RepeatRate.optionNames[(int)RepeatRateOptions.MONTHLY] &&
                          t.StartTime.Value.Day >= weekStart.Day && t.EndTime.Value.Day < weekStart.Day + 7
                    select t;

                foreach (Task t in query)
                {
                    result.Add(t);
                }
            }
            return result;
        }

        /// <summary>
        /// Select annual tasks of given user for the week
        /// </summary>
        /// <returns> List of given user's tasks </returns>
        public static List<Task> SelectRelevantAnnualTasks(int userId, DateTime weekStart)
        {
            List<Task> result = new List<Task>();
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from t in db.Tasks
                    where t.UserID == userId&& t.Name == RepeatRate.optionNames[(int)RepeatRateOptions.ANNUAL] &&
                          t.StartTime.Value.DayOfYear >= weekStart.DayOfYear &&
                          t.EndTime.Value.DayOfYear < weekStart.DayOfYear + 7
                    select t;

                foreach (Task t in query)
                {
                    result.Add(t);
                }
            }
            return result;
        }

        /// <summary>
        /// Select task types of given user
        /// </summary>
        /// <returns> List of given user's task types </returns>
        public static List<TaskType> SelectTaskTypes(int userId)
        {
            List<TaskType> result = new List<TaskType>();
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from tt in db.TaskTypes
                    where tt.UserID == userId
                    select tt;

                foreach (TaskType tt in query)
                {
                    result.Add(tt);
                }
            }
            return result;
        }

        /// <summary>
        /// Select available repeat rates
        /// </summary>
        /// <returns> List of available repeat rates </returns>
        public static List<string> GetRepeatTypes()
        {
            return RepeatRate.optionNames;
        }

        /// <summary>
        /// Select amount of hours spent for every task type on given weeks
        /// </summary>
        /// <returns> Map of task types and hours spent </returns>
        public static Dictionary<TaskType, float> SelectWeeklyStatistics(DateTime weekStart, int weekAmount = 1)
        {
            if (weekAmount <= 0)
            {
                throw new ArgumentException("Invalid amount of weeks to count statistics for");
            }

            Dictionary<TaskType, float> result = new Dictionary<TaskType, float>();
            using (DiaryContext db = new DiaryContext())
            {
                var query =
                    from t in db.TaskCompletions
                    where t.Date > weekStart && t.Date < weekStart.AddDays(7 * weekAmount)
                    select t;

                foreach (TaskCompletion tc in query)
                {
                    TaskType tt = tc.Task.TaskType;
                    TimeSpan time = (tc.Task.EndTime - tc.Task.StartTime).Value;
                    float hours = time.Hours + (float) time.Minutes / 60;

                    if (result.ContainsKey(tt))
                    {
                        result[tt] += hours;
                    }
                    else
                    {
                        result.Add(tt, hours);
                    }
                }
            }
            return result;
        }
    }
}
