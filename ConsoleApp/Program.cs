using System;
using System.Collections.Generic;
using System.Linq;
using ModelBloger;

namespace ConsoleApp
{
    internal class Program
    {
        private static Logic _logic = new Logic();

        /// <summary>
        /// Точка входа, главное меню программы.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        /// <returns>Ничего не возвращает.</returns>
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== ТЕРМИНАЛ УПРАВЛЕНИЯ БЛОГЕРАМИ ===");
                Console.WriteLine("1. Вывести список всех блогеров");
                Console.WriteLine("2. Добавить нового блогера");
                Console.WriteLine("3. Удалить блогера по ID");
                Console.WriteLine("4. Редактировать блогера по ID");
                Console.WriteLine("5. Отсортировать по количеству подписчиков");
                Console.WriteLine("6. Фильтрация по платформе");
                Console.WriteLine("7. Сортировка по подписчикам (с приоритетом платформы)");
                Console.WriteLine("8. Сумма подписчиков по платформе");
                Console.WriteLine("0. Выход из программы");
                Console.WriteLine("=====================================");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowAllBloggers();
                        break;
                    case "2":
                        AddNewBlogger();
                        break;
                    case "3":
                        DeleteBlogger();
                        break;
                    case "4":
                        EditBlogger();
                        break;
                    case "5":
                        _logic.SortSubscribers();
                        Console.WriteLine("Список успешно отсортирован по убыванию подписчиков!");
                        WaitForKey();
                        break;
                    case "6":
                        FilterBloggers();
                        break;
                    case "7":
                        SortSubscribersWithPlatformPriority();
                        break;
                    case "8":
                        ShowSubscribersByPlatform();
                        break;
                    case "0":
                        isRunning = false;
                        Console.WriteLine("Программа завершена. До свидания!");
                        break;
                    default:
                        Console.WriteLine("Ошибка: Неверный пункт меню. Попробуйте снова.");
                        WaitForKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Выводит список всех блогеров в виде таблицы.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private static void ShowAllBloggers()
        {
            PrintAllBloggers();
            WaitForKey();
        }

        /// <summary>
        /// Печатает таблицу блогеров без паузы. Используется в других методах.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private static void PrintAllBloggers()
        {
            List<Blogger> list = _logic.ReadTable();

            if (list.Count == 0)
            {
                Console.WriteLine("Список блогеров пуст.");
                return;
            }

            Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-12} | {4,-15}",
                "ID", "Имя", "Подписчики", "Платформа", "Тематика");
            Console.WriteLine(new string('-', 75));

            foreach (var b in list)
            {
                Console.WriteLine("{0,-5} | {1,-20} | {2,-15:N0} | {3,-12} | {4,-15}",
                    b.Id, b.Name, b.Subscribers, b.Platform, b.Topic);
            }
        }

        /// <summary>
        /// Запрашивает у пользователя данные и добавляет нового блогера.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private static void AddNewBlogger()
        {
            Console.WriteLine("--- Добавление нового блогера ---");

            Console.Write("Введите ID (число): ");
            string idInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idInput))
            {
                Console.WriteLine("Ошибка: ID не введён.");
                WaitForKey();
                return;
            }

            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
                WaitForKey();
                return;
            }

            if (_logic.IdExists(id))
            {
                Console.WriteLine($"Ошибка: блогер с ID {id} уже существует.");
                WaitForKey();
                return;
            }

            Console.Write("Введите имя/никнейм: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ошибка: имя не может быть пустым.");
                WaitForKey();
                return;
            }

            Console.Write("Введите кол-во подписчиков: ");
            string subsInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(subsInput))
            {
                Console.WriteLine("Ошибка: количество подписчиков не введено.");
                WaitForKey();
                return;
            }

            if (!int.TryParse(subsInput, out int subs))
            {
                Console.WriteLine("Ошибка: подписчики должны быть числом.");
                WaitForKey();
                return;
            }

            if (subs < 0)
            {
                Console.WriteLine("Ошибка: подписчики не могут быть отрицательными.");
                WaitForKey();
                return;
            }

            Console.Write("Введите платформу (YouTube, Twitch...): ");
            string platformInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(platformInput))
            {
                Console.WriteLine("Ошибка: платформа не может быть пустой.");
                WaitForKey();
                return;
            }

            string platform = NormalizePlatform(platformInput);

            Console.Write("Введите тематику (Gaming, Tech...): ");
            string topic = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(topic))
            {
                Console.WriteLine("Ошибка: тематика не может быть пустой.");
                WaitForKey();
                return;
            }

            Blogger newBlogger = new Blogger(id, name, subs, platform, topic);
            _logic.AddBlogger(newBlogger);

            Console.WriteLine();
            Console.WriteLine($"Блогер \"{name}\" успешно добавлен!");
            WaitForKey();
        }

        /// <summary>
        /// Показывает список блогеров, затем удаляет выбранного по ID.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private static void DeleteBlogger()
        {
            Console.WriteLine("--- Удаление блогера ---");
            PrintAllBloggers();
            Console.WriteLine();

            Console.Write("Введите ID блогера для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _logic.RemoveBlogger(id);
                Console.WriteLine("Команда на удаление выполнена (если ID существовал, блогер удален).");
            }
            else
            {
                Console.WriteLine("Ошибка: введено не число.");
            }
            WaitForKey();
        }

        /// <summary>
        /// Показывает список, запрашивает ID, затем новые значения полей и сохраняет изменения.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private static void EditBlogger()
        {
            Console.WriteLine("--- Редактирование блогера ---");
            PrintAllBloggers();
            Console.WriteLine();

            Console.Write("Введите ID блогера для редактирования: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
                WaitForKey();
                return;
            }

            Blogger current = _logic.ReadTable().FirstOrDefault(b => b.Id == id);
            if (current == null)
            {
                Console.WriteLine($"Блогер с ID {id} не найден.");
                WaitForKey();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Оставьте поле пустым, чтобы сохранить текущее значение.");
            Console.WriteLine();

            Console.Write($"Имя [{current.Name}]: ");
            string name = Console.ReadLine();

            Console.Write($"Подписчики [{current.Subscribers}]: ");
            string subsInput = Console.ReadLine();

            Console.Write($"Платформа [{current.Platform}]: ");
            string platformInput = Console.ReadLine();

            Console.Write($"Тематика [{current.Topic}]: ");
            string topic = Console.ReadLine();

            if (name == "") name = current.Name;
            if (topic == "") topic = current.Topic;

            string platform;
            if (platformInput == "")
            {
                platform = current.Platform;
            }
            else
            {
                platform = NormalizePlatform(platformInput);
            }

            int subs = current.Subscribers;
            if (subsInput != "")
            {
                if (int.TryParse(subsInput, out int parsedSubs))
                {
                    subs = parsedSubs;
                }
                else
                {
                    Console.WriteLine("Ошибка: подписчики должны быть числом. Оставлено текущее значение.");
                }
            }

            _logic.Change(name, id, subs, platform, topic);

            Console.WriteLine();
            Console.WriteLine("Данные обновлены. Текущая запись:");
            Console.WriteLine("{0,-5} | {1,-20} | {2,-15:N0} | {3,-12} | {4,-15}",
                current.Id, current.Name, current.Subscribers, current.Platform, current.Topic);

            WaitForKey();
        }

        /// <summary>
        /// Запрашивает платформу из списка и выводит только блогеров этой платформы.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private static void FilterBloggers()
        {
            Console.WriteLine("--- Фильтрация по платформе ---");

            List<string> platforms = _logic.ReadTable()
                .Select(b => b.Platform)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            if (platforms.Count == 0)
            {
                Console.WriteLine("Список блогеров пуст — нет платформ для выбора.");
                WaitForKey();
                return;
            }

            Console.WriteLine("Доступные платформы:");
            for (int i = 0; i < platforms.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {platforms[i]}");
            }
            Console.WriteLine();

            Console.Write("Введите номер платформы: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number) || number < 1 || number > platforms.Count)
            {
                Console.WriteLine("Ошибка: введён неверный номер.");
                WaitForKey();
                return;
            }

            string chosen = platforms[number - 1];
            List<Blogger> filtered = _logic.FilterByPlatform(chosen);

            if (filtered.Count == 0)
            {
                Console.WriteLine($"Нет блогеров с платформой \"{chosen}\".");
                WaitForKey();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Блогеры с платформой \"{chosen}\":");
            Console.WriteLine();

            Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-12} | {4,-15}",
                "ID", "Имя", "Подписчики", "Платформа", "Тематика");
            Console.WriteLine(new string('-', 75));

            foreach (Blogger b in filtered)
            {
                Console.WriteLine("{0,-5} | {1,-20} | {2,-15:N0} | {3,-12} | {4,-15}",
                    b.Id, b.Name, b.Subscribers, b.Platform, b.Topic);
            }

            WaitForKey();
        }

        /// <summary>
        /// Спрашивает платформу из списка и выполняет двухуровневую сортировку.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private static void SortSubscribersWithPlatformPriority()
        {
            Console.WriteLine("--- Двухуровневая сортировка ---");

            List<string> platforms = _logic.ReadTable()
                .Select(b => b.Platform)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            if (platforms.Count == 0)
            {
                Console.WriteLine("Список блогеров пуст — нет платформ для выбора.");
                WaitForKey();
                return;
            }

            Console.WriteLine("Доступные платформы:");
            for (int i = 0; i < platforms.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {platforms[i]}");
            }
            Console.WriteLine();

            Console.Write("Введите номер платформы: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number) || number < 1 || number > platforms.Count)
            {
                Console.WriteLine("Ошибка: введён неверный номер.");
                WaitForKey();
                return;
            }

            string chosen = platforms[number - 1];
            _logic.SortSubscribersWithPlatformPriority(chosen);

            Console.WriteLine();
            Console.WriteLine($"Список пересортирован. Платформа \"{chosen}\" — наверху, внутри — по подписчикам.");
            WaitForKey();
        }

        /// <summary>
        /// Спрашивает платформу из списка, выводит сумму подписчиков и таблицу блогеров этой платформы.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private static void ShowSubscribersByPlatform()
        {
            Console.WriteLine("--- Сумма подписчиков по платформе ---");

            List<string> platforms = _logic.ReadTable()
                .Select(b => b.Platform)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            if (platforms.Count == 0)
            {
                Console.WriteLine("Список блогеров пуст — нет платформ для выбора.");
                WaitForKey();
                return;
            }

            Console.WriteLine("Доступные платформы:");
            for (int i = 0; i < platforms.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {platforms[i]}");
            }
            Console.WriteLine();

            Console.Write("Введите номер платформы: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number) || number < 1 || number > platforms.Count)
            {
                Console.WriteLine("Ошибка: введён неверный номер.");
                WaitForKey();
                return;
            }

            string chosen = platforms[number - 1];
            long total = _logic.GetSubscribersByPlatform(chosen);
            List<Blogger> filtered = _logic.FilterByPlatform(chosen);

            Console.WriteLine();
            Console.WriteLine($"Платформа \"{chosen}\": {total:N0} подписчиков всего.");
            Console.WriteLine();
            Console.WriteLine("Блогеры этой платформы:");
            Console.WriteLine();

            Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-12} | {4,-15}",
                "ID", "Имя", "Подписчики", "Платформа", "Тематика");
            Console.WriteLine(new string('-', 75));

            foreach (Blogger b in filtered)
            {
                Console.WriteLine("{0,-5} | {1,-20} | {2,-15:N0} | {3,-12} | {4,-15}",
                    b.Id, b.Name, b.Subscribers, b.Platform, b.Topic);
            }

            WaitForKey();
        }

        /// <summary>
        /// Возвращает "правильное" написание платформы.
        /// Если такая платформа уже есть у других блогеров — возвращает её написание.
        /// Иначе возвращает строку как есть.
        /// </summary>
        /// <param name="input">Строка, введённая пользователем.</param>
        /// <returns>Нормализованное название платформы или исходную строку без пробелов.</returns>
        private static string NormalizePlatform(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            string trimmed = input.Trim();

            foreach (Blogger b in _logic.ReadTable())
            {
                if (b.Platform.Equals(trimmed, StringComparison.OrdinalIgnoreCase))
                {
                    return b.Platform;
                }
            }

            return trimmed;
        }

        /// <summary>
        /// Пауза: ждёт нажатия клавиши перед возвратом в меню.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private static void WaitForKey()
        {
            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
    }
}