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

        // Identifiant secteur d'activite
        private int idSecteur;

        /// Nom secteur d'activite
        private string nomSecteur;

        /// Secteur d'activite exploitable par un employeur.
        private bool secteurActif;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_idSecteur">Identifiant du secteur d'activite</param>
        /// <param name="_nomSecteur">Nom du secteur d'activite</param>
        /// <param name="_secteurActif">Etat d'utilisation du secteur d'activite</param>
        public Secteur(int _idSecteur, string _nomSecteur, bool _secteurActif)
        {
            this.idSecteur = _idSecteur;
            this.nomSecteur = _nomSecteur;
            this.secteurActif = _secteurActif;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne l'identifiant du secteur d'activite</returns>
        public int getId() => this.idSecteur;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne le nom du secteur d'activite</returns>
        public string getNom() => this.nomSecteur;
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne l'etat d'utilisation du secteur d'activite sous forme de chaine (Oui/Non)</returns>
        public string getEstActifAsText() => this.estActif ? "Oui" : "Non";

        /// <summary>
        /// SET: Met a jour l'etat d'utilisation du secteur d'activite dans l'objet et la BDD
        /// GET: Retourne l'etat d'utilisation du secteur d'activite
        /// </summary>
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
