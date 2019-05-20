using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BindingSecondPart.DataAccess
{
    public class DataInitializer : CreateDatabaseIfNotExists<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            context.Items.Add(new Models.Item()
            {
                Name = "Bread",
                Price = 1000,
                Description = "Very tasty"
            });
        }
    }
}
