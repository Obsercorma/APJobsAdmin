using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaAPJobs
{
    public class StatutCandidature
    {
        // Identifiant du statut de candidature
        public readonly int idStatut;

        // Description du statut de candidature
        public readonly string descStatut;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_idStatut">Identifiant du statut de candidature</param>
        public StatutCandidature(int _idStatut)
        {
            this.idStatut = _idStatut;
            switch (_idStatut)
            {
                case 1:
                    this.descStatut = "En attente"; break;
                case 2:
                    this.descStatut = "Validée"; break;
                default:
                    this.descStatut = "Refusée"; break;
            }
        }

    }
}
