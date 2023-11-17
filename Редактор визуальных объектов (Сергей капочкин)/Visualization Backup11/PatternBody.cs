using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Visualization
{
    public class PatternBody
    {
        public string POName //Имя_образца (Образец операции)
        { get; set; }

        public string POType //Тип_образца (Образец операции)
        { get; set; }

        public bool POisTrace { get; set; } //Трассировка (Образец операции)
        public List<RelevantResource> RevList { get; set; }

        public TextBlock Vi2l { get; set; }

        public string revresName { get; set; } //Имя_релевантного_ресурса
        public List<PatternBodyParameter> PBparameter { get; set; }
        public List<Time> PBTime { get; set; }

        public static PatternBody createPB(ResourceType RRType)
        {
            PatternBody PB = new PatternBody();
            PB.revresName = Convert.ToString(RRType);



            return PB;
        }

    }
}
