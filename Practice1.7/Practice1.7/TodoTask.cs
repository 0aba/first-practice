namespace TodoAPP
{
    internal class TodoTask
    {
        public TodoTask(string title, string text, string timeEnd)
        {
            this.title = title;
            this.text = text;
            this.timeEnd = timeEnd;

            complited = false;
        }

        public string title { get; set; }

        public string text { get; set; }

        public string timeEnd { get; set; } // DateTime в string dd/MM/yyyy-HH:mm:ss

        public bool complited { get; set; }
    }
}
