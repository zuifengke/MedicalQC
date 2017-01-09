using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using MedQC.Web.EFDao;
using MedQC.Web.DataAccess.Meddoc;

namespace MedQC.Web
{
    public class MeddocEnterRepository
    {
        ///// <summary>
        ///// 获取DAL入口类
        ///// </summary>
        ///// <returns></returns>
        public static MeddocRepositoryEnter GetRepositoryEnter()
        {
            MeddocRepositoryEnter _enter = CallContext.GetData("CurrentMeddocRepositoryEnter") as MeddocRepositoryEnter;
            if (_enter == null)
            {
                _enter = new MeddocRepositoryEnter();
                CallContext.SetData("CurrentMeddocRepositoryEnter", _enter);
            }
            return _enter;
        }
    }
}