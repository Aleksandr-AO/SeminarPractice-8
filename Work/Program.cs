/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы 
каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2

int[,] CreateRandomArray(int row, int column) //Создаем рандомный массив и заполняем его от 1 до 9.
{
    int[,] newArray = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            newArray[i, j] = new Random().Next(1, 10);
        }
    }
    return newArray;
}

void ShowArray(int[,] array) //Метод показывает массив
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int [,] DecreaseArray(int[,] array1) // Метод упорядочивает по убыванию элементы каждой строки двумерного массива
{
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array1.GetLength(1); j++)
        {
            for (int k = 0; k < array1.GetLength(1) - 1; k++) // - 1 для того чтобы мы смогли сравнить последнюю цифру колонки
            {
                if (array1[i, k] < array1[i, k + 1]) // сравнение позиции i и последующей +1
                {
                    int temp = array1[i, k + 1];
                    array1[i, k + 1] = array1[i, k];
                    array1[i, k] = temp;
                }
            }
        }
    }
    return array1;
}

Console.Write("Input count of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.Write("Input count of columns: ");
int columns = Convert.ToInt32(Console.ReadLine());

int [,] array2 = CreateRandomArray(rows, columns);
ShowArray(array2);

int [,] arrayConvert = DecreaseArray(array2);
ShowArray(arrayConvert);


Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7



int[,] CreateRandomArray() //Создаем рандомный массив и заполняем его от 1 до 9.
{
    int[,] newArray = new int[4, 4];
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            newArray[i, j] = new Random().Next(1, 10);
        }
    }
    return newArray;
}

void ShowArray(int[,] array) //Метод показывает массив
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void NumberRowMinSumElements(int[,] array)
{
    int minRow = 0;
    int minSumRow = 0;
    int sumRow = 0;

    for (int i = 0; i < array.GetLength(1); i++)
    {
        minRow = minRow + array[0, i];
    }

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        sumRow = sumRow + array[i, j];
        if (sumRow < minRow)
        {
            minRow = sumRow;
            minSumRow = i;
        }
        sumRow = 0;
    }
    Console.Write($"Cтрока с наименьшей суммой элементов: {minSumRow + 1}");
}

int[,] array1 = CreateRandomArray();
ShowArray(array1);
NumberRowMinSumElements(array1);


Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

int[,] ArraySpiral(int row, int column)
{
    int[,] scroll = new int[row, column];
    int number = 1;
    int iMin = 0;
    int jMin = 0;
    int iMax = row;  
    int jMax = column;  
    while (iMin < iMax && jMin < jMax)
    {
        int i = iMin; 
        int j = jMin;  
        for (j = jMin; j < jMax; j++)
        {
            scroll[i, j] = number;
            number++;
        }
        j = jMax - 1;  
        for (i = iMin + 1; i < iMax; i++) 
        {
            scroll[i, j] = number; 
            number++;
        }
        i = iMax - 1;
        for (j = jMax - 2; j >= jMin; j--)
        {
            scroll[i, j] = number;
            number++;
        }
        j = jMin;
        for (i = iMax - 2; i > iMin; i--)
        {
            scroll[i, j] = number;
            number++;
        }
        iMin++;
        jMin++;
        iMax--;
        jMax--;
    }
    return scroll;
}

void ShowArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < 10)
            {
                Console.Write("0" + array[i, j]);
                Console.Write(" ");
            }
            else Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

Console.Write("Enter row: ");
int rows = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter column: ");
int columns = Convert.ToInt32(Console.ReadLine());

int[,] Done = new int[rows, columns];
ShowArray(ArraySpiral(rows, columns));
