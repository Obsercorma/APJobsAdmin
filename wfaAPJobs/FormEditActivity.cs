using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfaAPJobs.Properties;

namespace wfaAPJobs
{
    public partial class FormEditActivity : Form
    {
        // Secteur d'activite a editer ou a inserer.
        private Secteur activityToEdit;

        //Indique si le secteur d'activite doit etre insere ou edite.
        private bool isNewActivity;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_activityToEdit">Secteur d'activite a editer ou a inserer</param>
        public FormEditActivity(Secteur _activityToEdit)
        {
            InitializeComponent();
            this.activityToEdit = _activityToEdit;
            this.isNewActivity = false;
            btnEditActivity.Text = "Éditer";
        }

        /// <summary>
        /// 
        /// </summary>
        public FormEditActivity()
        {
            InitializeComponent();
            btnEditActivity.Text = "Ajouter";
            this.isNewActivity = true;
        }

        /// <summary>
        /// Complete les champs present sur le WPF si le secteur d'activite provient de la base de donnees.
        /// </summary>
        private void FormEditActivity_Load(object sender, EventArgs e)
        {
            if(this.activityToEdit != null)
            {
                labelEditActivity.Text += this.activityToEdit.getId().ToString();
                inputActitivtyName.Text = this.activityToEdit.getNom();
                chboxActivityEnabled.Checked = this.activityToEdit.estActif;
                return;
            }
            if(!this.isNewActivity)
                MessageBox.Show("Impossible d'éditer le secteur d'activité !", "Erreur édition du secteur d'activité", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Permet de valider "l'edition"/"l'insertion" du secteur d'activite
        /// </summary>
        private void btnEditActivity_Click(object sender, EventArgs e)
        {
            SqlConnector req = new SqlConnector();
            Dictionary<string, object> args = new Dictionary<string, object>();
            args.Add("@idAct", this.isNewActivity ? Program.listActivities.Last().getId()+1 : this.activityToEdit.getId());
            args.Add("@intitAct", inputActitivtyName.Text);
            args.Add("@estActif", chboxActivityEnabled.Checked);

            if(req.prepareAndExecNonQuery(this.isNewActivity ? Resources.REQ_INSERT_ACTIVITY :Resources.REQ_UPDATE_ACTIVITY, args))
            {
                MessageBox.Show(
                    (this.isNewActivity ? "Ajout" : "Édition") + " effectué avec succès",
                    (this.isNewActivity ? "Ajout" : "Édition") + " du secteur d'activité", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show(
                    "Impossible " + (this.isNewActivity ? "d'ajouter" : "d'éditer") + " d'éditer le secteur d'activité !", 
                    "Erreur " + (this.isNewActivity ? "ajout" : "édition") + " du secteur d'activité", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Close();
            req.CloseDB();
        }
    }
}
