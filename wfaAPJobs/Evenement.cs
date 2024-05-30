using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using wfaAPJobs.Properties;

namespace wfaAPJobs
{
    public class Horaires
    {
        public string from, to;
    }

    public class Evenement
    {
        private int _idEvt;
        private string _titreEvt;
        private string _descriptionEvt;
        private DateTime _dateEvt;
        private Horaires _horaires;
        private Utilisateur _auteurEvt;
        private bool _estPublie;

        public Evenement(
            int id,
            string titre,
            string description,
            DateTime date,
            Horaires horaires,
            Utilisateur auteur=null,
            bool estPublie=false
        )
        {
            this._idEvt = id;
            this._titreEvt = titre;
            this._descriptionEvt = description;
            this._dateEvt = date;
            this._horaires = horaires;
            this._auteurEvt = auteur;
            this._estPublie = estPublie;
        }

        public int idEvt
        {
            get
            {
                return this._idEvt;
            }
            set
            {
                this._idEvt = value;
            }
        }


        public string titreEvt
        {
            get
            {
                return this._titreEvt;
            }
            set
            {
                this._titreEvt = value;
            }
        }
        public string descriptionEvt
        {
            get
            {
                return this._descriptionEvt;
            }
            set
            {
                this._descriptionEvt = value;
            }
        }

        public DateTime dateEvt
        {
            get
            {
                return this._dateEvt;
            }
            set
            {
                this._dateEvt = value;
            }
        }

        public Horaires horaires
        {
            get
            {
                return this._horaires;
            }
            set
            {
                this._horaires = value;
            }
        }
        public Utilisateur auteur
        {
            get
            {
                return this._auteurEvt;
            }
            set
            {
                this._auteurEvt = value;
            }
        }
        public bool estPublie
        {
            get
            {
                return this._estPublie;
            }
            set
            {
                this._estPublie = value;
            }
        }

        public void saveIntoDB(bool isAnUpdate=false)
        {
            if (isAnUpdate)
            {
                return;
            }
        }

        public static List<Evenement> getAllEvents()
        {
            SqlConnector req = new SqlConnector();
            List<Evenement> events = new List<Evenement>();
            List<Dictionary<string, object>> data = req.query(Resources.REQ_GET_EVENTS);

            foreach (Dictionary<string, object> dt in data)
            {
                Utilisateur user = null;
//                if (dt["auteur"] != null)
//                    user = Program.listAccounts.Where(elem => elem.getId() == int.Parse(dt["auteur"].ToString())).ToList()[0];
                Horaires horaires = new Horaires();
                Horaires jsonHoraires = new Horaires();
                jsonHoraires.from = "08:30";
                jsonHoraires.to = "12:30";
                events.Add(
                    new Evenement(
                        int.Parse(dt["idEvt"].ToString()), 
                        dt["titreEvt"].ToString(), 
                        dt["description"].ToString(), 
                        DateTime.Parse(dt["dateEvt"].ToString()),
                        jsonHoraires,
                        user // auteur
                    )
                );
            }

            return events;
        }

    }
}
