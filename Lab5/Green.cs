using System.ComponentModel.DataAnnotations;

namespace Lab5 {
    public class Green {
        public int[] Task1(int[,] matrix) {
            int[] answer = null;
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            answer = new int[rows];

            for (var r = 0; r < rows; r += 1) {
                for (var c = 0; c < cols; c += 1) {
                    if (matrix[r, c] < matrix[r, answer[r]]) {
                        answer[r] = c;
                    }
                }
            }

            // end
            return answer;
        }

        public void Task2(int[,] matrix) {
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (var r = 0; r < rows; r += 1) {
                var max_c = 0;

                for (var c = 0; c < cols; c += 1) {
                    if (matrix[r, c] > matrix[r, max_c]) {
                        max_c = c;
                    }
                }

                var max_item = (double)matrix[r, max_c];

                for (var c = 0; c < max_c; c += 1) {
                    if (matrix[r, c] < 0) {
                        matrix[r, c] = (int)Math.Floor(matrix[r, c] / max_item);
                    }
                }
            }

            // end
        }
        public void Task3(int[,] matrix, int k) {
            // code here

            var size = matrix.GetLength(0);

            if (matrix.GetLength(1) != size) {
                return;
            }

            if (k >= size) {
                return;
            }

            var max_item_index = 0;
            for (var i = 0; i < size; i += 1) {
                if (matrix[i, i] > matrix[max_item_index, max_item_index]) {
                    max_item_index = i;
                }
            }

            if (k == max_item_index) {
                return;
            }

            for (var i = 0; i < size; i += 1) {
                (matrix[i, max_item_index], matrix[i, k]) = (matrix[i, k], matrix[i, max_item_index]);
            }

            // end
        }
        public void Task4(int[,] matrix) {
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (cols != rows) {
                return;
            }

            var max_item_row = 0;
            var max_item_col = 0;

            for (var r = 0; r < rows; r += 1) {
                for (var c = 0; c < cols; c += 1) {
                    if (matrix[r, c] > matrix[max_item_row, max_item_col]) {
                        max_item_col = c;
                        max_item_row = r;
                    }
                }
            }
            /*
Input: Matrix [4x4]
 1      2       4       6
 5     -6       7      11
-1      4      -5       6
 1      4       5       6

Output: Matrix [4x4]
 1      2       4       5
 6     11       6       6
-1      4      -5       7
 1      4       5      -6

Answer: Matrix [4x4]
 1      2       4       5
 6     11       6       6
-1      4      -5       7
 1      4       5      11 --- Ошибка, пропал элемент =(-6)
            */

            /*
            * 0 1 2 3 4
            0     |
            1 - - x - -
            2     |   
            3     | 
            4     | 
            */

            for (int i = 0; i < rows; i += 1) {
                (matrix[i, max_item_col], matrix[max_item_row, i]) = (matrix[max_item_row, i], matrix[i, max_item_col]);
                // (matrix[max_item_col, i], matrix[i, max_item_row]) = (matrix[i, max_item_row], matrix[max_item_col, i]);
                // matrix[max_item_row, i] = matrix[i, max_item_col];
            }

            // end
        }
        public int[,] Task5(int[,] matrix) {
            int[,] answer = null;
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var target_row_index = 0;
            var target_row_items_sum = 0;

            for (var r = 0; r < rows; r += 1) {
                var current_row_items_sum = 0;
                for (var c = 0; c < cols; c += 1) {
                    var item = matrix[r, c];
                    if (item > 0) {
                        current_row_items_sum += item;
                    }
                }

                if (current_row_items_sum > target_row_items_sum) {
                    target_row_index = r;
                    target_row_items_sum = current_row_items_sum;
                }
            }

            answer = new int[rows - 1, cols];

            for (var c = 0; c < cols; c += 1) {
                for (var r = 0; r < target_row_index; r += 1) {
                    answer[r, c] = matrix[r, c];
                }

                for (var r = target_row_index + 1; r < rows; r += 1) {
                    answer[r - 1, c] = matrix[r, c];
                }
            }

            // end
            return answer;
        }
        public void Task6(int[,] matrix) {
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var row_negative_items_map = new int[rows];

            for (var r = 0; r < rows; r += 1) {
                for (var c = 0; c < cols; c += 1) {
                    if (matrix[r, c] < 0) {
                        row_negative_items_map[r] += 1;
                    }
                }
            }

            var min_negatives_index = 0;
            var max_negatives_index = 0;

            for (var r = 0; r < rows; r += 1) {
                var item = row_negative_items_map[r];

                if (row_negative_items_map[min_negatives_index] < item) {
                    min_negatives_index = r;
                }

                if (row_negative_items_map[max_negatives_index] > item) {
                    max_negatives_index = r;
                }
            }

            for (var c = 0; c < cols; c += 1) {
                (matrix[min_negatives_index, c], matrix[max_negatives_index, c]) = (matrix[max_negatives_index, c], matrix[min_negatives_index, c]);
            }

            // end
        }
        public int[,] Task7(int[,] matrix, int[] array) {
            int[,] answer = null;
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (rows != array.Length) {
                return matrix;
            }

            var min_item_row = 0;
            var min_item_col = 0;

            for (var r = 0; r < rows; r += 1) {
                for (var c = 0; c < cols; c += 1) {
                    if (matrix[r, c] < matrix[min_item_row, min_item_col]) {
                        min_item_col = c;
                        min_item_row = r;
                    }
                }
            }

            answer = new int[rows, cols + 1];

            for (var r = 0; r < rows; r += 1) {
                for (var c = 0; c < min_item_col + 1; c += 1) {
                    answer[r, c] = matrix[r, c];
                }

                answer[r, min_item_col + 1] = array[r];
                
                for (var c = min_item_col + 1; c < cols; c += 1) {
                    answer[r, c + 1] = matrix[r, c];
                }
            }

            // end
            return answer;
        }
        public void Task8(int[,] matrix) {

            // code here

            // end

        }
        public void Task9(int[,] matrix) {

            // code here

            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix) {
            int[] A = null, B = null;

            // code here

            // end

            return (A, B);
        }
        public void Task11(int[,] matrix) {

            // code here

            // end

        }
        public void Task12(int[][] array) {

            // code here

            // end

        }
    }
}