using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using TestProject.IAppService;
using TestProject.Interface;
using TestProject.Model;

namespace TestProject.AppService
{
   public class TaskAppService:ApplicationService,ITaskAppService
    {
       private readonly ITaskRepository _taskRepository;
       private readonly IRepository<Person> _personRepository;

       public TaskAppService(ITaskRepository taskRepository, IRepository<Person> personRepository)
       {
           _taskRepository = taskRepository;
           _personRepository = personRepository;
       }



       public List<T> GetAllList<T>()
       {
           var result = _taskRepository.GetAllList();
           return result.MapTo<List<T>>();
       }

       public List<GetTasksOutput> GetTaskWitnPeople()
       {
           var result = _taskRepository.GetAll()
               .Join(_personRepository.GetAll(), a => a.Id, b => b.Id, (a, b) => new GetTasksOutput()
               {
                   Tasks = a,
                   Name = b.Name,
               }).ToList();
           return result;
       }


       public List<Task> GetList()
       {
           var result = from task in _taskRepository.GetAllList() where task.AssignedPersonId == 2 select task;
           return result.MapTo<List<Task>>();
           var tasksoutput = result.Select(a => new Task()
           {
               AssignedPersonId = a.AssignedPersonId
           }).ToList();
           return tasksoutput;
       }


       //public List<GetTasksOutput> GetTaskWitnPeople()
       //{
       //    var result = from t in _taskRepository.GetAll()
       //                 join p in _personRepository.GetAll() on t.Id equals p.Id
       //                 select new GetTasksOutput
       //                 {
       //                     Tasks = t,
       //                     Name = p.Name,

       //                 };
       //    return result.ToList();
       //}


    }
}
