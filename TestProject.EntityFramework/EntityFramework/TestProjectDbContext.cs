
using Abp.EntityFramework;
using System.Data.Entity;
using TestProject.Model;
using TestProject.User;

namespace TestProject.EntityFramework
{
    public class TestProjectDbContext : AbpDbContext
    {
        public virtual IDbSet<Task> Tasks { get; set; }

        public virtual IDbSet<Person> People { get; set; }

        public virtual IDbSet<Users> Useres { get; set; }
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public TestProjectDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TestProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TestProjectDbContext since ABP automatically handles it.
         */
        public TestProjectDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
