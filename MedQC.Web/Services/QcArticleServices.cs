using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedQC.Web.Utility;
using MedQC.Web.Models.Meddoc;

namespace MedQC.Web
{
    public class QcArticleServices
    {
        /// <summary>
        /// 获取分页文章列表
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static List<QcArticle> GetQcArticles(int memberID,string categoryCode,string order, int page, int size, out int totalCount)
        {
            int skip = (page - 1) * size;
            var result = MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.GetQcArticles(memberID, categoryCode,order, skip,size,out totalCount).ToList();
            return result;
        }
        /// <summary>
        /// 获取分页文章列表
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static List<Models.Book> GetBooks(string categoryCode)
        {
            var result = EnterRepository.GetRepositoryEnter().BookRepository.GetBooks(categoryCode,string.Empty).ToList();
            return result;
        }
        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static QcArticle GetQcArticle(int id)
        {
            var result = MeddocEnterRepository.GetRepositoryEnter().QcArticleRepository.GetQcArticle(id);

            return result;
        }

    }
}