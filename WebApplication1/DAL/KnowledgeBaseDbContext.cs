using System.Data.Entity;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    public class KnowledgeBaseDbContext : DbContext
    {
        public KnowledgeBaseDbContext() : base("DefaultConnection") { }
        public DbSet<Entidade> Entidades { get; set; }
    }
}