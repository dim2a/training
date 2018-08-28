using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace file
{
    internal class TaskWorker
    {
        internal string FormResult(string phrase) {
            string result = String.Empty;

            phrase = phrase.ToLower();

            try {
                var wordCollection = Regex.Split(phrase,@"[^a-z/-]+");  // в качестве разделителя используем все небуквенные символы и не '-'
                //сортируем по алфавиту, группируем коллекцию по слову и приводим к словарю где: ключ - слово, значение - число повторений
                var wordDictionary = wordCollection.OrderBy(word => word).GroupBy(word => word).ToDictionary(x => x.Key, y =>y.Count());
                //внутри словаря группируем по первой букве слова
                var firstLetterDictionary = wordDictionary.GroupBy(x => x.Key.First()).ToDictionary(x => x.Key, y => y);

                foreach (KeyValuePair<char, IGrouping<char, KeyValuePair<string, int>>> val in firstLetterDictionary) {
                    result += val.Key;
                    result += "\r\n";   //конец строки и перевод на новую строку

                    var sortedValues = val.Value.OrderBy(x => x.Value); //сортируем внутри сгруппированых элементов по частоте

                    foreach (var sortVal in sortedValues) {
                        result += $"{sortVal.Key} - {sortVal.Value}";
                        result += "\r\n";
                    }
                    result += "\r\n";
                }
            }
            catch(Exception e) {
                ExceptionHandler.ExceptionHandling(e);
            }
            return result;
        }

    }
}
