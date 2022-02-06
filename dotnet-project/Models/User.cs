using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dotnet_project.Models
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        [Display(Name = "Usuário", ShortName = "User")]
        public string nmLogin { get; set; }
        [Display(Name = "Senha", ShortName = "Pass")]
        public string dsSenha { get; set; }

    }
}