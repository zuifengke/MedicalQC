// ***********************************************************
// 数据库访问层与病历时效自动质控结果数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using MedQC.Web.Models.Meddoc;
using MedQC.Web.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MedQC.Web.OleDbAccess
{

    public class QcTimeRecordAccess : DBAccessBase
    {
        private static QcTimeRecordAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static QcTimeRecordAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcTimeRecordAccess();
                return QcTimeRecordAccess.m_Instance;
            }
        }
        
        /// <summary>
        /// 时效质控记录表查询
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        public bool GetQcTimeRecords(ref List<QcTimeRecord> lstQcTimeRecords)
        {
            if (base.DataAccess == null)
                return false;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24}"
              , SystemData.QcTimeRecordTable.BEGIN_DATE
              , SystemData.QcTimeRecordTable.CHECK_DATE
              , SystemData.QcTimeRecordTable.CHECKER_NAME
              , SystemData.QcTimeRecordTable.CREATE_ID
              , SystemData.QcTimeRecordTable.CREATE_NAME
              , SystemData.QcTimeRecordTable.DEPT_IN_CHARGE
              , SystemData.QcTimeRecordTable.DEPT_STAYED
              , SystemData.QcTimeRecordTable.DOC_ID
              , SystemData.QcTimeRecordTable.DOC_TITLE
              , SystemData.QcTimeRecordTable.DOCTOR_IN_CHARGE
              , SystemData.QcTimeRecordTable.DOCTYPE_ID
              , SystemData.QcTimeRecordTable.DOCTYPE_NAME
              , SystemData.QcTimeRecordTable.END_DATE
              , SystemData.QcTimeRecordTable.EVENT_ID
              , SystemData.QcTimeRecordTable.PATIENT_ID
              , SystemData.QcTimeRecordTable.PATIENT_NAME
              , SystemData.QcTimeRecordTable.POINT
              , SystemData.QcTimeRecordTable.QC_EXPLAIN
              , SystemData.QcTimeRecordTable.QC_RESULT
              , SystemData.QcTimeRecordTable.REC_NO
              , SystemData.QcTimeRecordTable.RECORD_TIME
              , SystemData.QcTimeRecordTable.VISIT_ID
              , SystemData.QcTimeRecordTable.EVENT_NAME
              , SystemData.QcTimeRecordTable.EVENT_TIME
              , SystemData.QcTimeRecordTable.DOC_TIME);

            string szCondition = String.Format("1=1");

            string szSQL = null;

            szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                , szField, SystemData.DataTable.QC_TIME_RECORD, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return true;
                }
                if (lstQcTimeRecords == null)
                    lstQcTimeRecords = new List<QcTimeRecord>();
                do
                {
                    QcTimeRecord record = new QcTimeRecord();
                    if (!dataReader.IsDBNull(0)) record.BeginDate = dataReader.GetDateTime(0);
                    if (!dataReader.IsDBNull(1)) record.CheckDate = dataReader.GetDateTime(1);
                    if (!dataReader.IsDBNull(2)) record.CheckName = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) record.CreateID = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) record.CreateName = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) record.DeptInCharge = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) record.DeptStayed = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) record.DocID = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) record.DocTitle = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) record.DoctorInCharge = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) record.DocTypeID = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) record.DocTypeName = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) record.EndDate = dataReader.GetDateTime(12);
                    if (!dataReader.IsDBNull(13)) record.EventID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) record.PatientID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) record.PatientName = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) record.Point = float.Parse(dataReader.GetValue(16).ToString());
                    if (!dataReader.IsDBNull(17)) record.QcExplain = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) record.QcResult = dataReader.GetValue(18).ToString();
                    if (!dataReader.IsDBNull(19)) record.RecNo = int.Parse(dataReader.GetValue(19).ToString());
                    if (!dataReader.IsDBNull(20)) record.RecordTime = dataReader.GetDateTime(20);
                    if (!dataReader.IsDBNull(21)) record.VisitID = dataReader.GetString(21);
                    if (!dataReader.IsDBNull(22)) record.EventName = dataReader.GetString(22);
                    if (!dataReader.IsDBNull(23)) record.EventTime = dataReader.GetDateTime(23);
                    if (!dataReader.IsDBNull(24)) record.DocTime = dataReader.GetDateTime(24);
                    lstQcTimeRecords.Add(record);

                } while (dataReader.Read());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 时效质控超时记录表查询
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcTimeRecords(DateTime dtBeginTime, DateTime dtEndTime, string szQcResult
            , string szDeptCode,string szTimeType, ref List<QcTimeRecord> lstQcTimeRecords)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24}"
                , SystemData.QcTimeRecordTable.BEGIN_DATE
                , SystemData.QcTimeRecordTable.CHECK_DATE
                , SystemData.QcTimeRecordTable.CHECKER_NAME
                , SystemData.QcTimeRecordTable.CREATE_ID
                , SystemData.QcTimeRecordTable.CREATE_NAME
                , SystemData.QcTimeRecordTable.DEPT_IN_CHARGE
                , SystemData.QcTimeRecordTable.DEPT_STAYED
                , SystemData.QcTimeRecordTable.DOC_ID
                , SystemData.QcTimeRecordTable.DOC_TITLE
                , SystemData.QcTimeRecordTable.DOCTOR_IN_CHARGE
                , SystemData.QcTimeRecordTable.DOCTYPE_ID
                , SystemData.QcTimeRecordTable.DOCTYPE_NAME
                , SystemData.QcTimeRecordTable.END_DATE
                , SystemData.QcTimeRecordTable.EVENT_ID
                , SystemData.QcTimeRecordTable.PATIENT_ID
                , SystemData.QcTimeRecordTable.PATIENT_NAME
                , SystemData.QcTimeRecordTable.POINT
                , SystemData.QcTimeRecordTable.QC_EXPLAIN
                , SystemData.QcTimeRecordTable.QC_RESULT
                , SystemData.QcTimeRecordTable.REC_NO
                , SystemData.QcTimeRecordTable.RECORD_TIME
                , SystemData.QcTimeRecordTable.VISIT_ID
                , SystemData.QcTimeRecordTable.EVENT_NAME
                , SystemData.QcTimeRecordTable.EVENT_TIME
                , SystemData.QcTimeRecordTable.DOC_TIME);

            string szCondition = String.Format("1=1");
            if (!string.IsNullOrEmpty(szTimeType))
            {
                szCondition = string.Format("{0} AND {1} >= {2} AND {1} <={3}"
                  , szCondition
                  , szTimeType
                  , base.DataAccess.GetSqlTimeFormat(dtBeginTime)
                  , base.DataAccess.GetSqlTimeFormat(dtEndTime)
                  );

            }
            else
                szCondition = string.Format("{0} AND {1} >= {2} AND {1} <={3}"
                    , szCondition
                    , SystemData.QcTimeRecordTable.CHECK_DATE
                    , base.DataAccess.GetSqlTimeFormat(dtBeginTime)
                    , base.DataAccess.GetSqlTimeFormat(dtEndTime)
                    );
            if (!GlobalMethods.Misc.IsEmptyString(szQcResult))
            {
                szCondition = string.Format("{0} AND {1} in({2})"
                    , szCondition
                    , SystemData.QcTimeRecordTable.QC_RESULT
                    , szQcResult
                );
            }
            if (!GlobalMethods.Misc.IsEmptyString(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1} = '{2}' "
                    , szCondition
                    , SystemData.QcTimeRecordTable.DEPT_IN_CHARGE
                    , szDeptCode
                );
            }
            string szOrderBy = string.Format("{0},{1},{2}"
                , SystemData.QcTimeRecordTable.DEPT_IN_CHARGE, SystemData.QcTimeRecordTable.PATIENT_ID
                , SystemData.QcTimeRecordTable.VISIT_ID);

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                , SystemData.DataTable.QC_TIME_RECORD, szCondition, szOrderBy);



            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcTimeRecords == null)
                    lstQcTimeRecords = new List<QcTimeRecord>();
                do
                {
                    QcTimeRecord record = new QcTimeRecord();
                    if (!dataReader.IsDBNull(0)) record.BeginDate = dataReader.GetDateTime(0);
                    if (!dataReader.IsDBNull(1)) record.CheckDate = dataReader.GetDateTime(1);
                    if (!dataReader.IsDBNull(2)) record.CheckName = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) record.CreateID = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) record.CreateName = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) record.DeptInCharge = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) record.DeptStayed = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) record.DocID = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) record.DocTitle = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) record.DoctorInCharge = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) record.DocTypeID = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) record.DocTypeName = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) record.EndDate = dataReader.GetDateTime(12);
                    if (!dataReader.IsDBNull(13)) record.EventID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) record.PatientID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) record.PatientName = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) record.Point = float.Parse(dataReader.GetValue(16).ToString());
                    if (!dataReader.IsDBNull(17)) record.QcExplain = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) record.QcResult = dataReader.GetValue(18).ToString();
                    if (!dataReader.IsDBNull(19)) record.RecNo = int.Parse(dataReader.GetValue(19).ToString());
                    if (!dataReader.IsDBNull(20)) record.RecordTime = dataReader.GetDateTime(20);
                    if (!dataReader.IsDBNull(21)) record.VisitID = dataReader.GetString(21);
                    if (!dataReader.IsDBNull(22)) record.EventName = dataReader.GetString(22);
                    if (!dataReader.IsDBNull(23)) record.EventTime = dataReader.GetDateTime(23);
                    if (!dataReader.IsDBNull(24)) record.DocTime = dataReader.GetDateTime(24);
                    lstQcTimeRecords.Add(record);

                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.GetQcTimeRecords", new string[] { "szGroupName", "szConfigName", "SQL" }
                        , new object[] { szSQL }, "没有查询到记录!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }
    }
}
