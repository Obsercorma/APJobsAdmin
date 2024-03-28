using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaAPJobs
{
    public static class Program
    {
        public static List<Offre> listOffers;
        public static List<Contrat> listContracts;
        public static List<Secteur> listActivities;
        public static List<Candidature> listCandidacies;
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
