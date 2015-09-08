using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongrunningTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task<ReturnType>> listtasks = new List<Task<ReturnType>>();
            Console.WriteLine("Starting new thread...." + DateTime.Now);
            Task<ReturnType> s1 = Method1Async();
            Task<ReturnType> s2 = Method2Async();
            Task<ReturnType> s3 = Method3Async();
            listtasks.Add(s1);
            listtasks.Add(s2);
            listtasks.Add(s3);
            Task.WhenAny(listtasks);
            foreach (var item in listtasks)
            {
                Console.WriteLine(item.Id +" :" +item.Result.Message +" at time " + item.Result.time);
            }
            //Console.WriteLine(s1.Result);
            Console.WriteLine("Finishing thread...." + DateTime.Now);
        //    Console.ReadLine();


        }

        private static async Task<ReturnType> Method1Async()
        {
            //throw new NotImplementedException();
           
            await asyncdealy(7500);
            ReturnType ret1 = new ReturnType
            {
                time = DateTime.Now,
                Message = "I am from Method1"
            };
            return await Task.Run(()=> ret1);
        }

        private static Task asyncdealy(int time)
        {
            return Task.Delay(time);
        }

        private static async Task<ReturnType> Method2Async()
        {
            //throw new NotImplementedException();
            await asyncdealy(5000);
            ReturnType ret3 = new ReturnType
            {
                time = DateTime.Now,
                Message = "I am from Method2"
            };
            return await Task.Run(() => ret3);
        }

        private static async Task<ReturnType> Method3Async()
        {
            //throw new NotImplementedException();
            await asyncdealy(4000);
            ReturnType ret2 = new ReturnType
            {
                time = DateTime.Now,
                Message = "I am from Method3"
            };
            return await Task.Run(() => ret2);
        }
    }
}
