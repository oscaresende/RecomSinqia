using System;
using System.Collections.Generic;
using System.Data.Entity;
using RecomSinqia.Models;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Configuration;

namespace RecomSinqia.AcessoDados
{
	public class RecomSinqiaContexto : DbContext
	{
		public RecomSinqiaContexto() : base("name=RecomSinqiaContexto")
        {

		}
		public DbSet<Gerencia> Gerencia { get; set; }
		public DbSet<Classificacao> Classificacao { get; set; }
		public DbSet<TipoFalha> TipoFalha { get; set; }
		public DbSet<Prioridade> Prioridade { get; set; }
		public DbSet<Dificuldade> Dificuldade { get; set; }
		public DbSet<Colaborador> Colaborador { get; set; }
		public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Sistema> Sistema { get; set; }
        public DbSet<Recomendacao> Recomendacao { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));

		}		
		
	}
}