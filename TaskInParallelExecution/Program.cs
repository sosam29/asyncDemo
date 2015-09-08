using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskInParallelExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskmain = MaintaskAsync();
            
        }

        private async static Task MaintaskAsync()
        {
            //await Task.Delay(2000);
            //List<Task<string>> alltasks = new List<Task<string>>();

            
            //alltasks.Add(SecondTaskAsync);
            //alltasks.Add(ThirdTaskAsync);


            Console.WriteLine("Main Task Started....");
            //string t1 = await FirstTaskAsync();
            //alltasks.Add(FirstTaskAsync);
            Console.WriteLine("First task called");
            string t2  = await SecondTaskAsync();
            Console.WriteLine("Second task called");
            string t3 = await ThirdTaskAsync();
            Console.WriteLine("Third task called");
           
            Console.WriteLine("Main Task Finished....");
            Console.ReadLine();
        }
        private  static Task<string> FirstTaskAsync()
        {
              //Task.Run(() =>
              //          {
              //              Task.Delay(2000);
              //              return "Task 1 completed";
              //          });

            return Task.Delay(2000)
                .ContinueWith(t => "returned task 1");



        }
        private static async Task<string> SecondTaskAsync()
        {
            await Task.Delay(4000);
            return "Task 2 completed";
        }
        private static async Task<string> ThirdTaskAsync()
        {
            await Task.Delay(6000);
             return "Task 3 completed";
        }
    }
}
