using System;
using System.IO;

namespace Копировалка_ссылок
{
    class FileWorker
    {
        readonly string directoryPath = @"Files";
        readonly string filePath = @"Files\Referenses.txt";
        public void CheckDirectory() {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            if (!directory.Exists)
                directory.Create();
        }

        public void WriteFile(string text) {
            File.AppendAllText(filePath, $@"{text};");
        }

        public string[] ReadFile() {
            if (!File.Exists(filePath)) {
                File.Create(filePath);
                return null;
            }
            else {
                string text = File.ReadAllText(filePath);
                if (text != "")
                    return text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                return null;
            }
        }
        
        public void DeleteReferens(string text) {
            string textFile = File.ReadAllText(filePath);
            if (textFile.Contains($@"{text};")) {
                textFile = textFile.Replace($"{text};", "");
                File.WriteAllText(filePath, textFile);
            }
        }
    }
}
