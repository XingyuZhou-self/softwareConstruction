// 1、为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法。
// 通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）。
using System;

namespace GenericLinkedListDemo
{
    // 节点类 
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    // 泛型链表类
    public class MyLinkedList<T>
    {
        private Node<T> head;

        // 添加元素到链表尾部
        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node<T>(value);
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node<T>(value);
            }
        }

        // ForEach方法，遍历链表中的所有元素并执行指定的Action
        public void ForEach(Action<T> action)
        {
            Node<T> current = head;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 创建链表并添加一些整数元素
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.Add(5);
            list.Add(4);
            list.Add(3);
            list.Add(8);

            // 打印链表元素
            Console.WriteLine("链表元素：");
            list.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            // 使用lambda表达式求最大值、最小值和求和
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            list.ForEach(x =>
            {
                if (x > max) max = x;
                if (x < min) min = x;
                sum += x;
            });

            Console.WriteLine($"最大值：{max}");
            Console.WriteLine($"最小值：{min}");
            Console.WriteLine($"求和：{sum}");
        }
    }
}
