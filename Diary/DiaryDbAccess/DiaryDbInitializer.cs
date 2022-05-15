using System.Data.Entity;

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
