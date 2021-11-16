using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Models.Context
{
    public class Dotnetsln5Context: DbContext
    {
        public Dotnetsln5Context(DbContextOptions<Dotnetsln5Context> options): base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
