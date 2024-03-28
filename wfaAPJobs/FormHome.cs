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

namespace wfaAPJobs
{
    public partial class FormHome : Form
    {
        
        Offre selectedOffer;
        Secteur selectedActivity;
        //Candidature selectedCandidacy;
        Utilisateur selectedAccount;
        int posSelectedRow, posSelectedCol = 0;
        public FormHome()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Rendu DGV : Liste des offres
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

        private void renderActivities()
        {
            dgvListActivities.Rows.Clear();
            Program.listActivities = Secteur.getAll();

            foreach (Secteur activity in Program.listActivities)
            {
                dgvListActivities.Rows.Add(
                    activity.getId(),
                    activity.getNom() + " | #" + activity.getId().ToString(),
                    activity.getEstActifAsText()
                );
            }
        }
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
                    utilisateur.getStatut(),
                    utilisateur.getCV(),
                    utilisateur.compteBanni ? "Oui" : "Non"
                );
            }
        }

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
            dgvListAccounts.Columns[6].Name = "Est banni";
            dgvListAccounts.RowHeadersVisible = false;

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void updateActivitiesActions()
        {
            btnEditActivity.Enabled = true;
            btnRemoveActivity.Enabled = true;
            this.posSelectedRow = dgvListActivities.SelectedCells[0].RowIndex;
            this.posSelectedCol = dgvListActivities.Rows[this.posSelectedRow].Cells[0].ColumnIndex;
            int selectedDgvIDActivity = (int)dgvListActivities.Rows[this.posSelectedRow].Cells[0].Value;
            this.selectedActivity = Program.listActivities.Where(activity => activity.getId() == selectedDgvIDActivity).ToList()[0];
        }

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

        private void dgvListAccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cv = this.selectedAccount.getCV();
            if(e.ColumnIndex == 5)
                System.Diagnostics.Process.Start((Program.DEBUG_MODE ? "http://localhost:8000/" : "http://apjobs.test/") + cv);
        }

        private void dgvListActivities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.updateActivitiesActions();
        }

        private void dgvListAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.updateAccountsActions();
        }

        private void dgvListOffers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.updateOffersActions();
        }
        private void btnRefreshActivities_Click(object sender, EventArgs e)
        {
            this.renderActivities();
            dgvListActivities.ClearSelection();
            btnEditActivity.Enabled = false;
            btnRemoveActivity.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.renderOffers();
            dgvListOffers.ClearSelection();
            btnCheckOffer.Enabled = false;
            btnRemoveOffer.Enabled = false;
        }

        private void btnCheckOffer_Click(object sender, EventArgs e)
        {
            this.selectedOffer.conformiteOffre = this.selectedOffer.conformiteOffre != Offre.CONFORMITY_VALIDATED ? Offre.CONFORMITY_VALIDATED : Offre.CONFORMITY_UNVALIDATED;
            this.renderOffers();
            dgvListOffers.CurrentCell = dgvListOffers[6,this.posSelectedRow];
            this.updateOffersActions();
        }
        
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

        private void btnCheckActivity_Click(object sender, EventArgs e)
        {
            this.selectedActivity.estActif = !this.selectedActivity.estActif;
            this.renderActivities();
            dgvListActivities.CurrentCell = dgvListActivities[2, this.posSelectedRow];
            this.updateActivitiesActions();
        }

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

        private void btnEditActivity_Click(object sender, EventArgs e)
        {
            FormEditActivity form = new FormEditActivity(this.selectedActivity);
            form.Show();
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            FormEditActivity form = new FormEditActivity();
            form.Show();
        }

        private void btnRefreshAccount_Click(object sender, EventArgs e)
        {
            btnEnableAccount.Enabled = false;
            this.renderAccounts();
            dgvListAccounts.ClearSelection();
        }

        private void btnEnableAccount_Click(object sender, EventArgs e)
        {
            this.selectedAccount.compteBanni = !this.selectedAccount.compteBanni;
            this.renderAccounts();
            dgvListAccounts.CurrentCell = dgvListAccounts[6, this.posSelectedRow];
            this.updateAccountsActions();
        }
        
        private void btnRemoveOffer_Click(object sender, EventArgs e)
        {
            this.selectedOffer.estRetire = !this.selectedOffer.estRetire;
            this.renderOffers();
            dgvListOffers.CurrentCell = dgvListOffers[7,this.posSelectedRow];
            this.updateOffersActions();
        }
    }
}
