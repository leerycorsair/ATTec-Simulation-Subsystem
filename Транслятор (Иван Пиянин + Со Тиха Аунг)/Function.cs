using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATTranslation
{
    /// <summary>
    /// Функция
    /// </summary>
    public class Function
    {
        /// <summary>
        /// Имя_функции
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Возвращаемый_тип
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Тело_функции
        /// </summary>
        public string tale { get; set; }
        /// <summary>
        /// Параметры функции
        /// </summary>
        public List<FuncParam> param { get; set; }
        public IEnumerator<Function> GetEnumerator()
        {
            while (true)
                yield return this;
        }
    }
    /// <summary>
    /// Параметры функции
    /// </summary>
    public class FuncParam
    {
        /// <summary>
        /// Имя_параметра_функции
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Тип_параметра_функции
        /// </summary>
        public string type { get; set; }
    }
}
