using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ElementsLesson.Services;

namespace ElementsLesson.DataAccess
{
    public class DataInitializer : DropCreateDatabaseAlways<SecurityContext>
    {
        protected override void Seed(SecurityContext context)
        {
            context.Users.Add(new Models.User()
            {
                Login = "admin",
                Password = DataEncryptor.HashPassword("123")
            });
            context.SaveChanges();
        }
    }
}
