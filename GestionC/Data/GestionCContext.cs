using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionC.Modelos;

namespace GestionC.Data
{
    public class GestionCContext : DbContext
    {
        public GestionCContext (DbContextOptions<GestionCContext> options)
            : base(options)
        {
        }

        public DbSet<GestionC.Modelos.Usuario>? Usuario { get; set; }
    }
}
