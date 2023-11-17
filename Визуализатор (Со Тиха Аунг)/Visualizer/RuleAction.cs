using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    public class RuleAction
    {
        /// <summary>
        /// Список_статических_элементов
        /// </summary>
        public List<SElement> SElementList { get; set; }
        /// <summary>
        /// Список_динамических_элементов
        /// </summary>
        public List<DElement> DElementList { get; set; }
    }
    public class SElement
    {
        /// <summary>
        /// Имя_элемента
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// X-координат
        /// </summary>
        public string xCor { get; set; }
        /// <summary>
        /// Y-координат
        /// </summary>
        public string yCor { get; set; }
    }


    public class DElement
    {
        /// <summary>
        /// Имя_элемента
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Начало X-координата
        /// </summary>
        public string xCorStart { get; set; }
        /// <summary>
        /// Конец X-координата
        /// </summary>
        public string xCorEnd { get; set; }
        /// <summary>
        /// Тип изменения X-координата
        /// </summary>
        public string xChangeType { get; set; }
        /// <summary>
        /// Значение изменения X-координата
        /// </summary>
        public string xChangeValue { get; set; }
        /// <summary>
        /// Начало Y-координата
        /// </summary>
        public string yCorStart { get; set; }
        /// <summary>
        /// Конец Y-координата
        /// </summary>
        public string yCorEnd { get; set; }
        /// <summary>
        /// Тип изменения Y-координата
        /// </summary>
        public string yChangeType { get; set; }
        /// <summary>
        /// Значение изменения Y-координата
        /// </summary>
        public string yChangeValue { get; set; }
    }

}
