﻿namespace Exam70483CodeSamples.Threading._06
{
    using System;
    using System.Threading;

    /// <summary>
    /// Using ThreadLocal<T>
    /// </summary>
    /// <see cref="https://msdn.microsoft.com/en-us/library/dd642243(v=vs.110).aspx"/>
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/system.threading.thread.currentthread(v=vs.110).aspx"/>
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/system.threading.executioncontext.suppressflow(v=vs.110).aspx"/>
    class Program
    {
        static ThreadLocal<int> _field = new ThreadLocal<int>(() =>
        {
            return Thread.CurrentThread.ManagedThreadId;
        });

        static void Main(string[] args)
        {
            new Thread(() =>
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread A: {0}", i);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread B: {0}", i);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}