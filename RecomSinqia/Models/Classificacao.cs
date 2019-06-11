using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecomSinqia.Models
{
	public class Classificacao
	{
		private int _id;
		public virtual int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _nome;
		public virtual string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		private string _sigla;
		public virtual string Sigla
		{
			get { return _sigla; }
			set { _sigla = value; }
		}

		public override string ToString()
		{
			return Nome;
		}
	}
}