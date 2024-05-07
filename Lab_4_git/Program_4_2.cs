    using System;
    using System.IO;

    namespace Lab4
    {
        class Program_4_2
        {
            public static void Program(string FILE)
            {
            //обробка виключень
                try
                {
                    if (FILE == null) 
                    {
                        LocalNetworkUsers.FILE_NAME = "LocalNetworkUsers.txt";
                    }
                    else 
                    {
                        LocalNetworkUsers.FILE_NAME = FILE;
                    }

                    char x; //змінна для збереження натиснутого символу

                //Виведення меню
                    do
                    {
                        Console.WriteLine("\nГарячі клавіші:" +
                                      "\t[Д] -------- додавання записів\n" +
                                      "\t\t[Р] -------- редагування записів\n" +
                                      "\t\t[Delete] --- знищення записів\n" +
                                      "\t\t[В] -------- виведення інформації з файла на екран\n" +
                                      "\t\t[П] -------- пошук користувача за його прізвищем\n" +
                                      "\t\t[С] -------- сортування за різними полями\n" +
                                      "\t\t[ESC] ---- вихід");

                        _ = LocalNetworkUsers.TestInvNum(); 
                        x = Console.ReadKey(true).KeyChar; //зчитування натиснутого символу

                        switch (x)//Перевірка натиснутого символу   
                        {
                            case 'Д':
                            case 'д':
                            case 'L':
                            case 'l':
                                LocalNetworkUsers.AddUser(); //виклик методу для додавання записів
                                Console.Clear();//кочищення консолі
                                break;

                            case 'Р':
                            case 'р':
                            case 'H':
                            case 'h':
                                LocalNetworkUsers.EditTovar(); 
                                Console.Clear();
                                break;

                            case (char)ConsoleKey.Delete:
                            case (char)0:
                                LocalNetworkUsers.DellLocalNetworkUsers(); 
                                Console.Clear();
                                break;  

                            case 'В':
                            case 'в':
                            case 'D':
                            case 'd':
                                Console.Clear();
                                LocalNetworkUsers.ViewTable(); 
                                break;

                            case 'П':
                            case 'п':
                            case 'G':
                            case 'g':
                                _ = LocalNetworkUsers.SurnameSearch();
                                break;

                            case 'С':
                            case 'с':
                            case 'C':
                            case 'c':
                                Console.Clear();
                                LocalNetworkUsers.SortLocalNetworkUsers(); 
                                break;

                            default: break;//для інших випадків нічого не робити
                        }
                    } while (x != (char)ConsoleKey.Escape); //повторювати цикл
                }
                catch (FileNotFoundException) //обробка виключень
                {
                    Console.WriteLine("Файл створено, наповніть його даними!");
                 
                    File.Create(LocalNetworkUsers.FILE_NAME).Close();//створення порожнього файлу
                    _ = Console.ReadKey(true); return;//завершення методу
                }
            //обробка інших виключень
                catch (Exception e) 
                {
                    Console.WriteLine("Помилка: " + e.Message);
                    _ = Console.ReadKey(true); return;
                }
            }
        }
    }
