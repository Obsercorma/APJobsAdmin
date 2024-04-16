using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using wfaAPJobs.Properties;

namespace wfaAPJobs
{
    public class Offre
    {
        // Etat de conformite de l'offre
        private int _conformiteOffre = 0;

        // Etat de retrait de l'offre
        private bool _estRetire = false;
        
        // Identifiant de l'offre
        public readonly int idOffre;

        // Intitule de l'offre
        public readonly string intitOffre;

        // Objet vers le secteur d'activite associe
        public readonly Secteur secteur;

        // Lieu de travail
        public readonly string lieuTravail;

        // Objet vers le type de contrat associe
        public readonly Contrat contrat;

        // Date: Debut de la periode
        public readonly DateTime debutPeriode;

        // Date: Fin de la periode
        public readonly DateTime finPeriode;

        // Nom et identifiant de l'employeur.
        public readonly KeyValuePair<string,int> employeur;

        // Constante: Etat de conformite -> etat par defaut (Offre n'etant pas validee explicitement.
        public static readonly int CONFORMITY_NOT_GIVEN = 0;

        // Constante: Etat de conformite -> Offre validee explicitement
        public static readonly int CONFORMITY_VALIDATED = 1;

        // Constante: Etat de conformite -> Offre non conforme
        public static readonly int CONFORMITY_UNVALIDATED = 2;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_idOffre">Identifiant de l'offre</param>
        /// <param name="_intitOffre">Intitule de l'offre</param>
        /// <param name="_secteur">objet: Secteur d'activite</param>
        /// <param name="_lieuTravail">Lieu de travail</param>
        /// <param name="_contrat">objet: Type de contrat</param>
        /// <param name="_debutPeriode">objet: Date de debut de la periode</param>
        /// <param name="_finPeriode">objet: Date de fin de la periode</param>
        /// <param name="_employeur">objet cle-valeur unique: Nom et identifiant l'employeur (provenant d'un compte utilisateur)</param>
        /// <param name="conformiteOffre">Indicateur booleen: Conformite de l'offre</param>
        /// <param name="estRetire">Indicateur booleen: Etat de retrait de l'offre</param>
        public Offre(
            int _idOffre,
            string _intitOffre,
            Secteur _secteur,
            string _lieuTravail,
            Contrat _contrat,
            DateTime _debutPeriode,
            DateTime _finPeriode,
            KeyValuePair<string,int> _employeur,
            int conformiteOffre,
            bool estRetire
        )
        {
            this.idOffre = _idOffre;
            this.intitOffre = _intitOffre;
            this.secteur = _secteur;
            this.contrat = _contrat;
            this.debutPeriode = _debutPeriode;
            this.finPeriode = _finPeriode;
            this.employeur = _employeur;
            this._conformiteOffre = conformiteOffre;
            this._estRetire = estRetire;
        }

        /// <summary>
        /// Accesseur (R/W): Indique et met a jour la validitee de l'offre.
        /// </summary>
        public int conformiteOffre
        {
            get
            {
                return this._conformiteOffre;
            }
            set
            {
                SqlConnector req = new SqlConnector();
                Dictionary<string, object> args = new Dictionary<string, object>();
                args.Add("@estValide", value);
                args.Add("@id", this.idOffre);
                if (req.prepareAndExecNonQuery(Resources.REQ_UPDATE_OFFER_VALIDITY, args))
                {
                    this._conformiteOffre = value;
                }
                req.CloseDB();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne la traduction du code de conformite renseigne.</returns>
        public string getTypeConformite()
        {
            switch (this.conformiteOffre)
            {
                case 0:
                    return "En attente";
                case 1:
                    return "Conforme";
                default:
                    return "Non conforme";
            }
        }

        /// <summary>
        /// Accesseur (R/W): Indique et met a jour l'etat de retrait de l'offre.
        /// </summary>
        public bool estRetire
        {
            get
            {
                return this._estRetire;
            }
            set
            {
                SqlConnector req = new SqlConnector();
                Dictionary<string, object> args = new Dictionary<string, object>();
                args.Add("@estRetire", value);
                args.Add("@id", this.idOffre);
                if (req.prepareAndExecNonQuery(Resources.REQ_UPDATE_OFFER_DISPLAYING, args))
                {
                    this._estRetire = value;
                }
                req.CloseDB();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne la liste des offres depuis la BDD.</returns>
        public static List<Offre> getAllOffers()
        {
            SqlConnector req = new SqlConnector();
            List<Offre> offres = new List<Offre>();
            List<Dictionary<string,object>> data = req.query(Resources.REQ_GETOFFERS); // NO LIMIT NEEDED NOW...

            foreach (Dictionary<string,object> result in data)
            {
                Contrat contrat = new Contrat(int.Parse(result["idContrat"].ToString()), result["intitContrat"].ToString());
                Secteur secteur = new Secteur(int.Parse(result["idAct"].ToString()), result["intitAct"].ToString(), bool.Parse(result["estActif"].ToString()));
                DateTime finPeriode;
                DateTime.TryParse(result["finPeriod"].ToString(), out finPeriode);
                offres.Add(new Offre(
                    (int) result["idOffre"],
                    result["intitoffre"].ToString(),
                    secteur,
                    result["lieuTravail"].ToString(),
                    contrat,
                    DateTime.Parse(result["debutPeriod"].ToString()),
                    finPeriode,
                    new KeyValuePair<string, int>(result["nom"].ToString(), (int) result["idEmployeur"]),
                    int.Parse(result["estValide"].ToString()),
                    (bool) result["estRetire"]
                ));
            }
            return offres;
        }
    }
}
