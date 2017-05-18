using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookApp.UI
{
    class Company
    {
        private string name;
        private string email;
        private string phone;
        private string identi;
        private string weburl;


        public string CompanyName
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string ContactNo
        {
            get { return phone; }
            set { phone = value; }
        }

        public string IdentificationNo
        {
            get { return identi; }
            set { identi = value; }
        }
       
        public string WebSiteUrl
        {
            get { return weburl; }
            set { weburl = value; }
        }   

    }
}
