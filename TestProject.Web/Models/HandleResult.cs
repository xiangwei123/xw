using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Web.Models
{
    public class HandleResult
    {
        public HandleResult() : this(false) { }
        public HandleResult(bool succeed) : this(succeed, null) { }

        public HandleResult(bool succeed, string errorMessage)
        {
            Succeed = succeed;
            ErrorMessage = errorMessage;
        }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Succeed { get; set; }
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 是否拒绝
        /// </summary>
        public bool Disallow { get; set; }
    }
    public class HandleResult<T> : HandleResult
    {
        public T Data { get; set; }
    }
}