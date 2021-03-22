using System;

namespace AmazonInterview.Evalground {
    public static class Second {
		public static void Go() {
			var line = Console.ReadLine();
			var words = line.Split(' ');
			var aWord = words[0];
			var bWord = words[1];
			var bPosition = -1;
			var occurrencesCounter = 0;

			foreach (var character in aWord) {
				for (var i = bPosition + 1; i < bWord.Length; i++) {
					if (bWord[i] == character) {
						bPosition = i;
						occurrencesCounter++;
						break;
					}
				}
			}

			if (occurrencesCounter == aWord.Length)
				Console.WriteLine("1");
			else
				Console.WriteLine("0");
		}
	}
}
