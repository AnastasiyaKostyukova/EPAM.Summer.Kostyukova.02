using System;
using System.Diagnostics;

namespace LogiсOfEuclideanAlgorithm
{
    public class NodCalculator
    {
        private Stopwatch stopWatch = new Stopwatch();

        public TimeAndResult GetNODbyEuclideanAlgorithm(int a, int b)
        {
            stopWatch.Reset();
            stopWatch.Start();
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a < b)
            {
                int c = a;
                a = b;
                b = c;
            }

            while (a % b != 0)
            {
                int c = a;
                a = b;
                b = c % b;
            }

            var miliseconds = stopWatch.ElapsedTicks;
            stopWatch.Stop();
            var timeAndResult = new TimeAndResult
            {
                Result = b,
                ExecutionTimeTicks = miliseconds
            };

            return timeAndResult;            
        }


        public TimeAndResult GetNODbyEuclideanAlgorithm(params int[] numbers)
        {
            stopWatch.Reset();
            stopWatch.Start();

            numbers = GetPositiveArr(numbers);
            var minIndex = GetMaxMinHelper(numbers).MinIndex;
            var min = numbers[minIndex];

            while (ArrIncludeAMemberNotMultipleOfMin(min, numbers))
            {
                for (var i = 0; i < numbers.Length; i++)
                {
                    if (i == minIndex || numbers[i] % min == 0)
                    {
                        continue;
                    }

                    var c = numbers[i];
                    numbers[i] = min;
                    numbers[minIndex] = c % min;
                }

                minIndex = GetMaxMinHelper(numbers).MinIndex;
                min = numbers[minIndex];
            }

            var miliseconds = stopWatch.ElapsedTicks;
            stopWatch.Stop();
            var timeAndResult = new TimeAndResult
            {
                Result = min,
                ExecutionTimeTicks = miliseconds
            };

            return timeAndResult;
        }


        public TimeAndResult GetNODbyBinaryEuclidianAlgoritm(int a, int b)
        {
            stopWatch.Reset();
            stopWatch.Start();

            var k = 1;

            while (a != 0 && b != 0)
            {
                if (a % 2 == 0 && b % 2 == 0)
                {
                    a = a / 2;
                    b = b / 2;
                    k = k * 2;
                }
                else if (a % 2 == 0)
                {
                    a = a / 2;
                }
                else
                {
                    b = b / 2;
                }

                if (a >= b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            var miliseconds = stopWatch.ElapsedTicks;
            stopWatch.Stop();
            var timeAndResult = new TimeAndResult
            {
                Result = b * k,
                ExecutionTimeTicks = miliseconds
            };

            return timeAndResult;
        }


        public TimeAndResult GetNODbyBinaryEuclidianAlgoritm(params int[] numbers)
        {
            stopWatch.Reset();
            stopWatch.Start();

            var k = 1;

            while (AreNumbersNotEqualZero(numbers))
            {
                if (AreNumbersEven(numbers))
                {
                    for (var i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = numbers[i] / 2;
                    }

                    k = k * 2;
                }
                else
                {
                    for (var i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            numbers[i] = numbers[i] / 2;
                        }
                    }
                }

                var maxMinHelper = GetMaxMinHelper(numbers);
                numbers[maxMinHelper.MaxIndex] = numbers[maxMinHelper.MaxIndex] - numbers[maxMinHelper.MinIndex];
            }

            var maxMinHelper1 = GetMaxMinHelper(numbers);

            var miliseconds = stopWatch.ElapsedTicks;
            stopWatch.Stop();
            var timeAndResult = new TimeAndResult
            {
                Result = numbers[maxMinHelper1.MaxIndex] * k,
                ExecutionTimeTicks = miliseconds
            };

            return timeAndResult;
        }

        private bool AreNumbersEven(params int[] numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    return false;
                }
            }

            return true;
        }


        private bool AreNumbersNotEqualZero(params int[] numbers)
        {
            foreach (var number in numbers)
            {
                if (number == 0)
                {
                    return false;
                }
            }

            return true;
        }



        private int[] GetPositiveArr(params int[] numbers)
        {
            int[] positiveArr = new int[numbers.Length];
            for (var i = 0; i < numbers.Length; i++)
            {
                positiveArr[i] = Math.Abs(numbers[i]);
            }

            return positiveArr;
        }

        private MaxMinValuesOfTheArr GetMaxMinHelper(params int[] numbers)
        {
            var min = int.MaxValue;
            var max = int.MinValue;
            var minIndex = -1;
            var maxIndex = -1;

            for (var i = 0; i < numbers.Length; i++)
            {
                if (min > numbers[i])
                {
                    min = numbers[i];
                    minIndex = i;
                }

                if (max < numbers[i])
                {
                    max = numbers[i];
                    maxIndex = i;
                }
            }

            return new MaxMinValuesOfTheArr
            {
                MaxIndex = maxIndex,
                MinIndex = minIndex
            };
        }


        private bool ArrIncludeAMemberNotMultipleOfMin(int min, params int[] numbers)
        {
            if (min == 0)
            {
                return false;
            }

            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % min != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
