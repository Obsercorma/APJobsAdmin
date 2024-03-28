namespace wfaAPJobs
{
    partial class FormEditActivity
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
            this.labelEditActivity = new System.Windows.Forms.Label();
            this.inputActitivtyName = new System.Windows.Forms.TextBox();
            this.labelActivityName = new System.Windows.Forms.Label();
            this.chboxActivityEnabled = new System.Windows.Forms.CheckBox();
            this.btnEditActivity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelEditActivity
            // 
            this.labelEditActivity.AutoSize = true;
            this.labelEditActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditActivity.Location = new System.Drawing.Point(6, 9);
            this.labelEditActivity.Name = "labelEditActivity";
            this.labelEditActivity.Size = new System.Drawing.Size(151, 18);
            this.labelEditActivity.TabIndex = 0;
            this.labelEditActivity.Text = "Secteur d\'activité #";
            // 
            // inputActitivtyName
            // 
            this.inputActitivtyName.Location = new System.Drawing.Point(12, 97);
            this.inputActitivtyName.Name = "inputActitivtyName";
            this.inputActitivtyName.Size = new System.Drawing.Size(227, 20);
            this.inputActitivtyName.TabIndex = 1;
            // 
            // labelActivityName
            // 
            this.labelActivityName.AutoSize = true;
            this.labelActivityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActivityName.Location = new System.Drawing.Point(9, 79);
            this.labelActivityName.Name = "labelActivityName";
            this.labelActivityName.Size = new System.Drawing.Size(150, 15);
            this.labelActivityName.TabIndex = 2;
            this.labelActivityName.Text = "Nom du secteur d\'activité :";
            // 
            // chboxActivityEnabled
            // 
            this.chboxActivityEnabled.AutoSize = true;
            this.chboxActivityEnabled.Checked = true;
            this.chboxActivityEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxActivityEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxActivityEnabled.Location = new System.Drawing.Point(15, 123);
            this.chboxActivityEnabled.Name = "chboxActivityEnabled";
            this.chboxActivityEnabled.Size = new System.Drawing.Size(78, 19);
            this.chboxActivityEnabled.TabIndex = 3;
            this.chboxActivityEnabled.Text = "Est Actif ?";
            this.chboxActivityEnabled.UseVisualStyleBackColor = true;
            // 
            // btnEditActivity
            // 
            this.btnEditActivity.Location = new System.Drawing.Point(167, 186);
            this.btnEditActivity.Name = "btnEditActivity";
            this.btnEditActivity.Size = new System.Drawing.Size(75, 23);
            this.btnEditActivity.TabIndex = 4;
            this.btnEditActivity.Text = "Éditer";
            this.btnEditActivity.UseVisualStyleBackColor = true;
            this.btnEditActivity.Click += new System.EventHandler(this.btnEditActivity_Click);
            // 
            // FormEditActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 221);
            this.Controls.Add(this.btnEditActivity);
            this.Controls.Add(this.chboxActivityEnabled);
            this.Controls.Add(this.labelActivityName);
            this.Controls.Add(this.inputActitivtyName);
            this.Controls.Add(this.labelEditActivity);
            this.Name = "FormEditActivity";
            this.Text = "Éditer le secteur d\'activité";
            this.Load += new System.EventHandler(this.FormEditActivity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEditActivity;
        private System.Windows.Forms.TextBox inputActitivtyName;
        private System.Windows.Forms.Label labelActivityName;
        private System.Windows.Forms.CheckBox chboxActivityEnabled;
        private System.Windows.Forms.Button btnEditActivity;
    }
}