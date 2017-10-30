using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PushPopPeekSize.Models
{
    public class Scripture
    {
        public int Id { get; set; }
        public string Text { get; set; }
        
    }

    public class ScriptureContext : DbContext
    {
        public ScriptureContext()
            :base("ScriptureDbConnection")
        { }
        public DbSet<Scripture> Scriptures { get; set; }
    }

    public class ScriptureDbInitializer: CreateDatabaseIfNotExists<ScriptureContext>
    {
        protected override void Seed(ScriptureContext db)
        {
           // db.Scriptures.Add(new Scripture {Text = "Hello"});
           // db.SaveChanges();

            base.Seed(db);
        }
    }
}