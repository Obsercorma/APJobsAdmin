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
using BC = BCrypt.Net;

namespace wfaAPJobs
{
    public partial class FormLogin : Form
    {
        public static bool estConnecte = false;
        public FormLogin()
        {
            InitializeComponent();
            labelErrMesg.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnector req = new SqlConnector();
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("@email", boxUserEmail.Text);
            List<Dictionary<string,object>> data = req.query("SELECT nom, prenom, passwd FROM utilisateur WHERE email = @email", args);
            if(data != null && data.Count > 0)
            {
                Dictionary<string,object> result = data[0];
                if(result == null)
                {
                    labelErrMesg.Text = "Identifiants incorrects !";
                }else
                {
                    labelErrMesg.Text = !BC.BCrypt.Verify(boxPasswd.Text, result["passwd"].ToString()) ? "Mot de passe invalide !" : "";
                    estConnecte = true;
                    this.Close();
                }
            }else
            {
                labelErrMesg.Text = "Identifiants incorrects !";
            }
            req.CloseQuery();
            req.CloseDB();
        }
    }
}
