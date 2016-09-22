using System;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.InteropServices;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Runtime.Validation;
using Abp.Threading;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Newtonsoft.Json;
using TestProject.UserService;
using TestProject.UserService.Dto;
using TestProject.Web.Models;
using Action = Antlr.Runtime.Misc.Action;

namespace TestProject.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class TestProjectControllerBase : AbpController
    {
        public IUserService userService { get; set; }

        public string CurrentUserId
        {
            get { return CurrentUser == null ? null : CurrentUser.Id.ToString(); }
        }

        public UsersOutput CurrentUser
        {
            get { return !AbpSession.UserId.HasValue ? null : userService.GetUserById(Int32.Parse(AbpSession.UserId.Value.ToString())); }
        }

        protected TestProjectControllerBase()
        {
            LocalizationSourceName = TestProjectConsts.LocalizationSourceName;
        }

        public HandleResult Execute(Action action)
        {
            var hr = new HandleResult();
            try
            {
                action();
                hr.Succeed = true;
            }
            catch (UserFriendlyException exception)
            {
                hr.ErrorMessage = exception.Message;
            }
            catch (AbpValidationException exception)
            {
                foreach (var item in exception.ValidationErrors)
                {
                    hr.ErrorMessage += string.Format("{0}<br/>", item);
                }
            }
            catch (AbpException exception)
            {
                hr.ErrorMessage = exception.Message;
            }
            catch (DbEntityValidationException exception)
            {
                foreach (var item2 in exception.EntityValidationErrors.SelectMany(item => item.ValidationErrors))
                {
                    hr.ErrorMessage += string.Format("{0}:{1}<br/>", item2.PropertyName, item2.ErrorMessage);
                }
            }
            catch (DbUpdateException exception)
            {
                hr.ErrorMessage += exception.InnerException.InnerException;
            }
            catch (Exception e)
            {
                hr.ErrorMessage = e.Message;
            }
            return hr;
        }

        public HandleResult<T> Execute<T>(Func<T> func)
        {
            var hr = new HandleResult<T>();
            try
            {
                hr.Data = func();
                hr.Succeed = true;
            }
            catch (UserFriendlyException exception)
            {
                hr.ErrorMessage = exception.Message;
            }
            catch (AbpValidationException exception)
            {
                foreach (var item in exception.ValidationErrors.SelectMany(a => a.ErrorMessage))
                {
                    hr.ErrorMessage += item;
                }
            }
            catch (AbpException exception)
            {
                hr.ErrorMessage = exception.Message;
            }
            catch (DbEntityValidationException exception)
            {
                foreach (var item2 in exception.EntityValidationErrors.SelectMany(item => item.ValidationErrors))
                {
                    hr.ErrorMessage += string.Format("{0}:{1}\r\n", item2.PropertyName, item2.ErrorMessage);
                }
            }
            catch (DbUpdateException exception)
            {
                hr.ErrorMessage += exception.InnerException.InnerException;
            }
            catch (Exception e)
            {
                hr.ErrorMessage = e.Message;
            }
            return hr;
        }

        readonly string _physicalPath = ConfigurationManager.AppSettings["AdminUploadPhysicalPath"];
        readonly string _virtualPath = ConfigurationManager.AppSettings["AdminUploadVirtualDirectory"];
        public readonly static string BaiduMapAPIBrowserAK = ConfigurationManager.AppSettings["BaiduMapAPIBrowserAK"];

        /// <summary>
        /// 生成上传文件路径
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="href">文件url地址</param>
        /// <returns></returns>
        public string GenerateUploadFilePath(string path, string fileName, out string href)
        {
            path = path.TrimEnd('\\').TrimStart('\\');

            var nameArr = fileName.Split('.');
            if (nameArr.Length == 1)
            {
                fileName = Guid.NewGuid().ToString("N");
            }
            else
            {
                fileName = Guid.NewGuid().ToString("N") + "." + nameArr[nameArr.Length - 1];
            }
            var fullPath = System.IO.Path.Combine(_physicalPath, path);
            if (!System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.CreateDirectory(fullPath);
            }
            href = _virtualPath + "/" + System.IO.Path.Combine(path, fileName).Replace("\\", "/");
            return System.IO.Path.Combine(_physicalPath, path, fileName);
        }
        public string GenerateUploadFilePathAsThumbnail(string path, string fileName, out string href, out string thumbnail)
        {
            path = path.TrimEnd('\\').TrimStart('\\');

            var nameArr = fileName.Split('.');
            if (nameArr.Length == 1)
            {
                fileName = Guid.NewGuid().ToString("N");
            }
            else
            {
                fileName = Guid.NewGuid().ToString("N") + "." + nameArr[nameArr.Length - 1];
            }
            var fullPath = System.IO.Path.Combine(_physicalPath, path);
            if (!System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.CreateDirectory(fullPath);
            }
            href = _virtualPath + "/" + System.IO.Path.Combine(path, fileName).Replace("\\", "/");
            var index = href.LastIndexOf(".");
            if (index > 0)
            {
                thumbnail = href.Substring(0, index) + "_t" + href.Substring(index, href.Length - index);
            }
            else
            {
                thumbnail = href + "_t";
            }
            return System.IO.Path.Combine(_physicalPath, path, fileName);
        }

        public void DeleteFile(params string[] path)
        {
            try
            {
                foreach (var s in path)
                {
                    var p = s;
                    if (!System.IO.File.Exists(p))
                    {

                        p = System.IO.Path.Combine(_physicalPath, p.Replace(_virtualPath.TrimEnd('/') + "/", "").Replace("/", "\\"));
                    }
                    System.IO.File.Delete(p);
                }

            }
            catch
            {
                // ignored
            }
        }

        //public void SEO(string key)
        //{
        //    var config = AsyncHelper.RunSync((() =>
        //            IocManager.Instance.Resolve<IM.Configuration.Configuration.IConfigurationAppService>().GetConfigurationByKeyAsync(
        //                new IdInput<string>() { Id = key }
        //            )));
        //    if (config != null && !string.IsNullOrWhiteSpace(config.Value))
        //    {
        //        this.SEO(JsonConvert.DeserializeObject<SEODto>(config.Value));
        //    }
        //}
        //public void SEO(SEODto dto)
        //{
        //    ViewBag.SEO = dto;
        //}
    }
}