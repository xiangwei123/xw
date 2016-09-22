using System;
using System.Data.Entity.Migrations;
using TestProject.Model;

namespace TestProject.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TestProject.EntityFramework.TestProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TestProject";
        }

        protected override void Seed(TestProject.EntityFramework.TestProjectDbContext context)
        {
            context.People.AddOrUpdate(
                p => p.Name,
                new Person { Name = "Isaac Asimov" },
            new Person { Name = "Thomas More" },
            new Person { Name = "George Orwell" },
            new Person { Name = "Douglas Adams" }
                );

            context.Tasks.AddOrUpdate(new Task { AssignedPersonId = 1, CreationTime = DateTime.Now, Description = "Isaac Asimov",State = TaskState.Active},
                new Task { AssignedPersonId = 2,CreationTime = DateTime.Now, Description = "Thomas More", State = TaskState.Active },
                new Task { AssignedPersonId = 3, CreationTime = DateTime.Now, Description = "George Orwell", State = TaskState.Active },
                new Task { AssignedPersonId = 4, CreationTime = DateTime.Now, Description = "Douglas Adams", State = TaskState.Active });
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
