using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Model;

namespace TestProject.Interface
{
   public interface ITaskRepository:IRepository<Task,long>
    {
       List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state);
    }
}
