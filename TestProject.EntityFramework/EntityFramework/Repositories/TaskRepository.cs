
using System.Linq;
using TestProject.Interface;
using TestProject.Model;
namespace TestProject.EntityFramework.Repositories
{
    public class TaskRepository : TestProjectRepositoryBase<Task, long>, ITaskRepository
    {
        public TaskRepository(Abp.EntityFramework.IDbContextProvider<TestProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public System.Collections.Generic.List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state)
        {
            var query = GetAll();
            query = query.Where(a => a.AssignedPersonId == assignedPersonId.Value);
            return query.ToList();
        }
    }
}
