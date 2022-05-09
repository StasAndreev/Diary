using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace DBAccess
{
    public class DBAccess
    {
        /// <summary>
        /// Inserts new user (id field is redundant)
        /// </summary>
        /// <param name="user"> User info </param>
        /// <returns> id of this user </returns>
        public static int InsertUser(User user)
        {
            int result = 0;
            using(DiaryEntities db = new DiaryEntities())
            {
                User u = db.User.Add(user);
                db.SaveChanges();
                result = u.id;
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
            using (DiaryEntities db = new DiaryEntities())
            {
                Task t = db.Task.Add(task);
                db.SaveChanges();
                result = t.id;
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
            using (DiaryEntities db = new DiaryEntities())
            {
                TaskType tt = db.TaskType.Add(type);
                db.SaveChanges();
                result = tt.id;
            }
            return result;
        }


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
