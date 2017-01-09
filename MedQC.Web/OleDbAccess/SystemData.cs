using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web
{
    public struct SystemData
    {  /// <summary>
       /// 返回值常量
       /// </summary>
        public struct ReturnValue
        {
            /// <summary>
            /// 正常(0)
            /// </summary>
            public const short OK = 0;
            /// <summary>
            /// 参数错误(1)
            /// </summary>
            public const short PARAM_ERROR = 1;
            /// <summary>
            /// 取消
            /// </summary>
            public const short CANCEL = 2;
            /// <summary>
            /// 接口内部异常(3)
            /// </summary>
            public const short EXCEPTION = 3;
            /// <summary>
            /// 资源未发现(4)
            /// </summary>
            public const short RES_NO_FOUND = 4;
            /// <summary>
            /// 资源已经存在(5)
            /// </summary>
            public const short RES_IS_EXIST = 5;
            /// <summary>
            /// 失败
            /// </summary>
            public const short FAILED = 7;
            /// <summary>
            /// 数据库访问错误(2)
            /// </summary>
            public const short ACCESS_ERROR = 6;
            /// <summary>
            /// 其他错误(9)
            /// </summary>
            public const short OTHER_ERROR = 9;
        }
        /// <summary>
        /// 病案状态常量
        /// </summary>
        public struct MrStatus
        {
            public const string Online = "O";
            public const string Close = "C";
            public const string Archive = "A";
            public const string Offline = "F";

            public static string GetMrStatusName(string szCode)
            {
                string szName = string.Empty;
                switch (szCode)
                {
                    case MrStatus.Online:
                        szName = "工作";
                        break;
                    case MrStatus.Close:
                        szName = "关闭";
                        break;
                    case MrStatus.Archive:
                        szName = "归档";
                        break;
                    case MrStatus.Offline:
                        szName = "脱机";
                        break;
                    default:
                        szName = "未知";
                        break;
                }
                return szName;
            }
        }
        /// <summary>
        /// 程序单实例运行映射名称
        /// </summary>
        public struct MappingName
        {
            /// <summary>
            /// 病历质控系统
            /// </summary>
            public const string MEDQC_SYS = "MedQcSys";
            /// <summary>
            /// 病历编辑器系统
            /// </summary>
            public const string MEDDOC_SYS = "MedDocSys";
            /// <summary>
            /// 病历提醒系统
            /// </summary>
            public const string MEDTASK_SYS = "MedTask";
            /// <summary>
            /// 质检问题提醒系统
            /// </summary>
            public const string QUESTION_CHAT_SYS = "QuestionChat";
            /// <summary>
            /// 病历模板系统
            /// </summary>
            public const string TEMPLET_SYS = "MedTemplet";
            /// <summary>
            /// 配置管理程序
            /// </summary>
            public const string CONFIG_SYS = "MdsConfig";
            /// <summary>
            /// 病历检索系统
            /// </summary>
            public const string SEARCH_SYS = "MedSearch";
            /// <summary>
            /// 脚本调试程序
            /// </summary>
            public const string SCRIPT_DEBUG_SYS = "ScriptDebuger";
            /// <summary>
            /// 自动升级程序
            /// </summary>
            public const string UPGRADE_SYS = "Upgrade";
        }

        /// <summary>
        /// 聊天消息数据类型
        /// </summary>
        public struct MsgChatDataType
        {
            /// <summary>
            /// 文本
            /// </summary>
            public const string ChatContent = "0";

            /// <summary>
            /// 图片
            /// </summary>
            public const string Image = "1";

        }
        /// <summary>s
        /// 数据库类型常量
        /// </summary>
        public struct DatabaseType
        {
            /// <summary>
            /// ORACLE数据库类型
            /// </summary>
            public const string ORACLE = "ORACLE";
            /// <summary>
            /// SQLSERVER数据库类型
            /// </summary>
            public const string SQLSERVER = "SQLSERVER";
        }
        #region"FileType"
        /// <summary>
        /// 文件扩展名常量
        /// </summary>
        public struct FileType
        {
            /// <summary>
            /// 医疗文档扩展名"smdf"
            /// </summary>
            public const string MED_DOCUMENT = "smdf";
            /// <summary>
            /// 文档模板文件扩展名"smdt"
            /// </summary>
            public const string DOC_TEMPLET = "smdt";
            /// <summary>
            /// XDB病历文档扩展名"xml"
            /// </summary>
            public const string XML_DOCUMENT = "xml";
            /// <summary>
            /// HTML病历文档扩展名"html"
            /// </summary>
            public const string HTML_DOCUMENT = "html";
            /// <summary>
            /// PDF病历文档扩展名"pdf"
            /// </summary>
            public const string PDF_DOCUMENT = "pdf";
        }
        #endregion
        /// <summary>
        /// 数据库驱动类型常量
        /// </summary>
        public struct DataProvider
        {
            /// <summary>
            /// .NET提供的SqlClient驱动类型
            /// </summary>
            public const string SQLCLIENT = "System.Data.SqlClient";
            /// <summary>
            /// .NET提供的Oracle驱动类型
            /// </summary>
            public const string ORACLE = "System.Data.OracleClient";
            /// <summary>
            /// .NET提供的OleDb驱动类型
            /// </summary>
            public const string OLEDB = "System.Data.OleDb";
            /// <summary>
            /// .NET提供的ODBC驱动类型
            /// </summary>
            public const string ODBC = "System.Data.Odbc";
            /// <summary>
            /// Oracle提供的ODPNET驱动类型
            /// </summary>
            public const string ODPNET = "Oracle.DataAccess.Client";
        }

        /// <summary>
        /// 病质控审查状态常量
        /// </summary>
        public struct MedQCStatus
        {
            /// <summary>
            /// 未审查
            /// </summary>
            public const string NO_CHECK = "-1";
            /// <summary>
            /// 已审查
            /// </summary>
            public const string CHECKED = "0";
            /// <summary>
            /// 审查通过
            /// </summary>
            public const string PASS = "1";
            /// <summary>
            /// 审查后存在问题
            /// </summary>
            public const string EXIST_BUG = "2";
            /// <summary>
            /// 审查后存在严重问题
            /// </summary>
            public const string SERIOUS_BUG = "3";
        }

        /// <summary>
        /// 病人病情状态常量
        /// </summary>
        public struct PatientCondition
        {
            /// <summary>
            /// 一般
            /// </summary>
            public const string REGULAR = "一般";
            /// <summary>
            /// 病重
            /// </summary>
            public const string SERIOUS = "急";
            /// <summary>
            /// 病危
            /// </summary>
            public const string CRITICAL = "危";

            /// <summary>
            /// 获取病人状态中文描述
            /// </summary>
            /// <param name="szConditionCode">病人病情状态代码</param>
            /// <returns>病人状态中文描述</returns>
            public static string GetConditionDesc(string szConditionCode)
            {
                if (szConditionCode == "2")
                    return PatientCondition.SERIOUS;
                else if (szConditionCode == "1")
                    return PatientCondition.CRITICAL;
                else
                    return PatientCondition.REGULAR;
            }
        }
        /// <summary>
        /// 病人病情状态常量
        /// </summary>
        public struct OrderStatus
        {
            /// <summary>
            /// 新开
            /// </summary>
            public const string New = "新开";
            /// <summary>
            /// 执行
            /// </summary>
            public const string Process = "执行";
            /// <summary>
            /// 停止
            /// </summary>
            public const string Stop = "停止";
            /// <summary>
            /// 作废
            /// </summary>
            public const string Delete = "作废";

            public static string GetOrderStatusDesc(string szOrderStatus)
            {
                if (szOrderStatus == "1")
                    return OrderStatus.New;
                else if (szOrderStatus == "2")
                    return OrderStatus.Process;
                else if (szOrderStatus == "3")
                    return OrderStatus.Stop;
                else if (szOrderStatus == "4")
                    return OrderStatus.Delete;
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 问题状态
        /// </summary>
        public struct MsgState
        {
            public const string CnUnCheck = "未接收";
            public const string CnChecked = "已确认";
            public const string CnModified = "已修改";
            public const string CnPass = "合格";

            public const string UnCheck = "0";
            public const string Checked = "1";
            public const string Modified = "2";
            public const string Pass = "3";

            public static string GetCnMsgState(string szStateCode)
            {
                string szMsgState = string.Empty;
                switch (szStateCode)
                {
                    case MsgState.UnCheck:
                        szMsgState = MsgState.CnUnCheck;
                        break;
                    case MsgState.Checked:
                        szMsgState = MsgState.CnChecked;
                        break;

                    case MsgState.Modified:
                        szMsgState = MsgState.CnModified;
                        break;

                    case MsgState.Pass:
                        szMsgState = MsgState.CnPass;
                        break;

                    default:
                        break;
                }
                return szMsgState;
            }
            public static string GetMsgStateCode(string szState)
            {
                string szMsgStateCode = string.Empty;
                switch (szState)
                {
                    case MsgState.CnChecked:
                        szMsgStateCode = MsgState.Checked;
                        break;

                    case MsgState.CnUnCheck:
                        szMsgStateCode = MsgState.UnCheck;
                        break;

                    case MsgState.CnModified:
                        szMsgStateCode = MsgState.Modified;
                        break;

                    case MsgState.CnPass:
                        szMsgStateCode = MsgState.Pass;
                        break;

                    default:
                        break;
                }
                return szMsgStateCode;
            }
        }
        /// <summary>
        /// 时效规则类型
        /// </summary>
        public struct WrittenState
        {

            /// <summary>
            /// 正常
            /// </summary>
            public const string CnNormal = "正常";

            /// <summary>
            /// 未书写超时
            /// </summary>
            public const string CnUnwrite = "未书写超时";

            /// <summary>
            /// 书写超时
            /// </summary>
            public const string CnTimeout = "书写超时";

            /// <summary>
            /// 书写提前
            /// </summary>
            public const string CnEarly = "书写提前";

            /// <summary>
            /// 正常未书写
            /// </summary>
            public const string CnUnwriteNormal = "正常未书写";



            /// <summary>
            /// 正常
            /// </summary>
            public const string Normal = "0";
            /// <summary>
            /// 未书写超时
            /// </summary>
            public const string Unwrite = "1";
            /// <summary>
            /// 书写提前
            /// </summary>
            public const string Early = "2";
            /// <summary>
            /// 书写超时
            /// </summary>
            public const string Timeout = "3";
            /// <summary>
            /// 正常未书写
            /// </summary>
            public const string UnwriteNormal = "4";



            public static string GetCnWrittenState(string szStateCode)
            {
                string szWrittenState = string.Empty;
               
                switch (szStateCode)
                {
                    case WrittenState.Early:
                        szWrittenState = WrittenState.CnEarly;
                        break;

                    case WrittenState.Normal:
                        szWrittenState = WrittenState.CnNormal;
                        break;

                    case WrittenState.Timeout:
                        szWrittenState = WrittenState.CnTimeout;
                        break;

                    case WrittenState.UnwriteNormal:
                        szWrittenState = WrittenState.CnUnwriteNormal;
                        break;

                    case WrittenState.Unwrite:
                        szWrittenState = WrittenState.CnUnwrite;
                        break;

                    default:
                        break;
                }
                return szWrittenState;
            }
            public static string GetWrittenStateCode(string szState)
            {
                string szWrittenState = string.Empty;
                switch (szState)
                {
                    case WrittenState.CnEarly:
                        szWrittenState = WrittenState.Early;
                        break;

                    case WrittenState.CnNormal:
                        szWrittenState = WrittenState.Normal;
                        break;

                    case WrittenState.CnTimeout:
                        szWrittenState = WrittenState.Timeout;
                        break;

                    case WrittenState.CnUnwrite:
                        szWrittenState = WrittenState.Unwrite;
                        break;

                    case WrittenState.CnUnwriteNormal:
                        szWrittenState = WrittenState.UnwriteNormal;
                        break;

                    default:
                        break;
                }
                return szWrittenState;
            }
        }
        /// <summary>
        /// 程序启动参数有关常量
        /// </summary>
        public struct StartupArgs
        {
            /// <summary>
            /// 启动参数中的组间分隔符
            /// </summary>
            public const string GROUP_SPLIT = "|";
            /// <summary>
            /// 启动参数中的组内字段分隔符
            /// </summary>
            public const string FIELD_SPLIT = ";";
            /// <summary>
            /// 启动参数字符串内的被转义字符
            /// </summary>
            public const string ESCAPED_CHAR = " ";
            /// <summary>
            /// 启动参数字符串内的转义符
            /// </summary>
            public const string ESCAPE_CHAR = "$";
        }
        /// <summary>
        /// 配置文件常量
        /// </summary>
        public struct ConfigKey
        {
            /// <summary>
            /// 配置字典表中病历可选功能配置组【审签配置相关】
            /// </summary>
            public const string AUDIT_OPTION = "AUDIT_OPTION";
            /// <summary>
            /// 配置字典表中病历可选功能配置组【各种格式配置相关】
            /// </summary>
            public const string STYLE_OPTION = "STYLE_OPTION";
            /// <summary>
            /// 配置字典表中病历可选功能配置组【病历痕迹配置相关】
            /// </summary>
            public const string TRACE_OPTION = "TRACE_OPTION";
            /// <summary>
            /// 配置字典表中质控可选功能配置组【质控系统选项】
            /// </summary>
            public const string QCSYS_OPTION = "QCSYS_OPTION";
            /// <summary>
            /// 登录对话框缺省登录用户
            /// </summary>
            public const string DEFAULT_LOGIN_USERID = "LoginForm.DefaultUserID";

            /// <summary>
            /// 患者列表窗口缺省检索类型
            /// </summary>
            public const string DEFAULT_SEARCH_TYPE = "PatientList.SearchType";
            /// <summary>
            /// 患者列表窗口缺省科室代码
            /// </summary>
            public const string DEFAULT_DEPT_CODE = "PatientList.DeptCode";
            /// 患者列表窗口按科室检索入院时间段起始值
            /// </summary>
            public const string DEPT_DEFAULT_ADMISSION_BEGIN = "PatientList.AdmissionTimeBegin";
            /// <summary>
            /// 患者列表窗口按科室检索入院时间段截止值
            /// </summary>
            public const string DEPT_DEFAULT_ADMISSION_END = "PatientList.AdmissionTimeEnd";

            /// <summary>
            /// 患者列表窗口缺省病人ID
            /// </summary>
            public const string DEFAULT_PATIENT_ID = "PatientList.PatientID";

            /// <summary>
            /// 新格式病历窗口病历是否合并显示
            /// </summary>
            public const string DOC_COMBIN_DISPLAY = "MedDocumentForm.DisplayByCombin";

            /// <summary>
            /// 主程序是否显示工具条
            /// </summary>
            public const string SHOW_TOOL_STRIP = "MainForm.ShowToolStrip";

            /// <summary>
            /// 主程序是否显示状态条
            /// </summary>
            public const string SHOW_STATUS_STRIP = "MainForm.ShowStatusStrip";

            /// <summary>
            /// 文档窗口是否是以嵌入到主窗口的方式显示
            /// </summary>
            public const string DOCUMENT_FORM_EMBED = "MainForm.DocumentFormEmbed";

            /// <summary>
            /// 是否在同一个窗口中显示多个病人的病历记录
            /// </summary>
            public const string SHOW_MANY_PATIENT_DOCLIST = "MainForm.ShowPatsDocList";

            /// <summary>
            /// 是否限定患者列表检索方式，如果是配置的值是true则默认使用病人ID检索方式。
            /// </summary>
            public const string RESTRICTSEARCHTYPE = "RestrictSearchType.Enabled";
            /// <summary>
            /// 是否有允许通过adt_log表查询危重患者列表
            /// </summary>
            public const string SERIOUSPATLIST_BY_ADTLOG = "SeriousPatListByAdtLog.Enabled";
            /// <summary>
            /// 是否以只读状态打开病历
            /// </summary>
            public const string DOCUMENT_READONLY = "Document.ReadOnly";
            /// <summary>
            /// 是否允许用户删除或修改非本人添加的反馈信息
            /// </summary>
            public const string MODIFY_OR_DELETE_QUESTION = "ModifyOrDeleteQuestion.Enabled";
            /// <summary>
            /// 科室质控查看统计是否显示除本人以外的检查者姓名
            /// </summary>
            public const string STAT_SHOW_CHECKER_NAME = "StatShowCheckerName.Enabled";
            /// <summary>
            /// 配置版本更新FTP
            /// </summary>
            public const string UPGRADE_FTP = "UPGRADE_FTP";
            /// <summary>
            /// 当前版本号
            /// </summary>
            public const string CURRENT_VERSION = "Current.Version";
            /// <summary>
            /// 有消息变化时是否自动弹出消息框配置项
            /// </summary>
            public const string TASK_AUTO_POPOP_MESSAGE = "MedTask.TaskAutoPopupMessage";
            /// <summary>
            /// 任务提醒系统任务列表刷新时间间隔
            /// </summary>
            public const string TASK_REFRESH_INTERVAL = "MedTask.TaskRefreshInterval";
            /// <summary>
            /// 任务提醒系统任务列表刷新后是否闪动托盘图标
            /// </summary>
            public const string TASK_ICON_BLINK = "MedTask.TaskIconBlink";
            /// <summary>
            /// 任务提醒系统任务列表刷新后是否弹出消息提示
            /// </summary>
            public const string TASK_POPUP_TIP = "MedTask.ShowPopupTip";

            /// <summary>
            /// EMR数据库类型
            /// </summary>
            public const string EMR_DB_TYPE = "EmrDbType";
            /// <summary>
            /// EMR数据库驱动类型
            /// </summary>
            public const string EMR_PROVIDER = "EmrDbProvider";
            /// <summary>
            /// EMR数据库连接串
            /// </summary>
            public const string EMR_CONN_STRING = "EmrDbConnString";
            /// <summary>
            /// EMR数据库连接串加密key
            /// </summary>
            public const string CONFIG_ENCRYPT_KEY = "SUPCON.MEDDOC.ENCRYPT.KEY";
            /// <summary>
            /// 病历数据库类型
            /// </summary>
            public const string MDS_DB_TYPE = "MdsDbType";
            /// <summary>
            /// 病历数据库驱动类型
            /// </summary>
            public const string MDS_PROVIDER_TYPE = "MdsDbProvider";
            /// <summary>
            /// 病历数据库连接串
            /// </summary>
            public const string MDS_CONN_STRING = "MdsDbConnString";
            /// <summary>
            /// 宝典控件数据库连接串
            /// </summary>
            public const string OCX_CONNECTION_STRING = "MedEditorConnString";
            /// <summary>
            /// 配置字典表中文档存储模式配置
            /// </summary>
            public const string STORAGE_MODE = "STORAGE_MODE";
            /// <summary>
            /// 配置字典表中文档存储模式FTP
            /// </summary>
            public const string STORAGE_MODE_FTP = "FTP";
            /// <summary>
            /// 配置字典表中文档存储模式DB
            /// </summary>
            public const string STORAGE_MODE_DB = "DB";

            /// <summary>
            /// 配置字典表中FTP文档库访问参数配置组名称
            /// </summary>
            public const string DOC_FTP = "DOCFTP";
            /// <summary>
            /// 配置字典表中FTP文档库IP
            /// </summary>
            public const string FTP_IP = "IP";
            /// <summary>
            /// 配置字典表中FTP文档库端口
            /// </summary>
            public const string FTP_PORT = "PORT";
            /// <summary>
            /// 配置字典表中FTP文档库用户名
            /// </summary>
            public const string FTP_USER = "USER";
            /// <summary>
            /// 配置字典表中FTP文档库密码
            /// </summary>
            public const string FTP_PWD = "PWD";
            /// <summary>
            /// 配置版本更新ftp地址 FTP_DIR
            /// </summary>
            public const string FTP_DIR = "FTP_DIR";
            /// <summary>
            /// 配置字典表中FTP协议模式
            /// </summary>
            public const string FTP_MODE = "FTP_MODE";
            /// <summary>
            /// 配置字典表中SYSTEM_OPTION配置组名称
            /// </summary>
            public const string SYSTEM_OPTION = "SYSTEM_OPTION";
            /// <summary>
            /// 配置字典表中QC(质控科)能否保存文档
            /// </summary>
            public const string QC_SAVE_DOC_ENABLE = "QC_SAVE_DOC_ENABLE";
            /// <summary>
            /// 病历时效质控数据生成是否只记录异常情况
            /// </summary>
            public const string TIME_RECORD_ONLY_ABNORMAL = "TimeRecord.OnlyAbNormal";
            /// <summary>
            /// 病案范围从病人入科至出院天数
            /// </summary>
            public const string TIME_RECORD_DISCHARGE_DAYS = "TimeRecord.DischargeDays";
            /// <summary>
            /// 时效质控开始生成时间
            /// </summary>
            public const string TIME_RECORD_START_TIME = "TimeRecord.StartTime";
            /// <summary>
            /// 是否开启内容检查
            /// </summary>
            public const string CONTENT_RECORD_RUNNING = "ContentRecord.Running";
            /// <summary>
            /// 提醒系统登录对话框缺省登录用户
            /// </summary>
            public const string MEDTASK_DEFAULT_USERID = "MedTask.DefaultUserID";

            #region SystemOption
            /// <summary>
            /// 病历编辑器系统产品授权代码
            /// </summary>
            public const string SYSTEM_OPTION_CERT_CODE = "CERT_CODE";
            /// <summary>
            /// 外部程序调用结构化病历检索工具授权码
            /// </summary>
            public const string SYSTEM_OPTION_MEDSEARCH_CODE = "MEDSEARCH_CODE";
            /// <summary>
            /// 病历编辑器系统产品授权医院名称
            /// </summary>
            public const string SYSTEM_OPTION_HOSPITAL_NAME = "HOSPITAL_NAME";
            /// <summary>
            /// 编辑器系统缺省文本编辑器
            /// </summary>
            public const string SYSTEM_OPTION_DEFAULT_EDITOR = "DEFAULT_EDITOR";
            /// <summary>
            /// 配置医生文书上下两条诊断的时间差(单位:天)
            /// </summary>
            public const string SYSTEM_OPTION_DIAGNOSIS_TIME_INTERVAL = "DIAGNOSIS_TIME_INTERVAL";
            /// <summary>
            /// 配置字典表中病历可选功能配置组之基本输入框元素ID
            /// </summary>
            public const string SYSTEM_OPTION_BIND_REFRESH_ELEMENT = "BIND_REFRESH_ELEMENT";

            /// <summary>
            /// 编辑器系统病历记录等是否允许连续书写病历
            /// </summary>
            public const string SYSTEM_OPTION_WRITING_BY_SERIAL = "WRITING_BY_SERIAL";
            /// <summary>
            /// 病历数据访问服务URL地址
            /// </summary>
            public const string SYSTEM_OPTION_WEB_SERVICE_URL = "MD_SERVICE_URL";
            /// <summary>
            /// 病历的文档时间是否显示为病历内部的实际记录时间
            /// </summary>
            public const string SYSTEM_OPTION_SHOWAS_RECORD_TIME = "SHOWAS_RECORD_TIME";

            /// <summary>
            /// 病历合并列表是否仅显示归档病历配置组
            /// </summary>
            public const string SYSTEM_OPTION_COMBIN_NOT_ARICHVE_DOC = "COMBIN_NOT_ARICHVE_DOC";
            /// <summary>
            /// 合并文档列表是否从选中的文档开始续打
            /// </summary>
            public const string SYSTEM_OPTION_AUTO_NEXT_PRINT = "AUTO_NEXT_PRINT";

            /// <summary>
            /// 导入医嘱、检验等是否默认按自定义格式导入
            /// </summary>
            public const string SYSTEM_OPTION_IMPORT_DEFINE_STYLE = "IMPORT_DEFINE_STYLE";
            /// <summary>
            /// 病历中选择类型的元素:1-单击弹出元素选择器,0-双击弹出元素选择器
            /// </summary>
            public const string SYSTEM_OPTION_ELEMENT_SELECTOR_CLICK = "ELEMENT_SELECTOR_CLICK";

            /// <summary>
            /// 是否启用打开文档自动插入图片签名.0-关闭,1-启用
            /// </summary>
            public const string SYSTEM_OPTION_DOC_SIGN_PIC = "DOC_SIGN_PIC";

            /// <summary>
            /// 签名图片缩放
            /// </summary>
            public const string SYSTEM_OPTION_SIGN_IMAGE_ZOOM = "SIGN_IMAGE_ZOOM";


            /// <summary>
            /// 会诊病历类型,多个病历类型用半角逗号隔开，eg,123_1,456_1
            /// </summary>
            public const string SYSTEM_OPTION_CONSULTATION_TYPES = "CONSULTATION_TYPES";
            /// <summary>
            /// 质控科人员是否可以保持病历
            /// </summary>
            public const string SYSTEM_OPTION_QC_DOC_SAVE_ENABLE = "QC_DOC_SAVE_ENABLE";
            /// <summary>
            /// 是否启动将出院诊断插入K21表中
            /// </summary>
            public const string SYSTEM_OPTION_OUT_HOUSPITAL_DIAG_K21 = "OUT_HOUSPITAL_DIAG_K21";


            /// <summary>
            /// 初步诊断所在单元格宽度
            /// </summary>
            public const string SYSTEM_OPTION_FIRST_DIAGNOSIS_WIDTH = "FIRST_DIAGNOSIS_WIDTH";
            /// <summary>
            /// 最后诊断所在单元格宽度
            /// </summary>
            public const string SYSTEM_OPTION_LAST_DIAGNOSIS_WIDTH = "LAST_DIAGNOSIS_WIDTH";
            /// <summary>
            /// 病历正常书写判断标准
            /// </summary>
            public const string SYSTEM_OPTION_DOC_WRITE_RULE = "DOC_WRITE_RULE";
            /// <summary>
            /// 是否在打印或者预览前删除签名图片
            /// </summary>
            public const string SYSTEM_OPTION_DEL_SIGNPIC_BEFOREPRINT = "DEL_SIGNPIC_BEFOREPRINT";

            /// <summary>
            /// 是否存在历史病历服务器
            /// </summary>
            public const string SYSTEM_OPTION_HAS_HISFTP = "HAS_HISFTP";
            /// <summary>
            /// 是否异步保存病历及XML文档
            /// </summary>
            public const string SYSTEM_OPTION_IS_ASYNCH_SAVE_DOC = "IS_ASYNCH_SAVE_DOC";
            /// <summary>
            /// 保密科室列表
            /// </summary>
            public const string SYSTEM_OPTION_SECRET_DEPT_LIST = "SECRET_DEPT_LIST";
            /// <summary>
            /// 合并打开病历类型IDS
            /// </summary>
            public const String SYSTEM_OPTION_COMBIN_EDIT_DOCTYPEIDS = "COMBIN_EDIT_DOCTYPEIDS";
            /// <summary>
            /// 需要上级审核病历后才能打印的用户等级
            /// 多个用户等级用逗号分隔
            /// </summary>
            public const string SYSTEM_OPTION_PRINT_AUDIT_USER_GRADE = "PRINT_AUDIT_USER_GRADE";
            /// <summary>
            /// 用户验证WebService地址
            /// </summary>
            public const string SYSTEM_OPTION_USER_VALIDATION_SERVICE_URL = "USER_VALIDATION_SERVICE_URL";
            /// <summary>
            /// 还允许召回病人的最大天数
            /// 通常意义还要限制最多允许召回多少天之前出院的病人
            /// </summary>
            public const string SYSTEM_OPTION_RECALL_UP_TO_DAYS = "RECALL_UP_TO_DAYS";
            /// <summary>
            /// 入院|转科后可编辑遍历的时效（小时）
            /// </summary>
            public const string SYSTEM_OPTION_WRITE_DOC_HOURS = "WRITE_DOC_HOURS";
            /// <summary>
            /// 新建病历的时候是否将所有元素设置为不可删除（复杂元素除外）
            /// </summary>
            public const string SYSTEM_OPTION_ALLOW_DELETE_TEMPLET_ELEMENTS = "ALLOW_DELETE_TEMPLET_ELEMENTS";
            /// <summary>
            /// 是否允许不提交病历就直接修改确认诊断元素
            /// </summary>
            public const string SYSTEM_OPTION_ALLOW_UPDATE_LASTDIAGNOSIS_NOLIMIT = "ALLOW_UPDATE_LASTDIAGNOSIS__NOLIMIT";
            /// <summary>
            /// 是否允许提交病历后可继续修改初步诊断元素
            /// </summary>
            public const string SYSTEM_OPTION_ALLOW_UPDATE_FIRSTDIAGNOSIS_NOLIMIT = "ALLOW_UPDATE_FIRSTDIAGNOSIS__NOLIMIT";
            /// <summary>
            /// 是否允许手动输入诊断信息
            /// </summary>
            public const string SYSTEM_OPTION_ALLOW_INPUT_DIAGNOSIS = "ALLOW_INPUT_TDIAGNOSIS";
            /// <summary>
            /// 需要记录文档份数的文档类型ID
            /// </summary>
            public const string SYSTEM_OPTION_NEED_SUM_DOCTYPEIDS = "NEED_SUM_DOCTYPEIDS";
            /// <summary>
            /// 允许任何人编辑的文档类型ID集合
            /// </summary>
            public const string SYSTEM_OPTION_ALL_EDITABLE_DOC_TYPE_IDS = "ALL_EDITABLE_DOC_TYPE_IDS";
            /// <summary>
            /// 是否启用新质控监控病历相关事件
            /// </summary>
            public const string SYSTEM_OPTION_NEW_QC_ENABLE = "NEW_QC_ENABLE";
            /// <summary>
            /// 是否在更新病历时更新质检问题状态为已修改
            /// </summary>
            public const string SYSTEM_OPTION_IS_UPDATE_QCSTATUS = "IS_UPDATE_QCSTATUS";
            /// <summary>
            /// 病案评分甲乙分标准
            /// </summary>
            public const string SYSTEM_OPTION_GRADING_STANDARD = "GRADING_STANDARD";
            /// <summary>
            /// 诊断类型文书类型ID
            /// </summary>
            public const string SYSTEM_OPTION_DIAGNOSIS_DOC_TYPE_IDS = "DIAGNOSIS_DOC_TYPE_IDS";
            #endregion
            #region AUDIT_OPTION配置组【审签配置信息】
            /// <summary>
            /// 是否启用病历三级审签
            /// </summary>
            public const string AUDIT_OPTION_DOC_AUDIT_ENABLED = "DOC_AUDIT_ENABLED";
            /// <summary>
            /// 是否在保存第三级审签后CA认证
            /// </summary>
            public const string AUDIT_OPTION_CA_CHECK = "CA_CHECK";
            /// <summary>
            /// 开启三级审签后，是否允许上级医生无条件修改创建者的病历 0允许，1不允许
            /// </summary>
            public const string AUDIT_OPTION_DOC_AUDIT_EDIT_MODE = "DOC_AUDIT_EDIT_MODE";
            /// <summary>
            /// 是否修改已审核的模板后需要再次审核
            /// </summary>
            public const string AUDIT_OPTION_TEMPLET_CHECK_MODE = "TEMPLET_CHECK_MODE";
            /// <summary>
            /// 配置字典表中病历可选功能配置组之是否需要审核模板
            /// </summary>
            public const string AUDIT_OPTION_NEED_CHECK_TEMPLET = "NEED_CHECK_TEMPLET";
            /// <summary>
            /// 是否开启模板三级审核
            /// </summary>
            public const string AUDIT_OPTION_TEMPLET_THIRDLEVEL_AUDIT = "TEMPLET_THIRDLEVEL_AUDIT";
            /// <summary>
            /// 三级签名样式布局
            /// <para>6X1,表示有包含日期，且日期在名字下方</para>
            /// <para>3X1,表示不包含日期</para>
            /// <para>3X2,表示有包含日期，且日期在名字右方</para>
            /// </summary>
            public const string AUDIT_OPTION_SIGN_LAYOUT = "SIGN_LAYOUT";
            /// <summary>
            /// 配置为1时:
            /// 一级未签名,二级去签名时提示不允许签名
            ///一级二级未签名时,三级医生仅提示是否继续签名
            ///默认配置为0
            /// </summary>
            public const string AUDIT_OPTION_DOC_AUDIT_SIGN_WARM = "DOC_AUDIT_SIGN_WARM";
            #endregion
            #region STYLE_OPTION配置组【编辑器默认字体、行距信息】
            /// <summary>
            /// 配置字典表中病历可选功能配置组之缺省字体名
            /// </summary>
            public const string STYLE_OPTION_DEFAULT_FONT_NAME = "DEFAULT_FONT_NAME";
            /// <summary>
            /// 配置字典表中病历可选功能配置组之缺省字体大小
            /// </summary>
            public const string STYLE_OPTION_DEFAULT_FONT_SIZE = "DEFAULT_FONT_SIZE";
            /// <summary>
            /// 配置字典表中病历可选功能配置组之缺省行距
            /// </summary>
            public const string STYLE_OPTION_DEFAULT_LINE_SPACE = "DEFAULT_LINE_SPACE";
            /// <summary>
            /// 配置字典表中病历可选功能配置组之自动绑定的日期格式
            /// </summary>
            public const string STYLE_OPTION_BIND_DATE_FORMAT = "BIND_DATE_FORMAT";
            /// <summary>
            /// 配置字典表中病历可选功能配置组之自动绑定的带时间的日期格式
            /// </summary>
            public const string STYLE_OPTION_BIND_TIME_FORMAT = "BIND_TIME_FORMAT";
            /// <summary>
            /// 病历编辑器系统主窗口已有病历列表,文档时间显示格式
            /// </summary>
            public const string STYLE_OPTION_DOC_TIME_FORMAT = "DOC_TIME_FORMAT";
            #endregion
            #region TRACE_OPTION配置组【病历痕迹显示配置信息】
            /// <summary>
            /// 是否任何人每次修改病历一直保留修订痕迹
            /// </summary>
            public const string TRACE_OPTION_EDIT_TRACE_ALWAYS = "EDIT_TRACE_ALWAYS";
            /// <summary>
            /// 编辑器中修订文档时是否保留文档修订痕迹
            /// </summary>
            public const string TRACE_OPTION_EDIT_TRACE_ENABLED = "EDIT_TRACE_ENABLED";
            /// <summary>
            /// 编辑器系统界面上是否显示修订历史相关功能界面
            /// </summary>
            public const string TRACE_OPTION_DISPLAY_EDIT_HISTORY = "DISPLAY_EDIT_HISTORY";
            /// <summary>
            /// 当EDIT_TRACE_ENABLED配置为1时，0默认显示痕迹，1点击痕迹保留按钮显示痕迹
            /// </summary>
            public const string TRACE_OPTION_SHOW_TRACE_MODE = "SHOW_TRACE_MODE";
            #endregion
            #region PRINT_OPTION配置组【打印相关配置信息】
            /// <summary>
            /// 配置字典表中病历可选功能配置组【病历痕迹配置相关】
            /// </summary>
            public const string PRINT_OPTION = "PRINT_OPTION";
            /// <summary>
            /// 病历草稿状态下是否能够打印,1可以打印,0不能打印.默认1,草稿状态也能打印
            /// </summary>
            public const string PRINT_OPTION_PRINT_DRAFT_ENABLED = "PRINT_DRAFT_ENABLED";

            /// <summary>
            /// 在开启三级审签的时候是否允许未经过上级审签的病历打印,1允许,0不允许
            /// </summary>
            public const string PRINT_OPTIONN_PRINT_NEED_AUDIT = "PRINT_NEED_AUDIT";
            #endregion
            #region QCSYS_OPTION 【质控系统配置项】
            /// <summary>
            /// 质控检索病人，切换检索方式后是否立即查询，1默认立即查询，0点击查询才会检索数据
            /// </summary>
            public const string QCSYS_OPTION_IS_PATSEARCH_ASYN = "IS_PATSEARCH_ASYN";
            /// <summary>
            /// 是否启用消息系统
            /// </summary>
            public const string QCSYS_OPTION_IS_SHOW_QCHAT = "IS_SHOW_QCHAT";
            /// <summary>
            /// 质控登陆验证方式 1为老的用户密码 2为数据库账户/密码登录
            /// </summary>
            public const string QCSYS_OPTION_LOGIN_TYPE = "LOGIN_TYPE";
            /// <summary>
            /// 登陆验证数据库名
            /// </summary>
            public const string QCSYS_OPTION__LOGIN_DB_NAME = "LOGIN_DB_NAME";
            /// <summary>
            /// 病历扫描系统地址
            /// </summary>
            public const string QCSYS_OPTION_DOC_IE_URL = "DOC_IE_URL";
            #endregion
        }

        /// <summary>
        /// 文件扩展名常量
        /// </summary>
        public struct FileExt
        {
            /// <summary>
            /// 医疗文档扩展名"smdf"
            /// </summary>
            public const string MED_DOCUMENT = "smdf";
            /// <summary>
            /// 文档模板文件扩展名"smdt"
            /// </summary>
            public const string DOC_TEMPLET = "smdt";
            /// <summary>
            /// XDB病历文档扩展名"xml"
            /// </summary>
            public const string XML_DOCUMENT = "xml";
            /// <summary>
            /// HTML病历文档扩展名"html"
            /// </summary>
            public const string HTML_DOCUMENT = "html";
            /// <summary>
            /// PDF病历文档扩展名"pdf"
            /// </summary>
            public const string PDF_DOCUMENT = "pdf";
        }

        /// <summary>
        /// 文档类型数据表字段定义
        /// </summary>
        internal struct DocTypeTable
        {
            /// <summary>
            /// 文档类型代码
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            /// <summary>
            /// 文档类型名
            /// </summary>
            public const string DOCTYPE_NAME = "DOCTYPE_NAME";
            /// <summary>
            /// 文档类型对应的主文档类型
            /// </summary>
            public const string HOSTTYPE_ID = "HOSTTYPE_ID";
            /// <summary>
            /// 排序值
            /// </summary>
            public const string ORDER_VALUE = "ORDER_VALUE";
            /// <summary>
            /// 文档是否可重复
            /// </summary>
            public const string IS_REPEATED = "IS_REPEATED";
            /// <summary>
            /// DOC 表示医生 NUR 表示护士 CIS表示其它应用系统 ADM 管理人员等
            /// </summary>
            public const string DOC_RIGHT = "DOC_RIGHT";
            /// <summary>
            /// 应用环境(IP住院 OP门诊)
            /// </summary>
            public const string APPLY_ENV = "APPLY_ENV";
            /// <summary>
            /// 标识当前是否有效
            /// </summary>
            public const string IS_VALID = "IS_VALID";
            /// <summary>
            /// 标识当前是否能创建
            /// </summary>
            public const string CAN_CREATE = "CAN_CREATE";
            /// <summary>
            /// 是否独立纸张打印
            /// </summary>
            public const string IS_TOTAL_PAGE = "IS_TOTAL_PAGE";
            /// <summary>
            /// 标识当前病历类型创建的文档打印时末页是否允许接着打印其他病历
            /// </summary>
            public const string IS_END_EMPTY = "IS_END_EMPTY";
            /// <summary>
            /// 表示文档的签名方式
            /// </summary>
            public const string SIGN_FLAG = "SIGN_FLAG";
            /// <summary>
            /// 文档类型的修改时间
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";
            /// <summary>
            /// 是否允许保存结构化数据
            /// </summary>
            public const string IS_STRUCT = "IS_STRUCT";
            /// <summary>
            /// 文档模板数据
            /// </summary>
            public const string TEMPLET_DATA = "TEMPLET_DATA";
            /// <summary>
            /// 是否自动重新生成病历标题
            /// </summary>
            public const string AUTO_MAKE_TITLE = "AUTO_MAKE_TITLE";
            /// <summary>
            /// 是否需要自动合并显示
            /// </summary>
            public const string NEED_COMBIN = "NEED_COMBIN";
        }
        /// <summary>
        /// 系统配置字典表各字段定义
        /// </summary>
        internal struct ConfigDictTable
        {
            /// <summary>
            /// 配置组名称
            /// </summary>
            public const string GROUP_NAME = "GROUP_NAME";
            /// <summary>
            /// 配置项名称
            /// </summary>
            public const string CONFIG_NAME = "CONFIG_NAME";
            /// <summary>
            /// 配置项值
            /// </summary>
            public const string CONFIG_VALUE = "CONFIG_VALUE";
            /// <summary>
            /// 配置项描述
            /// </summary>
            public const string CONFIG_DESC = "CONFIG_DESC";
        }

        /// <summary>
        /// RDB数据视图
        /// </summary>
        internal struct DataView
        {
            /// <summary>
            /// 以往病历数据视图
            /// </summary>
            public const string PAST_DOC = "PAST_DOC_V";
            /// <summary>
            /// 医嘱数据视图
            /// </summary>
            public const string ORDERS = "ORDERS_V";
            /// <summary>
            /// ICD诊断数据视图
            /// </summary>
            public const string ICD_DIAGNOSIS = "ICD_DIAGNOSIS_V";
            /// <summary>
            /// 检查主索引数据视图
            /// </summary>
            public const string EXAM_MASTER = "EXAM_MASTER_V";
            /// <summary>
            /// 检查报告数据视图
            /// </summary>
            public const string EXAM_RESULT = "EXAM_RESULT_V";
            /// <summary>
            /// 检验主记录数据视图
            /// </summary>
            public const string LAB_MASTER = "LAB_MASTER_V";
            /// <summary>
            /// 检验结果数据视图
            /// </summary>
            public const string LAB_RESULT = "LAB_RESULT_V";
            /// <summary>
            /// 病案质量监控日志
            /// </summary>
            public const string QC_LOG_V = "QC_LOG_V";
            /// <summary>
            /// 病人就诊视图
            /// </summary>
            public const string PAT_VISIT_V = "PAT_VISIT_V";
            /// <summary>
            /// 病人反馈信息视图
            /// </summary>
            public const string QC_MSG_V = "QC_MSG_V";
            /// <summary>
            /// 反馈信息模板视图
            /// </summary>
            public const string MSG_TEMPLET_V = "MSG_TEMPLET_V";
            /// <summary>
            /// 反馈信息类别视图
            /// </summary>
            public const string MSG_TYPE_V = "MSG_TYPE_V";
            /// <summary>
            /// 病人诊断信息视图
            /// </summary>
            public const string DIAGNOSIS_V = "DIAGNOSIS_V";
            /// <summary>
            /// 在院病人信息视图
            /// </summary>
            public const string INP_VISIT_V = "INP_VISIT_V";
            /// <summary>
            /// 病人病案评分视图
            /// </summary>
            public const string QC_SCORE_V = "QC_SCORE_V";
            /// <summary>
            /// 科室视图
            /// </summary>
            public const string DEPT_V = "DEPT_V";
            /// <summary>
            /// 病人病情变化视图
            /// </summary>
            public const string ADT_LOG_V = "ADT_LOG_V";
            /// <summary>
            /// 病人手术视图
            /// </summary>
            public const string OPERATION_V = "OPERATION_V";
            /// <summary>
            /// 手术操作字典视图
            /// </summary>
            public const string OPERATION_DICT_V = "OPERATION_DICT_V";
            /// <summary>
            /// 用户视图
            /// </summary>
            public const string USER_V = "USER_V";
            /// <summary>
            /// 责任医生视图
            /// </summary>
            public const string PAT_DOCTOR_V = "PAT_DOCTOR_V";
            /// <summary>
            /// 费别字典视图
            /// </summary>
            public const string CHARGE_TYPE_DICT_V = "CHARGE_TYPE_DICT_V";
            /// <summary>
            /// 身份字典视图
            /// </summary>
            public const string IDENTITY_DICT_V = "IDENTITY_DICT_V";
            /// <summary>
            /// 医生管辖科室视图
            /// </summary>
            public const string DOC_ADMIN_DEPTS_V = "DOC_ADMIN_DEPTS_V";
            /// <summary>
            /// 病历审核申请表视图
            /// </summary>
            public const string DOC_RECORD_MODIFY_APPLY_V = "DOC_RECORD_MODIFY_APPLY_V";

        }

        /// <summary>
        /// 以往病历信息数据视图字段定义
        /// </summary>
        internal struct PastDocView
        {
            /// <summary>
            /// 文档的唯一标识
            /// </summary>
            public const string DOC_ID = "DOC_ID";
            /// <summary>
            /// 文档的类型
            /// </summary>
            public const string DOC_TYPE = "DOC_TYPE";
            /// <summary>
            /// 文档的显示标题
            /// </summary>
            public const string DOC_TITLE = "DOC_TITLE";

            /// <summary>
            /// 文档作者ID
            /// </summary>
            public const string CREATOR_ID = "CREATOR_ID";
            /// <summary>
            /// 文档作者姓名
            /// </summary>
            public const string CREATOR_NAME = "CREATOR_NAME";
            /// <summary>
            /// 文档生成的时间
            /// </summary>
            public const string CREATE_TIME = "DOC_TIME";
            /// <summary>
            /// 文档修改者ID
            /// </summary>
            public const string MODIFIER_ID = "MODIFIER_ID";
            /// <summary>
            /// 文档修改者姓名
            /// </summary>
            public const string MODIFIER_NAME = "MODIFIER_NAME";
            /// <summary>
            /// 文档修改时间
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";

            /// <summary>
            /// 文档所属的病人号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 文档所属病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";

            /// <summary>
            /// 就诊号
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊时间
            /// </summary>
            public const string VISIT_TIME = "VISIT_TIME";
            /// <summary>
            /// 就诊类型
            /// </summary>
            public const string VISIT_TYPE = "VISIT_TYPE";

            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";

            /// <summary>
            /// 文档次序编号
            /// </summary>
            public const string ORDER_VALUE = "ORDER_VALUE";
            /// <summary>
            /// 是否需要合并
            /// </summary>
            public const string NEED_COMBIN = "NEED_COMBIN";
            /// <summary>
            /// 病历文件类型
            /// </summary>
            public const string FILE_TYPE = "FILE_TYPE";
            /// <summary>
            /// 病历文件名
            /// </summary>
            public const string FILE_NAME = "FILE_NAME";
            /// <summary>
            /// 病历文件路径
            /// </summary>
            public const string FILE_PATH = "FILE_PATH";
            /// <summary>
            /// 病历文档数据
            /// </summary>
            public const string FILE_DATA = "FILE_DATA";
        }

        /// <summary>
        /// 医生医嘱表字段定义
        /// </summary>
        internal struct OrdersView
        {
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊号
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 医嘱序号
            /// </summary>
            public const string ORDER_NO = "ORDER_NO";
            /// <summary>
            /// 医嘱子序号
            /// </summary>
            public const string ORDER_SUB_NO = "ORDER_SUB_NO";
            /// <summary>
            /// 长期医嘱标志
            /// </summary>
            public const string REPEAT_INDICATOR = "REPEAT_INDICATOR";
            /// <summary>
            /// 医嘱类别
            /// </summary>
            public const string ORDER_CLASS = "ORDER_CLASS";
            /// <summary>
            /// 医嘱下达时间
            /// </summary>
            public const string ENTER_DATE_TIME = "ENTER_DATE_TIME";
            /// <summary>
            /// 医嘱内容
            /// </summary>
            public const string ORDER_TEXT = "ORDER_TEXT";
            /// <summary>
            /// 是否自带药
            /// </summary>
            public const string DRUG_BILLING_ATTR = "DRUG_BILLING_ATTR";
            /// <summary>
            /// 剂量
            /// </summary>
            public const string DOSAGE = "DOSAGE";
            /// <summary>
            /// 计量单位
            /// </summary>
            public const string DOSAGE_UNITS = "DOSAGE_UNITS";
            /// <summary>
            /// 途径
            /// </summary>
            public const string ADMINISTRATION = "ADMINISTRATION";
            /// <summary>
            /// 频次
            /// </summary>
            public const string FREQUENCY = "FREQUENCY";
            /// <summary>
            /// 医生说明
            /// </summary>
            public const string FREQ_DETAIL = "FREQ_DETAIL";
            /// <summary>
            /// 带药量
            /// </summary>
            public const string PACK_COUNT = "PACK_COUNT";
            /// <summary>
            /// 医嘱停止时间
            /// </summary>
            public const string END_DATE_TIME = "END_DATE_TIME";
            /// <summary>
            /// 医生
            /// </summary>
            public const string DOCTOR = "DOCTOR";
            /// <summary>
            /// 护士
            /// </summary>
            public const string NURSE = "NURSE";
            /// <summary>
            /// 新开停止医嘱标志
            /// </summary>
            public const string START_STOP_INDICATOR = "START_STOP_INDICATOR";
            /// <summary>
            /// 医嘱状态
            /// </summary>
            public const string ORDER_STATUS = "ORDER_STATUS";
            /// <summary>
            /// 医嘱标识
            /// </summary>
            public const string ORDER_FLAG = "ORDER_FLAG";
        }
        /// <summary>
        /// 检验主记录表字段定义
        /// </summary>
        internal struct LabMasterView
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 申请序号
            /// </summary>
            public const string TEST_ID = "TEST_ID";
            /// <summary>
            /// 检验主题
            /// </summary>
            public const string SUBJECT = "SUBJECT";
            /// <summary>
            /// 检验标本
            /// </summary>
            public const string SPECIMEN = "SPECIMEN";
            /// <summary>
            /// 申请时间
            /// </summary>
            public const string REQUEST_TIME = "REQUEST_TIME";
            /// <summary>
            /// 申请医生
            /// </summary>
            public const string REQUEST_DOCTOR = "REQUEST_DOCTOR";
            /// <summary>
            /// 报告状态
            /// </summary>
            public const string RESULT_STATUS = "RESULT_STATUS";
            /// <summary>
            /// 报告时间
            /// </summary>
            public const string REPORT_TIME = "REPORT_TIME";
            /// <summary>
            /// 报告医生
            /// </summary>
            public const string REPORT_DOCTOR = "REPORT_DOCTOR";
        }

        /// <summary>
        /// 检验结果表字段定义
        /// </summary>
        internal struct LabResultView
        {
            /// <summary>
            /// 申请序号
            /// </summary>
            public const string TEST_ID = "TEST_ID";
            /// <summary>
            /// 检验报告项目名称
            /// </summary>
            public const string ITEM_NO = "ITEM_NO";
            /// <summary>
            /// 检验报告项目名称
            /// </summary>
            public const string ITEM_NAME = "ITEM_NAME";
            /// <summary>
            /// 检验结果值
            /// </summary>
            public const string ITEM_RESULT = "ITEM_RESULT";
            /// <summary>
            /// 检验结果单位
            /// </summary>
            public const string ITEM_UNITS = "ITEM_UNITS";
            /// <summary>
            /// 检验结果参考值
            /// </summary>
            public const string ITEM_REFER = "ITEM_REFER";
            /// <summary>
            /// 结果正常标志
            /// </summary>
            public const string ABNORMAL_INDICATOR = "ABNORMAL_INDICATOR";
        }
        /// <summary>
        /// 检查主表字段定义
        /// </summary>
        internal struct ExamMasterView
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 申请序号
            /// </summary>
            public const string EXAM_ID = "EXAM_ID";
            /// <summary>
            /// 检查类别
            /// </summary>
            public const string SUBJECT = "SUBJECT";
            /// <summary>
            /// 申请日期
            /// </summary>
            public const string REQUEST_TIME = "REQUEST_TIME";
            /// <summary>
            /// 申请医生
            /// </summary>
            public const string REQUEST_DOCTOR = "REQUEST_DOCTOR";
            /// <summary>
            /// 报告状态
            /// </summary>
            public const string RESULT_STATUS = "RESULT_STATUS";
            /// <summary>
            /// 报告日期
            /// </summary>
            public const string REPORT_TIME = "REPORT_TIME";
            /// <summary>
            /// 报告人
            /// </summary>
            public const string REPORT_DOCTOR = "REPORT_DOCTOR";
        }

        /// <summary>
        /// 检查报告表字段定义
        /// </summary>
        internal struct ExamResultView
        {
            /// <summary>
            /// 申请序号
            /// </summary>
            public const string EXAM_ID = "EXAM_ID";
            /// <summary>
            /// 检查参数
            /// </summary>
            public const string PARAMETERS = "PARAMETERS";
            /// <summary>
            /// 检查所见
            /// </summary>
            public const string DESCRIPTION = "DESCRIPTION";
            /// <summary>
            /// 检查印象
            /// </summary>
            public const string IMPRESSION = "IMPRESSION";
            /// <summary>
            /// 检查建议
            /// </summary>
            public const string RECOMMENDATION = "RECOMMENDATION";
            /// <summary>
            /// 是否阳性
            /// </summary>
            public const string IS_ABNORMAL = "IS_ABNORMAL";
            /// <summary>
            /// 使用仪器
            /// </summary>
            public const string DEVICE = "DEVICE";
            /// <summary>
            /// 报告中图象编号
            /// </summary>
            public const string USE_IMAGE = "USE_IMAGE";
        }

        /// <summary>
        /// 时效性质控记录表
        /// </summary>
        public struct QcTimeRecordTable
        {
            /// <summary>
            /// 病人ID号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 住院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 诊疗事件ID号
            /// </summary>
            public const string EVENT_ID = "EVENT_ID";
            /// <summary>
            /// 诊疗事件名称
            /// </summary>
            public const string EVENT_NAME = "EVENT_NAME";
            /// <summary>
            /// 诊疗事件时间
            /// </summary>
            public const string EVENT_TIME = "EVENT_TIME";
            /// <summary>
            /// 文书类型ID号
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            /// <summary>
            /// 文书类型名
            /// </summary>
            public const string DOCTYPE_NAME = "DOCTYPE_NAME";
            /// <summary>
            /// 正常书写开始时间
            /// </summary>
            public const string BEGIN_DATE = "BEGIN_DATE";
            /// <summary>
            /// 正常书写截止时间
            /// </summary>
            public const string END_DATE = "END_DATE";
            /// <summary>
            /// 扣分
            /// </summary>
            public const string POINT = "POINT";
            /// <summary>
            /// 检查者姓名
            /// </summary>
            public const string CHECKER_NAME = "CHECKER_NAME";
            /// <summary>
            /// 检查时间
            /// </summary>
            public const string CHECK_DATE = "CHECK_DATE";
            /// <summary>
            /// 文档ID号
            /// </summary>
            public const string DOC_ID = "DOC_ID";
            /// <summary>
            /// 文档标题
            /// </summary>
            public const string DOC_TITLE = "DOC_TITLE";
            /// <summary>
            /// 份数
            /// </summary>
            public const string REC_NO = "REC_NO";
            /// <summary>
            /// 病历记录时间
            /// </summary>
            public const string RECORD_TIME = "RECORD_TIME";
            /// <summary>
            /// 病历创建时间
            /// </summary>
            public const string DOC_TIME = "DOC_TIME";
            /// <summary>
            /// <summary>
            /// 时效质控结果
            /// </summary>
            public const string QC_RESULT = "QC_RESULT";
            /// <summary>
            /// 病历书写者ID
            /// </summary>
            public const string CREATE_ID = "CREATE_ID";
            /// <summary>
            /// 病历书写者姓名
            /// </summary>
            public const string CREATE_NAME = "CREATE_NAME";
            /// <summary>
            /// 质控依据说明
            /// </summary>
            public const string QC_EXPLAIN = "QC_EXPLAIN";
            /// <summary>
            /// 书写此病历的责任医生(经治)_统计
            /// </summary>
            public const string DOCTOR_IN_CHARGE = "DOCTOR_IN_CHARGE";
            /// <summary>
            /// 书写此病历的责任科室_统计
            /// </summary>
            public const string DEPT_IN_CHARGE = "DEPT_IN_CHARGE";
            /// <summary>
            /// 当前病人所在科室_综合查询
            /// </summary>
            public const string DEPT_STAYED = "DEPT_STAYED";
            /// <summary>
            /// 出院时间
            /// </summary>
            public const string DISCHARGE_TIME = "DISCHARGE_TIME";
            /// <summary>
            /// 是否短信已通知 0：未通知 1：已通知
            /// </summary>
            public const string MESSAGE_NOTIFY = "MESSAGE_NOTIFY";
            /// <summary>
            /// 是否是单项否决  1 是 0 否
            /// </summary>
            public const string IS_VETO = "IS_VETO";

        }
        /// <summary>
        /// RDB数据表
        /// </summary>
        internal struct DataTable
        {
            /// <summary>
            /// 时效规则表
            /// </summary>
            public const string TIME_RULE = "TIME_RULE_T";
            /// <summary>
            /// 时效事件表
            /// </summary>
            public const string TIME_EVENT = "TIME_EVENT_T";
            /// <summary>
            /// 文档类型表
            /// </summary>
            public const string DOC_TYPE = "DOC_TYPE_DICT";
            /// <summary>
            /// 用户权限控制表
            /// </summary>
            public const string USER_RIGHT = "USER_RIGHT_T";
            /// <summary>
            /// 质控问题沟通信息记录表
            /// </summary>
            public const string QC_MSG_CHAT_LOG = "QC_MSG_CHAT_LOG_T";
            /// <summary>
            /// 时效性质控记录表
            /// </summary>
            public const string QC_TIME_RECORD = "QC_TIME_RECORD_T";
            /// <summary>
            /// 统计到个人的时效性质控记录表
            /// </summary>
            public const string QC_TIMERECORD_STATBYPATIENT = "QC_TIMERECORD_STATBYPATIENT_T";
            /// <summary>
            /// 统计到科室的时效性质控记录表
            /// </summary>
            public const string QC_TIMERECORD_STATBYDEPT = "QC_TIMERECORD_STATBYDEPT_T";
            /// <summary>
            /// 专家质控病案分配详情表
            /// </summary>
            public const string QC_SPECIAL_DETAIL = "QC_SPECIAL_DETAIL_T";
            /// <summary>
            /// 专家质控表
            /// </summary>
            public const string QC_SPECIAL_CHECK = "QC_SPECIAL_CHECK_T";
            /// <summary>
            /// 质控自动扣分规则配置表
            /// </summary>
            public const string QC_SCORE_CHECK = "QC_SCORE_CHECK_T";
            /// <summary>
            /// 病历时效扣分信息
            /// </summary>
            public const string QC_TIME_CHECK = "QC_TIME_CHECK";
            /// <summary>
            /// 病历文档状态信息
            /// </summary>
            public const string DOC_STATUS_T = "DOC_STATUS_T";
            /// <summary>
            /// 病历文档信息
            /// </summary>
            public const string EMR_DOC_T = "EMR_DOC_T";
            /// <summary>
            /// 文档索引信息表
            /// </summary>
            public const string EMR_DOC = "EMR_DOC_T";
            /// <summary>
            /// 文档状态表
            /// </summary>
            public const string DOC_STATUS = "DOC_STATUS_T";
            /// <summary>
            /// 系统配置字典表
            /// </summary>
            public const string CONFIG_DICT = "CONFIG_DICT";
            /// <summary>
            /// 时效记录表
            /// </summary>
            public const string QC_TIME_RECORD_T = "QC_TIME_RECORD_T";

            #region 护理文书表
            /// <summary>
            /// 表格视图列方案表
            /// </summary>
            public const string GRID_VIEW_SCHEMA = "GRID_VIEW_SCHEMA";
            /// <summary>
            /// 系统配置字典表
            /// </summary>
            public const string NURSING_SYSTEM_CONFIG = "SYSTEM_CONFIG";
            /// <summary>
            /// 表格视图列定义表
            /// </summary>
            public const string GRID_VIEW_COLUMN = "GRID_VIEW_COLUMN";
            /// <summary>
            /// 护理记录表格模板列值信息数据表
            /// </summary>
            public const string NUR_REC = "NUR_REC_INDEX";
            /// <summary>
            /// 文档摘要数据
            /// </summary>
            public const string DOC_SUMMARY_DATA = "DOC_SUMMARY_DATA";
            /// <summary>
            /// 文档类型表
            /// </summary>
            public const string NUR_DOC_TYPE = "NUR_DOC_TYPE";
            /// <summary>
            /// 病人在科记录视图
            /// </summary>
            public const string TRANSFER = "TRANSFER_V";
            /// <summary>
            /// 床位记录视图
            /// </summary>
            public const string BED_RECORD = "BED_RECORD_V";


            #endregion

        }
        /// <summary>
        /// 用户权限控制表
        /// </summary>
        public struct UserRightTable
        {
            /// <summary>
            /// 用户代码
            /// </summary>
            public const string USER_ID = "USER_ID";
            /// <summary>
            /// 用户密码
            /// </summary>
            public const string USER_PWD = "USER_PWD";
            /// <summary>
            /// 权限二进制位编码字符串
            /// </summary>
            public const string RIGHT_CODE = "RIGHT_CODE";
            /// <summary>
            /// 权限类型
            /// </summary>
            public const string RIGHT_TYPE = "RIGHT_TYPE";
            /// <summary>
            /// 权限描述
            /// </summary>
            public const string RIGHT_DESC = "RIGHT_DESC";
        }
        /// <summary>
        /// 质控问题沟通信息记录表
        /// </summary>
        public struct QCMsgChatTable
        {
            /// <summary>
            /// 消息编号
            /// </summary>
            public const string CHAT_ID = "CHAT_ID";
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 沟通内容
            /// </summary>
            public const string CHAT_CONTENT = "CONTENT";
            /// <summary>
            /// 消息图片
            /// </summary>
            public const string CHAT_IMAGE = "IMAGE";
            /// <summary>
            /// 沟通消息发出时间
            /// </summary>
            public const string CHAT_SEND_DATE = "SEND_DATE";
            /// <summary>
            /// 沟通消息发出人
            /// </summary>
            public const string SENDER = "SENDER";
            /// <summary>
            /// 消息接收者
            /// </summary>
            public const string LISTENER = "LISTENER";
            /// <summary>
            /// 是否已读
            /// </summary>
            public const string IS_READ = "IS_READ";
            /// <summary>
            /// 聊天消息数据类型 
            /// </summary>
            public const string MSG_CHAT_DATA_TYPE = "DATA_TYPE";


        }

        /// <summary>
        /// 病历审核申请表视图结构
        /// </summary>
        public struct DocRecordModifyApplyView
        {
            /// <summary>
            /// 病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 住院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 入院时间
            /// </summary>
            public const string VISIT_TIME = "VISIT_TIME";
            public const string DOC_ID = "DOC_ID";
            public const string DOC_TITLE = "DOC_TITLE";
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 修改理由
            /// </summary>
            public const string MODIFY_REASON = "MODIFY_REASON";
            /// <summary>
            /// 修改/更换前内容
            /// </summary>
            public const string BEFORE_CONTENT = "BEFORE_CONTENT";
            /// <summary>
            /// 修改/更换后内容
            /// </summary>
            public const string AFTER_CONTENT = "AFTER_CONTENT";
            /// <summary>
            /// 申请者ID
            /// </summary>
            public const string APPLICANT_ID = "APPLICANT_ID";
            /// <summary>
            /// 申请时间
            /// </summary>
            public const string APPLY_DATE = "APPLY_DATE";
            /// <summary>
            /// 科主任/护士长签字
            /// </summary>
            public const string HEADER_ID = "HEADER_ID";
            /// <summary>
            /// 科主任/护士长签字时间
            /// </summary>
            public const string HEADER_TIME = "HEADER_TIME";
            /// <summary>
            /// 科主任备注
            /// </summary>
            public const string HEADER_REMARK = "HEADER_REMARK";
            /// <summary>
            /// 审核状态【保存、已申请、撤销、退回、主任审核、质控科审核、完成】
            ///                            --BC、YSQ、CX、TH、ZSH、QCSH、WC
            /// </summary>
            public const string AUDIT_STATUS = "AUDIT_STATUS";
            /// <summary>
            /// 申请科室 
            /// </summary>
            public const string APPLY_DEPT_CODE = "APPLY_DEPT_CODE";
            /// <summary>
            /// 质控科签字ID
            /// </summary>
            public const string QC_ID = "QC_ID";
            /// <summary>
            /// 质控科时间
            /// </summary>
            public const string QC_TIME = "QC_TIME";
            /// <summary>
            /// 质控科备注
            /// </summary>
            public const string QC_REMARK = "QC_REMARK";
        }

        /// <summary>
        /// 专家质控病案分配详情表结构
        /// </summary>
        public struct QcSpecialDetailTable
        {
            /// <summary>
            /// 抽检批次号
            /// </summary>
            public const string CONFIG_ID = "CONFIG_ID";
            /// <summary>
            /// 专家账号
            /// </summary>
            public const string SPECIAL_ID = "SPECIAL_ID";
            /// <summary>
            /// 专家姓名
            /// </summary>
            public const string SPECIAL_NAME = "SPECIAL_NAME";
            /// <summary>
            /// 病人ID号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊号
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
        }

        /// <summary>
        /// 文档状态数据表字段定义
        /// </summary>
        internal struct DocStatusTable
        {
            /// <summary>
            /// 文档唯一标识
            /// </summary>
            public const string DOC_ID = "DOC_ID";
            /// <summary>
            /// 文档的状态(编辑中，已作废，可编辑，已归档)
            /// </summary>
            public const string DOC_STATUS = "DOC_STATUS";
            /// <summary>
            /// 操作者ID
            /// </summary>
            public const string OPERATOR_ID = "OPERATOR_ID";
            /// <summary>
            /// 操作者姓名
            /// </summary>
            public const string OPERATOR_NAME = "OPERATOR_NAME";
            /// <summary>
            /// 操作时间
            /// </summary>
            public const string OPERATE_TIME = "OPERATE_TIME";
            /// <summary>
            /// 状态描述
            /// </summary>
            public const string STATUS_DESC = "STATUS_DESC";
        }
        #region"TimeEventTable"
        /// <summary>
        /// 病历时效规则配置信息表
        /// </summary>
        internal struct TimeRuleTable
        {
            /// <summary>
            /// 配置ID字段
            /// </summary>
            public const string RULE_ID = "RULE_ID";
            /// <summary>
            /// 关联事件ID字段
            /// </summary>
            public const string EVENT_ID = "EVENT_ID";
            /// <summary>
            /// 应完成文档类型ID号列表字段
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            /// <summary>
            /// 应完成文档类型名称列表字段
            /// </summary>
            public const string DOCTYPE_NAME = "DOCTYPE_NAME";
            /// <summary>
            /// 应完成文档类型名称别名字段
            /// </summary>
            public const string DOCTYPE_ALIAS = "DOCTYPE_ALIAS";
            /// <summary>
            /// 最晚完成期限字段
            /// </summary>
            public const string WRITTEN_PERIOD = "WRITTEN_PERIOD";
            /// <summary>
            /// 是否循环检查时效字段
            /// </summary>
            public const string IS_REPEAT = "IS_REPEAT";
            /// <summary>
            /// 是否启用此时效名称
            /// </summary>
            public const string IS_VALID = "IS_VALID";
            /// <summary>
            /// 时效规则对应的质控扣分
            /// </summary>
            public const string QC_SCORE = "QC_SCORE";
            /// <summary>
            /// 时效定义名称描述字符串字段
            /// </summary>
            public const string RULE_DESC = "RULE_DESC";
            /// <summary>
            /// 时效规则在规则列表中的排序
            /// </summary>
            public const string ORDER_VALUE = "ORDER_VALUE";
        }
        #endregion
        /// <summary>
        /// 病人病情
        /// </summary>
        public struct ArrPatientCondition
        {
            /// <summary>
            /// 危
            /// </summary>
            public const string WEI = "1";
            /// <summary>
            /// 急
            /// </summary>
            public const string JI = "2";
            /// <summary>
            /// 一般
            /// </summary>
            public const string Normal = "3";

            public const string CnWEI = "危";
            public const string CnJI = "急";
            public const string CnNormal = "一般";

            public static string GetPatientConditionName(string code)
            {
                string result = code;
                switch (code)
                {
                    case ArrPatientCondition.WEI:
                        result = ArrPatientCondition.CnWEI;
                        break;
                    case ArrPatientCondition.JI:
                        result = ArrPatientCondition.CnJI;
                        break;
                    case ArrPatientCondition.Normal:
                        result = ArrPatientCondition.CnNormal;
                        break;
                    default:
                        break;
                }
                return result;
            }
            public static string GetPatientConditionCode(string Name)
            {
                string result = Name;
                switch (Name)
                {
                    case ArrPatientCondition.CnWEI:
                        result = ArrPatientCondition.WEI;
                        break;
                    case ArrPatientCondition.CnJI:
                        result = ArrPatientCondition.JI;
                        break;
                    case ArrPatientCondition.CnNormal:
                        result = ArrPatientCondition.Normal;
                        break;
                    default:
                        break;
                }
                return result;
            }
            public static string[] GetConfigTypes()
            {
                return new string[] { ArrPatientCondition.CnWEI, ArrPatientCondition.CnJI, ArrPatientCondition.CnNormal };
            }
        }
        /// <summary>
        /// 文档状态数据
        /// </summary>
        public struct DocStatus
        {
            /// <summary>
            /// 正常可编辑状态0
            /// </summary>
            public const string NORMAL = "0";
            /// <summary>
            /// 已锁定.正在被别人编辑1
            /// </summary>
            public const string LOCKED = "1";
            /// <summary>
            /// 已作废2
            /// </summary>
            public const string CANCELED = "2";
            /// <summary>
            /// 已归档3
            /// </summary>
            public const string ARCHIVED = "3";

            /// <summary>
            /// "警告：\r\n"
            /// "您可能正在其他机器上修改该病历,修改开始于{0},未正常关闭!\r\n"
            /// "在不同机器上同时修改同一份病历,可能会造成文档覆盖,所以还请您保存前先确认!"
            /// </summary>
            public const string LOCKED_STATUS_DESC1 = "警告：\r\n"
                + "您可能正在其他机器上修改该病历,修改开始于{0},未正常关闭!\r\n"
                + "在不同机器上同时修改同一份病历,可能会造成文档覆盖,所以还请您保存前先确认!";
            /// <summary>
            /// 文档已锁定状态描述
            /// “当前病历正在被{0}修订,修订开始于{1}”
            /// </summary>
            public const string LOCKED_STATUS_DESC2 = "当前病历正在被{0}修订,修订开始于{1}!";
            /// <summary>
            /// "警告：\r\n"
            /// "当前病历被{0}编辑超过24小时,目前已被系统自动解锁允许您编辑,\r\n"
            /// "如果您保存当前病历,那么会使对方无法保存,所以您保存前最好先和对方确认下!"
            /// </summary>
            public const string LOCKED_STATUS_DESC3 = "警告：\r\n"
                + "当前病历被{0}编辑已超过了24小时,目前已被系统自动解锁允许您编辑,\r\n"
                + "如果您保存当前病历,就会使对方无法保存,所以在您保存前最好先和对方确认一下!";
            /// <summary>
            /// 文档已作废状态描述
            /// “当前病历已经被{0}于{1}更新或删除”
            /// </summary>
            public const string CANCELED_STATUS_DESC = "当前病历已经被{0}于{1}更新或删除!";
            /// <summary>
            /// 文档已归档状态描述
            /// “当前病历已经被{0}于{1}归档”
            /// </summary>
            public const string ARCHIVED_STATUS_DESC = "当前病历已经被{0}于{1}归档!";
        }
        #region"TimeEventTable"
        /// <summary>
        /// 病历时效事件源配置信息表
        /// </summary>
        internal struct TimeEventTable
        {
            /// <summary>
            /// 事件编号字段
            /// </summary>
            public const string EVENT_ID = "EVENT_ID";
            /// <summary>
            /// 事件名称字段
            /// </summary>
            public const string EVENT_NAME = "EVENT_NAME";
            /// <summary>
            /// 配置的事件源SQL语句名称
            /// </summary>
            public const string SQL_TEXT = "SQL_TEXT";
            /// <summary>
            /// SQL字符串中的条件字段
            /// </summary>
            public const string SQL_CONDITON = "SQL_CONDITON";
            /// <summary>
            /// 依赖事件编号字段
            /// </summary>
            public const string DEPEND_EVENT = "DEPEND_EVENT";
        }
        #endregion
        /// <summary>
        /// 文档索引信息数据表字段定义
        /// </summary>
        internal struct MedDocTable
        {
            /// <summary>
            /// 所用的模版ID号
            /// </summary>
            public const string TEMPLET_ID = "TEMPLET_ID";
            /// <summary>
            /// 上级医生签名时间
            /// </summary>
            public const string PARENT_SIGN_DATE = "PARENT_SIGN_DATE";
            /// <summary>
            /// 经治医生签名时间
            /// </summary>
            public const string REQUEST_SIGN_DATE = "REQUEST_SIGN_DATE";
            /// <summary>
            /// 主任医生签名时间
            /// </summary>
            public const string SUPER_SIGN_DATE = "SUPER_SIGN_DATE";
            /// <summary>
            /// 文档的唯一标识
            /// </summary>
            public const string DOC_ID = "DOC_ID";
            /// <summary>
            /// 文档的类型
            /// </summary>
            public const string DOC_TYPE_ID = "DOC_TYPE";
            /// <summary>
            /// 文档的显示标题
            /// </summary>
            public const string DOC_TITLE = "DOC_TITLE";
            /// <summary>
            /// 文档生成的时间
            /// </summary>
            public const string DOC_TIME = "DOC_TIME";
            /// <summary>
            /// 文档集编号
            /// </summary>
            public const string DOC_SETID = "DOC_SETID";
            /// <summary>
            /// 文档版本
            /// </summary>
            public const string DOC_VERSION = "DOC_VERSION";
            /// <summary>
            /// 文档法定作者的标号
            /// </summary>
            public const string CREATOR_ID = "CREATOR_ID";
            /// <summary>
            /// 文档法定作者姓名
            /// </summary>
            public const string CREATOR_NAME = "CREATOR_NAME";
            /// <summary>
            /// 文档修改者的标号
            /// </summary>
            public const string MODIFIER_ID = "MODIFIER_ID";
            /// <summary>
            /// 文档修改者的标号
            /// </summary>
            public const string MODIFIER_NAME = "MODIFIER_NAME";
            /// <summary>
            /// 文档修改时间
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";
            /// <summary>
            /// 文档所属的病人号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 文档所属病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 就诊号
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊时间
            /// </summary>
            public const string VISIT_TIME = "VISIT_TIME";
            /// <summary>
            /// 就诊类型
            /// </summary>
            public const string VISIT_TYPE = "VISIT_TYPE";
            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 签名代码
            /// </summary>
            public const string SIGN_CODE = "SIGN_CODE";
            /// <summary>
            /// 隐私等级代码
            /// </summary>
            public const string CONFID_CODE = "CONFID_CODE";
            /// <summary>
            /// 文档次序编号
            /// </summary>
            public const string ORDER_VALUE = "ORDER_VALUE";
            /// <summary>
            /// 病历医生记录的时间
            /// </summary>
            public const string RECORD_TIME = "RECORD_TIME";
            /// <summary>
            /// 文档数据
            /// </summary>
            public const string DOC_DATA = "DOC_DATA";
            /// <summary>
            /// 编辑器内部控件类型
            /// </summary>
            public const string EMR_TYPE = "EMR_TYPE";
            /// <summary>
            /// 打印审核编码
            /// </summary>
            public const string PRINT_AUDIT = "PRINT_AUDIT";
            /// <summary>
            /// 打印审核者ID
            /// </summary>
            public const string PRINT_AUDIT_ID = "PRINT_AUDIT_ID";
            /// <summary>
            /// 打印审核者姓名
            /// </summary>
            public const string PRINT_AUDIT_NAME = "PRINT_AUDIT_NAME";
            /// <summary>
            /// 打印审核者等级
            /// </summary>
            public const string PRINT_AUDITOR_GRADE = "PRINT_AUDIT";
            /// <summary>
            /// 打印审核者ID
            /// </summary>
            public const string PRINT_AUDITOR_ID = "PRINT_AUDIT_ID";
            /// <summary>
            /// 打印审核者姓名
            /// </summary>
            public const string PRINT_AUDITOR_NAME = "PRINT_AUDIT_NAME";
        }

        /// <summary>
        /// 质控自动扣分规则配置表结构
        /// </summary>
        public struct QcScoreCheckTable
        {
            /// <summary>
            /// 自动扣分规则ID号
            /// </summary>
            public const string CONFIG_ID = "CONFIG_ID";
            /// <summary>
            /// 病历类型ID号
            /// </summary>
            public const string DOC_TYPE_ID = "DOC_TYPE_ID";
            /// <summary>
            /// 病历类型名
            /// </summary>
            public const string DOC_TYPE_NAME = "DOC_TYPE_NAME";
            /// <summary>
            /// 病历内元素名
            /// </summary>
            public const string ELEMENT = "ELEMENT";
            /// <summary>
            /// 关联逻辑性规则
            /// </summary>
            public const string QC_RULE = "QC_RULE";
            /// <summary>
            /// 关联逻辑性规则ID号
            /// </summary>
            public const string QC_RULE_ID = "QC_RULE_ID";
            /// <summary>
            /// 扣分依据
            /// </summary>
            public const string CONFIG_DESC = "CONFIG_DESC";
            /// <summary>
            /// 扣分值
            /// </summary>
            public const string POINT = "POINT";
            /// <summary>
            /// 内容自动扣分类型 0 ：内容逻辑性错误 1：元素内容为空
            /// </summary>
            public const string CONFIG_TYPE = "CONFIG_TYPE";
            /// <summary>
            /// 排序值
            /// </summary>
            public const string ORDER_VALUE = "ORDER_VALUE";
            /// <summary>
            /// 是否有效
            /// </summary>
            public const string IS_VALID = "IS_VALID";
        }

        /// <summary>
        /// 科室字段表字段定义
        /// </summary>
        internal struct DeptView
        {
            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 是临床科室
            /// </summary>
            public const string IS_CLINIC = "IS_CLINIC";
            /// <summary>
            /// 是门诊科室
            /// </summary>
            public const string IS_OUTP = "IS_OUTP";
            /// <summary>
            /// 是病区
            /// </summary>
            public const string IS_WARD = "IS_WARD";
            /// <summary>
            /// 是护理单元
            /// </summary>
            public const string IS_NURSE = "IS_NURSE";
            /// <summary>
            /// 输入码
            /// </summary>
            public const string INPUT_CODE = "INPUT_CODE";
        }
        
        /// <summary>
        /// 用户数据视图字段定义
        /// </summary>
        internal struct UserView
        {
            /// <summary>
            /// 用户Id
            /// </summary>
            public const string USER_ID = "USER_ID";
            /// <summary>
            /// 用户姓名
            /// </summary>
            public const string USER_NAME = "USER_NAME";
            /// <summary>
            /// 科室编码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 用户密码
            /// </summary>
            public const string USER_PWD = "USER_PWD";
            /// <summary>
            /// 用户等级
            /// </summary>
            public const string USER_GRADE = "USER_GRADE";
        }
        /// <summary>
        /// 费别字典视图字段定义
        /// </summary>
        internal struct ChargeTypeDicView
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string SERIAL_NO = "SERIAL_NO";
            /// <summary>
            /// 费别代码
            /// </summary>
            public const string CHARGE_TYPE_CODE = "CHARGE_TYPE_CODE";
            /// <summary>
            /// 费别名称
            /// </summary>
            public const string CHARGE_TYPE_NAME = "CHARGE_TYPE_NAME";
            /// <summary>
            /// 享受优惠价格标志
            /// </summary>
            public const string CHARGE_PRICE_INDICATOR = "CHARGE_PRICE_INDICATOR";

        }
        /// <summary>
        /// 费别字典视图字段定义
        /// </summary>
        internal struct IDentityDicView
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string SERIAL_NO = "SERIAL_NO";
            /// <summary>
            /// 身份代码
            /// </summary>
            public const string IDENTITY_CODE = "IDENTITY_CODE";
            /// <summary>
            /// 身份名称
            /// </summary>
            public const string IDENTITY_NAME = "IDENTITY_NAME";
            /// <summary>
            /// 优先标志
            /// </summary>
            public const string PRIORITY_INDICATOR = "PRIORITY_INDICATOR";

        }
        internal struct PatDoctorView
        {
            /// <summary>
            /// 病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊ID
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 入院时间
            /// </summary>
            public const string VISIT_TIME = "VISIT_TIME";
            /// <summary>
            /// 出院时间
            /// </summary>
            public const string DISCHARGE_TIME = "DISCHARGE_TIME";
            /// <summary>
            /// 出院科室
            /// </summary>
            public const string DISCHARGE_DEPT_CODE = "DISCHARGE_DEPT_CODE";
            /// <summary>
            /// 床位编号
            /// </summary>
            public const string BED_CODE = "BED_CODE";
            /// <summary>
            /// 经治医师ID
            /// </summary>
            public const string REQUEST_DOCTOR_ID = "REQUEST_DOCTOR_ID";
            /// <summary>
            /// 上级医师ID
            /// </summary>
            public const string PARENT_DOCTOR_ID = "PARENT_DOCTOR_ID";
            /// <summary>
            /// 主任医师ID
            /// </summary>
            public const string SUPER_DOCTOR_ID = "SUPER_DOCTOR_ID";
            /// <summary>
            /// 病人入院时所在部门
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
        }

        /// <summary>
        /// 在院病人数据视图字段定义
        /// </summary>
        internal struct InpVisitView
        {
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 床位码
            /// </summary>
            public const string BED_CODE = "BED_CODE";
            /// <summary>
            /// 科室码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 病区码
            /// </summary>
            public const string WARD_CODE = "WARD_CODE";
            /// <summary>
            /// 入院时间
            /// </summary>
            public const string ADMISSION_TIME = "VISIT_TIME";
            /// <summary>
            /// 入科时间
            /// </summary>
            public const string ADM_WARD_TIME = "ADM_WARD_TIME";
            /// <summary>
            /// 入院诊断
            /// </summary>
            public const string DIAGNOSIS = "DIAGNOSIS";
            /// <summary>
            /// 经治医师
            /// </summary>
            public const string INCHARGE_DOCTOR = "INCHARGE_DOCTOR";
            /// <summary>
            /// 病人病情
            /// </summary>
            public const string PATIENT_CONDITION = "PATIENT_CONDITION";
            /// <summary>
            /// 护理等级名称
            /// </summary>
            public const string NURSING_CLASS = "NURSING_CLASS";
            /// <summary>
            /// 预交金总额
            /// </summary>
            public const string PREPAYMENTS = "PREPAYMENTS";
            /// <summary>
            /// 累计未结费用
            /// </summary>
            public const string TOTAL_COSTS = "TOTAL_COSTS";
            /// <summary>
            /// 优惠后未结费用
            /// </summary>
            public const string TOTAL_CHARGES = "TOTAL_CHARGES";
        }

        /// <summary>
        /// 病人就诊视图
        /// </summary>
        internal struct PatVisitView
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 病人性别
            /// </summary>
            public const string PATIENT_SEX = "PATIENT_SEX";
            /// <summary>
            /// 病人生日
            /// </summary>
            public const string BIRTH_TIME = "BIRTH_TIME";
            /// <summary>
            /// 住址
            /// </summary>
            public const string ADDRESS = "ADDRESS";
            /// <summary>
            /// 工作单位
            /// </summary>
            public const string SERVICE_AGENCY = "SERVICE_AGENCY";
            /// <summary>
            /// 费别
            /// </summary>
            public const string CHARGE_TYPE = "CHARGE_TYPE";

            /// <summary>
            /// 就诊标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊时间
            /// </summary>
            public const string VISIT_TIME = "VISIT_TIME";
            /// <summary>
            /// 就诊类型(IP-住院 OP-门诊)
            /// </summary>
            public const string VISIT_TYPE = "VISIT_TYPE";
            /// <summary>
            /// 住院号
            /// </summary>
            public const string INP_NO = "INP_NO";
            /// <summary>
            /// 年龄
            /// </summary>
            public const string AGE = "AGE";
            /// <summary>
            /// 主治医师
            /// </summary>
            public const string ATTENDING_DOCTOR = "ATTENDING_DOCTOR";
            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 床号
            /// </summary>
            public const string BED_NO = "BED_CODE";
            /// <summary>
            /// 病人病情
            /// </summary>
            public const string PATIENT_CONDITION = "PATIENT_CONDITION";
            /// <summary>
            /// 经治医师
            /// </summary>
            public const string INCHARGE_DOCTOR = "INCHARGE_DOCTOR";
            /// <summary>
            /// 病情诊断
            /// </summary>
            public const string DIAGNOSIS = "DIAGNOSIS";
            /// <summary>
            /// 出院日期
            /// </summary>
            public const string DISCHARGE_TIME = "DISCHARGE_TIME";
            /// <summary>
            /// 出院方式
            /// </summary>
            public const string DISCHARGE_MODE = "DISCHARGE_MODE";
            /// <summary>
            /// 出院科室代码
            /// </summary>
            public const string DEPT_DISCHARGE_FROM = "DEPT_DISCHARGE_FROM";

            /// <summary>
            /// 病案归档状态
            /// </summary>
            public const string MR_STATUS = "MR_STATUS";

            ///<summary>
            ///病人身份
            ///</summary>
            public const string IDENTITY = "IDENTITY";
            /// <summary>
            /// 护理等级
            /// </summary>
            public const string NURSING_CLASS = "NURSING_CLASS";

        }

        /// <summary>
        /// 病情状态日志视图
        /// </summary>
        internal struct AdtLogView
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病情状态发烧时间
            /// </summary>
            public const string LOG_DATE_TIME = "LOG_DATE_TIME";
        }

        /// <summary>
        /// 病人诊断信息视图数据字段
        /// </summary>
        internal struct DiagnosisView
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 诊断类别代码
            /// </summary>
            public const string DIAGNOSIS_TYPE = "DIAGNOSIS_TYPE";
            /// <summary>
            /// 诊断类别
            /// </summary>
            public const string DIAGNOSIS_TYPE_NAME = "DIAGNOSIS_TYPE_NAME";
            /// <summary>
            /// 诊断序号
            /// </summary>
            public const string DIAGNOSIS_NO = "DIAGNOSIS_NO";
            /// <summary>
            /// 诊断描述
            /// </summary>
            public const string DIAGNOSIS_DESC = "DIAGNOSIS_DESC";
            /// <summary>
            /// 诊断日期
            /// </summary>
            public const string DIAGNOSIS_DATE = "DIAGNOSIS_DATE";
            /// <summary>
            /// 治疗结果
            /// </summary>
            public const string TREAT_RESULT = "TREAT_RESULT";
        }

        /// <summary>
        /// 病案质量监控信息表相关字段定义
        /// </summary>
        internal struct QCMessageView
        {
            /// <summary>
            /// 质检问题ID
            /// </summary>
            public const string MSG_ID = "MSG_ID";
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string NAME = "PATIENT_NAME";
            /// <summary>
            /// 病人所在科室
            /// </summary>
            public const string DEPT_STAYED = "DEPT_STAYED";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 病人经治医师
            /// </summary>
            public const string INCHARGE_DOCTOR = "DOCTOR_IN_CHARGE";
            /// <summary>
            /// 上级医生
            /// </summary>
            public const string PARENT_DOCTOR = "PARENT_DOCTOR";
            /// <summary>
            /// 主任医生
            /// </summary>
            public const string SUPER_DOCTOR = "SUPER_DOCTOR";
            /// <summary>
            /// 病案质量问题分类
            /// </summary>
            public const string QA_EVENT_TYPE = "QA_EVENT_TYPE";
            /// <summary>
            /// 反馈信息代码
            /// </summary>
            public const string QC_MSG_CODE = "QC_MSG_CODE";
            /// <summary>
            /// 反馈信息描述
            /// </summary>
            public const string MESSAGE = "MESSAGE";
            /// <summary>
            /// 发出者
            /// </summary>
            public const string ISSUED_BY = "ISSUED_BY";
            /// <summary>
            /// 发出者ID
            /// </summary>
            public const string ISSUED_ID = "ISSUED_ID";
            /// <summary>
            /// 发出时间
            /// </summary>
            public const string ISSUED_DATE_TIME = "ISSUED_DATE_TIME";
            /// <summary>
            /// 信息状态0 未确认/未接收  1 已确认/已接受 2 已修改 3合格
            /// </summary>
            public const string MSG_STATUS = "MSG_STATUS";
            /// <summary>
            /// 信息确认时间
            /// </summary>
            public const string ASK_DATE_TIME = "ASK_DATE_TIME";
            /// <summary>
            /// 病案质控类型
            /// </summary>
            public const string QC_MODULE = "QC_MODULE";
            /// <summary>
            /// 病历主题代码
            /// </summary>
            public const string TOPIC_ID = "TOPIC_ID";
            /// <summary>
            /// 病历主题
            /// </summary>
            public const string TOPIC = "TOPIC";
            /// <summary>
            /// 医生反馈信息
            /// </summary>
            public const string DOCTOR_COMMENT = "DOCTOR_COMMENT";
            /// <summary>
            /// 扣分值
            /// </summary>
            public const string POINT = "POINT";
            /// <summary>
            /// 扣分类型  0-自动扣分 1-手动输入扣分
            /// </summary>
            public const string POINT_TYPE = "POINT_TYPE";
            /// <summary>
            /// 强制锁定状态，0:不锁定 1:锁定，必须修改问题才能创建病历
            /// </summary>
            public const string LOCK_STATUS = "LOCK_STATUS";
            /// <summary>
            /// 应用环境 MEDDOC  NURDOC
            /// </summary>
            public const string APPLY_ENV = "APPLY_ENV";
        }

        /// <summary>
        /// 病案质量问题分类字典表相关字段定义
        /// </summary>
        internal struct QCMessageTypeView
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string SERIAL_NO = "SERIAL_NO";
            /// <summary>
            /// 问题分类
            /// </summary>
            public const string QA_EVENT_TYPE = "QA_EVENT_TYPE";
            /// <summary>
            /// 输入码
            /// </summary>
            public const string INPUT_CODE = "INPUT_CODE";
            /// <summary>
            /// 上级输入码
            /// </summary>
            public const string PARENT_CODE = "PARENT_CODE";
            /// <summary>
            /// 最大扣分数
            /// </summary>
            public const string MAX_SCORE = "MAX_SCORE";
            /// <summary>
            /// 应用环境
            /// </summary>
            public const string APPLY_ENV = "APPLY_ENV";
        }

        /// <summary>
        /// 质控反馈信息字典表相关字段定义
        /// </summary>
        internal struct QCMessageTempletView
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string SERIAL_NO = "SERIAL_NO";
            /// <summary>
            /// 反馈信息代码
            /// </summary>
            public const string QC_MSG_CODE = "QC_MSG_CODE";
            /// <summary>
            /// 问题分类
            /// </summary>
            public const string QA_EVENT_TYPE = "QA_EVENT_TYPE";
            /// <summary>
            /// 信息描述
            /// </summary>
            public const string MESSAGE = "MESSAGE";
            /// <summary>
            /// 信息标题
            /// </summary>
            public const string MESSAGE_TITLE = "MESSAGE_TITLE";
            /// <summary>
            /// 扣分
            /// </summary>
            public const string SCORE = "SCORE";
            /// <summary>
            /// 输入码
            /// </summary>
            public const string INPUT_CODE = "INPUT_CODE";
            /// <summary>
            /// 应用环境
            /// </summary>
            public const string APPLY_ENV = "APPLY_ENV";
            /// <summary>
            /// 单项否决
            /// </summary>
            public const string IsVeto = "ISVETO";
        }

        /// <summary>
        /// 病案质量监控日志表相关字段定义
        /// </summary>
        internal struct QCActionLogView
        {
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病人所在科室
            /// </summary>
            public const string DEPT_STAYED = "DEPT_STAYED";
            /// <summary>
            /// 审查日期
            /// </summary>
            public const string CHECK_DATE = "CHECK_DATE";
            /// <summary>
            /// 审查者
            /// </summary>
            public const string CHECKED_BY = "CHECKED_BY";
            /// <summary>
            /// 审查者ID
            /// </summary>
            public const string CHECKED_ID = "CHECKED_ID";
            /// <summary>
            /// 病历文档集ID
            /// </summary>
            public const string DOC_SETID = "DOC_SETID";
            /// <summary>
            /// 病历操作者姓名
            /// </summary>
            public const string CHECKED_NAME = "CHECKED_NAME";
            /// <summary>
            /// 病历操作者所在科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 病历操作者所在科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 病历操作类型(0-正在读；1-正在写；2-写完成；3-删除完成；4-归档完成)
            /// </summary>
            public const string CHECK_TYPE = "CHECK_TYPE";
            /// <summary>
            /// 日志类型(0-医生读写日志；1-质控读写日志；2-院级读写日志；)
            /// </summary>
            public const string LOG_TYPE = "LOG_TYPE";
            /// <summary>
            /// 日志描述信息
            /// </summary>
            public const string LOG_DESC = "LOG_DESC";
        }

        /// <summary>
        /// 病案评分视图数据字段
        /// </summary>
        internal struct QCScoreView
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病案状态
            /// </summary>
            public const string MR_STATUS = "MR_STATUS";
            /// <summary>
            /// 提交医生
            /// </summary>
            public const string SUBMIT_DOCTOR_ID = "SUBMIT_DOCTOR_ID";
            /// <summary>
            /// 院评
            /// </summary>
            public const string HOS_COMMENT = "HOS_COMMENT";
            /// <summary>
            /// 院评分数
            /// </summary>
            public const string HOS_ASSESS = "HOS_ASSESS";
            /// <summary>
            /// 病案等级
            /// </summary>
            public const string ARC_LEVEL = "ARC_LEVEL";
            /// <summary>
            /// 院评日期
            /// </summary>
            public const string HOS_DATE = "HOS_DATE";
            /// <summary>
            /// 院评质控人
            /// </summary>
            public const string HOS_QCMAN = "HOS_QCMAN";
        }

        /// <summary>
        /// 手术操作字典视图
        /// </summary>
        internal struct OperationDictView
        {
            /// <summary>
            /// 手术编码
            /// </summary>
            public const string OPERATION_CODE = "OPERATION_CODE";
            /// <summary>
            /// 手术名称
            /// </summary>
            public const string OPERATION_NAME = "OPERATION_NAME";
            /// <summary>
            /// 输入码
            /// </summary>
            public const string INPUT_CODE = "INPUT_CODE";
        }

        /// <summary>
        /// 病人手术视图数据字段
        /// </summary>
        internal struct OperationView
        {
            /// <summary>
            /// 病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊ID
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 手术序号
            /// </summary>
            public const string OPERATION_NO = "OPERATION_NO";
            /// <summary>
            /// 手术名称
            /// </summary>
            public const string OPERATION_DESC = "OPERATION_DESC";
            /// <summary>
            /// 手术编码
            /// </summary>
            public const string OPERATION_CODE = "OPERATION_CODE";
            /// <summary>
            /// 切口愈合情况
            /// </summary>
            public const string HEAL = "HEAL";
            /// <summary>
            /// 切口等级
            /// </summary>
            public const string WOUND_GRADE = "WOUND_GRADE";
            /// <summary>
            /// 手术日期
            /// </summary>
            public const string OPERATING_DATE = "OPERATING_DATE";
            /// <summary>
            /// 麻醉方法
            /// </summary>
            public const string ANAESTHESIA_METHOD = "ANAESTHESIA_METHOD";
            /// <summary>
            /// 手术医师
            /// </summary>
            public const string OPERATOR = "OPERATOR";
            /// <summary>
            /// 第一手术助手
            /// </summary>
            public const string FIRST_ASSISTANT = "FIRST_ASSISTANT";
            /// <summary>
            ///第二手术助手 
            /// </summary>
            public const string SECOND_ASSISTANT = "SECOND_ASSISTANT";
            /// <summary>
            /// 麻醉医师
            /// </summary>
            public const string ANESTHESIA_DOCTOR = "ANESTHESIA_DOCTOR";
        }

        /// <summary>
        /// 专家质控表结构
        /// </summary>
        public struct QcSpecialCheckTable
        {
            /// <summary>
            /// 抽检批次号
            /// </summary>
            public const string CONFIG_ID = "CONFIG_ID";
            /// <summary>
            /// 名称
            /// </summary>
            public const string NAME = "NAME";
            /// <summary>
            /// 开始时间
            /// </summary>
            public const string START_TIME = "START_TIME";
            /// <summary>
            /// 结束时间
            /// </summary>
            public const string END_TIME = "END_TIME";
            /// <summary>
            /// 病人病情
            /// </summary>
            public const string PATIENT_CONDITION = "PATIENT_CONDITION";
            /// <summary>
            /// 出院方式
            /// </summary>
            public const string DISCHARGE_MODE = "DISCHARGE_MODE";
            /// <summary>
            /// 每科室抽取
            /// </summary>
            public const string PER_COUNT = "PER_COUNT";
            /// <summary>
            /// 病案样本总数
            /// </summary>
            public const string PATIENT_COUNT = "PATIENT_COUNT";
            /// <summary>
            /// 专家人数
            /// </summary>
            public const string SPECIAL_COUNT = "SPECIAL_COUNT";
            /// <summary>
            /// 创建人
            /// </summary>
            public const string CREATER = "CREATER";
            /// <summary>
            /// 创建时间
            /// </summary>
            public const string CREATE_TIME = "CREATE_TIME";
        }

        /// <summary>
        /// 质控时效结果统计到科室
        /// </summary>
        public struct QcTimeRecordStatByDeptTable
        {
            /// <summary>
            /// 检查时间
            /// </summary>
            public const string CHECK_DATE = "CHECK_DATE";
            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 专家姓名
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 文档标题
            /// </summary>
            public const string DOC_TITLE = "DOC_TITLE";
            /// <summary>
            /// 正常书写数量
            /// </summary>
            public const string NORMAL = "NORMAL";
            /// <summary>
            /// 未书写数量
            /// </summary>
            public const string UNWRITE = "UNWRITE";
            /// <summary>
            /// 书写超时
            /// </summary>
            public const string TIMEOUT = "TIMEOUT";
            /// <summary>
            /// 正常未书写
            /// </summary>
            public const string UNWRITE_NORMAL = "UNWRITE_NORMAL";
            /// <summary>
            /// 提前书写数量
            /// </summary>
            public const string EARLY = "EARLY";
            /// <summary>
            /// 全科应写该病历总数
            /// </summary>
            public const string NEEDCOUNT = "NEED_COUNT";
            /// <summary>
            /// 未完成病历涉及的患者数
            /// </summary>
            public const string UNDOPATIENTCOUNT = "UNDO_PATIENT_COUNT";
            /// <summary>
            /// 科室当前在院人数
            /// </summary>
            public const string DEPTPATIENTCOUNT = "DEPT_PATIENT_COUNT";

        }
        /// <summary>
        /// 病历时效扣分表
        /// </summary>
        internal struct QcTimeCheckTable
        {
            /// <summary>
            /// 病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊ID
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 事件ID
            /// </summary>
            public const string EVENT_ID = "EVENT_ID";
            /// <summary>
            /// 文档类型ID
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            /// <summary>
            /// 病历书写起始日期
            /// </summary>
            public const string BEGIN_DATE = "BEGIN_DATE";
            /// <summary>
            /// 病历书写截止日期
            /// </summary>
            public const string END_DATE = "END_DATE";
            /// <summary>
            /// 扣分值
            /// </summary>
            public const string POINT = "POINT";
            /// <summary>
            /// 检查者姓名
            /// </summary>
            public const string CHECKER_NAME = "CHECKER_NAME";
            /// <summary>
            /// 检查日期
            /// </summary>
            public const string CHECK_DATE = "CHECK_DATE";
        }

        /// <summary>
        /// 病人入出转状态表
        /// </summary>
        internal struct AdtLogTable
        {
            /// <summary>
            /// 病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊ID
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病情状态
            /// </summary>
            public const string PATIENT_CONDITION = "PATIENT_CONDITION";
        }

        /// <summary>
        /// SQL命令常量
        /// </summary>
        internal struct SQL
        {
            /// <summary>
            /// "SELECT {0}"
            /// </summary>
            public const string SELECT = "SELECT {0}";
            /// <summary>
            /// "SELECT {0} FROM {1}"
            /// </summary>
            public const string SELECT_FROM = "SELECT {0} FROM {1}";
            /// <summary>
            /// "SELECT {0} FROM {1} WHERE {2}"
            /// </summary>
            public const string SELECT_WHERE = "SELECT {0} FROM {1} WHERE {2}";
            /// <summary>
            /// "SELECT {0} FROM {1} WHERE {2} IN({3})"
            /// </summary>
            public const string SELECT_WHERE_IN = "SELECT {0} FROM {1} WHERE {2} IN({3})";
            /// <summary>
            /// "SELECT {0} FROM {1} ORDER BY {2} ASC"
            /// </summary>
            public const string SELECT_ORDER_ASC = "SELECT {0} FROM {1} ORDER BY {2} ASC";
            /// <summary>
            /// "SELECT {0} FROM {1} ORDER BY {2} DESC"
            /// </summary>
            public const string SELECT_ORDER_DESC = "SELECT {0} FROM {1} ORDER BY {2} DESC";
            /// <summary>
            /// "SELECT {0} FROM {1} WHERE {2} ORDER BY {3} ASC"
            /// </summary>
            public const string SELECT_WHERE_ORDER_ASC = "SELECT {0} FROM {1} WHERE {2} ORDER BY {3} ASC";
            /// <summary>
            /// "SELECT {0} FROM {1} WHERE {2} ORDER BY {3} DESC"
            /// </summary>
            public const string SELECT_WHERE_ORDER_DESC = "SELECT {0} FROM {1} WHERE {2} ORDER BY {3} DESC";
            /// <summary>
            /// "SELECT DISTINCT {0} FROM {1} WHERE {2} ORDER BY {3} ASC"
            /// </summary>
            public const string SELECT_DISTINCT_WHERE_ORDER_ASC = "SELECT DISTINCT {0} FROM {1} WHERE {2} ORDER BY {3} ASC";
            /// <summary>
            /// "SELECT DISTINCT {0} FROM {1} WHERE {2} ORDER BY {3} DESC"
            /// </summary>
            public const string SELECT_DISTINCT_WHERE_ORDER_DESC = "SELECT DISTINCT {0} FROM {1} WHERE {2} ORDER BY {3} DESC";
            /// <summary>
            /// "INSERT INTO {0}({1}) VALUES({2})"
            /// </summary>
            public const string INSERT = "INSERT INTO {0}({1}) VALUES({2})";
            /// <summary>
            /// "UPDATE {0} SET {1} WHERE {2}"
            /// </summary>
            public const string UPDATE = "UPDATE {0} SET {1} WHERE {2}";
            /// <summary>
            /// "DELETE FROM {0} WHERE {1}"
            /// </summary>
            public const string DELETE = "DELETE FROM {0} WHERE {1}";
            /// <summary>
            /// "{0} UNION {1}"
            /// </summary>
            public const string UNION = "{0} UNION {1}";
            /// <summary>
            /// "SELECT {0} FROM {1} WHERE {2} GROUP BY {3}"
            /// </summary>
            public const string SELECT_FROM_WHERE_GROUP = "SELECT {0} FROM {1} WHERE {2} GROUP BY {3}";
        }

        /// <summary>
        /// 就诊类型常量
        /// </summary>
        internal struct VisitType
        {
            /// <summary>
            /// 住院
            /// </summary>
            public const string IP = "IP";
            /// <summary>
            /// 门诊
            /// </summary>
            public const string OP = "OP";
        }

        #region 护理文书系统
        /// <summary>
        /// 表格模板定义信息表
        /// </summary>
        internal struct GridViewSchemaTable
        {
            /// <summary>
            /// 表格ID字段
            /// </summary>
            public const string SCHEMA_ID = "SCHEMA_ID";

            /// <summary>
            /// 表格方案类型
            /// </summary>
            public const string SCHEMA_TYPE = "SCHEMA_TYPE";

            /// <summary>
            /// 表格名称字段
            /// </summary>
            public const string SCHEMA_NAME = "SCHEMA_NAME";

            /// <summary>
            /// 病区代码字段
            /// </summary>
            public const string WARD_CODE = "WARD_CODE";

            /// <summary>
            /// 病区名称字段
            /// </summary>
            public const string WARD_NAME = "WARD_NAME";

            /// <summary>
            /// 是否是缺省方案字段
            /// </summary>
            public const string IS_DEFAULT = "IS_DEFAULT";

            /// <summary>
            /// 创建者ID号字段
            /// </summary>
            public const string CREATOR_ID = "CREATOR_ID";

            /// <summary>
            /// 创建者姓名字段
            /// </summary>
            public const string CREATOR_NAME = "CREATOR_NAME";

            /// <summary>
            /// 创建时间字段
            /// </summary>
            public const string CREATE_TIME = "CREATE_TIME";

            /// <summary>
            /// 修修改者ID号字段
            /// </summary>
            public const string MODIFIER_ID = "MODIFIER_ID";

            /// <summary>
            /// 修改者姓名字段
            /// </summary>
            public const string MODIFIER_NAME = "MODIFIER_NAME";

            /// <summary>
            /// 修改时间字段
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";

            /// <summary>
            /// 当前方案自定义标记
            /// </summary>
            public const string SCHEMA_FLAG = "SCHEMA_FLAG";

            /// <summary>
            /// 批量入录关联护理记录列配置
            /// </summary>
            public const string RELATIVE_SCHEMA_ID = "RELATIVE_SCHEMA_ID";
        }
        /// <summary>
        /// 配置字典表配置项常量
        /// </summary>
        public struct NursingConfigKey
        {
            /// <summary>
            /// 配置字典表中文档存储模式配置
            /// </summary>
            public const string STORAGE_MODE = "STORAGE_MODE";

            /// <summary>
            /// 配置字典表中文档存储模式FTP
            /// </summary>
            public const string STORAGE_MODE_FTP = "FTP";

            /// <summary>
            /// 配置字典表中文档存储模式DB
            /// </summary>
            public const string STORAGE_MODE_DB = "DB";

            /// <summary>
            /// 配置字典表中程序升级版本信息
            /// </summary>
            public const string UPGRADE_VERSION = "UPGRADE_VERSION";

            /// <summary>
            /// 配置字典表中FTP程序升级访问参数配置组名称
            /// </summary>
            public const string UPGRADE_FTP = "UPGRADE_FTP";

            /// <summary>
            /// 配置字典表中FTP护理信息库资料访问参数配置组名称
            /// </summary>
            public const string INFOLIB_FTP = "INFOLIB_FTP";

            /// <summary>
            /// 配置字典表中FTP文档库访问参数配置组名称
            /// </summary>
            public const string DOC_FTP = "DOCFTP";

            /// <summary>
            /// 配置字典表中健康教育访问IIS地址
            /// </summary>
            public const string IIS_ADDRESS = "IIS_ADDRESS";

            /// <summary>
            /// 配置字典表中健康教育访问参数配置组名称
            /// </summary>
            public const string IIS = "HEALTHTECH_IIS";

            /// <summary>
            /// 配置字典表中FTP文档库IP
            /// </summary>
            public const string FTP_IP = "IP";

            /// <summary>
            /// 配置字典表中FTP文档库端口
            /// </summary>
            public const string FTP_PORT = "PORT";

            /// <summary>
            /// 配置字典表中FTP文档库用户名
            /// </summary>
            public const string FTP_USER = "USER";

            /// <summary>
            /// 配置字典表中FTP文档库密码
            /// </summary>
            public const string FTP_PWD = "PWD";

            /// <summary>
            /// 配置字典表中FTP协议模式
            /// </summary>
            public const string FTP_MODE = "FTP_MODE";

            /// <summary>
            /// 配置字典表中病历窗口名称配置组
            /// </summary>
            public const string WINDOW_NAME = "WINDOW_NAME";

            /// <summary>
            /// 批量录入窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_BATCH_RECORD = "WINDOW_NAME_BATCH_RECORD";

            /// <summary>
            /// 病人一览表床位窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_BED_VIEW = "WINDOW_NAME_BED_VIEW";

            /// <summary>
            /// 护士交接班窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_WORKSHIFT_RECORD = "WINDOW_NAME_WORKSHIFT_RECORD";

            /// <summary>
            /// 文书列表1窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_NURDOC_LIST1 = "WINDOW_NAME_NURDOC_LIST1";

            /// <summary>
            /// 文书列表2窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_NURDOC_LIST2 = "WINDOW_NAME_NURDOC_LIST2";

            /// <summary>
            /// 文书列表3窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_NURDOC_LIST3 = "WINDOW_NAME_NURDOC_LIST3";

            /// <summary>
            /// 文书列表4窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_NURDOC_LIST4 = "WINDOW_NAME_NURDOC_LIST4";

            /// <summary>
            /// 专科护理窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_SPECIAL_NURSING = "WINDOW_NAME_SPECIAL_NURSING";

            /// <summary>
            /// 护理记录窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_NURSING_RECORD = "WINDOW_NAME_NURSING_RECORD";

            /// <summary>
            /// 医嘱单窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_ORDERS_RECORD = "WINDOW_NAME_ORDERS_RECORD";

            /// <summary>
            /// 体温单窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_VITAL_SIGNS_GRAPH = "WINDOW_NAME_VITAL_SIGNS_GRAPH";

            /// <summary>
            /// 专科病人一览表窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_SPECIAL_PATIENT = "WINDOW_NAME_SPECIAL_PATIENT";

            /// <summary>
            /// 护理会诊窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_NURSING_CONSULT = "WINDOW_NAME_NURSING_CONSULT";

            /// <summary>
            /// 护理计划窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_NUR_CARE_PLAN = "WINDOW_NAME_NUR_CARE_PLAN";

            /// <summary>
            /// 全局模块之待办任务窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_NURSING_TASK = "WINDOW_NAME_NURSING_TASK";

            /// <summary>
            /// 全局模块之查询统计窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_NURSING_STAT = "WINDOW_NAME_NURSING_STAT";

            /// <summary>
            /// 病人模块之综合查询窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_INTEGRATE_QUERY = "WINDOW_NAME_INTEGRATE_QUERY";

            /// <summary>
            /// 病人模块之监护记录单窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_NURSING_MONITOR = "WINDOW_NAME_NURSING_MONITOR";

            /// <summary>
            /// 病人模块之WORD模板窗口名称配置
            /// </summary>
            public const string WINDOW_NAME_WORD_DOCUMENT = "WINDOW_NAME_WORD_DOCUMENT";

            /// <summary>
            /// 配置字典表中用户权限配置组
            /// </summary>
            public const string USER_RIGHT = "USER_RIGHT";

            /// <summary>
            /// 是否开启数据修改审批流程
            /// </summary>
            public const string USER_RIGHT_APPROVEL_DATA_MODIFY = "USER_RIGHT_APPROVEL_DATA_MODIFY";

            /// <summary>
            /// 实习护士可以编辑的数据时效配置
            /// </summary>
            public const string USER_RIGHT_STUDENT_NURSE_EDIT_TIME = "USER_RIGHT_STUDENT_NURSE_EDIT_TIME";

            /// <summary>
            /// 一般护士可以编辑的数据时效配置
            /// </summary>
            public const string USER_RIGHT_GENERAL_NURSE_EDIT_TIME = "USER_RIGHT_GENERAL_NURSE_EDIT_TIME";

            /// <summary>
            /// 质控护士可以编辑的数据时效配置
            /// </summary>
            public const string USER_RIGHT_QUALITY_NURSE_EDIT_TIME = "USER_RIGHT_QUALITY_NURSE_EDIT_TIME";

            /// <summary>
            /// 主管护师可以编辑的数据时效配置
            /// </summary>
            public const string USER_RIGHT_HIGHER_NURSE_EDIT_TIME = "USER_RIGHT_HIGHER_NURSE_EDIT_TIME";

            /// <summary>
            /// 主任护师可以编辑的数据时效配置
            /// </summary>
            public const string USER_RIGHT_HEAD_NURSE_EDIT_TIME = "USER_RIGHT_HEAD_NURSE_EDIT_TIME";

            /// <summary>
            /// 护理部可以编辑的数据时效配置
            /// </summary>
            public const string USER_RIGHT_LEADER_NURSE_EDIT_TIME = "USER_RIGHT_LEADER_NURSE_EDIT_TIME";

            /// <summary>
            /// 实习护士可以审核多长时间内其他护士提交的审核请求配置
            /// </summary>
            public const string USER_RIGHT_STUDENT_NURSE_GRANT_TIME = "USER_RIGHT_STUDENT_NURSE_GRANT_TIME";

            /// <summary>
            /// 一般护士可以审核多长时间内其他护士提交的审核请求配置
            /// </summary>
            public const string USER_RIGHT_GENERAL_NURSE_GRANT_TIME = "USER_RIGHT_GENERAL_NURSE_GRANT_TIME";

            /// <summary>
            /// 质控护士可以审核多长时间内其他护士提交的审核请求配置
            /// </summary>
            public const string USER_RIGHT_QUALITY_NURSE_GRANT_TIME = "USER_RIGHT_QUALITY_NURSE_GRANT_TIME";

            /// <summary>
            /// 主管护师可以审核多长时间内其他护士提交的审核请求配置
            /// </summary>
            public const string USER_RIGHT_HIGHER_NURSE_GRANT_TIME = "USER_RIGHT_HIGHER_NURSE_GRANT_TIME";

            /// <summary>
            /// 主任护师可以审核多长时间内其他护士提交的审核请求配置
            /// </summary>
            public const string USER_RIGHT_HEAD_NURSE_GRANT_TIME = "USER_RIGHT_HEAD_NURSE_GRANT_TIME";

            /// <summary>
            /// 护理部可以审核多长时间内其他护士提交的审核请求配置
            /// </summary>
            public const string USER_RIGHT_LEADER_NURSE_GRANT_TIME = "USER_RIGHT_LEADER_NURSE_GRANT_TIME";

            /// <summary>
            /// 护理文书文档列表默认加载时间（h）
            /// </summary>
            public const string DOC_LIST_LOAD_TIME = "DOC_LIST_LOAD_TIME";

            /// <summary>
            /// 配置字典表中病历可选功能配置组
            /// </summary>
            public const string SYSTEM_OPTION = "SYSTEM_OPTION";

            /// <summary>
            /// 护理病历系统产品授权代码
            /// </summary>
            public const string SYSTEM_OPTION_CERT_CODE = "CERT_CODE";

            /// <summary>
            /// 护理病历系统产品授权医院名称
            /// </summary>
            public const string SYSTEM_OPTION_HOSPITAL_NAME = "HOSPITAL_NAME";

            /// <summary>
            /// 0表示多病人窗口模式，1表示单病人窗口模式
            /// </summary>
            public const string SYSTEM_OPTION_SINGLE_PATIENT = "SINGLE_PATIENT_MODE";

            /// <summary>
            /// 总后版体征数据 
            /// </summary>
            public const string SYSTEM_OPTION_EMRS_VITAL = "EMRS_VITAL";

            /// <summary>
            /// 护理记录是否需要双签名
            /// </summary>
            public const string SYSTEM_OPTION_NURREC_DOUBLESIGN = "NURREC_DOUBLESIGN";

            /// <summary>
            /// 0-批量录入窗口不显示打印按钮
            /// 1-批量录入窗口显示打印按钮
            /// </summary>
            public const string SYSTEM_OPTION_OPTION_BATCH_RECORD_PRINT = "OPTION_BATCH_RECORD_PRINT";

            /// <summary>
            /// 0-护理记录单单条记录录入方式
            /// 1-护理记录单表格方式录入方式
            /// </summary>
            public const string SYSTEM_OPTION_REC_TABLE_INPUT = "OPTION_REC_TABLE_INPUT";

            /// <summary>
            /// 0-护理记录集中显示
            /// 1-护理记录显示按列显示方案归类显示
            /// </summary>
            public const string SYSTEM_OPTION_REC_SHOW_BY_TYPE = "OPTION_REC_SHOW_BY_TYPE";

            /// <summary>
            /// 护理记录显示按列显示方案归类显示开始时间
            /// </summary>
            public const string SYSTEM_OPTION_REC_SHOW_BY_TYPE_START_TIME = "OPTION_REC_SHOW_BY_TYPE_START_TIME";

            /// <summary>
            /// 任务提醒时间间隔
            /// </summary>
            public const string SYSTEM_OPTION_TASK_MESSAGE_TIME = "TASK_MESSAGE_TIME";

            /// <summary>
            /// 0-医嘱本窗口不显示打印按钮
            /// 1-医嘱本窗口显示打印按钮
            /// </summary>
            public const string SYSTEM_OPTION_OPTION_ORDERS_PRINT = "OPTION_ORDERS_PRINT";

            /// <summary>
            /// 0- 默认计算24小时出入量小结时，当天早上7点为昨天的24小结量，昨天的早上7点不算。
            /// 1- 计算24小时出入量小结时，当天早上7点不算为昨天24小结量，而昨天的早上7点算24小结量。
            /// 2-  计算24小结入量的时候，当天早上7点不算为昨天24小结量，而昨天的早上7点算24小结量；计算24小结出量时，
            ///     当天早上7点为昨天的24小结量，昨天的早上7点不算。
            /// </summary>
            public const string SYSTEM_OPTION_OPTION_CALCULATE_SUMMARY = "OPTION_CALCULATE_SUMMARY";

            /// <summary>
            /// 后台配置体征表中存储测试血压次数
            /// </summary>
            public const string SYSTEM_OPTION_OPTION_VITAL_BP_COUNT = "OPTION_VITAL_BP_COUNT";

            /// <summary>
            /// 后台配置文档是否归档校验
            /// 0- 不校验归档状态
            /// 1- 校验归档状态
            /// </summary>
            public const string DOC_PIGEONHOLE = "DOC_PIGEONHOLE";

            /// <summary>
            /// 护理小结模板名称
            /// </summary>
            public const string REC_SUMMARYNAME = "REC_SUMMARYNAME";

            /// <summary>
            /// 是否开启医嘱拆分执行计划
            /// </summary>
            public const string PLAN_ORDERS_REC = "PLAN_ORDERS_REC";

            /// <summary>
            /// 是否开启转科护理自动新增
            /// </summary>
            public const string SYSTEM_SPECIAL_NURSING_INCREASE = "SPECIAL_NURSING_INCREASE";

            /// <summary>
            /// 是否开启护理记录的单位非ml的判断
            /// </summary>
            public const string SYSTEM_NURRECORD_UNIT = "NURRECORD_UNIT";

            /// <summary>
            /// 是否开启护理计划新版配置（杭三修改）需搭配系统起始页（护理计划映射表）使用
            /// </summary>
            public const string NPC_NEW_MODEL = "NPC_NEW_MODEL";

            /// <summary>
            /// 是否开启表格式护理记录单 体征数据同步
            /// </summary>
            public const string VITAL_SIGNS_SYNC = "VITAL_SIGNS_SYNC";

            /// <summary>
            /// 义乌护理计划排序  可用于其他状态为1,2,3的排序  及进行中  完成  停止  这样排
            /// </summary>
            public const string NCP_LIST_SORT_YW = "NCP_LIST_SORT_YW";

            /// <summary>
            /// 护理记录列配置 是否将病区和全院一起显示 1是 0否 默认否
            /// </summary>
            public const string NUR_REC_SCHEMA_LIST_SHOWALL = "NUR_REC_SCHEMA_LIST_SHOWALL";
        }

        /// <summary>
        /// 系统配置字典表各字段定义
        /// </summary>
        internal struct NursingConfigDictTable
        {
            /// <summary>
            /// 配置组名称
            /// </summary>
            public const string GROUP_NAME = "GROUP_NAME";

            /// <summary>
            /// 配置项名称
            /// </summary>
            public const string CONFIG_NAME = "CONFIG_NAME";

            /// <summary>
            /// 配置项值
            /// </summary>
            public const string CONFIG_VALUE = "CONFIG_VALUE";

            /// <summary>
            /// 配置项描述
            /// </summary>
            public const string CONFIG_DESC = "CONFIG_DESC";
        }

        /// <summary>
        /// 表格模板列定义信息表
        /// </summary>
        internal struct GridViewColumnTable
        {
            /// <summary>
            /// 表格列所属方案ID字段
            /// </summary>
            public const string SCHEMA_ID = "SCHEMA_ID";

            /// <summary>
            /// 表格列ID字段
            /// </summary>
            public const string COLUMN_ID = "COLUMN_ID";

            /// <summary>
            /// 表格列名称字段
            /// </summary>
            public const string COLUMN_NAME = "COLUMN_NAME";

            /// <summary>
            /// 表格列名称多表头字段
            /// </summary>
            public const string COLUMN_GROUP = "COLUMN_GROUP";

            /// <summary>
            /// 列数据绑定名称标识字段
            /// </summary>
            public const string COLUMN_TAG = "COLUMN_TAG";

            /// <summary>
            /// 列显示索引
            /// </summary>
            public const string COLUMN_INDEX = "COLUMN_INDEX";

            /// <summary>
            /// 列类型字段
            /// </summary>
            public const string COLUMN_TYPE = "COLUMN_TYPE";

            /// <summary>
            /// 列宽字段
            /// </summary>
            public const string COLUMN_WIDTH = "COLUMN_WIDTH";

            /// <summary>
            /// 列显示数据的单位字段
            /// </summary>
            public const string COLUMN_UNIT = "COLUMN_UNIT";

            /// <summary>
            /// 列是否显示字段
            /// </summary>
            public const string IS_VISIBLE = "IS_VISIBLE";

            /// <summary>
            /// 列是否打印字段
            /// </summary>
            public const string IS_PRINT = "IS_PRINT";

            /// <summary>
            /// 是否居中显示和打印字段
            /// </summary>
            public const string IS_MIDDLE = "IS_MIDDLE";

            /// <summary>
            /// 列的可选项列表字段
            /// </summary>
            public const string COLUMN_ITEMS = "COLUMN_ITEMS";

            /// <summary>
            /// 列的文档类型字段
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
        }

        /// <summary>
        /// 护理记录表格数据信息表
        /// </summary>
        internal struct NursingRecInfoTable
        {
            /// <summary>
            /// 病人ID字段
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";

            /// <summary>
            /// 入院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";

            /// <summary>
            /// 病人子ID
            /// </summary>
            public const string SUB_ID = "SUB_ID";

            /// <summary>
            /// 记录的ID号
            /// </summary>
            public const string RECORD_ID = "RECORD_ID";

            /// <summary>
            /// 录入日期字段
            /// </summary>
            public const string RECORD_DATE = "RECORD_DATE";

            /// <summary>
            /// 录入时间字段
            /// </summary>
            public const string RECORD_TIME = "RECORD_TIME";

            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";

            /// <summary>
            /// 病人所在病区代码
            /// </summary>
            public const string WARD_CODE = "WARD_CODE";

            /// <summary>
            /// 病人所在病区名
            /// </summary>
            public const string WARD_NAME = "WARD_NAME";

            /// <summary>
            /// 记录创建者ID
            /// </summary>
            public const string CREATOR_ID = "CREATOR_ID";

            /// <summary>
            /// 记录创建者姓名
            /// </summary>
            public const string CREATOR_NAME = "CREATOR_NAME";

            /// <summary>
            /// 记录创建时间
            /// </summary>
            public const string CREATE_TIME = "CREATE_TIME";

            /// <summary>
            /// 记录修改者ID
            /// </summary>
            public const string MODIFIER_ID = "MODIFIER_ID";

            /// <summary>
            /// 记录修改者姓名
            /// </summary>
            public const string MODIFIER_NAME = "MODIFIER_NAME";

            /// <summary>
            /// 记录修改时间
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";

            /// <summary>
            /// 实际记录者1ID号
            /// </summary>
            public const string RECORDER1_ID = "RECORDER1_ID";

            /// <summary>
            /// 实际记录者1姓名
            /// </summary>
            public const string RECORDER1_NAME = "RECORDER1_NAME";

            /// <summary>
            /// 实际记录者2ID号
            /// </summary>
            public const string RECORDER2_ID = "RECORDER2_ID";

            /// <summary>
            /// 实际记录者2姓名
            /// </summary>
            public const string RECORDER2_NAME = "RECORDER2_NAME";

            /// <summary>
            /// 小结标记
            /// </summary>
            public const string SUMMARY_FLAG = "SUMMARY_FLAG";

            /// <summary>
            /// 实际记录者2姓名
            /// </summary>
            public const string SUMMARY_NAME = "SUMMARY_NAME";

            /// <summary>
            /// 实际记录者2姓名
            /// </summary>
            public const string SUMMARY_START_TIME = "SUMMARY_START_TIME";

            /// <summary>
            /// 护理记录自动文本
            /// </summary>
            public const string RECORD_CONTENT = "RECORD_CONTENT";

            /// <summary>
            /// 护理记录自定义文本
            /// </summary>
            public const string RECORD_REMARKS = "RECORD_REMARKS";

            /// <summary>
            /// 护理记录数据打印状态
            /// </summary>
            public const string RECORD_PRINTED = "RECORD_PRINTED";

            /// <summary>
            /// 护理记录数据状态
            /// </summary>
            public const string RECORD_STATUS = "RECORD_STATUS";

            /// <summary>
            /// 护理记录列显示配置ID号
            /// </summary>
            public const string SCHEMA_ID = "SCHEMA_ID";
        }
        /// <summary>
        /// 病历摘要数据表
        /// </summary>
        internal struct SummaryDataTable
        {
            /// <summary>
            /// 病历ID
            /// </summary>
            public const string DOC_ID = "DOC_ID";

            /// <summary>
            /// 数据标识
            /// </summary>
            public const string DATA_NAME = "DATA_NAME";

            /// <summary>
            /// 数据代码
            /// </summary>
            public const string DATA_CODE = "DATA_CODE";

            /// <summary>
            /// 数据值
            /// </summary>
            public const string DATA_VALUE = "DATA_VALUE";

            /// <summary>
            /// 数据类型
            /// </summary>
            public const string DATA_TYPE = "DATA_TYPE";

            /// <summary>
            /// 数据单位
            /// </summary>
            public const string DATA_UNIT = "DATA_UNIT";

            /// <summary>
            /// 数据产生时间
            /// </summary>
            public const string DATA_TIME = "DATA_TIME";

            /// <summary>
            /// 病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";

            /// <summary>
            /// 就诊ID
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";

            /// <summary>
            /// 病人子ID
            /// </summary>
            public const string SUB_ID = "SUB_ID";

            /// <summary>
            /// 病区代码
            /// </summary>
            public const string WARD_CODE = "WARD_CODE";

            /// <summary>
            /// 记录ID
            /// </summary>
            public const string RECORD_ID = "RECORD_ID";

            /// <summary>
            /// 所属文档类型ID
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
        }

        /// <summary>
        /// 文档类型数据表字段定义
        /// </summary>
        internal struct NurDocTypeTable
        {
            /// <summary>
            /// 文档类型代码
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";

            /// <summary>
            /// 排序值
            /// </summary>
            public const string DOCTYPE_NO = "DOCTYPE_NO";

            /// <summary>
            /// 文档类型名
            /// </summary>
            public const string DOCTYPE_NAME = "DOCTYPE_NAME";

            /// <summary>
            /// 应用环境
            /// </summary>
            public const string APPLY_ENV = "APPLY_ENV";

            /// <summary>
            /// 文档是否可重复
            /// </summary>
            public const string IS_REPEATED = "IS_REPEATED";

            /// <summary>
            /// 标识当前是否有效
            /// </summary>
            public const string IS_VALID = "IS_VALID";

            /// <summary>
            /// 标识当前是否可见
            /// </summary>
            public const string IS_VISIBLE = "IS_VISIBLE";

            /// <summary>
            /// 标识当前是否是目录
            /// </summary>
            public const string IS_FOLDER = "IS_FOLDER";

            /// <summary>
            /// 标识表单打印模式
            /// (0-不打印;1-打印表单;2-打印列表;3-都打印)
            /// </summary>
            public const string PRINT_MODE = "PRINT_MODE";

            /// <summary>
            /// 文档类型所在目录ID
            /// </summary>
            public const string PARENT_ID = "PARENT_ID";

            /// <summary>
            /// 文档类型的修改时间
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";

            /// <summary>
            /// 文档模板数据
            /// </summary>
            public const string TEMPLET_DATA = "TEMPLET_DATA";

            /// <summary>
            /// 文档默认排序列名
            /// </summary>
            public const string SORT_COLUMN = "SORTCOLUMN";

            /// <summary>
            /// 文档默认排序方式，0不排序；1升序；2降序
            /// </summary>
            public const string SORT_MODE = "SORTMODE";

            /// <summary>
            /// 文档所属列配置方案ID
            /// </summary>
            public const string SCHEMA = "SCHEMA";
        }

        /// <summary>
        /// 病人在科记录视图
        /// </summary>
        internal struct TransferView
        {
            /// <summary>
            /// 病人ID号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";

            /// <summary>
            /// 病人就诊号
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";

            /// <summary>
            /// 病人呆过的科室
            /// </summary>
            public const string DEPT_STAYED = "DEPT_STAYED";

            /// <summary>
            /// 入院时间
            /// </summary>
            public const string ADMISSION_DATE_TIME = "ADMISSION_DATE_TIME";

            /// <summary>
            /// 出院时间
            /// </summary>
            public const string DISCHARGE_DATE_TIME = "DISCHARGE_DATE_TIME";

            /// <summary>
            /// 转入科室
            /// </summary>
            public const string DEPT_TRANSFERED_TO = "DEPT_TRANSFERED_TO";

            /// <summary>
            /// 医生
            /// </summary>
            public const string DOCTOR_IN_CHARGE = "DOCTOR_IN_CHARGE";

            /// <summary>
            /// 医生科室
            /// </summary>
            public const string DOCTOR_DEPT = "DOCTOR_DEPT";

            /// <summary>
            /// 床位标号
            /// </summary>
            public const string BED_LABEL = "BED_LABEL";
        }
        /// <summary>
        /// 床位记录视图字段定义
        /// </summary>
        internal struct BedRecordView
        {
            /// <summary>
            /// 病区代码
            /// </summary>
            public const string WARD_CODE = "WARD_CODE";

            /// <summary>
            /// 病区名称
            /// </summary>
            public const string WARD_NAME = "WARD_NAME";

            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";

            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";

            /// <summary>
            /// 床位号
            /// </summary>
            public const string BED_NO = "BED_NO";

            /// <summary>
            /// 床位名称
            /// </summary>
            public const string BED_LABEL = "BED_LABEL";

            /// <summary>
            /// 编制类型
            /// </summary>
            public const string BED_APPROVED_TYPE = "BED_APPROVED_TYPE";

            /// <summary>
            /// 床类型
            /// </summary>
            public const string BED_SEX_TYPE = "BED_SEX_TYPE";

            /// <summary>
            /// 床位等级
            /// </summary>
            public const string BED_CLASS = "BED_CLASS";

            /// <summary>
            /// 床位状态
            /// </summary>
            public const string BED_STATUS = "BED_STATUS";
        }

        #endregion
    }
}