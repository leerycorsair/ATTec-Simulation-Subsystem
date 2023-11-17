using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATTranslation
{
    /// <summary>
    /// Тип ресурсов
    /// </summary>
    public class ResourceType
    {
        /// <summary>
        /// Имя_типа_ресурсов
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Вид_типа_ресурсов
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Параметр_типа
        /// </summary>
        public List<ResourceTypeParameter> param { get; set; }
      
    }
    /// <summary>
    /// Параметр типа ресурсов
    /// </summary>
    public class ResourceTypeParameter
    {
        /// <summary>
        /// Имя_параметра
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Тип_параметра
        /// </summary>
        public string type { get; set; }
        public string defaul { get; set; }
       
    }
}
