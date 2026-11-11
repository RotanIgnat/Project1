using System.Collections.Generic;
using ModelBloger;

namespace BusinessLogic
{
    /// <summary>
    /// Интерфейс для фильтрации, сортировки и подсчёта статистики блогеров.
    /// </summary>
    public interface ISortFilterService
    {
        /// <summary>
        /// Устанавливает фильтр по платформе.
        /// </summary>
        /// <param name="platform">Название платформы.</param>
        /// <returns>Ничего не возвращает.</returns>
        void FilterByPlatform(string platform);

        /// <summary>
        /// Сбрасывает фильтр по платформе.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        void ClearFilter();

        /// <summary>
        /// Возвращает текущую платформу, по которой установлен фильтр.
        /// </summary>
        /// <returns>Название платформы или null.</returns>
        string? GetCurrentFilter();

        /// <summary>
        /// Включает сортировку по убыванию подписчиков.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        void SortSubscribers();

        /// <summary>
        /// Включает двухуровневую сортировку.
        /// </summary>
        /// <param name="targetPlatform">Платформа, которая должна быть вверху.</param>
        /// <returns>Ничего не возвращает.</returns>
        void SortSubscribersWithPlatformPriority(string targetPlatform);

        /// <summary>
        /// Возвращает сумму подписчиков всех блогеров указанной платформы.
        /// </summary>
        /// <param name="platform">Название платформы.</param>
        /// <returns>Суммарное число подписчиков.</returns>
        long GetSubscribersByPlatform(string platform);

        /// <summary>
        /// Возвращает список блогеров для показа пользователю с учётом фильтра и сортировки.
        /// </summary>
        /// <returns>Список блогеров.</returns>
        List<Blogger> ReadTable();
    }
}