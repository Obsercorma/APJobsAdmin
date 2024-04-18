using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using wfaAPJobs.Properties;
using wfaAPJobs.Exceptions;

namespace wfaAPJobs
{
    public partial class FormHome : Form
    {
        // Offre selectionnee lors d'un clique sur une cellule de la DGV listant les offres.
        Offre selectedOffer;

        // Secteur d'activite selectionne lors d'un clique sur une cellule de la DGV en question.
        Secteur selectedActivity;

        // Compte utilisateur selectionne lors d'un clique sur une cellule de la DGV en question.
        Utilisateur selectedAccount;

        // Indexes de selections lors de la selection.
        int posSelectedRow, posSelectedCol = 0;

        /// <summary>
        /// 
        /// </summary>
        public FormHome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Rafraichit la DGV listant les offres.
        /// </summary>
        private void renderOffers()
        {
            dgvListOffers.Rows.Clear();
            Program.listOffers = Offre.getAllOffers();

            foreach (Offre offre in Program.listOffers)
            {
                dgvListOffers.Rows.Add(
                    offre.idOffre,
                    offre.intitOffre,
                    offre.secteur.getNom(),
                    offre.contrat.getNom(),
                    String.Format("{0} au {1}", offre.debutPeriode.ToString("MM/dd/yyyy"), offre.finPeriode.ToString("MM/dd/yyyy")),
                    offre.employeur.Key,
                    offre.getTypeConformite(),
                    offre.estRetire ? "Oui" : "Non"
                );
            }
        }

        /// <summary>
        /// Rafraichit la DGV listant les secteurs d'activites.
        /// </summary>
        private void renderActivities()
        {
            dgvListActivities.Rows.Clear();
            Program.listActivities = Secteur.getAll();

            foreach (Secteur activity in Program.listActivities)
            {
                dgvListActivities.Rows.Add(
                    activity.getId(),
                    activity.getNom(),
                    activity.getEstActifAsText()
                );
            }
        }

        /// <summary>
        /// Rafraichit la DGV listant les candidatures.
        /// </summary>
        private void renderCandidacies()
        {
            dgvListCandidacies.Rows.Clear();
            Program.listCandidacies = Candidature.getAll();

            foreach (Candidature candidature in Program.listCandidacies)
            {
                dgvListCandidacies.Rows.Add(
                    String.Format("{0} {1} {2}", candidature.candidat.getCivilite(),candidature.candidat.getNom(), candidature.candidat.getPrenom()),
                    candidature.offreCandidature.intitOffre + " | #" + candidature.offreCandidature.idOffre.ToString(),
                    candidature.statutCandidat.descStatut,
                    String.Format("{0} {1} {2}", candidature.employeur.getCivilite(),candidature.employeur.getNom(), candidature.employeur.getPrenom())
                );
            }
        }

        /// <summary>
        /// Rafraichit la DGV listant les comptes utilisateurs.
        /// </summary>
        private void renderAccounts()
        {
            dgvListAccounts.Rows.Clear();
            Program.listAccounts = Utilisateur.getAll();

            foreach(Utilisateur utilisateur in Program.listAccounts)
            {
                dgvListAccounts.Rows.Add(
                    utilisateur.getId(),
                    utilisateur.getCivilite() + " " + utilisateur.getNom() + " " + utilisateur.getPrenom(),
                    utilisateur.getEmail(),
                    utilisateur.getTel(),
                    utilisateur.estAdmin ? "Administrateur" : utilisateur.getStatut(),
                    utilisateur.getCV(),
                    utilisateur.compteBanni ? "Oui" : "Non"
                );
            }
        }
        /// <summary>
        /// Configuration de chaque DGV et affiche les Offres (etant situe dans la 1ere collection "CollectionTabControl").
        /// </summary>
        private void FormHome_Load(object sender, EventArgs e)
        {
            dgvListOffers.ColumnCount = 8;
            dgvListOffers.Columns[0].Name = "#";
            dgvListOffers.Columns[1].Name = "Intitulé";
            dgvListOffers.Columns[2].Name = "Secteur Act.";
            dgvListOffers.Columns[3].Name = "Contrat";
            dgvListOffers.Columns[4].Name = "Periode";
            dgvListOffers.Columns[5].Name = "Employeur";
            dgvListOffers.Columns[6].Name = "Conformité";
            dgvListOffers.Columns[7].Name = "Est retiré";
            dgvListOffers.RowHeadersVisible = false;
            this.renderOffers();

            dgvListActivities.ColumnCount = 3;
            dgvListActivities.Columns[0].Name = "#";
            dgvListActivities.Columns[1].Name = "Secteur d'activité";
            dgvListActivities.Columns[2].Name = "Est actif";
            dgvListActivities.RowHeadersVisible = false;

            dgvListCandidacies.ColumnCount = 4;
            dgvListCandidacies.Columns[0].Name = "Nom Postulant";
            dgvListCandidacies.Columns[1].Name = "Nom de l'offre/#ID";
            dgvListCandidacies.Columns[2].Name = "Statut";
            dgvListCandidacies.Columns[3].Name = "Nom employeur";
            dgvListCandidacies.RowHeadersVisible = false;

            dgvListAccounts.ColumnCount = 7;
            dgvListAccounts.Columns[0].Name = "#";
            dgvListAccounts.Columns[1].Name = "Nom complet";
            dgvListAccounts.Columns[2].Name = "email";
            dgvListAccounts.Columns[3].Name = "téléphone";
            dgvListAccounts.Columns[4].Name = "Statut";
            dgvListAccounts.Columns[5].Name = "CV";
            dgvListAccounts.Columns[6].Name = "Est désactivé";
            dgvListAccounts.RowHeadersVisible = false;

        }

        /// <summary>
        /// Fermeture de la fenetre.
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Met a jour les actions de l'offre selectionnee
        /// </summary>
        private void updateOffersActions()
        {
            btnCheckOffer.Enabled = true;
            btnRemoveOffer.Enabled = true;
            this.posSelectedRow = dgvListOffers.SelectedCells[0].RowIndex;
            this.posSelectedCol = dgvListOffers.Rows[this.posSelectedRow].Cells[0].ColumnIndex;
            int selectedDgvIDOffer = (int)dgvListOffers.Rows[this.posSelectedRow].Cells[0].Value;
            this.selectedOffer = Program.listOffers.Where(offer => offer.idOffre == selectedDgvIDOffer).ToList()[0];
            btnCheckOffer.Text = this.selectedOffer.conformiteOffre != Offre.CONFORMITY_VALIDATED ? "Valider l'offre" : "Invalider l'offre";
            btnRemoveOffer.Text = this.selectedOffer.estRetire ? "Remettre l'offre" : "Retirer l'offre";
        }

        /// <summary>
        /// Met a jour les actions du secteur d'activite selectionne.
        /// </summary>
        private void updateActivitiesActions()
        {
            btnEditActivity.Enabled = true;
            btnRemoveActivity.Enabled = true;
            this.posSelectedRow = dgvListActivities.SelectedCells[0].RowIndex;
            this.posSelectedCol = dgvListActivities.Rows[this.posSelectedRow].Cells[0].ColumnIndex;
            int selectedDgvIDActivity = (int)dgvListActivities.Rows[this.posSelectedRow].Cells[0].Value;
            this.selectedActivity = Program.listActivities.Where(activity => activity.getId() == selectedDgvIDActivity).ToList()[0];
        }

        /// <summary>
        /// Met a jour les actions du compte utilisateur selectionne
        /// </summary>
        private void updateAccountsActions()
        {
            btnEnableAccount.Enabled = true;
            this.posSelectedRow = dgvListAccounts.SelectedCells[0].RowIndex;
            this.posSelectedCol = dgvListAccounts.Rows[this.posSelectedRow].Cells[0].ColumnIndex;
            int selectedDgvIDAccounts = (int)dgvListAccounts.Rows[this.posSelectedRow].Cells[0].Value;
            this.selectedAccount = Program.listAccounts.Where(account => account.getId() == selectedDgvIDAccounts).ToList()[0];
            btnEnableAccount.Text = selectedAccount.compteBanni ? "Activer le compte" : "Désactiver le compte";
        }
        // EVENTS

        /// <summary>
        /// Ouvre le navigateur et accède au CV de l'utilisateur (Etudiant).
        /// </summary>
        private void dgvListAccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cv = this.selectedAccount.getCV();
            if(e.ColumnIndex == 5)
                System.Diagnostics.Process.Start((Program.DEBUG_MODE ? "http://localhost:8000/storage/" : "http://apjobs.test/storage/") + cv);
        }

        /// <summary>
        /// Actualisation des secteurs d'activites lors d'un clique sur une cellule de la DGV.
        /// </summary>
        private void dgvListActivities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.updateActivitiesActions();
        }
        /// <summary>
        /// Actualisation des comptes utilisateurs lors d'un clique sur une cellule de la DGV.
        /// </summary>
        private void dgvListAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.updateAccountsActions();
        }

        /// <summary>
        /// Actualisation des offres lors d'un clique sur une cellule de la DGV.
        /// </summary
        private void dgvListOffers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.updateOffersActions();
        }

        /// <summary>
        /// Retrait de la selection, et desactivation des actions concernant les secteurs d'activites.
        /// </summary>
        private void btnRefreshActivities_Click(object sender, EventArgs e)
        {
            this.renderActivities();
            dgvListActivities.ClearSelection();
            btnEditActivity.Enabled = false;
            btnRemoveActivity.Enabled = false;
        }

        /// <summary>
        /// Retrait de la selection, et desactivation des actions concernant les offres.
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.renderOffers();
            dgvListOffers.ClearSelection();
            btnCheckOffer.Enabled = false;
            btnRemoveOffer.Enabled = false;
        }

        /// <summary>
        /// Retrait de la selection, et desactivation des actions concernant les comptes utilisateurs.
        /// </summary>
        private void btnRefreshAccount_Click(object sender, EventArgs e)
        {
            btnEnableAccount.Enabled = false;
            this.renderAccounts();
            dgvListAccounts.ClearSelection();
        }

        /// <summary>
        /// Met a jour la conformite de l'offre.
        /// </summary>
        private void btnCheckOffer_Click(object sender, EventArgs e)
        {
            this.selectedOffer.conformiteOffre = this.selectedOffer.conformiteOffre != Offre.CONFORMITY_VALIDATED ? Offre.CONFORMITY_VALIDATED : Offre.CONFORMITY_UNVALIDATED;
            this.renderOffers();
            dgvListOffers.CurrentCell = dgvListOffers[6,this.posSelectedRow];
            this.updateOffersActions();
        }
        
        /// <summary>
        /// rafraichissement automatique lorsque l'utilisateur change d'onglet.
        /// </summary>
        private void onChangeTabs(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0: // Offres
                    this.renderOffers();
                    break;
                case 1: // Activites
                    this.renderActivities();
                    break;
                case 2: // Candidatures
                    this.renderCandidacies();
                    break;
                case 3: // Comptes
                    this.renderAccounts();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Met a jour l'utilisation du secteur d'activite sur le site web lors d'une creation d'offre.
        /// </summary>
        private void btnCheckActivity_Click(object sender, EventArgs e)
        {
            this.selectedActivity.estActif = !this.selectedActivity.estActif;
            this.renderActivities();
            dgvListActivities.CurrentCell = dgvListActivities[2, this.posSelectedRow];
            this.updateActivitiesActions();
        }

        /// <summary>
        /// Retire le secteur d'activite parmi la liste des objets ainsi que sur la BDD.
        /// </summary>
        private void btnRemoveActivity_Click(object sender, EventArgs e)
        {
            if (this.selectedActivity == null) return;
            SqlConnector req = new SqlConnector();
            Dictionary<string, object> args = new Dictionary<string, object>();
            args.Add("@idAct", this.selectedActivity.getId());
            if(req.prepareAndExecNonQuery(Resources.REQ_DELETE_ACTIVITY, args))
            {
                dgvListActivities.ClearSelection();
                this.renderActivities();
                return;
            }
            MessageBox.Show("Une erreur s'est produite lors de la suppression du secteur d'activitié !", "Erreur suppression", MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Ouvre l'interface d'edition d'un secteur d'activite.
        /// </summary>
        private void btnEditActivity_Click(object sender, EventArgs e)
        {
            FormEditActivity form = new FormEditActivity(this.selectedActivity);
            form.Show();
        }

        /// <summary>
        /// Ouvre l'interface d'edition en mode ajout pour un nouveau secteur d'activite.
        /// </summary>
        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            FormEditActivity form = new FormEditActivity();
            form.Show();
        }

        
        /// <summary>
        /// Met a jour l'activite d'un compte utilisateur.
        /// </summary>
        private void btnEnableAccount_Click(object sender, EventArgs e)
        {
            try
            {
                this.selectedAccount.compteBanni = !this.selectedAccount.compteBanni;
            }
            catch (UpdateContentUserException obj)
            {
                MessageBox.Show(obj.Message, "Erreur: Modification compte utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.renderAccounts();
            dgvListAccounts.CurrentCell = dgvListAccounts[6, this.posSelectedRow];
            this.updateAccountsActions();
        }

        /// <summary>
        /// Actualisation des candidatures sur evennement.
        /// </summary>
        private void btnRefreshCandidacies_Click(object sender, EventArgs e)
        {
            this.renderCandidacies();
        }

        /// <summary>
        /// Retire une offre du site web (l'offre reste presente dans la liste d'objets et dans la BDD).
        /// </summary>
        private void btnRemoveOffer_Click(object sender, EventArgs e)
        {
            this.selectedOffer.estRetire = !this.selectedOffer.estRetire;
            this.renderOffers();
            dgvListOffers.CurrentCell = dgvListOffers[7,this.posSelectedRow];
            this.updateOffersActions();
        }
    }
}
