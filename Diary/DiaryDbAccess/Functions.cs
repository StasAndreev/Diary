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
            int result = 0;
            using (DiaryContext db = new DiaryContext())
            {
                User u = db.Users.Add(user);
                db.SaveChanges();
                result = u.ID;
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
            int result = 0;
            using (DiaryContext db = new DiaryContext())
            {
                Task t = db.Tasks.Add(task);
                db.SaveChanges();
                result = t.ID;
            }
            return result;
        }

        /// <summary>
        /// Inserts new task type (id field is redundant)
        /// </summary>
        /// <param name="type"> Task type info </param>
        /// <returns> id for this task </returns>
        public static int InsertType(TaskType type)
        {
            int result = 0;
            using (DiaryContext db = new DiaryContext())
            {
                TaskType tt = db.TaskTypes.Add(type);
                db.SaveChanges();
                result = tt.ID;
            }
            return result;
        }

        /// <summary>
        /// Updates existing task found by ID field
        /// </summary>
        /// <param name="type"> Task type info </param>
        public static void UpdateTask(Task task)
        {

        }

        public static void UpdateType(TaskType type)
        {

        }

        public static void DeleteTask(int taskId)
        {

        }

        public static void DeleteType(int typeId)
        {

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
