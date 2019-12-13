namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactManager.Models.ContactManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactManager.Models.ContactManagerContext context)
        {
            DateTime dateNow = DateTime.Now;

            context.Users.AddOrUpdate(x => x.Id,
                new Models.User() { Id = 1, Name = "Admin", Surname = "Admin", Email = "admin@example.com", Password = "123456*aA", CategoryType = Models.CategoryType.Private, PhoneNumber = "123456789", BirthDate = dateNow });

            context.SaveChanges();
        }
    }
}
