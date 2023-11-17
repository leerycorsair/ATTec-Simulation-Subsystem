using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace Visualization
{
   public class PatternBodyDBContext:DbContext
    {
       public DbSet<PatternBodyParameter> PBContext { get; set; }
    }
}
