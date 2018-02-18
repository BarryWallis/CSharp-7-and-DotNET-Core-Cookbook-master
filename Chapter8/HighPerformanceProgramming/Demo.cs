using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace HighPerformanceProgramming
{
    public static class Demo
    {
        private static object threadLock = new object();

        public static void DoBackgroundTask()
        {
            WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has a threadstate of {Thread.CurrentThread.ThreadState} with {Thread.CurrentThread.Priority} priority");
            WriteLine($"Start thread sleep at {DateTime.Now.Second} seconds");
            Thread.CurrentThread.Abort();
            Thread.Sleep(3000);
            WriteLine($"End thread sleep at {DateTime.Now.Second} seconds");
        }

        public static void IncreaseThreadPoolSize()
        {
            int numberOfProcessors = Environment.ProcessorCount;
            WriteLine($"Processor Count = {numberOfProcessors}");

            ThreadPool.GetMinThreads(out int minWorkerTHreads, out int minConcurrentActiveRequests);
            WriteLine($"Threadpool minimum Worker = {minWorkerTHreads} and minimum Requests = {minConcurrentActiveRequests}");
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxConcurrentActiveRequests);
            WriteLine($"Threadpool maximum Worker = {maxWorkerThreads} and maximum Requests = {maxConcurrentActiveRequests}");

            Random random = new Random();
            int newMaxWorker = random.Next(minWorkerTHreads, maxWorkerThreads);
            WriteLine($"New Max Worker Thread gnerated = {newMaxWorker}");

            int newMaxRequests = random.Next(minConcurrentActiveRequests, maxConcurrentActiveRequests);
            WriteLine($"New Max Active Requests generated = {newMaxRequests}");

            bool changeSucceeded = ThreadPool.SetMaxThreads(newMaxWorker, newMaxRequests);
            if (changeSucceeded)
            {
                WriteLine($"SetMaxThreads completed");
                ThreadPool.GetMaxThreads(out int maxWorkerThreadCount, out int maxConcurrentActiveRequestCount);
                WriteLine($"ThreadPool Max Worker = {maxWorkerThreadCount} and Max Requests = {maxConcurrentActiveRequestCount}");
            }
            else
            {
                WriteLine($"SetMaxThreads failed");
            }
        }

        public static void MultipleThreadWait()
        {
            Task thread1 = Task.Factory.StartNew(() => RunThread(3));
            Task thread2 = Task.Factory.StartNew(() => RunThread(5));
            Task thread3 = Task.Factory.StartNew(() => RunThread(2));

            Task.WaitAll(thread1, thread2, thread3);
            WriteLine("All tasks completed");
        }

        private static void RunThread(int sleepSeconds)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            WriteLine($"Sleep thread {threadId} for {sleepSeconds} seconds at {DateTime.Now.Second} seconds");
            Thread.Sleep(sleepSeconds * 1000);
            WriteLine($"Wake thread {threadId} at {DateTime.Now.Second} seconds");
        }

        public static void LockThreadExample()
        {
            Task thread1 = Task.Factory.StartNew(() => ContendedResource(3));
            Task thread2 = Task.Factory.StartNew(() => ContendedResource(5));
            Task thread3 = Task.Factory.StartNew(() => ContendedResource(2));
            Thread.CurrentThread.Name = $"NewThread {Thread.CurrentThread.ManagedThreadId}";
            Task.WaitAll(thread1, thread2, thread3);
            WriteLine($"All tasks completed");
        }

        private static void ContendedResource(int sleepSeconds)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            lock (threadLock)
            {
                WriteLine($"Locked for thread {threadId}");
                Thread.Sleep(sleepSeconds * 1000);
            }
            WriteLine($"Lock released for thread {threadId}");
        }

        public static void ParallelInvoke()
        {
            WriteLine($"Parallel.Invoke started at {DateTime.Now.Second} seconds");
            Parallel.Invoke(
                () => PerformSomeTask(3),
                () => PerformSomeTask(5),
                () => PerformSomeTask(2)
            );
            WriteLine($"Parallel.Invoke completed at {DateTime.Now.Second} seconds");
        }

        private static void PerformSomeTask(int sleepSeconds)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            WriteLine($"Sleep thread {threadId} for {sleepSeconds} seconds");
            Thread.Sleep(sleepSeconds * 1000);
            WriteLine($"Thread {threadId} resumed");
        }

        public static double ReadCollectionForEach(List<string> intCollection)
        {
            Stopwatch timer = Stopwatch.StartNew();
            foreach (string integer in intCollection)
            {
                WriteLine(integer);
                Clear();
            }
            return timer.Elapsed.TotalSeconds;
        }

        public static double ReadCollectionPrallelForEach(List<string> intCollection)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Parallel.ForEach(intCollection, integer =>
            {
                WriteLine(integer);
                Clear();
            });
            return timer.Elapsed.TotalSeconds;
        }

        public static void CreateWriteFilesForEach(List<string> intCollection)
        {
            WriteLine($"Start foreach file method");
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (string integer in intCollection)
            {
                string filePath = $@"..\..\Output\ForEach_Log{integer}.txt";
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                    using (StreamWriter streamWriter = new StreamWriter(filePath, false))
                    {
                        streamWriter.WriteLine($"{integer}. Log file start: {DateTime.Now.ToUniversalTime().ToString()}");
                    }
                }
            }
            WriteLine($"foreach file method executed in {stopwatch.Elapsed.TotalSeconds}");
        }

        public static void CreateWriteFilesParallelForEach(List<string> intCollection)
        {
            WriteLine($"Start Parallel.ForEach file method");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.ForEach(intCollection, integer =>
            {
                string filePath = $@"..\..\Output\Parallel.ForEach_Log{integer}.txt";
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                    using (StreamWriter streamWriter = new StreamWriter(filePath, false))
                    {
                        streamWriter.WriteLine($"{integer}. Log file start: {DateTime.Now.ToUniversalTime().ToString()}");
                    }
                }
            });
            WriteLine($"Parallel.ForEach file method executed in {stopwatch.Elapsed.TotalSeconds}");
        }

        public static void CancelPareallelForEach(List<string> integerCollection, int timeOut)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.ForEach(integerCollection, (integer, state) =>
            {
                Thread.Sleep(1000);
                if (stopwatch.Elapsed.Seconds > timeOut)
                {
                    WriteLine($"Terminate thread {Thread.CurrentThread.ManagedThreadId}. Elapsed time {stopwatch.Elapsed.Seconds} seconds");
                    state.Break();
                }
                WriteLine($"Processing item {integer} on thread {Thread.CurrentThread.ManagedThreadId}");
            });
        }

        public static void CheckClientMachinesOnline(List<string> ipAddresses, int minimumAlive)
        {
            try
            {
                ParallelOptions options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = ipAddresses.Count()
                };
                int deadMachines = 0;
                Parallel.ForEach(ipAddresses, options, ipAddress =>
                {
                    if (MachineReturnedPing(ipAddress))
                    {

                    }
                    else
                    {
                        if (ipAddresses.Count() - Interlocked.Increment(ref deadMachines) < minimumAlive)
                        {
                            WriteLine($"Machines to check = {ipAddresses.Count()}");
                            WriteLine($"Dead machines = {deadMachines}");
                            WriteLine($"Minimum machines required = {minimumAlive}");
                            WriteLine($"Live machines = {ipAddresses.Count() - deadMachines}");
                            throw new Exception($"Minimum machines requirement of {minimumAlive} not met");
                        }
                    }
                });
            }
            catch (AggregateException aggregationException)
            {
                WriteLine($"An AggregationException has ocurred: {aggregationException.Message}");
                throw;
            }
        }

        private static bool MachineReturnedPing(string ipAddress) => false; 
    }
}
