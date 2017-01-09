using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web.Utility
{
    public class TimeHelper
    {
        /// <summary>
        /// 获取时间间隔
        /// </summary>
        /// <param name="Minutes"></param>
        /// <returns></returns>
        public static string GetTimeSpanMin(DateTime time1,DateTime time2)
        {
            int intMinutes = (time2 - time1).Minutes;
            string result = "";
            if (intMinutes % 60 == 0)
            {
                result = intMinutes / 60 + "小时";
            }
            else if (intMinutes < 60)
            {
                result = intMinutes + "分";
            }
            else
            {
                result = intMinutes / 60 + "小时" + intMinutes % 60 + "分";
            }
            return result;
        }
    }
}