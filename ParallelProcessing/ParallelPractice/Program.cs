using CSV;
using ParallelPractice.Model;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

namespace ParallelPractice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string inputFilePath = @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_80000000.csv";
            //string outputFilePath = @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\8000\MOCK_DATA_Output_80000000_{0}.csv";
            string outputFilePath = @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\8000\MOCK_DATA_Output_80000000.csv";
            int totalRecords = 80000000;
            int batchSize = 2500000;

            int currentIndex = 0;
            int len = (totalRecords + batchSize - 1) / batchSize;
            var totalCount = 0;
            // 驗證檔案路徑是否有效
            CSVHelper.FilePathReadCheck(inputFilePath);
            CSVHeader.CsvFileContent csvContent = CSVHeader.CheckReadHeader<UserInfo>(inputFilePath);

            //object writeLock = new object();
            ////Mutex mutex = new Mutex();

            //await Parallel.ForAsync(0, len, new ParallelOptions { MaxDegreeOfParallelism = 5 }, async (x, y) =>
            ////await Parallel.ForAsync(0, len, async (x, y) =>
            //{
            //    int startIndex = 1 + x * batchSize; // 計算當前批次的起始索引
            //    int quantity = Math.Min(batchSize, totalRecords - x * batchSize);
            //    int index = x;
            //    await Task.Run(() =>
            //    {
            //        Console.WriteLine($"任務{index}開始, startIndex = {startIndex}, quantity = {quantity}");
            //        var userInfos = CSVHelper.Read<UserInfo>(csvContent, inputFilePath, startIndex, quantity);
            //        lock (writeLock)
            //        {
            //            //CSVHelper.Write<UserInfo>(string.Format(outputFilePath, index), userInfos);
            //            CSVHelper.Write<UserInfo>(outputFilePath, userInfos);
            //            totalCount += userInfos.Count;
            //        }
            //        //mutex.WaitOne();
            //        //CSVHelper.Write<UserInfo>(outputFilePath, userInfos);
            //        //totalCount += userInfos.Count;
            //        //mutex.ReleaseMutex();
            //        Console.WriteLine($"任務{index}結束");
            //    });
            //});

            //// ConcurrentQueue
            //ConcurrentQueue<UserInfo> queue = new ConcurrentQueue<UserInfo>();
            //await Parallel.ForAsync(0, len, new ParallelOptions { MaxDegreeOfParallelism = 5 }, async (x, y) =>
            ////await Parallel.ForAsync(0, len, async (x, y) =>
            //{
            //    int startIndex = 1 + x * batchSize; // 計算當前批次的起始索引
            //    int quantity = Math.Min(batchSize, totalRecords - x * batchSize);
            //    int index = x;
            //    await Task.Run(() =>
            //    {
            //        Console.WriteLine($"任務{index}開始, startIndex = {startIndex}, quantity = {quantity}");
            //        var userInfos = CSVHelper.Read<UserInfo>(csvContent, inputFilePath, startIndex, quantity);
            //        foreach (UserInfo userInfo in userInfos)
            //            queue.Enqueue(userInfo);
            //    });
            //});
            //CSVHelper.Write<UserInfo>(outputFilePath, queue.ToList());
            //Console.WriteLine($"任務結束");

            ////concurrentBag
            //ConcurrentBag<UserInfo> bags = new ConcurrentBag<UserInfo>();
            //await Parallel.ForAsync(0, len, new ParallelOptions { MaxDegreeOfParallelism = 5 }, async (x, y) =>
            ////await Parallel.ForAsync(0, len, async (x, y) =>
            //{
            //    int startIndex = 1 + x * batchSize; // 計算當前批次的起始索引
            //    int quantity = Math.Min(batchSize, totalRecords - x * batchSize);
            //    int index = x;
            //    await Task.Run(() =>
            //    {
            //        Console.WriteLine($"任務{index}開始, startIndex = {startIndex}, quantity = {quantity}");
            //        var userInfos = CSVHelper.Read<UserInfo>(csvContent, inputFilePath, startIndex, quantity);
            //        foreach (UserInfo userInfo in userInfos)
            //            bags.Add(userInfo);
            //    });
            //});
            //CSVHelper.Write<UserInfo>(outputFilePath, bags.ToList());
            //Console.WriteLine($"任務結束");

            //// ReaderWriterLockSlim
            //ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
            //await Parallel.ForAsync(0, len, new ParallelOptions { MaxDegreeOfParallelism = 5 }, async (x, y) =>
            ////await Parallel.ForAsync(0, len, async (x, y) =>
            //{
            //    int startIndex = 1 + x * batchSize; // 計算當前批次的起始索引
            //    int quantity = Math.Min(batchSize, totalRecords - x * batchSize);
            //    int index = x;
            //    await Task.Run(() =>
            //    {
            //        Console.WriteLine($"任務{index}開始, startIndex = {startIndex}, quantity = {quantity}");
            //        rwLock.EnterReadLock();
            //        var userInfos = CSVHelper.Read<UserInfo>(csvContent, inputFilePath, startIndex, quantity);
            //        rwLock.ExitReadLock();

            //        rwLock.EnterWriteLock();
            //        CSVHelper.Write<UserInfo>(outputFilePath, userInfos);
            //        totalCount += userInfos.Count;
            //        rwLock.ExitWriteLock();
            //    });
            //});

            // cancellation Token => 玩一下這個
            // lock mutex concurrentBag/concurrentQueue/ReadWriteSlim/SemaphoreSlim(紅綠燈機制)

            // lock mutex concurrentQueue ReadWriteSlim

            //await Parallel.ForAsync(0, 10, async (x, y) =>
            //{
            //    await Task.Delay(1000);
            //    Console.WriteLine(x + "任務完成");
            //});
            //for (int i = 0; i < 10; i++)
            //{
            //    int index = i + 1;
            //    await Task.Run(async () =>
            //    {
            //        await Task.Delay(1000);
            //        Console.WriteLine(index + "任務完成");
            //    });
            //}
            stopwatch.Stop();
            Console.WriteLine(totalCount);
            Console.WriteLine(stopwatch.Elapsed.ToString());
            Console.WriteLine("Hello, World!");
        }
    }
}
