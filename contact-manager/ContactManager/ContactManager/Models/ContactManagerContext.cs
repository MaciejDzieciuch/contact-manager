using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public class ContactManagerContext : DbContext
    {
        public ContactManagerContext() : base("name=ContactManagerContext")
        {
        }

        public System.Data.Entity.DbSet<ContactManager.Models.User> Users { get; set; }
    }
}
