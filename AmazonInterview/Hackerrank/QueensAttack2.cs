using System.Collections.Generic;

namespace AmazonInterview.Hackerrank {
    public static class QueensAttack2 {
        // https://www.hackerrank.com/challenges/queens-attack-2/problem
        // QueensAttack2.Execute(4, 0, 4, 4, new int[0][]);
        // QueensAttack2.Execute(5, 3, 4, 3, new int[][] {
        //     new [] { 5, 5 },
        //     new [] { 4, 2 },
        //     new [] { 2, 3 }
        // });
        public static int Execute(int n, int k, int r_q, int c_q, int[][] obstacles) {
            var transformedObstacles = TransformObstacles(obstacles);
            var count = 0;
            var ring = 1;
            var upBlocked = false;
            var downBlocked = false;
            var leftBlocked = false;
            var rightBlocked = false;
            var diagUpLeftBlocked = false;
            var diagUpRightBlocked = false;
            var diagDownLeftBlocked = false;
            var diagDownRightBlocked = false;

            r_q -= 1;
            c_q -= 1;

            while (!upBlocked || !downBlocked || !leftBlocked || !rightBlocked || !diagUpLeftBlocked || !diagUpRightBlocked || !diagDownLeftBlocked || !diagDownRightBlocked) {
                var rowIndexUp = r_q - ring;
                var rowIndexDown = r_q + ring;
                var colIndexLeft = c_q - ring;
                var colIndexRight = c_q + ring;

                if (!upBlocked && rowIndexUp >= 0)
                    LockOrIncrement(transformedObstacles, rowIndexUp, c_q, ref count, ref upBlocked);
                if (!downBlocked && rowIndexDown < n)
                    LockOrIncrement(transformedObstacles, rowIndexDown, c_q, ref count, ref downBlocked);
                if (!leftBlocked && colIndexLeft >= 0)
                    LockOrIncrement(transformedObstacles, r_q, colIndexLeft, ref count, ref leftBlocked);
                if (!rightBlocked && colIndexRight < n)
                    LockOrIncrement(transformedObstacles, r_q, colIndexRight, ref count, ref rightBlocked);
                if (!diagUpLeftBlocked && rowIndexUp >= 0 && colIndexLeft >= 0)
                    LockOrIncrement(transformedObstacles, rowIndexUp, colIndexLeft, ref count, ref diagUpLeftBlocked);
                if (!diagUpRightBlocked && rowIndexUp >= 0 && colIndexRight < n)
                    LockOrIncrement(transformedObstacles, rowIndexUp, colIndexRight, ref count, ref diagUpRightBlocked);
                if (!diagDownLeftBlocked && rowIndexDown < n && colIndexLeft >= 0)
                    LockOrIncrement(transformedObstacles, rowIndexDown, colIndexLeft, ref count, ref diagDownLeftBlocked);
                if (!diagDownRightBlocked && rowIndexDown < n && colIndexRight < n)
                    LockOrIncrement(transformedObstacles, rowIndexDown, colIndexRight, ref count, ref diagDownRightBlocked);
                if (rowIndexUp <= 0) {
                    upBlocked = true;
                    diagUpLeftBlocked = true;
                    diagUpRightBlocked = true;
                }
                if (rowIndexDown >= n - 1) {
                    downBlocked = true;
                    diagDownLeftBlocked = true;
                    diagDownRightBlocked = true;
                }
                if (colIndexLeft <= 0) {
                    leftBlocked = true;
                    diagUpLeftBlocked = true;
                    diagDownLeftBlocked = true;
                }
                if (colIndexRight >= n - 1) {
                    rightBlocked = true;
                    diagUpRightBlocked = true;
                    diagDownRightBlocked = true;
                }

                ring++;
            }

            return count;
        }

        private static HashSet<int>[] TransformObstacles(int[][] obstacles) {
            var maxRow = 0;

            for (var i = 0; i < obstacles.Length; i++) {
                if (obstacles[i][0] > maxRow)
                    maxRow = obstacles[i][0];
            }

            var transformedObstacles = new HashSet<int>[maxRow];

            for (var i = 0; i < obstacles.Length; i++) {
                if (transformedObstacles[obstacles[i][0] - 1] == null)
                    transformedObstacles[obstacles[i][0] - 1] = new HashSet<int>();

                transformedObstacles[obstacles[i][0] - 1].Add(obstacles[i][1] - 1);
            }

            return transformedObstacles;
        }

        private static void LockOrIncrement(HashSet<int>[] obstacles, int rowIndex, int colIndex, ref int count, ref bool blocked) {
            if (rowIndex >= obstacles.Length) {
                count++;
                return;
            }

            var isObstacle = obstacles[rowIndex]?.Contains(colIndex) == true;

            if (isObstacle) blocked = true;
            else count++;
        }
    }
}
