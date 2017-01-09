using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedQC.Web.Models;
using MedQC.Web.Models.Meddoc;

namespace MedQC.Web.DataAccess.Meddoc
{
    public class QcArticleRepository : MeddocBaseRepository<Models.Meddoc.QcArticle>
    {

        /// <summary>
        /// 加载文章列表
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="startNum">起始数字</param>
        /// <param name="pageSize">页长</param>
        /// <param name="IsDesc">是否倒序排列</param>
        /// <param name="rowCount">总个数</param>
        /// <returns></returns>
        public IEnumerable<QcArticle> LoadPageList(string title, int categoryID, string categoryCode, string keywords, int startNum, int pageSize, out int rowCount)
        {
            rowCount = 0;
            var result = from p in db.Set<QcArticle>()
                         select new
                         {
                             p.CategoryCode,
                             p.Content,
                             p.CreateTime,
                             p.ID,
                             p.ImagePath,
                             p.Summary,
                             p.ModifyTime,
                             p.Title,
                             p.Keywords
                         };
            if (!string.IsNullOrEmpty(title))
            {
                result = result.Where(m => m.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(categoryCode))
            {
                result = result.Where(m => m.CategoryCode.Contains(categoryCode));
            }
            rowCount = result.Count();
            result = result.OrderByDescending(m => m.ModifyTime).Skip(startNum).Take(pageSize);

            string sql = result.ToString();
            return result.ToList().Select(m => new QcArticle()
            {
                ID = m.ID,
                CategoryCode = m.CategoryCode,
                Title = m.Title,
                ModifyTime = m.ModifyTime,
                Content = m.Content,
                ImagePath=m.ImagePath,
                Summary=m.Summary,
                CreateTime = m.CreateTime,
                Keywords=m.Keywords
            });
        }
        public IEnumerable<QcArticle> GetQcArticles(int memberID, string categoryCode, string order,int startNum,int pageSize,out int totalCount)
        {
            var result = from p in db.Set<QcArticle>()
                         select new
                         {
                             p.Content,
                             p.CategoryCode,
                             p.CreateTime,
                             p.ID,
                             p.ModifyTime,
                             p.Summary,
                             p.ImagePath,
                             p.Title,
                             p.ViewCount,
                             p.Keywords
                         };
            if (!string.IsNullOrEmpty(categoryCode))
            {
                result = result.Where(m => m.CategoryCode.Contains(categoryCode));
            }
            if (order == "latest")
                result = result.OrderByDescending(m => m.ModifyTime);
            else if (order == "hot")
                result = result.OrderByDescending(m => m.ViewCount);
            else
                result = result.OrderByDescending(m => m.ModifyTime);
            string sql = result.ToString();
            totalCount = result.Count();
            result = result.OrderByDescending(m => m.ModifyTime).Skip(startNum).Take(pageSize);
            return result.ToList().Select(m => new QcArticle()
            {
                ID = m.ID,
                Title = m.Title,
                ModifyTime = m.ModifyTime,
                Content = m.Content,
                ImagePath=m.ImagePath,
                Summary=m.Summary,
                CreateTime = m.CreateTime,
                ViewCount = m.ViewCount,
                CategoryCode = m.CategoryCode,
                Keywords=m.Keywords
            });
        }
        public QcArticle GetQcArticle(int id)
        {
            var result = from p in db.Set<QcArticle>()

                         select new
                         {
                             p.Content,
                             p.CategoryCode ,
                             p.CreateTime,
                             p.Summary,
                             p.ImagePath,
                             p.ID,
                             p.ModifyTime,
                             p.Title,
                             p.ViewCount,
                             p.Keywords
                         };
            result = result.Where(m => m.ID == id);
            return result.ToList().Select(m => new QcArticle()
            {
                ID = m.ID,
                Title = m.Title,
                ModifyTime = m.ModifyTime,
                Content = m.Content,
                Summary=m.Summary,
                ImagePath=m.ImagePath,
                CreateTime = m.CreateTime,
                ViewCount = m.ViewCount,
                CategoryCode = m.CategoryCode,
                Keywords=m.Keywords
            }).FirstOrDefault();
        }
    }
}