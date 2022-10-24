using System.Diagnostics;

namespace SandBoxCore.InterviewQuestions
{
    /// <summary>
    /// Examples taken from https://medium.com/weekly-webtips/a-quick-guide-on-big-o-notation-time-complexity-2ada6ce6c546
    /// </summary>
    public class BigO
    {
        public void Run()
        {
            ConstantTime();
            LinearTime();
            QuadraticTime();
            ExponentialTime();
            FactorialTime();
        }

        /// <summary>
        /// Constant Time - O(1)
        /// Constant time implies that no matter the length of the input, the number of operations will always remain the same.
        /// </summary>
        public void ConstantTime()
        {

            Console.WriteLine($"{Environment.NewLine}ConstantTime");
            var array1 = new List<int> { 6, 1, 5, 5, 4, 3 };
            var array2 = new List<int> { 4, 1, 99, 7, 3, 4, 1, 20, 5, 9, 200, 90 };
            var findThirdElement = (List<int> array) =>
            {
                return RunInStopwatch<int>(() =>
                {
                    return array[2];
                });
            };


            // Third element: 5
            Console.WriteLine($"Third element: {findThirdElement(array1)}");
            // Third element: 99
            Console.WriteLine($"Third element: {findThirdElement(array2)}");

        }

        /// <summary>
        /// Linear Time - O(n)
        /// Linear time implies that, as the input increases, the number of operations also increases proportionally.
        /// </summary>
        public void LinearTime()
        {
            Console.WriteLine($"{Environment.NewLine}LinerTime");
            var array1 = new List<int> { 0, 1, 2, 3, 4 };
            bool hasMatch(List<int> array, int num)
            {
                return RunInStopwatch<List<int>, int, bool>((array, num) =>
                {
                    for (var i = 0; i < array.Count; i++)
                    {
                        if (array[i] == num)
                        {
                            return true;
                        }
                    }
                    return false;
                }, array, num);
            };

            // Has a Match?: true
            Console.WriteLine($"Has a Match?: {hasMatch(array1, 3)}");
            //=> Has a Match?: false
            Console.WriteLine($"Has a Match?: {hasMatch(array1, 5)}");

        }

        /// <summary>
        /// Quadratic Time - O(n^2)
        /// Quadratic time implies that the number of operations is proportional to the square of the length of the input.
        /// </summary>
        /// <returns></returns>
        public void QuadraticTime()
        {
            Console.WriteLine($"{Environment.NewLine}QuadraticTime");
            var array1 = new List<int> { 0, 4, 1, 2, 5 };
            var array2 = new List<int> { 3, 4, 2, 7 };
            var array3 = new List<int> { 7, 6, 8, 3 };
            bool containsDuplicate(List<int> array1, List<int> array2)
            {
                return RunInStopwatch<List<int>, List<int>, bool>((array1, array2) =>
                {
                    for (var i = 0; i < array1.Count; i++)
                    {
                        for (var j = 0; j < array2.Count; j++)
                        {
                            if (array1[i] == array2[j])
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }, array1, array2);
            };

            //=> Contains Duplicate?: true
            Console.WriteLine($"Contains Duplicate?: {containsDuplicate(array1, array2)}");
            //=> Contains Duplicate?: false   
            Console.WriteLine($"Contains Duplicate?: {containsDuplicate(array1, array3)}");
        }

        /// <summary>
        /// Exponential Time - O(2^n)
        /// Exponential time implies that the number of operations is proportional to two to the nth power, n being the length of the input.
        /// This is recursive
        /// </summary>
        public void ExponentialTime()
        {
            Console.WriteLine($"{Environment.NewLine}ExponentialTime");
            int fibonacci(int num)
            {
                return RunInStopwatch<int, int>((int num) =>
                {
                    if (num <= 1)
                    {
                        return num;
                    }
                    else
                    {
                        return fibonacci(num - 2) + fibonacci(num - 1);
                    }
                }, num);
            };

            ////=> Fibonacci: 3
            Console.WriteLine($"Fibonacci: {fibonacci(4)}");
            ////=> Fibonacci: 55
            Console.WriteLine($"Fibonacci: {fibonacci(10)}");
            ////=> Fibonacci: 6765
            Console.WriteLine($"Fibonacci: {fibonacci(20)}");
        }

        /// <summary>
        /// Factorial Time - O(n!)
        /// Factorial time implies that the number of operations is proportional to n factorial.
        /// ??? This example does not seem as if it is Factorial ???
        /// </summary>
        public void FactorialTime()
        {
            Console.WriteLine($"{Environment.NewLine}FactoralTime:");
            var array1 = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };
            var array2 = new List<string> { "dog", "cat", "ferret" };
            var possibleCombinations = (IList<string> array) =>
            {
                return RunInStopwatch<int>(() =>
                {
                    var total = array.Count;
                    for (var i = 1; i < array.Count; i++)
                    {
                        total = (total * (array.Count - i));
                    }
                    return total;
                });
            };

            // The total number of possible combinations is: 2,004,310,016
            Console.WriteLine($"The total number of possible combinations for an array of length {array1.Count} is: {possibleCombinations(array1)}");
            // The total number of possible combinations is: 6
            Console.WriteLine($"The total number of possible combinations for an array of length {array2.Count} is: {possibleCombinations(array2)}");
        }

        private T RunInStopwatch<T>(Func<T> a)
        {
            var sw = Stopwatch.StartNew();
            var r = a.Invoke();
            sw.Stop();
            Console.WriteLine($"Runtime in ms was: {sw.ElapsedTicks}");
            return r;
        }

        private U RunInStopwatch<T, U>(Func<T, U> a, T t)
        {
            var sw = Stopwatch.StartNew();
            var r = a.Invoke(t);
            sw.Stop();
            Console.WriteLine($"Runtime was {sw.ElapsedTicks} ticks.");
            return r;
        }

        private V RunInStopwatch<T, U, V>(Func<T, U, V> a, T t, U u)
        {
            var sw = Stopwatch.StartNew();
            var r = a.Invoke(t, u);
            sw.Stop();
            Console.WriteLine($"Runtime was {sw.ElapsedTicks} ticks.");
            return r;
        }

    }
}
