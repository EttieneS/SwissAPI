using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SwissAPI.Models
{
    public class SchoolDbContext: DbContext {

        public DbSet<Teacher> Teacher { get; set; }
    }
}