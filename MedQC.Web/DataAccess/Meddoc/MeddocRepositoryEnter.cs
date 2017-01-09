using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedQC.Web.DataAccess.Meddoc
{
    public class MeddocRepositoryEnter
    {  /// <summary>
       /// 统一SaveChange方法
       /// </summary>
       /// <returns></returns>
        public int SaveChange()
        {
            return MeddocDbContextFactory.GetCurrentDbContext().SaveChanges();
        }
        
        /// <summary>
        /// 时效规则
        /// </summary>
        public TimeRuleRepository TimeRuleRepository { get { return new TimeRuleRepository(); } }
        /// <summary>
        /// 获取文章仓储
        /// </summary>
        public QcArticleRepository QcArticleRepository { get { return new QcArticleRepository(); } }
        /// <summary>
        /// 缺陷点核查规则仓储
        /// </summary>
        public QcCheckPointRepository QcCheckPointRepository { get { return new QcCheckPointRepository(); } }
    }
}