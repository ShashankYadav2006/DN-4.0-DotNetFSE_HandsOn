using System;
using System.Threading;
// Main method
public class TestLogger
{
    public static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();
        logger1.Log("First message");
        logger2.Log("Second message");
        Console.WriteLine("Logger instance comparison: logger1 and logger2 refer to the same object ? " + (logger1 == logger2));
        Thread t1 = new Thread(() =>
        {
            Logger l = Logger.GetInstance();
            l.Log("Message from thread 1");
        })
        {
            Name = "Thread-1"
        };
        Thread t2 = new Thread(() =>
        {
            Logger l = Logger.GetInstance();
            l.Log("Message from thread 2");
        })
        {
            Name = "Thread-2"
        };
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
    }
}
