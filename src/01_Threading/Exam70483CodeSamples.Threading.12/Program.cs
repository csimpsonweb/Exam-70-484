﻿namespace Exam70483CodeSamples.Threading._12
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Attaching child tasks to a parent task
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var result = new Int32[3];

                new Task(() => result[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                return result;
            });

            var finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (int i in parentTask.Result)
                        Console.WriteLine(i);
                });

            finalTask.Wait();
        }
    }
}