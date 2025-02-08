using CSV;
using CSV.Model;
using ParallelProcessing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProcessing
{
    internal class Program
    {
        private static Mutex mutex;

        static async Task Main(string[] args)
        {
            mutex = new Mutex(true, "TEST");
            if (!mutex.WaitOne(0, false))
            {
                Console.WriteLine("程式已開啟");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("開始執行...");

            DateTime startTime = DateTime.Now;
            //// 10000
            //List<UserInfo> userInfos = CSVHelper.Read<UserInfo>(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_10000.csv");
            //CSVHelper.Write(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_10000.csv", userInfos);

            //// 10000
            //CSVHelper.ProcessLargeCSV<UserInfo>(
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_10000.csv",
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_10000.csv",
            //    10000,
            //    1000000
            //    );

            //// 50000
            //List<UserInfo> userInfos = CSVHelper.Read<UserInfo>(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_50000.csv");
            //CSVHelper.Write(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_50000.csv", userInfos);

            //// 50000
            //CSVHelper.ProcessLargeCSV<UserInfo>(
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_50000.csv",
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_50000.csv",
            //    50000,
            //    1000000
            //    );

            //// 100000
            //List<UserInfo> userInfos = CSVHelper.Read<UserInfo>(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_100000.csv");
            //CSVHelper.Write(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_100000.csv", userInfos);

            //// 100000
            //CSVHelper.ProcessLargeCSV<UserInfo>(
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_100000.csv",
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_100000.csv",
            //    100000,
            //    1000000
            //    );

            //// 500000
            //List<UserInfo> userInfos = CSVHelper.Read<UserInfo>(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_500000.csv");
            //CSVHelper.Write(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_500000.csv", userInfos);

            //// 500000
            //CSVHelper.ProcessLargeCSV<UserInfo>(
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_500000.csv",
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_500000.csv",
            //    500000,
            //    1000000
            //    );

            //// 1000000
            //List<UserInfo> userInfos = CSVHelper.Read<UserInfo>(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_1000000.csv");
            //CSVHelper.Write(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_1000000.csv", userInfos);

            //// 1000000

            //string inputFilePath = @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_5000000.csv";
            //string outputFilePath = @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_5000000.csv";
            //int totalRecords = 5000000;
            //int batchSize = 100000;

            //int currentIndex = 0;
            //bool first = true;
            //while (currentIndex < totalRecords)
            //{
            //    int startIndex = currentIndex + 1; // 計算當前批次的起始索引
            //    int quantity = Math.Min(batchSize, totalRecords - currentIndex); // 確保最後一批數量正確

            //    DateTime s = DateTime.Now;

            //    // 讀取當前批次的資料
            //    var records = CSVHelper.Read<UserInfo>(first, inputFilePath, startIndex, quantity);

            //    DateTime e = DateTime.Now;
            //    var d = e - s;
            //    Console.WriteLine($"StartTime : {s.ToString("HH:mm:ss:fffffff")}");
            //    Console.WriteLine($"EndTime : {e.ToString("HH:mm:ss:fffffff")}");
            //    Console.WriteLine($"Diff : {d}");
            //    Console.WriteLine();

            //    // 寫入當前批次的資料
            //    CSVHelper.Write(outputFilePath, records);

            //    currentIndex += batchSize;
            //    first = false;
            //}

            //CSVHelper.ProcessLargeCSV<UserInfo>(
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_1000000.csv",
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_1000000.csv",
            //    1000000,
            //    100000
            //    );

            //// 5000000
            //List<UserInfo> userInfos = CSVHelper.Read<UserInfo>(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_5000000.csv");
            //CSVHelper.Write(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_5000000.csv", userInfos);

            //// 5000000
            //CSVHelper.ProcessLargeCSV<UserInfo>(
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_5000000.csv",
            //    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_5000000.csv",
            //    5000000,
            //    1000000
            //    );

            //string inputFilePath = @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_10000000.csv";
            //string outputFilePath = @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\1000\MOCK_DATA_Output_10000000_{0}.csv";
            //int totalRecords = 10000000;
            //int batchSize = 840000;

            //int currentIndex = 0;
            //int len = (totalRecords + batchSize - 1) / batchSize;
            //var totalCount = 0;
            //// 驗證檔案路徑是否有效
            //CSVHelper.FilePathReadCheck(inputFilePath);
            //CSVHeader.CsvFileContent csvContent = CSVHeader.CheckReadHeader<UserInfo>(inputFilePath);

            //List<Task> tasks = new List<Task>();
            //for (int i = 0; i < len; i++)
            //{
            //    int startIndex = currentIndex + 1; // 計算當前批次的起始索引
            //    int quantity = Math.Min(batchSize, totalRecords - currentIndex); // 確保最後一批數量正確
            //    int index = i;
            //    var task = Task.Run(() =>
            //    {
            //        Console.WriteLine($"任務{index}開始, startIndex = {startIndex}, quantity = {quantity}");
            //        var userInfos = CSVHelper.Read<UserInfo>(csvContent, inputFilePath, startIndex, quantity);
            //        //CSVHelper.Write<UserInfo>(string.Format(outputFilePath, index), userInfos);
            //        totalCount += userInfos.Count;
            //        Console.WriteLine($"任務{index}結束");
            //    });
            //    currentIndex += batchSize;
            //    tasks.Add(task);
            //}
            //await Task.WhenAll(tasks);
            ////// 10000000
            ////List<UserInfo> userInfos = CSVHelper.Read<UserInfo>(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_10000000.csv");
            ////CSVHelper.Write(@"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_10000000.csv", userInfos);

            ////// 10000000
            ////CSVHelper.ProcessLargeCSV<UserInfo>(
            ////    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\datas\MOCK_DATA_10000000.csv",
            ////    @"C:\Users\IRVING\Program Course\Code\ParallelProcessing\output\MOCK_DATA_Output_10000000.csv",
            ////    10000000,
            ////    5000000
            ////    );

            //Console.WriteLine();
            //Console.WriteLine();
            //DateTime endTime = DateTime.Now;
            //var diff = endTime - startTime;
            //Console.WriteLine($"StartTime : {startTime.ToString("HH:mm:ss:fffffff")}");
            //Console.WriteLine($"EndTime : {endTime.ToString("HH:mm:ss:fffffff")}");
            //Console.WriteLine($"Diff : {diff}");
            //Console.WriteLine(totalCount);
            Console.ReadLine();
        }
    }
}
