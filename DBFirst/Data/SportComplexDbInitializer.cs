using System.Data.Entity;
using Lab_03.Models;

namespace Lab_03.Data
{
    public class SportComplexDbInitializer : DropCreateDatabaseIfModelChanges<SportComplexContext>
    {
        protected override void Seed(SportComplexContext context)
        {
            context.Clients.Add(new Client
            {
                client_full_name = "John Doe",
                client_gender = true, // чоловік
                client_phone_number = "123-456-7890"
            });

            base.Seed(context);
        }
    }
}