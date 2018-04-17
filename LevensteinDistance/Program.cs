using ReadingScoreCalculation.Testing;
using System;

namespace ReadingScoreCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("********** Testing Reading Score ***********");
            Console.WriteLine("********************************************");

            Console.WriteLine();
            Console.WriteLine("Testing Reading Accuracy");

            TestingReadingAccuracy.TestDifferentStrings();
            TestingReadingAccuracy.TestSameStrings();
            TestingReadingAccuracy.SemanticallyIdenticalStringsNotNormalized();
            TestingReadingAccuracy.SemanticallyIdenticalStringsNormalized();

            Console.WriteLine();
            Console.WriteLine("Testing Reading Speed");

            TestingReadingSpeed.TestGreatSpeed();
            TestingReadingSpeed.TestExactReadingSpeed();
            TestingReadingSpeed.TestAverageSpeed();
            TestingReadingSpeed.TestBadSpeed();

            Console.WriteLine();
            Console.WriteLine("Testing Reading Score Calculation");

            TestingReadingScore.TestAAverage();
            TestingReadingScore.TestBAverage();
            TestingReadingScore.TestCAverage();

            Console.Read();
        }
    }
}
