using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATTranslation
{
    /// <summary>
    /// Операция
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Имя_операции
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Имя_образца
        /// </summary>
        public string template { get; set; }
        /// <summary>
        /// Тело_образца
        /// </summary>
        public string tale { get; set; }
    }
}
