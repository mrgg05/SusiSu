using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SusiSu.Enums
{
    public class Enums
    {

        public enum Tur
        {
            Cam,
            Plastik

        }
        public enum Boy
        {
            [Display(Name="0,5 L")]
            [Description("0,5 L")]
           kucuk,
            [Display(Name = "1,5 L")]
            [Description("1,5 L")]
           orta,
            [Display(Name = "5 L")]
            [Description("5 L")]
           buyuk,
            [Display(Name = "19 L")]
            [Description("19 L")]
           Damacana
           
        
    }

    }
}