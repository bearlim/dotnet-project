using dotnet_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotnet_project.Facade
{
    public class fcEmpresa : AbstractFacade
    {
        public List<Empresa> listarEmpresas()
        {
            String sql = "SELECT * FROM tb_EMPRESA";

            return Select<Empresa>(sql);
        } 
    }
}