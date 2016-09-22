using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace TestProject.Model
{
    public class Task : Entity<long>
    {
        
        public virtual Person AssignedPerson { get; set; }

        public virtual int? AssignedPersonId { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual TaskState State { get; set; }

        //public virtual Person peoson { get; set; }

        public Task()
        {
            CreationTime = DateTime.Now;
            State = TaskState.Active;
        }
    }
    public enum TaskState : byte
    {
        Active = 1,
        Completed = 2
    } 
}
