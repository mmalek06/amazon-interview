using AmazonInterview.Tasks;
using System;
using System.Linq;

namespace AmazonInterview {
    class Program {
        static void Main(string[] args) {
            ActivityNotifications.Execute2(new[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 }, 5); // 2 
            ActivityNotifications.Execute2(new[] { 1, 2, 3, 4, 4 }, 4); // 0
            ActivityNotifications.Execute2(new[] { 10, 20, 30, 40, 50 }, 3); // 1
            ActivityNotifications.Execute2(Resource.expenditures.Split(' ').Select(v => Convert.ToInt32(v.Trim())).ToArray(), 10000); // 633
            //ActivityNotifications.Execute2(new[] { 1, 6, 4, 9, 3, 2, 1, 8 }, 3);
        }
    }
}
