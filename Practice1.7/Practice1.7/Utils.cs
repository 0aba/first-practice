using Newtonsoft.Json;
using System.Threading.Tasks;


namespace TodoAPP
{
    internal class Utils
    {
        public string pathJSONData;

        public List<TodoTask> todoTasks; 

        const int NOT_DEFIND = -1;

        public Dictionary<string, string> commandsInfo = new Dictionary<string, string>()
        {
            {"help", "help"},
            {"help-command", "help-command (команда)"},
            {"exit", "exit"},
            {"add-note", "add-note \"(название)\" \"(текст)\" (время в формате [dd/MM/yyyy-HH:mm:ss] например: 22/04/2023-11:45:23)"},
            {"delete-note", "delete-note \"(название)\""},
            {"clear-notes", "clear-notes"},
            {"update-note", "update-note \"(старое название / NONE)\" \"(новое название / NONE)\" \"(текст / NONE)\" (время в формате [dd/MM/yyyy-HH:mm:ss] например: 22/04/2023-11:45:23 / NONE)"},
            {"completed-notes", "completed-notes"},
            {"overdue-notes", "overdue-notes"},
            {"incompleted-notes", "incompleted-notes"},
            {"about-note", "about-note \"(название)\""},
            {"notes", "notes"},
            {"notes-today", "notes-today"},
            {"notes-tomorrow", "notes-tomorrow"},
            {"notes-toweek", "notes-toweek"},
            {"mark-completed", "mark-completed \"(название)\""}
        };

        public Utils()
        {
            pathJSONData = Directory.GetCurrentDirectory() + "/DataAPP.json";

            if (!File.Exists(pathJSONData))
            {
                File.Create(pathJSONData).Close(); // Close(), чтобы небыло ошибки несуществующий файл.
            }

            string dataJSON = File.ReadAllText(pathJSONData);

            todoTasks = JsonConvert.DeserializeObject<List<TodoTask>>(dataJSON);

            if (todoTasks is null)
            {
                todoTasks = new List<TodoTask>();
            }
        }

        public void saveСhanges()
        {
            string serializedTodoTasks = JsonConvert.SerializeObject(todoTasks);

            File.WriteAllText(pathJSONData, serializedTodoTasks);
        }

        public List<string> getDataFromString(string command)
        {
            List<string> commandData = new List<string>();

            command += " ";
            bool notInBrackets = true;

            int startWord = 0;
            int endWord = 0;

            foreach (char chr in command)
            {
                if (chr.Equals('"'))
                {
                    notInBrackets = !notInBrackets;
                }

                if (notInBrackets && chr.Equals(' '))
                {
                    commandData.Add(command.Substring(startWord, endWord - startWord));

                    startWord = endWord + 1;
                }
                ++endWord;
            }

            return commandData;
        }

        public int getIndexTask(string title)
        {
            int index = NOT_DEFIND;

            for(int i = 0; i < todoTasks.Count ;++i)
            {
                if (todoTasks[i].title == title)
                {
                    return i;
                }
            }

            return index;
        }

        public void printNoteTitle(TodoTask task)
        {
            int wight = 100;

            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.Write("|");

            Console.SetCursorPosition((wight - task.title.Length) / 2, Console.CursorTop);
            Console.Write(task.title);
            Console.SetCursorPosition(wight - 1, Console.CursorTop);

            Console.WriteLine("|");
            Console.WriteLine("----------------------------------------------------------------------------------------------------\n" +
                             string.Format("|                                       {0,20}                                       |\n", task.timeEnd) +
                             "----------------------------------------------------------------------------------------------------");
        }
    }
}
