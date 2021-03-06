﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedQC.Web.Models;

namespace MedQC.Web.IBatisAccess
{
    public class SysMenuDao:BaseDao
    {
        private const string databaseName = SystemConst.SqlMapperConfig.SysSqlMapConfig;

        private static SysMenuDao m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static SysMenuDao Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new SysMenuDao();
                return SysMenuDao.m_Instance;
            }
        }
        public IList<SysMenu> GetSysMenus(SysMenu SysMenu)
        {
            var reValue =base.GetSqlMapper(databaseName).QueryForList<SysMenu>("SysConfig.SysMenu.GetSysMenus", SysMenu);
            logger.Debug("GetSysMenus:" + (reValue == null ? 0 : reValue.Count));
            return reValue;
        }
        
        public SysMenu QueryOne(int ID)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("ID", ID);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysMenu.QueryOne", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysMenu>("SysConfig.SysMenu.QueryOne", hashTable);
            
            return (SysMenu)reValue.FirstOrDefault();
        }
        public List<SysMenu> GetChildNodes(int ParentID,int UserID)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("ParentID", ParentID);
            hashTable.Add("UserID", UserID);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysMenu.GetChildNodes", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysMenu>("SysConfig.SysMenu.GetChildNodes", hashTable);

            return reValue.ToList();
        }

        public bool Insert(SysMenu SysMenu)
        {
            try
            {
                var result = base.GetSqlMapper(databaseName).Insert("SysConfig.SysMenu.Insert", SysMenu);
                SysMenu.ID = int.Parse(result.ToString());
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool Update(SysMenu SysMenu)
        {
            try
            {
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysMenu.Update", SysMenu);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysMenu.Update", SysMenu);
                
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                Hashtable hashTable = new Hashtable();
                hashTable.Add("ID", id);
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysMenu.Delete", hashTable);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysMenu.Delete", hashTable);

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }

        public IList<SysMenu> GetMenusByUserID(int UserID)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("UserID", UserID);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysMenu.GetMenusByUserID", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysMenu>("SysConfig.SysMenu.GetMenusByUserID", hashTable);

            return reValue;
        }

        public bool InsertUserMenu(int userid, int menuid)
        {
            try
            {

                Hashtable hashTable = new Hashtable();
                hashTable.Add("userid", userid);
                hashTable.Add("menuid", menuid);
                var result = base.GetSqlMapper(databaseName).Insert("SysConfig.SysMenu.InsertUserMenu", hashTable);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool DeleteUserMenu(int userid)
        {
            try
            {
                Hashtable hashTable = new Hashtable();
                hashTable.Add("userid", userid);
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysMenu.DeleteUserMenu", hashTable);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysMenu.DeleteUserMenu", hashTable);

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }


        public IList<SysMenu> GetMenusByRoleID(int RoleID)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("RoleID", RoleID);
            string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysMenu.GetMenusByRoleID", hashTable);
            var reValue = base.GetSqlMapper(databaseName).QueryForList<SysMenu>("SysConfig.SysMenu.GetMenusByRoleID", hashTable);

            return reValue;
        }

        public bool InsertRoleMenu(int roleid, int menuid)
        {
            try
            {

                Hashtable hashTable = new Hashtable();
                hashTable.Add("roleid", roleid);
                hashTable.Add("menuid", menuid);
                var result = base.GetSqlMapper(databaseName).Insert("SysConfig.SysMenu.InsertRoleMenu", hashTable);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool DeleteRoleMenu(int roleid)
        {
            try
            {
                Hashtable hashTable = new Hashtable();
                hashTable.Add("roleid", roleid);
                string sql = IBatisHelper.GetRuntimeSql(base.GetSqlMapper(databaseName), "SysConfig.SysMenu.DeleteRoleMenu", hashTable);
                base.GetSqlMapper(databaseName).Update("SysConfig.SysMenu.DeleteRoleMenu", hashTable);

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
    }
}
