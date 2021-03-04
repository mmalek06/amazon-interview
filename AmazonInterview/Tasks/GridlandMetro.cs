using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AmazonInterview.Tasks {
    // https://www.hackerrank.com/challenges/gridland-metro/problem
    // GridlandMetro.gridlandMetro(5, 5, 0, new int[][] {
    //    new[] {1, 0, 1 },
    //    new[] {2, 1, 3 },
    //    new[] {5, 0, 4 },
    //    new[] {1, 0, 3 },
    //    new[] {2, 3, 4 }
    //}); // 12 wolnych
    public class GridlandMetro {
        public static BigInteger gridlandMetro(int n, int m, int k, int[][] track) {
            var totalSquares = new BigInteger(n) * new BigInteger(m);
            var tracks = new Dictionary<int, List<int>>();

            foreach (var row in track) {
                var rowIdx = row[0] - 1;

                if (!tracks.ContainsKey(rowIdx)) {
                    totalSquares -= (row[2] - row[1] + 1);
                    tracks[rowIdx] = new List<int>();

                    tracks[rowIdx].AddRange(row.Skip(1).ToArray());
                } else {
                    var beginning = row[1];
                    var end = row[2];
                    var startIdx = -1;
                    var endIdx = -1;
                    var cachedTrack = tracks[rowIdx];

                    for (var i = 0; i < cachedTrack.Count - 1; i++) {
                        if (beginning >= cachedTrack[i] && beginning <= cachedTrack[i + 1])
                            startIdx = i % 2 > 0 ? i + 1 : i;
                        if (end >= cachedTrack[i] && end <= cachedTrack[i + 1])
                            endIdx = i % 2 > 0 ? i : i + 1;
                        if (startIdx > -1 && endIdx > -1)
                            break;
                    }

                    var addBothAtTheEnd = false;

                    if (startIdx == -1 && beginning >= cachedTrack[0] && endIdx == -1 && end >= cachedTrack.Last()) {
                        startIdx = cachedTrack.Count;
                        endIdx = cachedTrack.Count + 1;
                        addBothAtTheEnd = true;

                        cachedTrack.AddRange(new[] { 0, 0 });
                    }
                    if (startIdx == -1 && beginning <= cachedTrack[0])
                        startIdx = 0;
                    if (endIdx == -1 && end >= cachedTrack.Last())
                        endIdx = cachedTrack.Count - 1;

                    var occupied = 0;
                    var remove = 0;
                    var rangeStart = startIdx % 2 == 0 ? startIdx : startIdx - 1;
                    var rangeEnd = endIdx % 2 != 0 ? endIdx : endIdx + 1;

                    for (var i = rangeStart; i <= rangeEnd; i += 2) {
                        occupied += cachedTrack[i + 1] - cachedTrack[i] + 1;
                        remove++;
                    }

                    if (addBothAtTheEnd) {
                        cachedTrack.Insert(endIdx, end);
                        cachedTrack.RemoveRange(endIdx + 1, remove);
                        cachedTrack.Insert(startIdx, beginning);
                        cachedTrack.RemoveRange(startIdx + 1, remove);

                        totalSquares -= (cachedTrack[endIdx] - cachedTrack[startIdx] + 1);
                    } else {
                        if (end > cachedTrack[endIdx]) {
                            cachedTrack.Insert(endIdx, end);
                            cachedTrack.RemoveRange(endIdx + 1, remove);
                        }
                        if (beginning < cachedTrack[startIdx]) {
                            cachedTrack.Insert(startIdx, beginning);
                            cachedTrack.RemoveRange(startIdx + 1, remove);
                        }

                        totalSquares -= (cachedTrack[endIdx] - cachedTrack[startIdx] + 1) - occupied;
                    }                    
                }
            }

            return totalSquares;
        }
    }
}
