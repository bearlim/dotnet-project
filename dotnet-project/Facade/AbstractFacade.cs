using Dapper;
using dotnet_project.Db;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace dotnet_project.Facade
{
    public abstract class AbstractFacade
    {
        protected SqlConnection conn;

        public AbstractFacade()
        {
            conn = SingletonDb.getConnection();
        }

        /// <summary>
        /// Realiza um Select generico
        /// </summary>
        /// <param name="sql"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected List<T> Select<T>(string sql, object param = null)
        {
            try
            {
                return conn.Query<T>(sql, param).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void OpenConnection()
        {
            if (conn?.State != ConnectionState.Open)
                conn?.Open();
        }

        protected void CloseConnection()
        {
            if (conn?.State != ConnectionState.Closed)
                conn?.Close();
        }

        
    }

    public static class AbstractFacadeMethods
    {
        public static List<T> ToList<T>(this Query query)
        {
            return query.Get<T>().ToList();
        }

        public static T FirstOrDefault<T>(this Query query)
        {
            return query.Get<T>().FirstOrDefault();
        }

        public static bool Any(this Query query)
        {
            return query.Get().Any();
        }

        public static bool Any<T>(this Query query)
        {
            return query.Get<T>().Any();
        }
}