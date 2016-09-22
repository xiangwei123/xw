using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace TestProject.User
{
    public class Users : Entity
    {
        public string Account { get; set; }
        public string UserName { get; set; }
        public string  PassWord { get; set; }
        public string Remark { get; set; }
    }
}
