using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DiaryDbAccess
{
    public class DiaryDbInitializer : CreateDatabaseIfNotExists<DiaryContext>
    {
        protected override void Seed(DiaryContext context)
        {
            base.Seed(context);
            foreach (string name in RepeatRate.optionNames)
            {
                context.RepeatRates.Add(new RepeatRate { Name = name });
            }
            context.SaveChanges();
        }
    }
}
