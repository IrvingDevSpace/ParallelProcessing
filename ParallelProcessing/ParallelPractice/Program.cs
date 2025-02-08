using CSV;
using ParallelPractice.Model;
using System.Diagnostics;

namespace ParallelPractice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string inputFilePath = @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_80000000.csv";
            string outputFilePath = @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\8000\MOCK_DATA_Output_80000000_{0}.csv";
            int totalRecords = 80000000;
            int batchSize = 2500000;

            int currentIndex = 0;
            int len = (totalRecords + batchSize - 1) / batchSize;
            var totalCount = 0;
            // 驗證檔案路徑是否有效
            CSVHelper.FilePathReadCheck(inputFilePath);
            CSVHeader.CsvFileContent csvContent = CSVHeader.CheckReadHeader<UserInfo>(inputFilePath);

            await Parallel.ForAsync(0, len, new ParallelOptions { MaxDegreeOfParallelism = 5 }, async (x, y) =>
            //await Parallel.ForAsync(0, len, async (x, y) =>
            {
                int startIndex = 1 + x * batchSize; // 計算當前批次的起始索引
                int quantity = Math.Min(batchSize, totalRecords - x * batchSize);
                int index = x;
                await Task.Run(() =>
                {
                    Console.WriteLine($"任務{index}開始, startIndex = {startIndex}, quantity = {quantity}");
                    var userInfos = CSVHelper.Read<UserInfo>(csvContent, inputFilePath, startIndex, quantity);
                    CSVHelper.Write<UserInfo>(string.Format(outputFilePath, index), userInfos);
                    totalCount += userInfos.Count;
                    Console.WriteLine($"任務{index}結束");
                });
            });

            // cancellation Token => 玩一下這個
            // lock mutex concurrentBag/concurrentQueue/ReadWriteSlim/SemaphoreSlim(紅綠燈機制)

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
