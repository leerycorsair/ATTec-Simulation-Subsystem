using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATTranslation
{
    /// <summary>
    /// Образец операции
    /// </summary>
    public class OperationTemplate
    {
        /// <summary>
        /// Имя_образца
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Тип_образца
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Трассировка
        /// </summary>
        public string trace { get; set; }
        /// <summary>
        /// Релевантный_ресурс (список)
        /// </summary>
        public List<RelevantResource> relevantResource { get; set; }
        /// <summary>
        /// Время
        /// </summary>
        public Time time { get; set; }
        /// <summary>
        /// Тело_образца
        /// </summary>
        public List<Rule> rule { get; set; }
    }
    /// <summary>
    /// Релевантный ресурс для образца операции
    /// </summary>
    public class RelevantResource
    {
        /// <summary>
        /// Имя_релевантного_ресурса
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Описатель
        /// </summary>
        public string descriptor { get; set; }
        /// <summary>
        /// Статус_конвертора
        /// </summary>
        public string convertor { get; set; }
        /// <summary>
        /// Статус_конвертора_начала
        /// </summary>
        public string convertorStart { get; set; }
        /// <summary>
        /// Статус_конвертора_конца
        /// </summary>
        public string convertorEnd { get; set; }
    }
    /// <summary>
    /// Время для образца операции
    /// </summary>
    public class Time
    {
        /// <summary>
        /// Тип
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Закон
        /// </summary>
        public string law { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// Начало_интервала
        /// </summary>
        public string start { get; set; }
        /// <summary>
        /// Конец_интервала
        /// </summary>
        public string end { get; set; }
    }
    /// <summary>
    /// Правило для образца операции
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Имя_релевантного_ресурса
        /// </summary>
        public string resource { get; set; }
        /// <summary>
        /// Предусловие
        /// </summary>
        public string precondition { get; set; }
        /// <summary>
        /// Convert_event
        /// </summary>
        public string convertEvent { get; set; }
        /// <summary>
        /// Convert_rule
        /// </summary>
        public string convertRule { get; set; }
        /// <summary>
        /// Convert_begin
        /// </summary>
        public string convertBegin { get; set; }
        /// <summary>
        /// Convert_end
        /// </summary>
        public string convertEnd { get; set; }
    }
}
