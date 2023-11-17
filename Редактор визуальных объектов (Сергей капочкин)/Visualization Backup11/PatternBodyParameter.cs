using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Visualization
{
  public  class PatternBodyParameter
    {
        public string ConvertEvent { get; set; }
        public string FKPB { get; set; }
      [Key][Required]  public string ConvertRule { get; set; }
      public string precondition { get; set; }
        public string ConvertBegin { get; set; }
        public string ConvertEnd { get; set; }
        public string FKRevResName { get; set; }
        public string FKPOName { get; set; }
    }
}
