using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfaAPJobs
{
    public class StatutCandidature
    {
        public readonly int idStatut;
        public readonly string descStatut;

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
