using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedQC.Web.Models;

namespace MedQC.Web.EFDao
{
    public class OAuthUserRepository : BaseRepository<Models.OAuthUser>
    {
        /// <summary>
        /// 加载微信授权用户列表
        /// </summary>
        /// <param name="roleId">权限Id</param>
        /// <param name="mobile">手机号码</param>
        /// <param name="startNum">起始数字</param>
        /// <param name="pageSize">页长</param>
        /// <param name="IsDesc">是否倒序排列</param>
        /// <param name="rowCount">总个数</param>
        /// <returns></returns>
        public IQueryable<dynamic> LoadPageList(string Name, string Tel, int startNum, int pageSize, out int rowCount)
        {
            rowCount = 0;
            var result = from p in db.Set<Models.OAuthUser>()
                         select p;
            if (!string.IsNullOrEmpty(Tel))
            {
                result = result.Where(m => m.Tel.Contains(Tel));
            }
            if (!string.IsNullOrEmpty(Name))
            {
                result = result.Where(m => m.Name.Contains(Name) || m.NickName.Contains(Name));
            }
            result = result.OrderByDescending(m => m.CreateTime);

            rowCount = result.Count();
            return result.Skip(startNum).Take(pageSize);
        }
    }
}