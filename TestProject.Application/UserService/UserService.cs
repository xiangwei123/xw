using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using TestProject.User;
using TestProject.UserService.Dto;


namespace TestProject.UserService
{
    public class UserService :ApplicationService,IUserService
    {
        public IRepository<Users> _usersRepository;

        public UserService(IRepository<Users> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public List<UsersOutput> GetUserList()
        {
            var result = _usersRepository.GetAllList();
            return result.MapTo<List<UsersOutput>>();
        }

        public void AddUser(UsersInput input)
        {
            var model = input.MapTo<Users>();
            _usersRepository.Insert(model);
        }

        public void UpdateUser(UsersInput users)
        {
            throw new NotImplementedException();
        }

        public UsersOutput GetUserById(int id)
        {
            var model = _usersRepository.Get(id);
            return model.MapTo<UsersOutput>();
        }
    }
}
