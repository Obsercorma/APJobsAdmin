using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaAPJobs
{
    public class Contrat
    {
        // Code type du contrat
        private int idContrat;

        // Type du contrat (nom).
        private string nomContrat;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_idContrat">Code type du contrat</param>
        /// <param name="_nomContrat">Type du contrat (nom)</param>
        public Contrat(int _idContrat, string _nomContrat)
        {
            this.idContrat = _idContrat;
            this.nomContrat = _nomContrat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne le code type du contrat</returns>
        public int getId()
        {
            return this.idContrat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne l'intitule du type renseigne</returns>
        public string getNom()
        {
            return this.nomContrat;
        }
    }
}
