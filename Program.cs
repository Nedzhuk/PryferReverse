namespace PryferReverse;

internal class Program
{
    static void Main(string[] args)
    {
        int tmp = 0;
        string edgeArray = "";
        string resultFile = "Result.txt";
        string sourceFile = File.ReadAllText("Pryfer.txt");

        int[] vertexArray = new int[10];
        string[] sourceArray = sourceFile.Split(";");

        //Первичное заполнение массива вершин
        for (int i = 0; i < vertexArray.Length; i++)
        {
            vertexArray[i] = i + 1;
        }

        //Цикл, который выполняется при условии, что исходные данные не отсутствуют
        while (sourceFile[^1] != 0)
        {
            int[] minVertexArray = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int minVertex = int.MaxValue;

            Console.Write("\nКод прюфера:");
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Console.Write($" {sourceArray[i]}");
            }

            Console.Write("\nМассив вершин:");
            for (int i = 0; i < vertexArray.Length; i++)
            {
                Console.Write($" {vertexArray[i]}");
            }

            //Нахождение минимальных вершин среди всего массива
            for (int j = vertexArray.Length - 1; j >= 0; j--)
            {
                if (vertexArray[j] != 0)
                {
                    for (int i = 0; i < sourceArray.Length; i++)
                    {
                        if (vertexArray[j] == Convert.ToInt32(sourceArray[i]))
                        {
                            break;
                        }
                        else if (i == sourceArray.Length - 1)
                        {
                            minVertexArray[j] = vertexArray[j];
                        }
                    }
                }
            }

            for (int i = 0; i < minVertexArray.Length; i++)
            {
                if (minVertexArray[i] != 0 && minVertexArray[i] < minVertex)
                {
                    minVertex = minVertexArray[i];
                }
            }

            //Вывод для последней минимальной вершины
            if (sourceArray[^1] == "0")
            {
                edgeArray = WriteEdgeArray(edgeArray, vertexArray);
                Console.WriteLine($"\nМинимальная вершина: {minVertex}");
                break;
            }

            Console.WriteLine($"\nМинимальная вершина: {minVertex}");

            if (sourceArray[^1] != "0")
            {
                for (int i = 0; i < sourceArray.Length; i++)
                {
                    if (sourceArray[i] != "0")
                    {
                        edgeArray += sourceArray[i];
                        break;
                    }
                }
                edgeArray += $"-{minVertex}, ";
                Console.WriteLine($"Список ребер: {edgeArray}");
                sourceArray[tmp] = "0";

                vertexArray[minVertex - 1] = 0;
            }
            else
            {
                edgeArray = WriteEdgeArray(edgeArray, vertexArray);
                break;
            }
            tmp++;
        }

        File.WriteAllText(resultFile, edgeArray);
    }
    /// <summary>
    /// Изменение и вывод edgeArray
    /// </summary>
    /// <param name="edgeArray">Массив ребер</param>
    /// <param name="vertexArray">Массив вершин</param>
    /// <returns>Возвращает измененный edgeArray</returns>
    private static string WriteEdgeArray(string edgeArray, int[] vertexArray)
    {
        for (int i = 0; i < vertexArray.Length; i++)
        {
            if (vertexArray[i] != 0)
            {
                edgeArray += $"{vertexArray[i]} ";
            }
        }
        Console.WriteLine($"\nСписок ребер: {edgeArray}");
        return edgeArray;
    }
}