using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static SusiSu.Enums.Enums;

namespace SusiSu.Models
{
    public class Su
    {
        [Key]
        public int SuID { get; set; }

        [Required]
        [DisplayName("Stok Miktarı")]
        public int StokMiktari { get; set; }
       
        [DisplayName("Tür")]
        [Required]
        public Tur Tur { get; set; }

        [Required]
        public Boy Boy { get; set; }
        [Required]
        public int Fiyat { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Üretim Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UretimTarihi { get; set; } = DateTime.Now;

        
        private DateTime _SKullanmaTarihi;

        [DisplayName("Son Kullanma Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SKullanmaTarihi { get { return UretimTarihi.AddYears(3); }
            set
            {
                _SKullanmaTarihi = value;
            }
        }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        public virtual ICollection<SiparisDetay> SiparisDetay { get; set; }




    }
}