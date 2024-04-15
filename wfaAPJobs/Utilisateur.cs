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
        // Identifiant Utilisateur
        private int id;

        // Civilite de l'utilisateur
        private int civilite;

        // Nom et prenom de l'utilisateur
        private string nom, prenom;

        // Indicateur: Utilisateur est banni
        private bool estBanni;

        // Adresse email de l'utilisateur
        private string email;

        // Numero de telephone de l'utilisateur
        private string tel;

        // Chemin d'acces au CV de l'utilisateur (spécialement pour l'etudiant).
        private string cv = null;

        // Statut de l'utilisateur (Etudiant, Employeur particulier/professionnel).
        private int statut;

        /// <summary>
        /// Constructeur Utilisateur: Professionnel (WithCoords)
        /// </summary>
        /// <param name="_id">Identifiant Utilisateur</param>
        /// <param name="_civilite">Civilite de l'utilisateur</param>
        /// <param name="_nom">Nom de l'utilisateur</param>
        /// <param name="_prenom">Prenom de l'utilisateur</param>
        /// <param name="_email">Adresse email de l'utilisateur</param>
        /// <param name="_tel">Numero de telephone de l'utilisateur</param>
        /// <param name="_statut">Statut de l'utilisateur (Etudiant, Employeur...)</param>
        public Utilisateur(
            int _id,
            int _civilite,
            string _nom,
            string _prenom,
            string _email,
            string _tel,
            int _statut,
            bool _estBanni
        )
        {
            this.id = _id;
            this.civilite = _civilite;
            this.nom = _nom;
            this.prenom = _prenom;
            this.email = _email;
            this.tel = _tel;
            this.estBanni = _estBanni;
            this.statut = _statut;
        }
        /// <summary>
        /// Constructeur Utilisateur: Professionnel (WithoutCoords)
        /// </summary>
        /// <param name="_id">Identifiant Utilisateur</param>
        /// <param name="_civilite">Civilite de l'utilisateur</param>
        /// <param name="_nom">Nom de l'utilisateur</param>
        /// <param name="_prenom">Prenom de l'utilisateur</param>
        /// <param name="_statut">Statut de l'utilisateur (Etudiant, Employeur...)</param>
        /// <param name="_estBanni">Indicateur: Utilisateur est banni</param>
        public Utilisateur(
            int _id,
            int _civilite,
            string _nom,
            string _prenom,
            int _statut,
            bool _estBanni
        )
        {
            this.id = _id;
            this.civilite = _civilite;
            this.nom = _nom;
            this.prenom = _prenom;
            this.email = "";
            this.tel = "";
            this.estBanni = _estBanni;
            this.statut = _statut;
        }

        /// <summary>
        /// Constructeur Utilisateur: Etudiant (WithoutCoords)
        /// </summary>
        /// <param name="_id">Identifiant Utilisateur</param>
        /// <param name="_civilite">Civilite de l'utilisateur</param>
        /// <param name="_nom">Nom de l'utilisateur</param>
        /// <param name="_prenom">Prenom de l'utilisateur</param>
        /// <param name="_statut">Statut de l'utilisateur (Etudiant, Employeur...)</param>
        /// <param name="_estBanni">Indicateur: Utilisateur est banni</param>
        /// <param name="_cv">Chemin d'acces au CV</param>
        public Utilisateur(
            int _id,
            int _civilite,
            string _nom,
            string _prenom,
            string _cv,
            int _statut,
            bool _estBanni
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
            this.estBanni = _estBanni;
        }
        /// <summary>
        /// Constrcteur Utilisateur: Etudiant (WithCoords)
        /// </summary>
        /// <param name="_id">Identifiant Utilisateur</param>
        /// <param name="_civilite">Civilite de l'utilisateur</param>
        /// <param name="_nom">Nom de l'utilisateur</param>
        /// <param name="_prenom">Prenom de l'utilisateur</param>
        /// <param name="_statut">Statut de l'utilisateur (Etudiant, Employeur...)</param>
        /// <param name="_estBanni">Indicateur: Utilisateur est banni</param>
        /// <param name="_cv">Chemin d'acces au CV</param>
        /// <param name="_email">Adresse email de l'utilisateur</param>
        /// <param name="_tel">Numero de telephone de l'utilisateur</param>
        public Utilisateur(
            int _id,
            int _civilite,
            string _nom,
            string _prenom,
            string _email,
            string _tel,
            string _cv,
            int _statut,
            bool _estBanni
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
            this.estBanni = _estBanni;
        }

        /// <summary>
        /// Recuperation de l'identifiant utilisateur
        /// </summary>
        /// <returns>retourne l'identifiant de l'utilisateur</returns>
        public int getId()
        {
            return this.id;
        }

        /// <summary>
        /// Recuperation de la civilite de l'utilisateur
        /// </summary>
        /// <returns>retourne la civilite sous forme d'entier</returns>
        public int getIdCivilite()
        {
            return this.civilite;
        }

        /// <summary>
        /// Recuperation du statut utilisateur (Employeur, Etudiant...)
        /// </summary>
        /// <returns>Retourne le statut Utilisateur</returns>
        public int getIdStatut()
        {
            return this.statut;
        }

        /// <summary>
        /// Recuperation du statut utilisateur
        /// </summary>
        /// <returns>Retourne la traduction de l'ID du statut utilisateur</returns>
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
        /// Recuperation de la civilite
        /// </summary>
        /// <returns>Retourne la traduction de l'ID de la civilite</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne le nom de l'utilisateur</returns>
        public string getNom()
        {
            return this.nom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>retourne le prenom de l'utilisateur</returns>
        public string getPrenom()
        {
            return this.prenom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne l'adresse email de l'utilisateur</returns>
        public string getEmail()
        {
            return this.email;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne le numero de telephone de l'utilisateur</returns>
        public string getTel()
        {
            return this.tel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne le chemin d'acces du CV (Retourne null si l'utilisateur n'est pas un etudiant).</returns>
        public string getCV()
        {
            return this.cv;
        }

        /// <summary>
        /// SET: Met a jour l'indicateur booleen : "Est bannie".
        /// GET: retourne l'indicateur booleen.
        /// </summary>
        public bool compteBanni
        {
            get
            {
                return this.estBanni;
            }
            set
            {
                SqlConnector req = new SqlConnector();
                Dictionary<string, object> args = new Dictionary<string, object>();
                args.Add("@isBan", value);
                args.Add("@idUser", this.id);
                if (req.prepareAndExecNonQuery(Resources.REQ_BAN_OR_UNBAN_ACCOUNT, args))
                    this.estBanni = value;
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
