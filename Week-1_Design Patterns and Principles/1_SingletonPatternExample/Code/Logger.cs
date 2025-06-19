using System;
using System.Threading;

//Singleton
public class Logger
{
    private static volatile Logger instance;
    private static readonly object lockObject = new object();
    private Logger()
    {
        Console.WriteLine("[Logger Initialized]");
    }
    public static Logger GetInstance()
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
            }
        }
        return instance;
    }
    public void Log(string message)
    {
        string threadName = Thread.CurrentThread.Name ?? Thread.CurrentThread.ManagedThreadId.ToString();
        Console.WriteLine("[" + threadName + "] Logging message: \"" + message + "\"");
    }
}
