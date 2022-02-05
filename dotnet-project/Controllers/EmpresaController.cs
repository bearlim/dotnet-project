using dotnet_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dotnet_project.Facade;

namespace dotnet_project.Controllers
{
    public class EmpresaController : Controller
    {
        fcEmpresa fcEmpresa = new fcEmpresa();
        public ActionResult Index()
        {
            ViewBag.Empresas = fcEmpresa.listarEmpresas();
            return View();
        }
    }
}