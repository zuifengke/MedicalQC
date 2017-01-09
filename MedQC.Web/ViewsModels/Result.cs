using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web.ViewsModels
{
    /// <summary>
    /// 前端Ajax请求，统一返回结果对象
    /// </summary>
    public class Result
    {
        public string status  { get; set; }
        public string message { get; set; }
        public Result(){
            this.message = "操作成功";
            this.status = "success";
        }
        public Result(string status, string message)
        {
            this.status = status;
            this.message = message;
        }
    }
}