using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cw12_git.Model;

namespace Cw12_git.Data
{
    public class Cw12_gitContext : DbContext
    {
        public Cw12_gitContext (DbContextOptions<Cw12_gitContext> options)
            : base(options)
        {
        }

        public DbSet<Cw12_git.Model.Rezerwacja> Rezerwacja { get; set; } = default!;
    }
}
