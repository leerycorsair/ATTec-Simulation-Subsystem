using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualization
{/// <summary>
 /// Параметр типа ресурса
 /// </summary>
    public class ResourceTypeParameter
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Тип: 0-integer, 1-real, 2-bool
        /// </summary>
        public string Type

        {
            get;
            set;
        }

        public string FKName { get; set;
        }

    /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public string Default
        {
            get;
            set;
        }
        /// <summary>
        /// Значение
        /// </summary>
        public string Value
        {
            get;
            set;
        }

    }
}
