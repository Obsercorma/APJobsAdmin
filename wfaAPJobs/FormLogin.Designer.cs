namespace wfaAPJobs
{
    partial class FormLogin
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.boxUserEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUserEmail = new System.Windows.Forms.Label();
            this.labelpasswd = new System.Windows.Forms.Label();
            this.boxPasswd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.labelErrMesg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boxUserEmail
            // 
            this.boxUserEmail.Location = new System.Drawing.Point(44, 147);
            this.boxUserEmail.Name = "boxUserEmail";
            this.boxUserEmail.Size = new System.Drawing.Size(181, 22);
            this.boxUserEmail.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Se connecter";
            // 
            // labelUserEmail
            // 
            this.labelUserEmail.AutoSize = true;
            this.labelUserEmail.Location = new System.Drawing.Point(40, 128);
            this.labelUserEmail.Name = "labelUserEmail";
            this.labelUserEmail.Size = new System.Drawing.Size(78, 15);
            this.labelUserEmail.TabIndex = 2;
            this.labelUserEmail.Text = "Adresse email";
            // 
            // labelpasswd
            // 
            this.labelpasswd.AutoSize = true;
            this.labelpasswd.Location = new System.Drawing.Point(40, 183);
            this.labelpasswd.Name = "labelpasswd";
            this.labelpasswd.Size = new System.Drawing.Size(76, 15);
            this.labelpasswd.TabIndex = 4;
            this.labelpasswd.Text = "Mot de passe";
            // 
            // boxPasswd
            // 
            this.boxPasswd.Location = new System.Drawing.Point(44, 202);
            this.boxPasswd.Name = "boxPasswd";
            this.boxPasswd.Size = new System.Drawing.Size(181, 22);
            this.boxPasswd.TabIndex = 3;
            this.boxPasswd.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(92, 263);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 27);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Connexion";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelErrMesg
            // 
            this.labelErrMesg.AutoSize = true;
            this.labelErrMesg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrMesg.ForeColor = System.Drawing.Color.Red;
            this.labelErrMesg.Location = new System.Drawing.Point(40, 97);
            this.labelErrMesg.Name = "labelErrMesg";
            this.labelErrMesg.Size = new System.Drawing.Size(56, 13);
            this.labelErrMesg.TabIndex = 6;
            this.labelErrMesg.Text = "message";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 331);
            this.Controls.Add(this.labelErrMesg);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labelpasswd);
            this.Controls.Add(this.boxPasswd);
            this.Controls.Add(this.labelUserEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxUserEmail);
            this.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.Text = "Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox boxUserEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUserEmail;
        private System.Windows.Forms.Label labelpasswd;
        private System.Windows.Forms.TextBox boxPasswd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label labelErrMesg;
    }
}

