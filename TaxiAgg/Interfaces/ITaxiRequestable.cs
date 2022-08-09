using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiAgg.Models;

namespace TaxiAgg.Interfaces
{
    internal interface ITaxiRequestable
    {
        int ServiceId { get; }

        /// <summary>
        /// Поиск такси по запросу
        /// </summary>
        /// <param name="args">Данные для запроса</param>
        /// <returns>Ответ с данными по исполнителю запроса</returns>
        ResponseTaxiModel Request(RequestTaxiParams args);

        /// <summary>
        /// Забронировать такси
        /// </summary>
        bool Book(int Id);

        /// <summary>
        /// Снять бронь
        /// </summary>
        bool UnBook(int Id);
    }
}
