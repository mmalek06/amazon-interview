using System;
using System.Linq;

namespace AmazonInterview.Evalground {
    public static class First {
        public static void Go() {
			var nSteps = Convert.ToInt32(Console.ReadLine());
			var tolls = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
			long minCost = 0;

			for (var i = 0; i < tolls.Length;) {
				var first = tolls[i];
				long second = i + 1 >= tolls.Length ? int.MaxValue : tolls[i + 1];
				long third = i + 2 >= tolls.Length ? int.MaxValue : tolls[i + 2];
				long localMin = first + second;
				var increaseCounterBy = 1;

				if (first + third < localMin) {
					localMin = first + third;
					increaseCounterBy = 3;
				}
				if (second < localMin) {
					localMin = second;
					increaseCounterBy = 2;
				}
				if (second + third < localMin) {
					localMin = second + third;
					increaseCounterBy = 3;
				}

				i += increaseCounterBy;
				minCost += localMin;

				if (i + 1 >= tolls.Length - 1) {
					break;
                }
			}

			Console.WriteLine(minCost);
		}
    }
}
