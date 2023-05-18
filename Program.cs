namespace PryferReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string codePryfer = File.ReadAllText("Pryfer.txt");
            string tree = "";
            string[] masCodePryfer = codePryfer.Split(";");
            int[] mas = new int[10];
            
            int tmp = 0;

            for (int i = 0; i < mas.Length; i++) mas[i] = i + 1;
            while (codePryfer[codePryfer.Length - 1] != 0)
            {
                int[] masmin = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int min = int.MaxValue;

                Console.Write("\nКод прюфера:");
                for (int i = 0; i < masCodePryfer.Length; i++) Console.Write($" {masCodePryfer[i]}");

                Console.Write("\nМассив вершин:");
                for (int i = 0; i < mas.Length; i++) Console.Write($" {mas[i]}");


                for (int j = mas.Length - 1; j >= 0; j--)
                {
                    if(mas[j] != 0)
                    {
                        for (int i = 0; i < masCodePryfer.Length; i++)
                        {
                            if (mas[j] == Convert.ToInt32(masCodePryfer[i])) break;
                            else if (i == masCodePryfer.Length - 1) masmin[j] = mas[j];
                        }
                    }
                }

                for (int i = 0; i < masmin.Length; i++)
                    if (masmin[i] != 0 && masmin[i] < min) min = masmin[i];

                if (masCodePryfer[masCodePryfer.Length - 1] == "0")
                {
                    for (int i = 0; i < mas.Length; i++) if (mas[i] != 0) tree += $" {mas[i]}";
                    Console.WriteLine($"\nМинимальная вершина: {min}");
                    Console.WriteLine($"Список ребер: {tree}");
                    break;
                }
                    
                Console.WriteLine($"\nМинимальная вершина: {min}");

                if (masCodePryfer[masCodePryfer.Length - 1] != "0")
                {

                    for (int i = 0; i < masCodePryfer.Length; i++)
                        if (masCodePryfer[i] != "0")
                        {
                            tree += masCodePryfer[i];
                            break;
                        }
                    tree += $"-{min}, ";
                    Console.WriteLine($"Список ребер: {tree}");
                    masCodePryfer[tmp] = "0";

                    mas[min - 1] = 0;
                }
                else
                {
                    for (int i = 0; i < mas.Length; i++) if (mas[i] != 0) tree += $"{mas[i]} ";
                    Console.WriteLine($"Список ребер: {tree}");
                    break;
                }
                tmp++;
            }
            string result = "Result.txt";
            File.WriteAllText(result, tree);
        }
    }
}