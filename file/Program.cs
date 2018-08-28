using System;


namespace file
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите адрес входного файла");  //a.txt
            string inputFile = Console.ReadLine();

            string outputFile = "result.txt";   //сразу зададим имя выходного файла

            FileWorker fw = new FileWorker();

            while (!fw.CheckFileExisting(inputFile)) {
                Console.WriteLine("Файл не существует, повторите попытку: ");
                inputFile = Console.ReadLine();
            }

            var phrase = fw.ReadFile(inputFile);

            if (!string.IsNullOrEmpty(phrase)) {
                TaskWorker tw = new TaskWorker();

                string result = tw.FormResult(phrase);
                if (!string.IsNullOrEmpty(result)) {
                    fw.WriteFile(outputFile, result, out bool isWritingDone);
                    if (isWritingDone) {
                        Console.WriteLine($"Файл был записан, проверьте файл {outputFile}");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
