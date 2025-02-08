using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProcessing.Model
{
    public class UserInfo
    {
        //[DisplayName("Id")]
        public String Id { get; set; }

        //[DisplayName("名字")]
        public String FirstName { get; set; }

        //[DisplayName("姓氏")]
        public String LastName { get; set; }

        //[DisplayName("電子郵件")]
        public String Email { get; set; }

        //[DisplayName("性別")]
        public String Gender { get; set; }

        //[DisplayName("IP位址")]
        public String IpAddress { get; set; }
    }
}
