using System;
using System.IO;
using System.Linq;//імпорт простуро імен

namespace Lab4
{
    public class LocalNetworkUsers
    {
        private const int maxLength = -20;//для макс довжини рядка
        private static string file_name;//для зберігання імені файлу
        private string id, surname, group, account, account_type;//для зберігання атрибутів користувача

        //Метод для отримання та встановлення імені файлу
        public static string FILE_NAME{
            get => file_name;// для отримання імені файлу
            set{
                if (value.Length > 150)
                {
                    throw new Exception("Кількість символів в назві файла не може перевищювати 150 символів.\nВказана назва файла: " + value);
                }
                file_name = value;
            } }//для встановлення 

        //Властивість ID-класу
        public string ID
        {
        get => id;//отримання значення ID
            set//встановлення значення ID
            {
                TestMaxLength(value);//перевірка на макс. довжину
                if (value.Equals("null")) { }
                else
                {
                    TestIsNumber(value, "Введено невірний ID");
                    id = Convert.ToString(int.Parse(value));
                }
                id = value;
            }
        }
        //Перевірка довжини переданих значень
        public string Surname
        {
            get => surname;
            set
            {
                TestMaxLength(value);
                surname = value;
            }
        }
        public string Group
        {
            get => group;
            set
            {
                TestMaxLength(value);
                group = value;
            }
        }
        public string Account
        {
            get => account;
            set
            {
                TestMaxLength(value);
                account = value;
            }
        }
        public string AccountType
        {
            get => account_type;
            set
            {
                TestMaxLength(value);
                account_type = value;
            }
        }
        //за замовчуванням
        public LocalNetworkUsers()
        {
            ID = "null";
            Surname = "null";
            Group = "null";
            Account = "null";
            AccountType = "null";
        }
        public LocalNetworkUsers(string s)
        {
            // Створення масива "х" в якому зберігаються дані
            string[] x = s.Split(';').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag)).ToArray();

            if (x.Length != 5) // Якщо вказані не всі дані, або їх забагато, повідомляє як має бути оформлена база
            {
                throw new Exception("\nДані в базі мають бути в такому форматі: ID; прізвище; група; обліковий запис; тип облікового запису;\n" +
                "\nПричина помилки: " + s);
            }
            //Повернення значень
            ID = x[0];
            Surname = x[1];
            Group = x[2];
            Account = x[3];
            AccountType = x[4];
        }

        public override string ToString() // в якому форматі виводити дані на екран
        {// Формування рядка з даними у вигляді таблиці з розділювачами
            return string.Format($"{"|"}{ID,maxLength + 15} {"|"}{Surname,maxLength -15} {"|"}{Group,maxLength + 6} {"|"}{Account,maxLength -4} {"|"}{AccountType,maxLength + -10} |\n" +
                                 "=======================================================================================================================");
        }

        //Метод для виведення таблиці
        public static void ViewTable()
        {
            LocalNetworkUsers[] local_network_users = ImportLocalNetworkUsers();//читання даних та їх імпорт у масив
            if (local_network_users.Length > 0)//перевірка
            {
                TableCap();//виведення заголовка табл
                foreach (LocalNetworkUsers item in local_network_users)//виведення даних табл.
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Файл порожній");
            }
        }
        //виведення табл. з переданим масивом
        public static void ViewTable(LocalNetworkUsers[] local_network_users)
        {

            if (local_network_users.Length > 0)
            {
                TableCap();
                foreach (LocalNetworkUsers item in local_network_users)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Файл порожній");
            }
        }
        public static void ViewTable(LocalNetworkUsers local_network_users)
        {
            TableCap();
            Console.WriteLine(local_network_users);
        }

        public static void TableCap()//метод для виведення заголовка табл.
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("|  ID  |               Прізвище             |     Група     |     Обліковий запис     |     Тип облікового запису     |");
            Console.WriteLine("=======================================================================================================================");
        }
       
        public static int CheckSizeArray() // метод для підрахування кк. рядків
        {
            int size = 0;
            using (StreamReader f = new StreamReader(FILE_NAME))//відкр. файлу для зчитування
            {
                while ((_ = f.ReadLine()) != null) { ++size; }
                f.Close();
                return size;
            }
        }

        public static LocalNetworkUsers[] ImportLocalNetworkUsers()//метод для імпорту даних з файлу
        {
            // створення масива для зберігання даних
            LocalNetworkUsers[] local_network_users = new LocalNetworkUsers[CheckSizeArray()];
            using (StreamReader f = new StreamReader(FILE_NAME))
            {
                string s; // для збереження рядка з бази даних
                int i = 0; // індекс для масива
                while ((s = f.ReadLine()) != null) // запис рядка з бази в масив
                {
                    local_network_users[i] = new LocalNetworkUsers(s);
                    ++i;
                }
                f.Close(); // закриття файла
            }
            return local_network_users;
        }

        public static void OutputLocalNetworkUsers(LocalNetworkUsers[] local_network_users)//метод для запису даних з масиву у файл
        {
            using (StreamWriter f = new StreamWriter(FILE_NAME))
            {
                //Запис даних
                foreach (LocalNetworkUsers item in local_network_users)
                {
                    f.Write(item.ID + "; ");
                    f.Write(item.Surname + "; ");
                    f.Write(item.Group + "; ");
                    f.Write(item.Account + "; ");
                    f.Write(item.AccountType + ";\n");
                }
                f.Close(); // закриття файла
            }
        }

        //метод для додавання нового користувача до файлу та записує його дані у рядок
        public static void OutputLocalNetworkUsers(LocalNetworkUsers local_network_users)
        {
            using (StreamWriter f = new StreamWriter(FILE_NAME, true))
            {
                f.Write(local_network_users.ID + "; ");
                f.Write(local_network_users.Surname + "; ");
                f.Write(local_network_users.Group + "; ");
                f.Write(local_network_users.Account + "; ");
                f.Write(local_network_users.AccountType + ";\n");
                f.Close(); // закриття файла
            }
        }
       
        //Метод для додавання нового користувача через консоль та збереження даних у файлі
        public static void AddUser()
        {
            LocalNetworkUsers newTovar = new LocalNetworkUsers();
            char x;
            do
            {//зчитування та встановлення даних
                Console.WriteLine("\nID:");
                newTovar.ID = ReadID();

                Console.WriteLine("Прізвище:");
                newTovar.Surname = TestIsLetter();
                    
                Console.WriteLine("Група:");
                newTovar.Group = TestIsLetter();

                Console.WriteLine("Обліковий запис:");
                newTovar.Account = TestIsLetter();

                Console.WriteLine("Тип облікового запису:");
                newTovar.AccountType = TestIsLetter();
                //виведення даних 
                Console.Clear();
                ViewTable(newTovar);
                Console.WriteLine("Для збереження натисніть [Enter]");
                Console.WriteLine("Для скасування додавання натисніть будьяку клавішу");

                x = Console.ReadKey(true).KeyChar;

                if (x == (char)ConsoleKey.Escape) {
                    return;
                }
            } while (x != (char)ConsoleKey.Enter);
            OutputLocalNetworkUsers(newTovar);//збереження нового користувача у файл
        }

        //Метод для редагування вже існуючих записів
        public static void EditTovar()
        {
            //імпорт користувачів з файлу
            LocalNetworkUsers[] local_network_users = ImportLocalNetworkUsers();
            //виведення таблиці користувачів
            ViewTable(local_network_users);
            string[] test = new string[local_network_users.Length];
            test = local_network_users.Select(tag => tag.ID).ToArray();
            int index;
            do
            {
                Console.Write("Введіть ID запису який потрібно редагувати: \n>");
                string id = Console.ReadLine();//зчитування запису
                //пошук за записом
                index = Array.IndexOf(test, id);
                if (index != -1)
                {
                    char x = 'z';
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("\n");
                        if (x == '0')
                        {
                            Console.WriteLine("====================================Такого пункта немає===================================\n");
                        }
                        //виведення даних для редагування
                        ViewTable(local_network_users[index]);
                        Console.WriteLine("Виберіть що саме потрібно редагувати:");
                        Console.WriteLine("[1] ID");
                        Console.WriteLine("[2] Прізвище");
                        Console.WriteLine("[3] Група");
                        Console.WriteLine("[4] Обліковий запис");
                        Console.WriteLine("[5] Тип облікового запису");
                        Console.WriteLine("[ESC] Вихід");
                        x = Console.ReadKey(true).KeyChar;

                        switch (x)
                        {
                            case (char)ConsoleKey.Escape:
                                Console.WriteLine("++++++++++++");
                                break;
                                //викликання певних функцій та присвоєння результатів
                            case '1':
                                local_network_users[index].ID = ReadInvNum(local_network_users);
                                break;

                            case '2':
                                local_network_users[index].Surname = TestIsLetter();
                                break;

                            case '3':
                                local_network_users[index].Group = TestIsLetter();
                                break;

                            case '4':
                                local_network_users[index].Account = TestIsLetter();
                                break;

                            case '5':
                                local_network_users[index].AccountType = TestIsLetter();
                                break;

                            default:
                                x = '0';
                                break;
                        }
                        Console.WriteLine("==");
                    } while (x != (char)ConsoleKey.Escape);
                }
            } while (index == -1);
            OutputLocalNetworkUsers(local_network_users);//збереження змін
        }

        public static void DellLocalNetworkUsers()
        {
            LocalNetworkUsers[] lnu = ImportLocalNetworkUsers();//завантаження даних користувачів
            ViewTable(lnu);//вивід табл. з даними
            Console.Write("\nВведіть ID запису який потрібно видалити:\n>");//ведення ID користувача, який потрібно видалити
            string delInv = Console.ReadLine();
            //проходження по кожному записі і пошук Id, який потрібно видалити
            for (int i = 0; i < lnu.Length; i++)
            {
                if (int.Parse(lnu[i].ID).Equals(int.Parse(delInv)))//переврка чи id співпадають
                {
                    lnu = lnu.Where(val => val != lnu[i]).ToArray();//видалення з масиву
                }
            }
            OutputLocalNetworkUsers(lnu);//виведення оновленої табл
        }

        public static int TestInvNum()//перевірка унікальності номерів користувачів
        {
            int num = 0;
            LocalNetworkUsers[] local_network_users = ImportLocalNetworkUsers();//імпорт даних
            //перевірка кожного запису
            for (int i = 0; i < local_network_users.Length - 1; i++)
            {
                for (int j = 0; j < local_network_users.Length - 1; j++)
                {
                    if ((2 + j) - (1 + i) == 0)//пропускаємо перевірку якщо індекси збігаються
                    {
                        continue;
                    }
                    else if (local_network_users[i].ID.Equals(local_network_users[1 + j].ID))//перевірка чи id збігаються
                    {
                        num++;
                        Console.WriteLine("\nЗаписи:");
                        TableCap();
                        Console.WriteLine("" +
                                            local_network_users[i] + "\n" +
                                            local_network_users[1 + j] + "\n" +
                                            "\nМають одинакові номери\n" +
                                            "В базі ці записи знаходяться у рядках: " + (1 + i) + " --- " + (2 + j) +
                                            "\n------------------------------------------------------------------------------------------");
                    }
                }
            }
            return num;
        }
        //приватний метод для перевірки унікальності id
        private static bool TestInvNum(LocalNetworkUsers[] local_network_users, LocalNetworkUsers newTovar)
        {
            foreach (var item in local_network_users)//перевіряємо кожний ел. масиву
            {
                if (item.ID.Equals(newTovar.ID))//перевірка на співпадіння
                {
                    return true;//якщо знайдено
                }
            }
            return false;//якщо ні
        }
        //приватний метод для зчитування унікальності id введеного користувачем
        private static string ReadInvNum(LocalNetworkUsers[] local_network_users)
        {
            bool ok;
            LocalNetworkUsers local_network_userss = new LocalNetworkUsers();
            do
            {
                local_network_userss.ID = TestIsNumber();//зчитування id нового корисувача
                ok = TestInvNum(local_network_users, local_network_userss);//перевірка унікальнотсі
                if (ok)
                {
                    Console.WriteLine("Запис з таким номером уже є, задайте інший або відредагуйте дані уже існуючого запису");
                }
            } while (ok);
            return local_network_userss.ID;
        }
        private static string ReadID()
        {
            LocalNetworkUsers[] local_network_users = ImportLocalNetworkUsers();
            bool ok;
            LocalNetworkUsers local_network_userss = new LocalNetworkUsers();
            do
            {
                local_network_userss.ID = TestIsNumber();
                ok = TestInvNum(local_network_users, local_network_userss);
                if (ok)
                {
                    Console.WriteLine("Запис з таким номером уже є, задайте інший або відредагуйте дані уже існуючого запису");
                }
            } while (ok);
            return local_network_userss.ID;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static int SurnameSearch()//пошук користувачів за прізвищем
        {
            LocalNetworkUsers[] local_network_users = ImportLocalNetworkUsers();

            string surnameSearch = TestIsLetter();
            int num = 0;
            for (int i = 0; i < local_network_users.Length; i++)//пошук користувачів за введеним прізвищем
            {
                if (local_network_users[i].Surname.Contains(surnameSearch))
                {
                    TableCap();//вивід знайдених записів
                    for (int j = i; j < local_network_users.Length; j++)
                    {
                        if (local_network_users[j].Surname.Contains(surnameSearch))
                        {
                            num++;
                            Console.WriteLine(local_network_users[j]);
                        }
                    }
                    break;
                }
            }
            Console.WriteLine("\nЗнайдено записів = {0}\n", num);//вивід кількість знайдени записів
            return num;
        }

        public static void SortLocalNetworkUsers()//сортування записів користувачів за типом облікового запису.
        {
            LocalNetworkUsers[] local_network_users = ImportLocalNetworkUsers();
 
            Array.Sort(local_network_users, (a, b) => CompareAccountType(a, b));
            OutputLocalNetworkUsers(local_network_users);

            Console.WriteLine("База відcортована за полем: Тип облікового запису");
            
        }

        private static int CompareAccountType(LocalNetworkUsers a, LocalNetworkUsers b)
        {
            return a.AccountType.CompareTo(b.AccountType);
        }

        private static void TestIsNumber(string str, string ErrorMessage)
        {
            if (str.Equals("null"))
            {
                return;
            }
            // Перевірка чи str є числом, і якщо не є то створює виключення з текстом ErrorMessage
            if (!double.TryParse(str, out _))
            {
                Console.WriteLine("Причина помилки: \"{0}\"", str);
                throw new Exception(ErrorMessage);
            }
        }
        private static bool TestIsNumber(string str)
        {
            if (!double.TryParse(str, out _))
            {
                return false;
            }
            return true;
        }
        private static string TestIsNumber()
        {
            string tmp;
            bool tmp_bool;
            do
            {
                Console.Write(">");
                tmp = Console.ReadLine();
                if (tmp == null || tmp.Equals(""))
                {
                    return "null";
                }
                tmp_bool = TestIsNumber(tmp);
                if (!tmp_bool)
                {
                    Console.WriteLine("Помилка введіть ще раз!");
                }
            } while (!tmp_bool);
            return tmp;
        }
        private static string TestIsLetter()
        {
            string tmp;
            bool tmp_bool;
            do
            {
                Console.Write(">");
                tmp = Console.ReadLine();

                if (tmp == null || tmp.Equals(""))
                {
                    return "null";
                }
                tmp_bool = TestIsLetter(tmp);
                if (!tmp_bool)
                {
                    Console.WriteLine("Помилка введіть ще раз!");
                }
            } while (!tmp_bool);
            return tmp;
        }
        private static bool TestIsLetter(string str)
        {
            if (str.Length > -maxLength)
            {
                return false;
            }
            return true;
        }
        private static void TestMaxLength(string str)
        {
            if (str.Length > -maxLength * 2)
            {
                Console.WriteLine("Причина помилки: " + str);
                throw new Exception("Кількість символів не може бути довша за " + (-maxLength * 2) + " символів");
            }
        }
    }
}
