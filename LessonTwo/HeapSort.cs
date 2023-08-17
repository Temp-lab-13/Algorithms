// Сортировки.

// Задание: 
// Реализовать алгоритм пирамидальной сортировки (сортировка кучей).

// Процедура распечатывает полученный массив 
// и переводит каретку на новую строку.
void Print(int[] array)
{
    Console.Write(string.Join(" ", array));
    Console.WriteLine();
}

// Функция создаёт и возвращает рандомный целочисленный массив.
int[] CreatRandomArray(int length, int min, int max)
{
    int[] array = new int[length];
    for (int i = 0; i < length; i++)
    {
        array[i] = new Random().Next(min, max + 1);
    }
    return array;
}


void HeapSort(int[] array)
{
    for (int i = array.Length / 2 - 1; i >= 0; i--)
    {
        Heap(array, array.Length, i);
    }
    for (int i = array.Length - 1; i >= 0; i--)
    {
        int temp = array[0];
        array[0] = array[i];
        array[i] = temp;

        Heap(array, i, 0);
    }
}

void Heap(int[] array, int haepSize, int index)
{
    int maxElement = index;
    int leftChild = 2 * index + 1;
    int rightChild = 2 * index + 2;

    if (leftChild < haepSize && array[leftChild] > array[maxElement])
    {
        maxElement = leftChild;
    }
    if (rightChild < haepSize && array[rightChild] > array[maxElement])
    {
        maxElement = rightChild;
    }
    if (maxElement != index)
    {
        int temp = array[index];
        array[index] = array[maxElement];
        array[maxElement] = temp;

        Heap(array, haepSize, maxElement);
    }
}

int[] randomArray = CreatRandomArray(10, 0, 100);

Print(randomArray);

HeapSort(randomArray);

Print(randomArray);