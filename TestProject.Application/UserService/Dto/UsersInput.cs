using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using TestProject.User;

namespace TestProject.UserService.Dto
{
    [AutoMapTo(typeof(Users))]
    public class UsersInput : EntityDto
    {
        public string Account { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Remark { get; set; }
    }
}
