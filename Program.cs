class Progaramm
{
    static async Task WriteToFileAsync(string data, string fileName)
    {
        // Открытие файла для записи
        using (StreamWriter writer = File.AppendText(fileName))
        {
            // Асинхронно записать данные в файл
            await writer.WriteAsync(data);
        }
    }

    static void DoOtherTask(string fileName)
    {
        StreamReader reader = new StreamReader($"{fileName}.txt");
        string fCopy = reader.ReadToEnd();
        int i = fCopy.Length;
        Console.WriteLine("Длина записи в файле: " + i);
    }

    static async Task Main()
    {
        try
        {
            Console.WriteLine("Введите название файла:");
            string fileName = Console.ReadLine();
            Console.WriteLine("Введите данные для записи в файл: ");
            string data = Console.ReadLine();

            Console.WriteLine("Желаете ли вы добавить данные в файл?(Да/Нет)");
            string s = Console.ReadLine();
            if (s == "Да" ||  s == "да")
            {
                Console.WriteLine("Введите данные для записи в файл: ");
                string data2 = Console.ReadLine();
                data += data2;
            }
            Task task = WriteToFileAsync(data, $"{fileName}.txt");

            Console.WriteLine("Ожидание записи в файл...");

            DoOtherTask(fileName);

            await task;
        }
        catch { Console.WriteLine("Мимо, брат. Всё мимо"); }
    }
}