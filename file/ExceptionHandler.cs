using System;

namespace file
{
    public static class ExceptionHandler
    {
        public static void ExceptionHandling(Exception e) {
            Console.WriteLine($"Было сгенерировано исключение: {e.Message}");
        }
    }
}
