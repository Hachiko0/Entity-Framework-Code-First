using System.Data.Entity;

namespace DatabaseInitializers.Database
{
    public class MyInitializer : DropCreateDatabaseAlways<PremierLeagueContext>
    {
        protected override void Seed(PremierLeagueContext context)
        {
            context.Players.Add(new Player()
            {
                Age = 33,
                FirstName = "aaa",
                LastName = "bbb",
            });

            base.Seed(context);
        }
    }
}
