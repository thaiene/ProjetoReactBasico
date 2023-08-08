using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserCrudApi.Models;

namespace UserCrudApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Defina uma propriedade DbSet para cada tabela no banco de dados
        public DbSet<CadastroUsuario> CadastroUsuarios { get; set; }

        // Outras tabelas podem ser adicionadas aqui se necessário

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais de modelagem do banco de dados podem ser feitas aqui
        }
    }
}