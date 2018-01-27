using System.Collections.Generic;
using System.Web;

namespace SampleProject.Models
{

    public class CustomerModel
    {
        public int id { get; set; }
        public string firstName { get; set; }

        public string middleName { get; set; }

        public string lastName { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string  state { get; set; }
        public int phoneNO { get; set; }
        public int mobileNo { get; set; }
        public string address { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public List<HttpPostedFileBase> Files { get; set; }

        public string proofType { get; set; }

        public string btnValue { get; set; }


    }
}
 
  