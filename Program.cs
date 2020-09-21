using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_ProgramingIntrodution
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintTriangle(n);

            int n2 = 5;
            PrintSeriesSum(n2);

            int[] A = new int[] { 1, 2, 2, 6 }; ;
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs);

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine(time);

            string str1 = "goulls";
            string str2 = "gobulls";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine(minEdits);
        }

        static void PrintTriangle(int n)    
        {
            // Lopping on the required n number of rows
            for (int i = 0; i < n; i++)
            {
                String res = "";
                for (int j = 0; j < n - i; j++)
                {
                    // To display the required number of spaces before * in every row
                    res = res + " ";
                }
                for (int j = 0; j < 2 * i + 1; j++)
                {
                    // Displaying the number of stars equal to the ith odd number
                    res = res + "*";
                }
                // Printing each row in a new line to distinguish
                Console.WriteLine(res);
            }
        }

        static void PrintSeriesSum(int n)
        {
            int s = 0;
            String res = "";
            // To loop n times for odd numbers
            for (int i = 0; i < n; i++)
            {
                //ith odd number
                int temp = 2 * i + 1;
                res = res + temp + " ";
                s = s + temp;
            }
            // To print the n odd numbers series
            Console.WriteLine(res);
            // Printing the sum of those odd numbers
            Console.WriteLine(s);
        }

        static bool MonotonicCheck(int[] A)
        {
            // Flag to specify if the series is Ascending
            bool isAscending = false;
            // Flag to specify if the series is Descending
            bool isDescending = false;
            for (int i = 0; i < A.Length - 1; i++)
            {
                // Set the value to be true if the current bit is lesser than next bit
                if (A[i] <= A[i + 1])
                    isAscending = true;
                else
                {
                    // Set the value to false and break if the series is not in ascending at i
                    isAscending = false;
                    break;
                }
            }
            for (int i = 0; i < A.Length - 1; i++)
            {
                // Set the value to be true if the current bit is lesser than next bit
                if (A[i] >= A[i + 1])
                    isDescending = true;
                else
                {
                    // Set the value to false and break if the series is not in ascending at i
                    isDescending = false;
                    break;
                }
            }
            // If either the series is ascending or descending, return true, else false
            return isAscending || isDescending;
        }

        static int DiffPairs(int[] nums, int k)
        {
            // Sorting the array for ease of the problem
            Array.Sort(nums);
            Dictionary<int, int> added = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    // Check if the difference of ith and jth and if found as k, add them as a tuple to target dictionary
                    if (nums[j] - nums[i] == k)
                    {
                        // Adding if the key doesn't exist already
                        if (!(added.Keys.ToList().Contains(nums[i])))
                        {
                            added.Add(nums[i], nums[j]);
                        }
                        break;
                    }
                }
            }
            // Returning the size of map keys.
            return added.Keys.ToList().Count();
        }

        static int BullsKeyboard(string keyboard, string word)
        {
            int init = 0, moves = 0;
            for (int i = 0; i < word.Length; i++)
            {
                // To find at what position does the ith char in word exist in the keyboard
                int pos = keyboard.IndexOf(word[i]);
                moves += Math.Abs(pos - init);
                init = pos;
            }
            return moves;
        }

        static int StringEdit(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;
            // return length of the non empty string when one of them is empty
            if (n * m == 0)
            {
                return n + m;
            }
            // take an array to store the edit distances 
            int[,] d = new int[n + 1, m + 1];

            // initializing boundaries of the 2d array, with the word length till its position
            for (int i = 0; i < n + 1; i++)
            {
                d[i, 0] = i;
            }
            for (int j = 0; j < m + 1; j++)
            {
                d[0, j] = j;
            }

            // computing distances using the array creted above- DP    
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    // Condition for deletion
                    // d[i - 1, j] + 1;
                    // condition for insertion
                    // d[i, j - 1] + 1;
                    // condition for substitution
                    // d[i - 1, j - 1];
                    if (str1[i - 1] != str2[j - 1])
                    {
                        d[i - 1, j - 1]++;
                    }
                    d[i, j] = Math.Min(d[i - 1, j] + 1, Math.Min(d[i, j - 1] + 1, d[i - 1, j - 1]));
                }
            }
            // returning the bottom right value of the array gives us the edit distance between words
            return d[n, m];
        }
    }
}
