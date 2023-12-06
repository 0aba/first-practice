using System.Globalization;


namespace TodoAPP
{
    internal class Сommands
    {
        private Utils _utils = new Utils();
        const int EXIT_COMMAND = 0;

        public void runСommand(string command)
        {
            Console.Clear();

           List<string> commandData = _utils.getDataFromString(command);

            switch (commandData[0])
            {
                case "help":
                    help();
                    break;

                case "help-command":
                    if (commandData.Count != 2)
                    {
                        Console.WriteLine("Ошибка количества аргументов");
                        return;
                    }

                    helpСommand(commandData[1]);
                    break;

                case "exit":
                    exit();
                    break;

                case "add-note":
                    if (commandData.Count != 4)
                    {
                        Console.WriteLine("Ошибка количества аргументов");
                        return;
                    }

                    addNote(commandData[1].Substring(1, commandData[1].Length - 2),
                                commandData[2].Substring(1, commandData[2].Length - 2),
                                commandData[3]);
                    break;

                case "delete-note":
                    if (commandData.Count != 2)
                    {
                        Console.WriteLine("Ошибка количества аргументов");
                        return;
                    }

                    deleteNote(commandData[1].Substring(1, commandData[1].Length - 2));
                    break;

                case "notes":
                    printNotes();
                    break;

                case "update-note":
                    if (commandData.Count != 5)
                    { 
                        Console.WriteLine("Ошибка количества аргументов");
                        return;
                    }

                    updateNote(commandData[1].Substring(1, commandData[1].Length - 2),
                                   commandData[2].Substring(1, commandData[2].Length - 2),
                                   commandData[3].Substring(1, commandData[3].Length - 2),
                                   commandData[4]);
                    break;

                case "clear-notes":
                    clearNotes();
                    break;

                case "completed-notes":
                    printCompletedNotes();
                    break;

                case "overdue-notes":
                    printOverdueNotes();
                    break;

                case "incompleted-notes":
                    printInCompletedNotes();
                    break;

                case "about-note":
                    if (commandData.Count != 2)
                    {
                        Console.WriteLine("Ошибка количества аргументов");
                        return;
                    }

                    aboutNote(commandData[1].Substring(1, commandData[1].Length - 2));
                    break;

                case "notes-today":
                    printNotesToday();
                    break;

                case "notes-tomorrow":
                    printNotesTomorrow();
                    break;

                case "notes-toweek":
                    printNotesToweek();
                    break;

                case "mark-completed":
                    if (commandData.Count != 2)
                    {
                        Console.WriteLine("Ошибка количества аргументов");
                        return;
                    }

                    markCompleted(commandData[1].Substring(1, commandData[1].Length - 2));
                    break;

                default:
                    Console.WriteLine("Такой команды нету воспользуйтесь командой 'help'");
                    break;
            }
        }

        // ---------------------------------------------------------------КОМАНДЫ---------------------------------------------------------------

        private void help()
        {
            Console.WriteLine("Информация о командах :\n\n" +
                              "'help': информация о командах \n\n" +
                              "'help-command': информация о команде и ее синтаксисе \n\n" +
                              "'exit': завершение программы \n\n" +
                              "'add-note': добавление заметки \n\n" +
                              "'delete-note': удаление заметки \n\n" +
                              "'clear-notes': удалить всех заметок \n\n" +
                              "'update-note': обнавление заметки \n\n" +
                              "'notes': вывести все заметки \n\n" +
                              "'completed-notes': вывести завершенные заметки \n\n" +
                              "'overdue-notes':  вывести просроченные заметки \n\n" +
                              "'incompleted-notes': вывести не завершенные заметки \n\n" +
                              "'about-note': подробнее о заметке \n\n" +
                              "'notes-today': заметки на сегодня \n\n" +
                               "'notes-tomorrow': заметки на завтра \n\n" +
                              "'notes-toweek': заметки на неделю \n\n" +
                              "'mark-completed': пометить заметку как выполненную \n\n"
                              );
        }

        private void helpСommand(string command)
        {
            string commandInfo = _utils.commandsInfo.GetValueOrDefault(command);

            Console.WriteLine("Дополнительная ифнормация: \n" +
                              "NONE - это специальное слово, которое означает оставить без изменений \n" +
                              "(см. в help-command в каких аргументах команды можно использовать) \n" +
                              "\"(...)\" - это означает, что информация должна быть записана в этих скобках \" \" даже если это одно слово \n" +
                              "(см. в help-command в каких аргументах команды нужно использовать) \n");
            Console.WriteLine("Синтаксис команды: ");

            Console.WriteLine(commandInfo is null ? "Ошибка такой команды нету" : commandInfo);
        }

        private void exit()
        {
            Environment.Exit(EXIT_COMMAND);
        }

        private void addNote(string title, string text, string timeEnd)
        {
            // timeEndParse не используется, но это обязательный аргумент TryParseExact
            bool isParse = DateTime.TryParseExact(timeEnd, "dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var timeEndParse);
            
            if (!isParse)
            {
                Console.WriteLine("Ошибка введенной даты: используете формат dd/MM/yyyy-HH:mm:ss например: 22/12/2023-11:05:00 ");
                return;
            }

            if(title.Length >= 100)
            {
                Console.WriteLine("Название должно быть меньше 100 символов");
                return;
            }

            TodoTask newTask = new TodoTask(title, text, timeEnd);
            _utils.todoTasks.Add(newTask);

            _utils.saveСhanges();
        }

        private void updateNote(string oldTitle, string newTitle, string text, string timeEnd)
        {
            int index = _utils.getIndexTask(oldTitle);

            if (index == -1)
            {
                Console.WriteLine("Ошибка такого элемента нету");
                return;
            }
            
            if (!newTitle.Equals("NONE"))
            {
                _utils.todoTasks[index].title = newTitle;
            }

            if (!text.Equals("NONE"))
            {
                _utils.todoTasks[index].text = text;
            }

            if (!timeEnd.Equals("NONE"))
            {
                // timeEndParse не используется, но это обязательный аргумент TryParseExact
                bool isParse = DateTime.TryParseExact(timeEnd, "dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var timeEndParse);

                if (isParse)
                {
                    _utils.todoTasks[index].timeEnd = timeEnd;
                }
                else
                {
                    Console.WriteLine("Ошибка введенной даты: используете формат dd/MM/yyyy-HH:mm:ss например: 02/12/2023-01:45:23 ");
                    Console.WriteLine("Ошибка время не было изменино");
                }
            }

            _utils.saveСhanges();
        }

        private void deleteNote(string title)
        {
            int index = _utils.getIndexTask(title);

            if(index == -1)
            {
                Console.WriteLine("Ошибка такого элемента нету");
                return;
            }

            _utils.todoTasks.RemoveAt(index);
            _utils.saveСhanges();
        }

        public void clearNotes()
        {
            _utils.todoTasks.Clear();

            _utils.saveСhanges();
        }

        private void printNotes()
        {
            foreach (TodoTask task in _utils.todoTasks)
            {
                _utils.printNoteTitle(task);

                Console.WriteLine();
            }
        }

        private void printCompletedNotes()
        {
            foreach (TodoTask task in _utils.todoTasks)
            {
                if (task.complited == true)
                {
                    _utils.printNoteTitle(task);

                    Console.WriteLine();
                }
            }
        }

        private void printOverdueNotes()
        {
            DateTime timeNow = DateTime.Now;

            foreach (TodoTask task in _utils.todoTasks)
            {
                DateTime taskData = DateTime.ParseExact(task.timeEnd, "dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);

                if (timeNow > taskData && task.complited != true)
                {
                    _utils.printNoteTitle(task);

                    Console.WriteLine();
                }
            }
        }

        private void printInCompletedNotes()
        {
            DateTime timeNow = DateTime.Now;

            foreach (TodoTask task in _utils.todoTasks)
            {
                DateTime taskData = DateTime.ParseExact(task.timeEnd, "dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);

                if (timeNow < taskData && task.complited != true)
                {
                    _utils.printNoteTitle(task);

                    Console.WriteLine();
                }
            }
        }

        private void aboutNote(string title)
        {
            int index = _utils.getIndexTask(title);

            if (index == -1)
            {
                Console.WriteLine("Ошибка такого элемента нету");
                return;
            }

            TodoTask taskAbout = _utils.todoTasks[index];

            _utils.printNoteTitle(taskAbout);

            Console.Write("|");
            byte countCharInLine = 0;

            foreach (char chr in taskAbout.text)
            {
                Console.Write(chr);

                if (countCharInLine == 95)
                {
                    Console.WriteLine("— |");
                    Console.Write("|");
                    countCharInLine = 0;
                }

                ++countCharInLine;
            }

            Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n" +
                 string.Format("|                                              {0,2} выполнена                                        |", (taskAbout.complited) ? "  ": "не") +
                              "\n----------------------------------------------------------------------------------------------------"
                              );
        }

        private void printNotesToday()
        {
            DateTime timeNow = DateTime.Now;

            foreach (TodoTask task in _utils.todoTasks)
            {
                DateTime taskData = DateTime.ParseExact(task.timeEnd, "dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);

                if (timeNow.Year == taskData.Year && timeNow.Month == taskData.Month && timeNow.Day == taskData.Day && task.complited != true)
                {
                   _utils.printNoteTitle(task);

                    Console.WriteLine();
                }
            }
        }

        private void printNotesTomorrow()
        {
            DateTime timeNow = DateTime.Now;

            timeNow = timeNow.AddDays(1);

            foreach (TodoTask task in _utils.todoTasks)
            {
                DateTime taskData = DateTime.ParseExact(task.timeEnd, "dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);

                if (timeNow.Year == taskData.Year && timeNow.Month == taskData.Month && timeNow.Day == taskData.Day && task.complited != true)
                {
                    _utils.printNoteTitle(task);

                    Console.WriteLine();
                }
            }
        }

        private void printNotesToweek()
        {
            DateTime timeNow = DateTime.Now;

            DateTime timeAfter7Days = DateTime.Now.AddDays(7);

            foreach (TodoTask task in _utils.todoTasks)
            {
                DateTime taskData = DateTime.ParseExact(task.timeEnd, "dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);

                if (timeNow < taskData && taskData <= timeAfter7Days && task.complited != true)
                {
                    _utils.printNoteTitle(task);

                    Console.WriteLine();
                }
            }
        }

        private void markCompleted(string title)
        {
            int index = _utils.getIndexTask(title);

            if (index == -1)
            {
                Console.WriteLine("Ошибка такого элемента нету");
                return;
            }

            _utils.todoTasks[index].complited = true;

            _utils.saveСhanges();
        }
    }
}
