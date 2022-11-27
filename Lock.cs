using System;
using System.Threading;
	
public sealed class Program
{
    private static int _val;

    static void Foo(object num)
    {
        lock ((Object)_val)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(num);
            }
        }
    }

    public static void Main()
    {
        Thread thread1 = new Thread(() => Program.Foo(1));
        Thread thread2 = new Thread(() => Program.Foo(2));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}