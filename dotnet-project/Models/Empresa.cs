using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotnet_project.Models
{
    public class Empresa
    {
        public int idEmpresa { get; set; }
        public string nmEmpresa { get; set; }
        public string nmRazaoSocial { get; set; }
        public string cdCNPJ { get; set; }

    }
}