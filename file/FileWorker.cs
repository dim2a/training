using System;
using System.IO;

namespace file
{
    internal class FileWorker
    {

        internal string ReadFile(string path) {
            string text = String.Empty;
            try {
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream)) {
                    text = streamReader.ReadToEnd();
                }
            }
            catch(Exception e) {
                ExceptionHandler.ExceptionHandling(e);
            }
            return text;
        }

        internal void WriteFile(string path, string strToSave, out bool success) {
            try {
                var filestream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                using (var streamReader = new StreamWriter(filestream)) {
                    streamReader.Write(strToSave);
                    success = true;
                }
            }
            catch(Exception e) {
                ExceptionHandler.ExceptionHandling(e);
                success = false;
            }
        }

        internal bool CheckFileExisting(string path) {
            return File.Exists(path);
        }

    }
}
