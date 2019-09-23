using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecomSinqia.Models
{
	public class Recomendacao
	{
		private int _id;
		public virtual int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private Gerencia _gerencia;
		public virtual Gerencia Gerencia
		{
			get { return _gerencia; }
			set { _gerencia = value; }
		}

		public int GerenciaId { get; set; }

        private Cliente _cliente;
        public virtual Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public int ClienteId { get; set; }

        private Sistema _sistema;
        public virtual Sistema Sistema
        {
            get { return _sistema; }
            set { _sistema = value; }
        }

        public int SistemaId { get; set; }

        private Modulo _modulo;
        public virtual Modulo Modulo
        {
            get { return _modulo; }
            set { _modulo = value; }
        }

        public int ModuloId { get; set; }

        private Classificacao _classificacao;
		public virtual Classificacao Classificacao
		{
			get { return _classificacao; }
			set { _classificacao = value; }
		}

		public int ClassificacaoId { get; set; }

		private TipoFalha _tipoFalha;
		public virtual TipoFalha TipoFalha
		{
			get { return _tipoFalha; }
			set { _tipoFalha = value; }
		}

		public int TipoFalhaId { get; set; }

        private Prioridade _prioridade;
        public virtual Prioridade Prioridade
        {
            get { return _prioridade; }
            set { _prioridade = value; }
        }

        public int PrioridadeId { get; set; }

        private Dificuldade _dificuldade;
		public virtual Dificuldade Dificuldade
		{
			get { return _dificuldade; }
			set { _dificuldade = value; }
		}

		public int DificuldadeId { get; set; }		      

        private Colaborador _colaborador;
		public virtual Colaborador Colaborador
		{
			get { return _colaborador; }
			set { _colaborador = value; }
		}

		public int ColaboradorId { get; set; }

        private string _observacao;
        public virtual string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; }
        }

    }
}