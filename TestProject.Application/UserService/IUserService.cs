using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using TestProject.User;
using TestProject.UserService.Dto;

namespace TestProject.UserService
{
    
   public interface IUserService:IApplicationService
   {
       List<UsersOutput> GetUserList();

       void AddUser(UsersInput input);

       void UpdateUser(UsersInput users);

       UsersOutput GetUserById(int id);
   }
}
