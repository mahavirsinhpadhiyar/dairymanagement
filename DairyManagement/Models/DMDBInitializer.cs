using DairyManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DairyManagement.Models
{
    public class DMDBInitializer: DropCreateDatabaseIfModelChanges<DMDBContext>
    {
        protected override void Seed(DMDBContext context)
        {
            UserInfo userInfo = new UserInfo()
            {
                Id = 1,
                FirstName = "Jagabhai",
                LastName = "Makwana",
                UserId = "Admin",
                Password = "Admin@123"
            };

            base.Seed(context);
        }
    }
}