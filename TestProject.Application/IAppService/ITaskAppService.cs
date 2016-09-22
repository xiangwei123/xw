using Abp.Application.Services;
using System.Collections.Generic;
using TestProject.Model;

namespace TestProject.IAppService
{
    public interface ITaskAppService : IApplicationService
    {
        List<T> GetAllList<T>();

        List<GetTasksOutput> GetTaskWitnPeople();
    }
}
