using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace Visualization
{
    /// <summary>
    /// Ресурс
    /// </summary>
    public class Resource
    {
     
        ///<summary>
        ///Имя ресурса
        ///</summary>
        public string Name
        {
            get;
            set;
        }
        public int state
        {
            get;
            set;
        }
        /// <summary>
        /// Признак трассировки
        /// </summary>
        public string isTrace
        {
            get;
            set;
        }
        public bool boolisTrace
        {
            get;
            set;
        }
        /// <summary>
        /// Соответствующий тип ресурса
        /// </summary>
        public ResourceType Type
        {
            get;
            set;
        }
        public string RType
        {
            get;
            set;
        }
        public string RNameTest
        {
            get;
            set;
        }
        /// <summary>
        /// Описание параметра
        /// </summary>
        public List<ResourceTypeParameter> Param
        {
            get;
            set;
        }
        /// <summary>
        /// Визуализация
        /// </summary>
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
        public string EventStat { get; set; }

        public void merd(string Name, string Type )
        {
            RNameTest = Name;
            RType = Type;


        }
        public void ResourceTypeNotEmpty(ObservableCollection<ResourceType> RT )
        {
           if (RT.Count == 0)
           {
               state = 2;
               EventStat = "Нет типов ресурсов";
           }


        }


        public void RTypeEmpty(string type)
        {
            if (type.Length == 0)
            {
                state = 1;
                EventStat = "Не выбран тип ресурсов";
            }
            
        }
        public static Resource createResource(ResourceType resType)
        {
            Resource res = new Resource();
            res.Type = resType;
            res.Param = new List<ResourceTypeParameter>();
            for (int i = 0; i < resType.Param.Count; i++)
            {
                ResourceTypeParameter t = new ResourceTypeParameter();
                t.Name = resType.Param.ElementAt(i).Name;
                t.Type = resType.Param.ElementAt(i).Type;
                t.Default = resType.Param.ElementAt(i).Default;
                res.Param.Add(t);
            }
           
            return res;
        }
         bool isComboSelect = false;
       


                
            


        
        }

    }

