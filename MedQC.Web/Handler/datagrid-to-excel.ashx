<%@ WebHandler Language="C#" Class="UEditorHandler"%>

using System;
using System.Web;
using System.IO;
using System.Text;
using MedQC.Web;
public class UEditorHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
            
        string fn = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls";
        string filepath = string.Format("{0}{1}"
            , context.Server.MapPath(SystemContext.FilePath.Excel)
            , fn);
        string data = context.Request.Form["data"];
        File.WriteAllText(filepath, data, Encoding.UTF8);
        string webpath = SystemContext.FilePath.Excel.Replace("~","") + fn;
        context.Response.Write(webpath);
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}