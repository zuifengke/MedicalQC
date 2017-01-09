using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedQC.Web.Utility;

namespace MedQC.Web.Services
{
    public class OperationMasterServices
    {
        /// <summary>
        /// 获取疑似重返手术室列表
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public static List<Models.OperationMaster> GetSuspectedReturns()
        {
            var list = IBatisAccess.OperationMasterDao.Instance.GetSuspectedReturns(null,null).ToList();
            var result = new List<Models.OperationMaster>();
            string operation_name_keys = SystemContext.Instance.OperationParameter[SystemConst.OperationParameter.operation_name_keys];
            string operation_keys_count = SystemContext.Instance.OperationParameter[SystemConst.OperationParameter.operation_keys_count];
            string filtering_characters = SystemContext.Instance.OperationParameter[SystemConst.OperationParameter.filtering_characters];
            foreach (var item1 in list)
            {
                if (item1.OPERATION_NAME == null)
                    item1.OPERATION_NAME = string.Empty;
                bool isDisplay = false;
                foreach (var item2 in list.Where(m => m.PATIENT_ID == item1.PATIENT_ID && m.OPER_ID != item1.OPER_ID))
                {
                    if (item2.OPERATION_NAME == null)
                        item2.OPERATION_NAME = string.Empty;

                    if (item1.OPERATION_NAME.ToUpper().Contains("MRI")
                        || item2.OPERATION_NAME.ToUpper().Contains("MRI"))
                        break;
                    if (item1.OPERATION_NAME.ToUpper().Contains("CT")
                        || item2.OPERATION_NAME.ToUpper().Contains("MRI"))
                        break;
                    //判断两次手术是否有关键字

                    if (!string.IsNullOrEmpty(operation_name_keys))
                    {
                        if (StringOperation.IsHaveKeyWord(item1.OPERATION_NAME, operation_name_keys.Split(','))
                            || StringOperation.IsHaveKeyWord(item2.OPERATION_NAME, operation_name_keys.Split(',')))
                        {
                            isDisplay = true;
                            break;
                        }
                    }
                    //判断两次手术是否有两个汉字以上重复

                    string lcsstr = StringOperation.LCS(item1.OPERATION_NAME, item2.OPERATION_NAME);
                    if (lcsstr.Length >= int.Parse(operation_keys_count))
                    {
                        isDisplay = true;
                    }
                    //排除关键字
                    if ((item1.OPERATION_NAME.Contains("左") && item2.OPERATION_NAME.Contains("右"))
                        || (item1.OPERATION_NAME.Contains("右") && item2.OPERATION_NAME.Contains("左")))
                        break;
                    //排除关键字
                    if (item2.OPERATION_NAME.Contains("部分") &&
                        (item2.OPERATION_NAME.Contains("全部")
                        || item2.OPERATION_NAME.Contains("根治")))
                    {
                        break;
                    }
                    foreach (var item in filtering_characters.Split(','))
                    {
                        if (item1.OPERATION_NAME.Contains(item)
                            || item1.OPERATION_NAME.Contains(item))
                        {
                            isDisplay = false;
                            break;
                        }
                    }
                }
                if (isDisplay)
                {
                    item1.CONTINUED_TIMESPAN = TimeHelper.GetTimeSpanMin(item1.START_DATE_TIME, item1.END_DATE_TIME);
                    result.Add(item1);
                }
            }
            //排除已经确认的二次手术患者
            var lstScOpreation = IBatisAccess.ScOperationDao.Instance.GetReturnRoom();
            for (int i = result.Count - 1; i >= 0; i--)
            {
                var item = result[i];
                if (lstScOpreation.Where(m => m.PATIENT_ID == item.PATIENT_ID).Count() > 0)
                    result.Remove(item);
            }
            return result;
        }

    }
}