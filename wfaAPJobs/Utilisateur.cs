using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wfaAPJobs.Properties;

namespace wfaAPJobs
{
    public class Utilisateur
    {
        private int id;
        private int civilite;
        private string nom, prenom;
        private bool estBannie;
        private string email;
        private string tel;
        private string cv;
        private int statut;

        /// <summary>
        /// Constructeur Utilisateur: Professionnel (WithCoords)
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_civilite"></param>
        /// <param name="_nom"></param>
        /// <param name="_prenom"></param>
        /// <param name="_email"></param>
        /// <param name="_tel"></param>
        public Utilisateur(
            int _id,
            int _civilite,
            string _nom,
            string _prenom,
            string _email,
            string _tel,
            int _statut,
            bool _estBannie
        )
        {
            this.id = _id;
            this.civilite = _civilite;
            this.nom = _nom;
            this.prenom = _prenom;
            this.email = _email;
            this.tel = _tel;
            this.estBannie = _estBannie;
            this.statut = _statut;
        }
        /// <summary>
        /// Constructeur Utilisateur: Professionnel (WithoutCoords)
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_civilite"></param>
        /// <param name="_nom"></param>
        /// <param name="_prenom"></param>
        public Utilisateur(
            int _id,
            int _civilite,
            string _nom,
            string _prenom,
            int _statut,
            bool _estBannie
        )
        {
            this.id = _id;
            this.civilite = _civilite;
            this.nom = _nom;
            this.prenom = _prenom;
            this.email = "";
            this.tel = "";
            this.estBannie = _estBannie;
            this.statut = _statut;
        }

        /// <summary>
        /// Constructeur Utilisateur: Etudiant (WithoutCoords)
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_civilite"></param>
        /// <param name="_nom"></param>
        /// <param name="_prenom"></param>
        /// <param name="_cv"></param>
        public Utilisateur(
            int _id,
            int _civilite,
            string _nom,
            string _prenom,
            string _cv,
            int _statut,
            bool _estBannie
        )
        {
            this.id = _id;
            this.civilite = _civilite;
            this.nom = _nom;
            this.prenom = _prenom;
            this.email = "";
            this.tel = "";
            this.cv = _cv;
            this.statut = _statut;
            this.estBannie = _estBannie;
        }
        /// <summary>
        /// Constrcteur Utilisateur: Etudiant (WithCoords)
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_civilite"></param>
        /// <param name="_nom"></param>
        /// <param name="_prenom"></param>
        /// <param name="_email"></param>
        /// <param name="_tel"></param>
        /// <param name="_cv"></param>
        public Utilisateur(
            int _id,
            int _civilite,
            string _nom,
            string _prenom,
            string _email,
            string _tel,
            string _cv,
            int _statut,
            bool _estBannie
        )
        {
            this.id = _id;
            this.civilite = _civilite;
            this.nom = _nom;
            this.prenom = _prenom;
            this.email = _email;
            this.tel = _tel;
            this.cv = _cv;
            this.statut = _statut;
            this.estBannie = _estBannie;
        }

        public int getId()
        {
            return this.id;
        }

        public int getIdCivilite()
        {
            return this.civilite;
        }
        public int getIdStatut()
        {
            return this.statut;
        }
        public string getStatut()
        {
            switch (this.statut)
            {
                case 1:
                    return "Étudiant";
                case 2:
                    return "Particulier PRO.";
                default:
                    return "Professionnel";
            }
        }
        /// <summary>
        /// Retourne "M.", "Mme" en fonction de l'ID de civilite.
        /// </summary>
        /// <returns></returns>
        public string getCivilite()
        {
            switch (this.civilite)
            {
                case 1:
                    return "M.";
                case 2:
                    return "Mme";
                default:
                    return "~.";
            }
        }
        public string getNom()
        {
            return this.nom;
        }
        public string getPrenom()
        {
            return this.prenom;
        }
        public string getEmail()
        {
            return this.email;
        }
        public string getTel()
        {
            return this.tel;
        }
        public string getCV()
        {
            return this.cv;
        }

        public bool compteBanni
        {
            get
            {
                return this.estBannie;
            }
            set
            {
                SqlConnector req = new SqlConnector();
                Dictionary<string, object> args = new Dictionary<string, object>();
                args.Add("@isBan", value);
                args.Add("@idUser", this.id);
                if (req.prepareAndExecNonQuery(Resources.REQ_BAN_OR_UNBAN_ACCOUNT, args))
                    this.estBannie = value;
                req.CloseQuery();
                req.CloseDB();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne la liste de tout les utilisateurs</returns>
        public static List<Utilisateur> getAll()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            SqlConnector req = new SqlConnector();
            List<Dictionary<string,object>> data = req.query(Resources.REQ_GET_ACCOUNTS);

            foreach(Dictionary<string,object> dt in data)
            {
                utilisateurs.Add(new Utilisateur(
                    int.Parse(dt["idUser"].ToString()),
                    int.Parse(dt["civilite"].ToString()),
                    dt["nom"].ToString(),
                    dt["prenom"].ToString(),
                    dt["email"].ToString(),
                    dt["tel"].ToString(),
                    dt["cvUser"].ToString(),
                    int.Parse(dt["idStatut"].ToString()),
                    bool.Parse(dt["isBan"].ToString())
                ));
            }
            req.CloseQuery();
            req.CloseDB();

            return utilisateurs;
        }
    }
}
