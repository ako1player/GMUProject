using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GMUProject.Data
{
    public class GMUProjectContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GMUProjectContext() : base("name=GMUProjectContext")
        {
        }

        public System.Data.Entity.DbSet<GMUProject.Models.Application> Applications { get; set; }

        public System.Data.Entity.DbSet<GMUProject.Models.Decision> Decisions { get; set; }

        public System.Data.Entity.DbSet<GMUProject.Models.Major> Majors { get; set; }

        public System.Data.Entity.DbSet<GMUProject.Models.Term> Terms { get; set; }
    }
}
