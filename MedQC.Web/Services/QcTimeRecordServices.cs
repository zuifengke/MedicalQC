using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedQC.Web.Utility;
using MedQC.Web.OleDbAccess;
using System.Data;

namespace MedQC.Web
{
    public class QcTimeRecordServices
    {
        /// <summary>
        /// 获取全院前十二个月的超时率
        /// </summary>
        /// <returns></returns>
        public static List<ViewsModels.DataChat> GetQuanyuanChaoshiLv()
        {
            List<ViewsModels.DataChat> lstDataChat = new List<ViewsModels.DataChat>();
            //分月查询记录总数，超时数
            DateTime now = DateTime.Parse(string.Format("{0}-{1}-01 00:00:00", DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month));


            int total = 0;
            int timeoutcount = 0;

            for (int i = 1; i <= 12; i++)
            {
                DataSet ds = null;
                //每月应写病历总数
                string sql1 = string.Format("select count(*) from qc_time_record_t t where t.end_date < to_date('{0}', 'yyyy-MM-dd HH24:mi:ss') and t.end_date > to_date('{1}', 'yyyy-Mm-dd HH24:mi:ss')"
                , now.AddMonths(1 - i).ToString("yyyy-MM-dd HH:mm:ss"), now.AddMonths(-i).ToString("yyyy-MM-dd HH:mm:ss"));
                //每月病历超时数
                string sql2 = string.Format("select count(*) from qc_time_record_t t where t.end_date < to_date('{0}', 'yyyy-MM-dd HH24:mi:ss') and t.end_date > to_date('{1}', 'yyyy-Mm-dd HH24:mi:ss') and t.qc_result in (1,3)"
                , now.AddMonths(1 - i).ToString("yyyy-MM-dd HH:mm:ss"), now.AddMonths(-i).ToString("yyyy-MM-dd HH:mm:ss"));
                CommonAccess.Instance.ExecuteQuery(sql1, out ds);
                if (ds != null)
                {
                    total = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                if (total == 0)
                {
                    lstDataChat.Add(new ViewsModels.DataChat(0, now.AddMonths(-i).ToString("yyyy-MM")));
                    continue;
                }
                CommonAccess.Instance.ExecuteQuery(sql1, out ds);
                if (ds != null)
                {
                    timeoutcount = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                int percent = (int)Math.Round((decimal)timeoutcount / total, 2) * 100;
                lstDataChat.Add(new ViewsModels.DataChat(percent, now.AddMonths(-i).ToString("yyyy-MM")));
            }
            return lstDataChat;
        }
        /// <summary>
        /// 获取当月每个科室超时率排名
        /// </summary>
        /// <returns></returns>
        public static List<ViewsModels.DataChat> GetDeptRanking()
        {
            List<ViewsModels.DataChat> lstDataChat = new List<ViewsModels.DataChat>();
            //分月查询记录总数，超时数
            DateTime endTime = DateTime.Parse(string.Format("{0}-{1}-01 00:00:00", DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(0).Month));
            DateTime startTime = endTime.AddMonths(-2);

            DataSet ds = null;
            //每月应写病历总数
            string sql = string.Format("select t.dept_stayed,  t.total, t.timeoutcount,   TRUNC((timeoutcount / total), 4) * 100 as percent from(select count(*) total,   count(case     when t.qc_result in (1, 3) then  1    else      null       end) as timeoutcount,       t.dept_stayed   from qc_time_record_t t  where t.Check_date >=    to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')   and t.Check_date <=  to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')    group by dept_stayed order by t.dept_stayed) t"
                , startTime.ToString("yyyy-MM-dd HH:mm:ss")
                , endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            CommonAccess.Instance.ExecuteQuery(sql, out ds);
            if (ds != null && ds.Tables[0].Rows.Count>0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string deptName = ds.Tables[0].Rows[i]["dept_stayed"].ToString();
                    int percent = (int)float.Parse(ds.Tables[0].Rows[i]["percent"].ToString());
                    lstDataChat.Add(new ViewsModels.DataChat(percent,deptName));
                }
            }
            return lstDataChat;
        }
        /// <summary>
        /// 获取当月医生超时率排名
        /// </summary>
        /// <returns></returns>
        public static List<ViewsModels.DataChat> GetDoctorRanking()
        {
            List<ViewsModels.DataChat> lstDataChat = new List<ViewsModels.DataChat>();
            //分月查询记录总数，超时数
            DateTime endTime = DateTime.Parse(string.Format("2016-05-01 00:00:00", DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month));
            DateTime startTime = endTime.AddMonths(-1);

            DataSet ds = null;
            //每月应写病历总数
            string sql = string.Format("select t.doctor_in_charge,  t.total, t.timeoutcount,   TRUNC((timeoutcount / total), 4) * 100 as percent from(select count(*) total,   count(case     when t.qc_result in (1, 3) then  1    else      null       end) as timeoutcount,       t.doctor_in_charge   from qc_time_record_t t  where t.Check_date >=    to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')   and t.Check_date <=  to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')  and doctor_in_charge is not null   group by doctor_in_charge order by t.doctor_in_charge) t"
                , startTime.ToString("yyyy-MM-dd HH:mm:ss")
                , endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            CommonAccess.Instance.ExecuteQuery(sql, out ds);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    string deptName = ds.Tables[0].Rows[i]["doctor_in_charge"].ToString();
                    int percent= (int)float.Parse(ds.Tables[0].Rows[i]["percent"].ToString());
                    lstDataChat.Add(new ViewsModels.DataChat(percent, deptName));
                }
            }
            return lstDataChat;
        }
    }
}