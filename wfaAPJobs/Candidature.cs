using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wfaAPJobs.Properties;

namespace wfaAPJobs
{
    public class Candidature
    {
        // Compte utilisateur: Etudiant associe a la candidature.
        public readonly Utilisateur candidat;

        // Compte Utilisateur: Employeur associe a la candidature.
        public readonly Utilisateur employeur;

        // Statut de la candidature.
        public readonly StatutCandidature statutCandidat;

        // Offre associe a la candidature.
        public readonly Offre offreCandidature;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_candidat">Objet: Compte utilisateur: Etudiant associe a la candidature.</param>
        /// <param name="_statutCandidature">Objet: Statut de la candidature.</param>
        /// <param name="_offreCandidature">Offre associe a la candidature.</param>
        /// <param name="_employeur">Objet: Compte Utilisateur: Employeur associe a la candidature.</param>
        public Candidature(Utilisateur _candidat, StatutCandidature _statutCandidature, Offre _offreCandidature, Utilisateur _employeur)
        {
            this.candidat = _candidat;
            this.statutCandidat = _statutCandidature;
            this.offreCandidature = _offreCandidature;
            this.employeur = _employeur;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retourne la liste des candidatures depuis la DB.</returns>
        public static List<Candidature> getAll()
        {
            SqlConnector req = new SqlConnector();
            List<Candidature> candidatures = new List<Candidature>();
            List<Dictionary<string, object>> data = req.query(Resources.REQ_GET_CANDIDATURES); // NO LIMIT NEEDED NOW...

            foreach(Dictionary<string,object> dt in data)
            {
                Utilisateur candidat = new Utilisateur(int.Parse(dt["idUser"].ToString()), int.Parse(dt["civilite"].ToString()), dt["nom"].ToString(), dt["prenom"].ToString(), dt["email"].ToString(), dt["tel"].ToString(), int.Parse(dt["idStatut"].ToString()), bool.Parse(dt["isBan"].ToString()));
                Utilisateur employeur = new Utilisateur(int.Parse(dt["idEmployeur"].ToString()), int.Parse(dt["civEmployeur"].ToString()), dt["nomEmployeur"].ToString(), dt["prenomEmployeur"].ToString(), int.Parse(dt["idStatut"].ToString()), bool.Parse(dt["isBan"].ToString()));
                Offre offreConcernee = Program.listOffers.Where(elem => (elem.idOffre == (int)dt["idOffre"])).ToList()[0];
                candidatures.Add(new Candidature(candidat, new StatutCandidature(int.Parse(dt["idStatut"].ToString())), offreConcernee, employeur));
            }

            return candidatures;
        }
    }
}
