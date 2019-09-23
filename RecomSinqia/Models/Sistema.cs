using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecomSinqia.Models
{
    public class Sistema
    {
        private int _id;
        public int Id
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
    }
}