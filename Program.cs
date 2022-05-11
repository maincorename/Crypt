
class Program
{
    public static void Main()
    {
        try
        {
            //todo все локальные переменные в var
            Console.WriteLine("Зашифровать(0) файл или расшифровать(1)?: ");
            int changeCrypt = Convert.ToInt32(Console.ReadLine()); //todo все Console.ReadLine() в отдельные переменные

            Console.WriteLine("Задайте кол-во строк: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Задайте кол-во столбцов: ");//todo->
            int columns = Convert.ToInt32(Console.ReadLine());//todo повторяющийся выше код, надо вынести в метод типа: private int GetNumberFromUser(string title)
            
            string namefile = "cryptedText.txt";
            string[] Text; // todo локальные переменные называем с маленькой буквы 
            string[,] mas = new string[rows, columns];

            Text = File.ReadAllLines(namefile);

            int ltext = Text[0].Length;
            int count = 0;

            //todo цикл можно вынести в отдельный метод 
            for (int i = 0; i < rows; i++) //записывание данных файла в двумерный массив, заданный пользователем
            {
                for (int j = 0; j < columns; j++)
                {
                    if (count < ltext)
                    {
                        mas[i, j] = Convert.ToString(Text[0][count]);
                        count++;
                    }
                    else mas[i, j] = " ";
                }
            }

            char[] charText = new char[rows*columns]; //string[] Text запрещает менять элементы по индексу 
            count = 0;
            if(changeCrypt == 0) //todo в тернарный оператор с вызовами разных методов
            {
                //todo в отдельный метод
                for (int j = columns - 1; j < columns; j--) //зашифровка методом перестановки
                {
                    for (int i = 0; i < rows; i++)
                    {
                        charText[count] = Convert.ToChar(mas[i, j]);
                        count++;
                    }
                    if (j == 0) break;
                }
            } else
            {
                //todo в отдельный метод
                for (int j = 0; j < columns; j++) //расшифровка. при расшифровке НЕ квадратных матриц, размерность вписывать инвертную шифрованной
                {                                 //шифровали 5х6 расшифровка будет работать при 6x5
                    for (int i = rows - 1; i < rows; i--)
                    {
                        charText[count] = Convert.ToChar(mas[i, j]);
                        count++;
                        if (i == 0) break;
                    }
                }
            }
            
            StreamWriter sw = new StreamWriter("cryptedText.txt"); //todo имена лучше не сокращать => streamWriter
            sw.WriteLine(charText);
            sw.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine("Файл не может быть прочитан: ");
            Console.WriteLine(e.Message);
        }
        //todo обработать не только IO exceptions
    }
}



