namespace wfaAPJobs
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbHome = new System.Windows.Forms.TabControl();
            this.tpListOffers = new System.Windows.Forms.TabPage();
            this.btnRemoveOffer = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCheckOffer = new System.Windows.Forms.Button();
            this.labeloffers = new System.Windows.Forms.Label();
            this.dgvListOffers = new System.Windows.Forms.DataGridView();
            this.tbListActivities = new System.Windows.Forms.TabPage();
            this.btnRemoveActivity = new System.Windows.Forms.Button();
            this.btnEditActivity = new System.Windows.Forms.Button();
            this.btnAddActivity = new System.Windows.Forms.Button();
            this.btnRefreshActivities = new System.Windows.Forms.Button();
            this.labellistActvities = new System.Windows.Forms.Label();
            this.dgvListActivities = new System.Windows.Forms.DataGridView();
            this.tbListCandidacies = new System.Windows.Forms.TabPage();
            this.btnRefreshCandidacies = new System.Windows.Forms.Button();
            this.labelListCandidacies = new System.Windows.Forms.Label();
            this.dgvListCandidacies = new System.Windows.Forms.DataGridView();
            this.tbListAccounts = new System.Windows.Forms.TabPage();
            this.btnEnableAccount = new System.Windows.Forms.Button();
            this.btnRefreshAccount = new System.Windows.Forms.Button();
            this.labelAccounts = new System.Windows.Forms.Label();
            this.dgvListAccounts = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tbHome.SuspendLayout();
            this.tpListOffers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOffers)).BeginInit();
            this.tbListActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListActivities)).BeginInit();
            this.tbListCandidacies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCandidacies)).BeginInit();
            this.tbListAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbHome
            // 
            this.tbHome.Controls.Add(this.tpListOffers);
            this.tbHome.Controls.Add(this.tbListActivities);
            this.tbHome.Controls.Add(this.tbListCandidacies);
            this.tbHome.Controls.Add(this.tbListAccounts);
            this.tbHome.Location = new System.Drawing.Point(12, 41);
            this.tbHome.Multiline = true;
            this.tbHome.Name = "tbHome";
            this.tbHome.SelectedIndex = 0;
            this.tbHome.Size = new System.Drawing.Size(812, 406);
            this.tbHome.TabIndex = 1;
            this.tbHome.Selected += new System.Windows.Forms.TabControlEventHandler(this.onChangeTabs);
            // 
            // tpListOffers
            // 
            this.tpListOffers.Controls.Add(this.btnRemoveOffer);
            this.tpListOffers.Controls.Add(this.btnRefresh);
            this.tpListOffers.Controls.Add(this.btnCheckOffer);
            this.tpListOffers.Controls.Add(this.labeloffers);
            this.tpListOffers.Controls.Add(this.dgvListOffers);
            this.tpListOffers.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.tpListOffers.Location = new System.Drawing.Point(4, 22);
            this.tpListOffers.Name = "tpListOffers";
            this.tpListOffers.Padding = new System.Windows.Forms.Padding(3);
            this.tpListOffers.Size = new System.Drawing.Size(804, 380);
            this.tpListOffers.TabIndex = 0;
            this.tpListOffers.Text = "Offres";
            this.tpListOffers.UseVisualStyleBackColor = true;
            // 
            // btnRemoveOffer
            // 
            this.btnRemoveOffer.Enabled = false;
            this.btnRemoveOffer.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveOffer.Location = new System.Drawing.Point(260, 347);
            this.btnRemoveOffer.Name = "btnRemoveOffer";
            this.btnRemoveOffer.Size = new System.Drawing.Size(121, 27);
            this.btnRemoveOffer.TabIndex = 5;
            this.btnRemoveOffer.Text = "Retirer l\'offre";
            this.btnRemoveOffer.UseVisualStyleBackColor = true;
            this.btnRemoveOffer.Click += new System.EventHandler(this.btnRemoveOffer_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(6, 347);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(121, 27);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Actualiser";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCheckOffer
            // 
            this.btnCheckOffer.Enabled = false;
            this.btnCheckOffer.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOffer.Location = new System.Drawing.Point(133, 347);
            this.btnCheckOffer.Name = "btnCheckOffer";
            this.btnCheckOffer.Size = new System.Drawing.Size(121, 27);
            this.btnCheckOffer.TabIndex = 3;
            this.btnCheckOffer.Text = "Valider l\'offre";
            this.btnCheckOffer.UseVisualStyleBackColor = true;
            this.btnCheckOffer.Click += new System.EventHandler(this.btnCheckOffer_Click);
            // 
            // labeloffers
            // 
            this.labeloffers.AutoSize = true;
            this.labeloffers.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeloffers.Location = new System.Drawing.Point(6, 13);
            this.labeloffers.Name = "labeloffers";
            this.labeloffers.Size = new System.Drawing.Size(115, 19);
            this.labeloffers.TabIndex = 1;
            this.labeloffers.Text = "Liste des offres";
            // 
            // dgvListOffers
            // 
            this.dgvListOffers.AllowUserToAddRows = false;
            this.dgvListOffers.AllowUserToDeleteRows = false;
            this.dgvListOffers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListOffers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvListOffers.Location = new System.Drawing.Point(0, 44);
            this.dgvListOffers.Name = "dgvListOffers";
            this.dgvListOffers.ReadOnly = true;
            this.dgvListOffers.Size = new System.Drawing.Size(804, 297);
            this.dgvListOffers.TabIndex = 0;
            this.dgvListOffers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListOffers_CellContentClick);
            // 
            // tbListActivities
            // 
            this.tbListActivities.Controls.Add(this.btnRemoveActivity);
            this.tbListActivities.Controls.Add(this.btnEditActivity);
            this.tbListActivities.Controls.Add(this.btnAddActivity);
            this.tbListActivities.Controls.Add(this.btnRefreshActivities);
            this.tbListActivities.Controls.Add(this.labellistActvities);
            this.tbListActivities.Controls.Add(this.dgvListActivities);
            this.tbListActivities.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.tbListActivities.Location = new System.Drawing.Point(4, 22);
            this.tbListActivities.Name = "tbListActivities";
            this.tbListActivities.Padding = new System.Windows.Forms.Padding(3);
            this.tbListActivities.Size = new System.Drawing.Size(804, 380);
            this.tbListActivities.TabIndex = 1;
            this.tbListActivities.Text = "Secteurs activités";
            this.tbListActivities.UseVisualStyleBackColor = true;
            // 
            // btnRemoveActivity
            // 
            this.btnRemoveActivity.Enabled = false;
            this.btnRemoveActivity.Font = new System.Drawing.Font("Open Sans", 10F);
            this.btnRemoveActivity.Location = new System.Drawing.Point(260, 347);
            this.btnRemoveActivity.Name = "btnRemoveActivity";
            this.btnRemoveActivity.Size = new System.Drawing.Size(139, 27);
            this.btnRemoveActivity.TabIndex = 9;
            this.btnRemoveActivity.Text = "Retirer une activité";
            this.btnRemoveActivity.UseVisualStyleBackColor = true;
            this.btnRemoveActivity.Click += new System.EventHandler(this.btnRemoveActivity_Click);
            // 
            // btnEditActivity
            // 
            this.btnEditActivity.Enabled = false;
            this.btnEditActivity.Font = new System.Drawing.Font("Open Sans", 10F);
            this.btnEditActivity.Location = new System.Drawing.Point(133, 347);
            this.btnEditActivity.Name = "btnEditActivity";
            this.btnEditActivity.Size = new System.Drawing.Size(121, 27);
            this.btnEditActivity.TabIndex = 7;
            this.btnEditActivity.Text = "Éditer l\'activité";
            this.btnEditActivity.UseVisualStyleBackColor = true;
            this.btnEditActivity.Click += new System.EventHandler(this.btnEditActivity_Click);
            // 
            // btnAddActivity
            // 
            this.btnAddActivity.Font = new System.Drawing.Font("Open Sans", 10F);
            this.btnAddActivity.Location = new System.Drawing.Point(677, 347);
            this.btnAddActivity.Name = "btnAddActivity";
            this.btnAddActivity.Size = new System.Drawing.Size(121, 27);
            this.btnAddActivity.TabIndex = 6;
            this.btnAddActivity.Text = "Ajouter";
            this.btnAddActivity.UseVisualStyleBackColor = true;
            this.btnAddActivity.Click += new System.EventHandler(this.btnAddActivity_Click);
            // 
            // btnRefreshActivities
            // 
            this.btnRefreshActivities.Font = new System.Drawing.Font("Open Sans", 10F);
            this.btnRefreshActivities.Location = new System.Drawing.Point(6, 347);
            this.btnRefreshActivities.Name = "btnRefreshActivities";
            this.btnRefreshActivities.Size = new System.Drawing.Size(121, 27);
            this.btnRefreshActivities.TabIndex = 5;
            this.btnRefreshActivities.Text = "Actualiser";
            this.btnRefreshActivities.UseVisualStyleBackColor = true;
            this.btnRefreshActivities.Click += new System.EventHandler(this.btnRefreshActivities_Click);
            // 
            // labellistActvities
            // 
            this.labellistActvities.AutoSize = true;
            this.labellistActvities.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labellistActvities.Location = new System.Drawing.Point(6, 13);
            this.labellistActvities.Name = "labellistActvities";
            this.labellistActvities.Size = new System.Drawing.Size(134, 19);
            this.labellistActvities.TabIndex = 2;
            this.labellistActvities.Text = "Liste des Activités";
            // 
            // dgvListActivities
            // 
            this.dgvListActivities.AllowUserToAddRows = false;
            this.dgvListActivities.AllowUserToDeleteRows = false;
            this.dgvListActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListActivities.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvListActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListActivities.Location = new System.Drawing.Point(0, 44);
            this.dgvListActivities.Name = "dgvListActivities";
            this.dgvListActivities.ReadOnly = true;
            this.dgvListActivities.Size = new System.Drawing.Size(804, 297);
            this.dgvListActivities.TabIndex = 0;
            this.dgvListActivities.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListActivities_CellContentClick);
            // 
            // tbListCandidacies
            // 
            this.tbListCandidacies.Controls.Add(this.btnRefreshCandidacies);
            this.tbListCandidacies.Controls.Add(this.labelListCandidacies);
            this.tbListCandidacies.Controls.Add(this.dgvListCandidacies);
            this.tbListCandidacies.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.tbListCandidacies.Location = new System.Drawing.Point(4, 22);
            this.tbListCandidacies.Name = "tbListCandidacies";
            this.tbListCandidacies.Size = new System.Drawing.Size(804, 380);
            this.tbListCandidacies.TabIndex = 2;
            this.tbListCandidacies.Text = "Candidatures";
            this.tbListCandidacies.UseVisualStyleBackColor = true;
            // 
            // btnRefreshCandidacies
            // 
            this.btnRefreshCandidacies.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshCandidacies.Location = new System.Drawing.Point(6, 344);
            this.btnRefreshCandidacies.Name = "btnRefreshCandidacies";
            this.btnRefreshCandidacies.Size = new System.Drawing.Size(121, 27);
            this.btnRefreshCandidacies.TabIndex = 8;
            this.btnRefreshCandidacies.Text = "Actualiser";
            this.btnRefreshCandidacies.UseVisualStyleBackColor = true;
            // 
            // labelListCandidacies
            // 
            this.labelListCandidacies.AutoSize = true;
            this.labelListCandidacies.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListCandidacies.Location = new System.Drawing.Point(6, 10);
            this.labelListCandidacies.Name = "labelListCandidacies";
            this.labelListCandidacies.Size = new System.Drawing.Size(164, 19);
            this.labelListCandidacies.TabIndex = 7;
            this.labelListCandidacies.Text = "Liste des candidatures";
            // 
            // dgvListCandidacies
            // 
            this.dgvListCandidacies.AllowUserToAddRows = false;
            this.dgvListCandidacies.AllowUserToDeleteRows = false;
            this.dgvListCandidacies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListCandidacies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvListCandidacies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListCandidacies.Location = new System.Drawing.Point(0, 41);
            this.dgvListCandidacies.Name = "dgvListCandidacies";
            this.dgvListCandidacies.ReadOnly = true;
            this.dgvListCandidacies.Size = new System.Drawing.Size(804, 297);
            this.dgvListCandidacies.TabIndex = 6;
            // 
            // tbListAccounts
            // 
            this.tbListAccounts.Controls.Add(this.btnEnableAccount);
            this.tbListAccounts.Controls.Add(this.btnRefreshAccount);
            this.tbListAccounts.Controls.Add(this.labelAccounts);
            this.tbListAccounts.Controls.Add(this.dgvListAccounts);
            this.tbListAccounts.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.tbListAccounts.Location = new System.Drawing.Point(4, 22);
            this.tbListAccounts.Name = "tbListAccounts";
            this.tbListAccounts.Size = new System.Drawing.Size(804, 380);
            this.tbListAccounts.TabIndex = 3;
            this.tbListAccounts.Text = "Comptes";
            this.tbListAccounts.UseVisualStyleBackColor = true;
            // 
            // btnEnableAccount
            // 
            this.btnEnableAccount.Enabled = false;
            this.btnEnableAccount.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnableAccount.Location = new System.Drawing.Point(133, 344);
            this.btnEnableAccount.Name = "btnEnableAccount";
            this.btnEnableAccount.Size = new System.Drawing.Size(166, 27);
            this.btnEnableAccount.TabIndex = 12;
            this.btnEnableAccount.Text = "Activer le compte";
            this.btnEnableAccount.UseVisualStyleBackColor = true;
            this.btnEnableAccount.Click += new System.EventHandler(this.btnEnableAccount_Click);
            // 
            // btnRefreshAccount
            // 
            this.btnRefreshAccount.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshAccount.Location = new System.Drawing.Point(6, 344);
            this.btnRefreshAccount.Name = "btnRefreshAccount";
            this.btnRefreshAccount.Size = new System.Drawing.Size(121, 27);
            this.btnRefreshAccount.TabIndex = 11;
            this.btnRefreshAccount.Text = "Actualiser";
            this.btnRefreshAccount.UseVisualStyleBackColor = true;
            this.btnRefreshAccount.Click += new System.EventHandler(this.btnRefreshAccount_Click);
            // 
            // labelAccounts
            // 
            this.labelAccounts.AutoSize = true;
            this.labelAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccounts.Location = new System.Drawing.Point(6, 10);
            this.labelAccounts.Name = "labelAccounts";
            this.labelAccounts.Size = new System.Drawing.Size(139, 17);
            this.labelAccounts.TabIndex = 10;
            this.labelAccounts.Text = "Liste des comptes";
            // 
            // dgvListAccounts
            // 
            this.dgvListAccounts.AllowUserToAddRows = false;
            this.dgvListAccounts.AllowUserToDeleteRows = false;
            this.dgvListAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListAccounts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvListAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListAccounts.Location = new System.Drawing.Point(0, 41);
            this.dgvListAccounts.Name = "dgvListAccounts";
            this.dgvListAccounts.ReadOnly = true;
            this.dgvListAccounts.Size = new System.Drawing.Size(804, 297);
            this.dgvListAccounts.TabIndex = 9;
            this.dgvListAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListAccounts_CellContentClick);
            this.dgvListAccounts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListAccounts_CellContentDoubleClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(713, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(111, 34);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Se déconnecter";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 459);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tbHome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHome";
            this.Text = "Administraton Jobs";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.tbHome.ResumeLayout(false);
            this.tpListOffers.ResumeLayout(false);
            this.tpListOffers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOffers)).EndInit();
            this.tbListActivities.ResumeLayout(false);
            this.tbListActivities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListActivities)).EndInit();
            this.tbListCandidacies.ResumeLayout(false);
            this.tbListCandidacies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCandidacies)).EndInit();
            this.tbListAccounts.ResumeLayout(false);
            this.tbListAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAccounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tbHome;
        private System.Windows.Forms.TabPage tpListOffers;
        private System.Windows.Forms.TabPage tbListActivities;
        private System.Windows.Forms.TabPage tbListCandidacies;
        private System.Windows.Forms.Label labeloffers;
        private System.Windows.Forms.DataGridView dgvListOffers;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCheckOffer;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRemoveOffer;
        private System.Windows.Forms.Label labellistActvities;
        private System.Windows.Forms.Button btnRefreshActivities;
        private System.Windows.Forms.Button btnEditActivity;
        private System.Windows.Forms.Button btnAddActivity;
        private System.Windows.Forms.Button btnRemoveActivity;
        private System.Windows.Forms.TabPage tbListAccounts;
        private System.Windows.Forms.Button btnRefreshCandidacies;
        private System.Windows.Forms.Label labelListCandidacies;
        private System.Windows.Forms.DataGridView dgvListCandidacies;
        private System.Windows.Forms.DataGridView dgvListActivities;
        private System.Windows.Forms.Button btnRefreshAccount;
        private System.Windows.Forms.Label labelAccounts;
        private System.Windows.Forms.DataGridView dgvListAccounts;
        private System.Windows.Forms.Button btnEnableAccount;
    }
}