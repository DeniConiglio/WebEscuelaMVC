using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Data
{
    public class EscuelaDBMVC:DbContext
    {
        public EscuelaDBMVC() : base("keyEscuelaDB") { }

        public DbSet<Aula> Aulas { get; set; }
    }
}