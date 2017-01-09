<%@ WebHandler Language="C#" Class="UEditorHandler" %>

using System;
using System.Web;
using System.IO;
using System.Collections;
using Newtonsoft.Json;

public class UEditorHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        //SiteConfig
        switch (context.Request["action"])
        {
            case "getconfig":
                GetConfig(context);
                break;
            case "saveconfig":
                SaveConfig(context);
                break;

        }
    }
    public void GetConfig(HttpContext context)
    {
        try
        {
            
            SiteConfig siteConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~").GetSection("SiteConfig") as SiteConfig;
            WriteJson(
            new
            {
                HospitalName = siteConfig.HospitalName
            }, context);
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public void SaveConfig(HttpContext context)
    {
        SiteConfig siteConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~").GetSection("SiteConfig") as SiteConfig;
        siteConfig.HospitalName = context.Request.Form["HospitalName"];
        siteConfig.CurrentConfiguration.Save();
        WriteJson(
            new
            {
                HospitalName = siteConfig.HospitalName
            }, context);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    protected void WriteJson(object response, HttpContext context)
    {
        string jsonpCallback = context.Request["callback"],
            json = JsonConvert.SerializeObject(response);
        if (String.IsNullOrWhiteSpace(jsonpCallback))
        {
            context.Response.AddHeader("Content-Type", "text/plain");
            context.Response.Write(json);
        }
        else
        {
            context.Response.AddHeader("Content-Type", "application/javascript");
            context.Response.Write(String.Format("{0}({1});", jsonpCallback, json));
        }
        context.Response.End();
    }
}