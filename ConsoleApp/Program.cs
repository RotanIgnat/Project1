using System;
using System.Collections.Generic;
using ModelBloger;

namespace ConsoleApp
{
    internal class Program
    {
        private static Logic _logic = new Logic();

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
                Console.WriteLine("6. Оставить только определенную платформу (Фильтр)");
                Console.WriteLine("7. Сортировка по подписчикам (с приоритетом платформы)"); // Новый пункт
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
                        SortSubscribersWithPlatformPriority(); // Вызов нового метода
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

        // 1. Вывод таблицы блогеров
        private static void ShowAllBloggers()
        {
            List<Blogger> list = _logic.ReadTable();

            if (list.Count == 0)
            {
                Console.WriteLine("Список блогеров пуст.");
            }
            else
            {
                Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-12} | {4,-15}", "ID", "Имя", "Подписчики", "Платформа", "Тематика");
                Console.WriteLine(new string('-', 75));

                foreach (var b in list)
                {
                    // Форматируем вывод: :N0 разделяет тысячи пробелами (например, 10 000 000)
                    Console.WriteLine("{0,-5} | {1,-20} | {2,-15:N0} | {3,-12} | {4,-15}", b.Id, b.Name, b.Subscribers, b.Platform, b.Topic);
                }
            }
            WaitForKey();
        }

        // 2. Добавление нового блогера
        private static void AddNewBlogger()
        {
            Console.WriteLine("--- Добавление нового блогера ---");

            Console.Write("Введите ID (число): ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            if (_logic.IdExists(id))
            {
                Console.WriteLine($"Ошибка: блогер с ID {id} уже существует.");
                WaitForKey();
                return;
            }

            Console.Write("Введите имя/никнейм: ");
            string name = Console.ReadLine();

            Console.Write("Введите кол-во подписчиков: ");
            if (!int.TryParse(Console.ReadLine(), out int subs)) return;

            Console.Write("Введите платформу (YouTube, Twitch...): ");
            string platform = Console.ReadLine();

            Console.Write("Введите тематику (Gaming, Tech...): ");
            string topic = Console.ReadLine();

            // Создаем объект через круглые скобки, используя ваш конструктор
            Blogger newBlogger = new Blogger(id, name, subs, platform, topic);
            _logic.AddBlogger(newBlogger);

            Console.WriteLine($"\nБлогер {name} успешно добавлен!");
            WaitForKey();
        }

        // 3. Удаление по ID
        private static void DeleteBlogger()
        {
            Console.Write("Введите ID блогера для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _logic.RemoveBlogger(id);
                Console.WriteLine("Команда на удаление выполнена (если ID существовал, блогер удален).");
            }
            else
            {
                Console.WriteLine("Ошибка: Введено не число.");
            }
            WaitForKey();
        }

        // 4. Редактировать данных
        private static void EditBlogger()
        {
            Console.Write("Введите ID блогера для редактирования: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            Console.Write("Введите НОВОЕ имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите НОВОЕ кол-во подписчиков: ");
            if (!int.TryParse(Console.ReadLine(), out int subs)) return;

            Console.Write("Введите НОВУЮ платформу: ");
            string platform = Console.ReadLine();

            Console.Write("Введите НОВУЮ тематику: ");
            string topic = Console.ReadLine();

            _logic.Change(name, id, subs, platform, topic);
            Console.WriteLine("Данные обновлены (если блогер с таким ID существовал).");
            WaitForKey();
        }

        // 5. Фильтрация
        private static void FilterBloggers()
        {
            Console.Write("Введите название платформы для фильтрации (остальные будут удалены): ");
            string platform = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(platform))
            {
                _logic.FilterByPlatform(platform);
                Console.WriteLine($"Список изменен. Оставлены только блогеры с платформы: {platform}");
            }
            WaitForKey();
        }

        // 7. Сортировка по двум уровням (Новый метод)
        private static void SortSubscribersWithPlatformPriority()
        {
            Console.WriteLine("--- Двухуровневая сортировка ---");
            Console.Write("Введите название платформы, которая должна быть на самом верху: ");
            string platform = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(platform))
            {
                // Вызываем метод с OrderByDescending и ThenByDescending из класса Logic
                _logic.SortSubscribersWithPlatformPriority(platform);
                Console.WriteLine($"\nСписок успешно пересортирован! Блогеры с платформы {platform} подняты вверх, и все группы упорядочены по подписчикам.");
            }
            else
            {
                Console.WriteLine("Ошибка: Введено пустое название платформы.");
            }
            WaitForKey();
        }

        // Вспомогательный метод для паузы экрана
        private static void WaitForKey()
        {
            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
    }
}
