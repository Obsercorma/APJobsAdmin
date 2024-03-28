using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wfaAPJobs.Properties;

namespace wfaAPJobs
{
    public class Secteur
    {
        /// <summary>
        /// Identifiant secteur d'activite
        /// </summary>
        private int idSecteur;
        /// <summary>
        /// Nom secteur d'activite
        /// </summary>
        private string nomSecteur;

        /// <summary>
        /// Secteur d'activite exploitable par un employeur.
        /// </summary>
        private bool secteurActif;

        public Secteur(int _idSecteur, string _nomSecteur, bool _secteurActif)
        {
            this.idSecteur = _idSecteur;
            this.nomSecteur = _nomSecteur;
            this.secteurActif = _secteurActif;
        }

        public int getId() => this.idSecteur;

        public string getNom() => this.nomSecteur;
        
        public string getEstActifAsText() => this.estActif ? "Oui" : "Non";

        public bool estActif
        {
            get
            {
                return this.secteurActif;
            }
            set
            {
                SqlConnector req = new SqlConnector();
                Dictionary<string, object> args = new Dictionary<string, object>();
                args.Add("@estActif", value);
                args.Add("@idAct", this.idSecteur);
                if (req.prepareAndExecNonQuery(Resources.REQ_UPDATE_ACTIVITY_DISPLAYING, args))
                {
                    this.secteurActif = value;
                }
                req.CloseDB();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne la liste de tous les secteurs d'activites depuis la DB.</returns>
        public static List<Secteur> getAll()
        {
            SqlConnector req = new SqlConnector();
            List<Secteur> secteurs = new List<Secteur>();
            List<Dictionary<string, object>> data = req.query(Resources.REQ_GETACTIVITIES); // NO LIMIT NEEDED NOW...

            foreach(Dictionary<string, object> dt in data)
            {
                secteurs.Add(new Secteur((int)dt["idAct"], dt["intitAct"].ToString(), bool.Parse(dt["estActif"].ToString())));
            }

            return secteurs;
        }
    }
}
