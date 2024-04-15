using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using wfaAPJobs.Properties;

namespace wfaAPJobs
{
    /**
     * Use this for MySql Connections methods only.
     */
    public class SqlConnector
    {
        // MySQL
        private MySqlConnection cnx;
        private MySqlDataReader reqQuery;
        // END;

        // Indicateur: Erreur retournee depuis la BDD.
        private bool gotErrorCnx = false;

        /// <summary>
        /// Initialisation de la connexion a la base de donnees
        /// </summary>
        public SqlConnector()
        {
            try
            {
                this.cnx = new MySqlConnection(Resources.MARIADB_SERVER_PATH);
                this.cnx.Open();
            }catch(MySqlException)
            {
                this.gotErrorCnx = true;
            }
        }
        /// <summary>
        /// Execute la requete preparee avec ses arguments. N'attend aucun resultat.
        /// </summary>
        /// <param name="request">Chaine de la requete preparee</param>
        /// <param name="args">Arguments de la requete</param>
        /// <returns>Retourne vrai si la requete s'est effectue correctement</returns>
        public bool prepareAndExecNonQuery(string request, Dictionary<string,object> args)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(request, this.cnx);
                cmd.Prepare();
                foreach(KeyValuePair<string,object> arg in args)
                {
                    cmd.Parameters.AddWithValue(arg.Key, arg.Value);
                }
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Execute la requete renseignee. 
        /// </summary>
        /// <param name="request">Requete SQL</param>
        /// <returns>Retourne les lignes resultantes sous forme de dictionnaire</returns>
        public List<Dictionary<string,object>> query(string request)
        {
            try
            {
                List<Dictionary<string, object>> values = new List<Dictionary<string,object>>();
                MySqlCommand cmd = new MySqlCommand(request, this.cnx);
                this.reqQuery = cmd.ExecuteReader();
                while (reqQuery.Read())
                {
                    Dictionary<string,object> tmp = new Dictionary<string, object>();
                    for (int i = 0; i < reqQuery.FieldCount; i++)
                        if(!tmp.ContainsKey(reqQuery.GetName(i)))
                            tmp.Add(reqQuery.GetName(i), reqQuery.GetValue(i));
                    values.Add(tmp);
                }
                reqQuery.Close();
                return values;
            }
            catch (MySqlException)
            {
                if (this.reqQuery != null && !this.reqQuery.IsClosed) this.reqQuery.Close();
                this.cnx.Close();
                return null;
            }
        }
        /// <summary>
        /// Execute la requete preparee avec ses arguments.
        /// </summary>
        /// <param name="request">Chaine de la requete preparee</param>
        /// <param name="args">Arguments de la requete</param>
        /// <returns>Retourne les lignes resultantes de la requete executee.</returns>
        public List<Dictionary<string, object>> query(string request, Dictionary<string,string> args)
        {
            try
            {
                List<Dictionary<string, object>> values = new List<Dictionary<string, object>>();
                MySqlCommand cmd = new MySqlCommand(request, this.cnx);

                foreach(KeyValuePair<string,string> argKV in args)
                {
                    cmd.Parameters.AddWithValue(argKV.Key, argKV.Value);
                }
                this.reqQuery = cmd.ExecuteReader();
                while (reqQuery.Read())
                {
                    Dictionary<string, object> tmp = new Dictionary<string, object>();
                    for (int i = 0; i < reqQuery.FieldCount; i++)
                        if (!tmp.ContainsKey(reqQuery.GetName(i)))
                            tmp.Add(reqQuery.GetName(i), reqQuery.GetValue(i));
                    values.Add(tmp);
                }
                reqQuery.Close();
                return values;
            }
            catch (MySqlException)
            {
                if (this.reqQuery != null && !this.reqQuery.IsClosed) this.reqQuery.Close();
                this.cnx.Close();
                return null;
            }
        }

        /// <summary>
        /// Stoppe la connexion pour une interrogation SQL.
        /// </summary>
        public void CloseQuery()
        {
            if(this.reqQuery != null) this.reqQuery.Close();
        }
        
        /// <summary>
        /// Stoppe la connexion a la base de donnees.
        /// </summary>
        public void CloseDB()
        {
            this.cnx.Close();
        }
    }
}
