using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaAPJobs
{
    public static class Program
    {
        // Liste des offres.
        public static List<Offre> listOffers;

        // Liste de tout les types de contrats.
        public static List<Contrat> listContracts;

        // Liste de tous les secteurs d'activite.
        public static List<Secteur> listActivities;

        // Liste de toutes les candidatures.
        public static List<Candidature> listCandidacies;

        // Liste de tous les comptes utilisateurs
        public static List<Utilisateur> listAccounts;
        public static bool DEBUG_MODE = true;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
            if(FormLogin.estConnecte)
                Application.Run(new FormHome());

        }
    }
}
