using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web
{
    public struct SystemConst
    {
        public struct SqlMapperConfig
        {
            public const string AESqlMapConfig = "Maps/AESqlMap.config";

            public const string MeddocSqlMapConfig = "Maps/MeddocSqlMap.config";

            public const string SysSqlMapConfig = "Maps/SysConfigSqlMap.config";

            public const string OperationSqlMapConfig = "Maps/OperationSqlMap.config";

        }
        public struct OperationParameter
        {
            /// <summary>
            /// 手术质量
            /// </summary>
            public const string operation = "operation";
            /// <summary>
            /// 手术名称中包含关键字
            /// </summary>
            public const string operation_name_keys = "operation_name_keys";
            /// <summary>
            /// 过滤字符
            /// </summary>
            public const string filtering_characters = "filtering_characters";
            /// <summary>
            /// 并发症类型
            /// </summary>
            public const string complication_type = "complication_type";
            /// <summary>
            /// 手术名称中字符一致个数
            /// </summary>
            public const string operation_keys_count = "operation_keys_count";
            /// <summary>
            /// 二次手术判断条件
            /// </summary>
            public const string reoperation_judge_condition = "reoperation_judge_condition";
            /// <summary>
            /// 医嘱关键字
            /// </summary>
            public const string order_keywords = "order_keywords";
            /// <summary>
            /// 病历问题
            /// </summary>
            public const string medical_history_problem = "medical_history_problem";
            /// <summary>
            /// 预警条件
            /// </summary>
            public const string warning_condition = "warning_condition";
            /// <summary>
            /// 手术后预警天数
            /// </summary>
            public const string post_operative_warning_days = "post_operative_warning_days";
            /// <summary>
            /// 体温度数
            /// </summary>
            public const string temperature_degree = "temperature_degree";
            /// <summary>
            /// 手后天数
            /// </summary>
            public const string operation_days = "operation_days";
            /// <summary>
            /// 二次手术预警判断条件
            /// </summary>
            public const string two_operation_early_warning_judgment_condition = "two_operation_early_warning_judgment_condition";
            /// <summary>
            /// 患者重返原因
            /// </summary>
            public const string patients_return_reason = "patients_return_reason";
            /// <summary>
            /// 重返指标相关参数
            /// </summary>
            public const string return_parameters = "return_parameters";
            /// <summary>
            /// 二次手术预警病历过滤
            /// </summary>
            public const string two_surgical_early_warning_medical_records_filtering = "two_surgical_early_warning_medical_records_filtering";
            /// <summary>
            /// 出院疑似并发症判断条件设置
            /// </summary>
            public const string complication_judge_condition = "complication_judge_condition";
            /// <summary>
            /// 并发症关键字
            /// </summary>
            public const string complication_keys = "complication_keys";

        }
        /// <summary>
        /// 文章类别代码
        /// </summary>
        public struct CategoryCode
        {
            /// <summary>
            /// 规章制度
            /// </summary>
            public const string guizhangzhidu = "guizhangzhidu";
            /// <summary>
            /// 治疗常规
            /// </summary>
            public const string zhiliaochanggui = "zhiliaochanggui";
            /// <summary>
            /// 病历书写规范
            /// </summary>
            public const string binglishuxieguifan = "binglishuxieguifan";
            public static string GetCategoryName(string categoryCode) {
                string categroyName = string.Empty;
                switch (categoryCode)
                {
                    case CategoryCode.guizhangzhidu:
                        categroyName = "规章制度";
                        break;
                    case CategoryCode.zhiliaochanggui:
                        categroyName = "治疗常规";
                        break;
                    case CategoryCode.binglishuxieguifan:
                        categroyName = "病历书写规范";
                        break;

                    default:
                        break;
                }
                return categroyName;
            }
            /// <summary>
            /// 服务帮助
            /// </summary>
            public const string Help = "help";
            /// <summary>
            /// 常见问题解答
            /// </summary>
            public const string HelpAsk = "help-ask";
            /// <summary>
            /// 考生注意事项
            /// </summary>
            public const string HelpZhuyi = "help-zhuyi";
            /// <summary>
            /// 酒店入住
            /// </summary>
            public const string HelpRuzhu = "help-ruzhu";

            /// <summary>
            /// 资讯
            /// </summary>
            public const string News = "news";
            /// <summary>
            /// 官网公告
            /// </summary>
            public const string NewsGongGao = "news-gonggao";
            /// <summary>
            /// 考试资料
            /// </summary>
            public const string NewsExamData = "news-examdata";
            /// <summary>
            /// 复习秘籍
            /// </summary>
            public const string NewsReview = "news-review";
            /// <summary>
            /// 成绩查询
            /// </summary>
            public const string NewsScore = "news-score";
            /// <summary>
            /// 考试经验
            /// </summary>
            public const string NewsJingyan = "news-jingyan";

            /// <summary>
            /// 关于我们
            /// </summary>
            public const string About = "about";
            /// <summary>
            /// 关于我们
            /// </summary>
            public const string AboutUs = "about-us";
            /// <summary>
            /// 联系我们
            /// </summary>
            public const string AboutContact = "about-contact";
            /// <summary>
            /// 加入我们
            /// </summary>
            public const string AboutJoin = "about-join";
            /// <summary>
            /// 营业执照
            /// </summary>
            public const string AboutCard = "about-card";

            /// <summary>
            /// 酒店推荐
            /// </summary>
            public const string Hotel = "hotel";
            /// <summary>
            /// 三星级
            /// </summary>
            public const string HotelThree = "hotel-three";
            /// <summary>
            /// 四星级
            /// </summary>
            public const string HotelFour = "hotel-four";
            /// <summary>
            /// 五星级
            /// </summary>
            public const string HotelFive = "hotel-five";
            /// <summary>
            /// 普通旅馆
            /// </summary>
            public const string HotelNormal = "hotel-normal";


            /// <summary>
            /// 培训
            /// </summary>
            public const string Train = "train";

            /// <summary>
            /// 书籍
            /// </summary>
            public const string Book = "book";
            /// <summary>
            /// 数学
            /// </summary>
            public const string BookMath = "book-math";
            /// <summary>
            /// 英语
            /// </summary>
            public const string BookEnglish = "book-english";
            /// <summary>
            /// 政治
            /// </summary>
            public const string BookPolity = "book-polity";
            /// <summary>
            /// 计算机
            /// </summary>
            public const string BookComputer = "book-computer";

            /// <summary>
            /// 博客
            /// </summary>
            public const string Blog = "blog";
            /// <summary>
            /// 博客-心情随笔
            /// </summary>
            public const string BolgSuibi = "blog-suibi";
            /// <summary>
            /// 博客-考试日记
            /// </summary>
            public const string BolgKaoshi = "blog-kaoshi";
            /// <summary>
            /// 博客-视频
            /// </summary>
            public const string BlogVideo = "blog-video";
            /// 博客-美图
            /// </summary>
            public const string BlogPicture = "blog-picture";


            /// <summary>
            /// 广告推广
            /// </summary>
            public const string Advert = "advert";
            /// <summary>
            /// 淘宝活动
            /// </summary>
            public const string AdvertHuodong = "advert-huodong";



        }
    }
}