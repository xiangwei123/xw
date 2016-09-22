using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using QConnectSDK;
using QConnectSDK.Context;
using TestProject.IAppService;
using TestProject.Model;
using RestSharp.Validation;
using TestProject.UserService;
using TestProject.UserService.Dto;

namespace TestProject.Web.Controllers
{
    public class TaskController : TestProjectControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITaskAppService _taskAppService;


        public TaskController(ITaskAppService taskAppService, IUserService userService)
        {
            _taskAppService = taskAppService;
            _userService = userService;
        }
        public ActionResult Index()
        {
            var modelList = _userService.GetUserList();
            ViewData["ModelList"] = modelList;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult InsertUser(UsersInput input)
        {
            var result = Execute(() =>
            {
                _userService.AddUser(input);
            });
            return Json(result);
        }
    }
}