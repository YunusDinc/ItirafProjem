using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCItiraf.Models
{
    public class Itiraf
    {
        [Key]
        public int ItirafID { get; set; }
        [Required]
        public string Mesaj { get; set; }
        public int ToplamBegeni { get; set; }
        public DateTime Tarih { get; set; }

        [NotMapped] //veritabanına kaydedilmesin
        public string NeKadarOnce
        {
            get
            {
                //nesnenin tarihini çıkardık
                TimeSpan fark = DateTime.Now - Tarih;
                string sonuc = fark.Days + " gün, " + fark.Hours + " saat, " + fark.Minutes + " dakika önce yazıldı.";
                return sonuc;
            }
        }

        public Itiraf() { Tarih = DateTime.Now; }
    }
}
