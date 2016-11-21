using MVCItiraf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCItiraf.Controllers
{
   public class ItirafController : Controller
    {
        // localhost:1111/Itiraf/
        // localhost:1111/Itiraf/Index
        public ActionResult Index()
        { //Anasayfa
            ItirafContext ctx = new ItirafContext();
            return View(ctx.itiraflar.OrderByDescending(x=> x.ItirafID).ToList());
        }
        [HttpGet]
        public ActionResult ItirafYaz()
        {
            return View();
        }

        [HttpPost]
        //mesaj parametresinin adı input'un name özelliğinden geliyor
        public ActionResult ItirafYaz(string mesaj)
        {
            ItirafContext ctx = new ItirafContext();
            Itiraf i = new Itiraf();
            i.Mesaj = mesaj;
            ctx.itiraflar.Add(i);
            ctx.SaveChanges();
            return View();
        }
        // localhost:1111/
        public string Alkisla(int hangiitiraf)
        {
            if (Session["alkis"+hangiitiraf] == null)
            {
                //oy verebilir, daha once alkis olusmamıs
                //veritabanından alkışlanan itirafı bulalım
                ItirafContext ctx = new ItirafContext();
                var i = ctx.itiraflar.Find(hangiitiraf);
                //begenisayısını 1 artıralım
                i.ToplamBegeni++;
                //veritabanına kaydedelim
                ctx.Entry(i).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                Session["alkis"+hangiitiraf] = "birsey";
                return "Teşekkür ederiz";
            }
            else
                return "Daha önce oy kullanmışsınız";
        }
        public string Kiskisla(int hangiitiraf)
        {
            if (Session["Kiskisla" + hangiitiraf] == null)
            {
                ItirafContext ctx = new ItirafContext();
                var i = ctx.itiraflar.Find(hangiitiraf);


                
            }
        }
    }
}
