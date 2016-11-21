using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCItiraf.Models
{
   public class ItirafContext : DbContext
    {
        public virtual DbSet<Itiraf> itiraflar { get; set; }
    }
}
