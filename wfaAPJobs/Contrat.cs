using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaAPJobs
{
    public class Contrat
    {
        private int idContrat;
        private string nomContrat;

        public Contrat(int _idContrat, string _nomContrat)
        {
            this.idContrat = _idContrat;
            this.nomContrat = _nomContrat;
        }

        public int getId()
        {
            return this.idContrat;
        }
        public string getNom()
        {
            return this.nomContrat;
        }
    }
}
