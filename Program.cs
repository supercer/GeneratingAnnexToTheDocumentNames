using System;

namespace GeneratingAnnexToTheDocumentNames
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string name;
                Console.WriteLine("Для выхода введите 1");
                Console.WriteLine("Введите название приложения");
                name = Console.ReadLine();
                if (name == "1") break;
                NamesForAnnexToTheDocument pril = new NamesForAnnexToTheDocument();
                pril.NameForAnnexToTheDocument = name;
                Console.WriteLine("Текущее приложение" + pril.ToString());
                Console.WriteLine("Введите название приложения для вывода следующего");
                name = Console.ReadLine();
                if (name == "1") break;
                Console.WriteLine(pril.AssigningTheNextNumberToTheAnnexToTheDocument(name));
            }
        }
    }
}
