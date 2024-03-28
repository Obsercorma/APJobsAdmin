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
        private int _conformiteOffre = 0;
        private bool _estRetire = false;
        public readonly int idOffre;
        public readonly string intitOffre;
        public readonly Secteur secteur;
        public readonly string lieuTravail;
        public readonly Contrat contrat;
        public readonly DateTime debutPeriode;
        public readonly DateTime finPeriode;
        public readonly KeyValuePair<string,int> employeur;

        public static readonly int CONFORMITY_NOT_GIVEN = 0;
        public static readonly int CONFORMITY_VALIDATED = 1;
        public static readonly int CONFORMITY_UNVALIDATED = 2;

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
