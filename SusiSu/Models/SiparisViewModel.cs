using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SusiSu.Enums.Enums;

namespace SusiSu.Models
{
    public class SiparisViewModel
    {

        public string UserID { get; set; }
        public Boy Boy { get; set; }
        public Tur Tur { get; set; }
        public int Adet { get; set; }
      

        public DateTime? SiparisTarihi { get; set; } = DateTime.Now;

        public int SiparisID { get; set; }

      



    }
}