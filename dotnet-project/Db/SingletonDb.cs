using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace dotnet_project.Db
{
    public class SingletonDb
    {
        /// <summary>
        /// O objeto intance é a instância única da própria classe SingletonConexao;
        /// Seu modificador "readonly", determina que o mesmo só pode ser alterado na sua declaração ou dentro de um método construtor.
        /// </summary>
        private static readonly SingletonDb instance = new SingletonDb();

        /// <summary>
        /// Construtor privado para não permir que outras classes consiguam estaciar a SingletonConexao diretamente.
        /// </summary>
        private SingletonDb() { }

        /// <summary>
        /// Este método é a única forma das classes externas conseguirem acessar está classe.
        /// </summary>
        /// <returns>Retorna o variavel instance, que contém a instancia desta classe.</returns>
        public static SingletonDb getInstance()
        {
            return instance;
        }
        /// <summary>
        /// Este método a responsavel por instanciar uma nova conexão, passando por parâmetro a String de conexão.
        /// </summary>
        /// <returns>Retorna uma conexão com o banco de dados já preparada para se conectar.</returns>
        public static SqlConnection getConnection()
        {
            SqlConnection sqlConn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=db_aspnet;Data Source=DESKTOP-A5LEM6K\SQLEXPRESS");
            return sqlConn;
        }
    }
}