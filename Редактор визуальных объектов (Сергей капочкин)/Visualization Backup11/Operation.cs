using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace Visualization
{
   public  class Operation 
    {
    public string OPName { get; set; }
       public string OPPatName { get; set; }
       public string OPBody { get; set; }

       public static Operation createOperation(PatternOperations pbx)
       {
           Operation oper = new Operation();
           oper.OPPatName = Convert.ToString(pbx);



           return oper;
       }
      

       public int OPIndex { get; set; }
       public TextBlock Visual
       {
           get;
           set;
       }
       /// <summary>
       /// Линия для соединения с типом ресурсов
       /// </summary>
       public Line Line
       {
           get;
           set;
       }
    }
}
