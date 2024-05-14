using System;

public class Node // Оголошення класу Node 
{
    public int data; // Поле для збереження даних
    public Node next; // Вказівник на наступний елемент

    public Node(int value) // Конструктор класу Node
    {
        data = value;
        next = null;
    }
}

public class LinkedList // Оголошення класу LinkedList
{
    public Node head; // Поле для початкового вузла списку

    public void Add(int value) // Метод для додавання елементу до списку
    {
        if (head == null) // Якщо список порожній
        {
            head = new Node(value); // Створення нового вузла та встановлення його як початкового
        }
        else
        {
            AddRecursive(head, value); // Додавання елементу рекурсивно
        }
    }

    private void AddRecursive(Node current, int value) // Рекурсивне додавання елементу
    {
        if (current.next == null) // Якщо поточний вузол є останнім
        {
            current.next = new Node(value); // Створення нового вузла та встановлення його як наступного для поточного вузла
        }
        else
        {
            AddRecursive(current.next, value); // Рекурсивний виклик для наступного вузла
        }
    }

    public void Print() // Метод для виведення списку на екран
    {
        PrintRecursive(head); // Рекурсивне виведення списку
        Console.WriteLine(); // Виведення символу нового рядка після виведення всього списку
    }

    private void PrintRecursive(Node current) // Рекурсивне виведення списку
    {
        if (current != null) // Якщо поточний вузол не є останнім
        {
            Console.Write(current.data + " "); // Виведення значення поточного вузла
            PrintRecursive(current.next); // Рекурсивний виклик для наступного вузла
        }
    }

    public void RemoveByValue(int value) // Метод для вилучення елементів із списку за заданим значенням
    {
        head = RemoveRecursive(head, value); // Рекурсивне вилучення елементу
    }

    private Node RemoveRecursive(Node current, int value) // Рекурсивне вилучення елементу
    {
        if (current == null) // Якщо досягнуто кінця списку
        {
            return null;
        }
        if (current.data == value) // Якщо поточний вузол має задане значення
        {
            return current.next; // Повернення наступного вузла, щоб видалити поточний
        }
        current.next = RemoveRecursive(current.next, value); // Рекурсивний виклик для наступного вузла
        return current; // Повернення поточного вузла
    }
}

public class Program // Оголошення класу Program
{
    static void Main(string[] args) // Основний метод програми
    {
        LinkedList list = new LinkedList(); // Створення нового списку

        // Додавання елементів до списку
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(2);

        Console.WriteLine("Список елементів:"); // Виведення тексту на екран
        list.Print(); // Виведення списку на екран

        Console.WriteLine("Введіть значення для вилучення зі списку: ");
        int valueToRemove = Convert.ToInt32(Console.ReadLine());

        list.RemoveByValue(valueToRemove); // Виклик методу для вилучення елементів із списку за заданим значенням

        Console.WriteLine($"Список після вилучення елементів за значенням {valueToRemove}:"); // Виведення тексту на екран
        list.Print(); // Виведення списку на екран

        Console.ReadLine(); // Очікування натискання клавіші Enter перед завершенням програми
    }
}
