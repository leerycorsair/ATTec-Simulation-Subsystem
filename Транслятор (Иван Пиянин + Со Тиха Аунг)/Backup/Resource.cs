using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATTranslation
{
    /// <summary>
    /// Ресурс
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Имя_ресурса
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Имя_типа_ресурсов
        /// </summary>
        public string resource { get; set; }
        /// <summary>
        /// Трассировка
        /// </summary>
        public string trace { get; set; }
        /// <summary>
        /// Начальные_значения
        /// </summary>
        public string defaul { get; set; }
    }
}
