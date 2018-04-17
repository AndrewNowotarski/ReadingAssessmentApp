using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingScoreCalculation.Testing
{
    public static class TestingReadingScore
    {
        public static void TestAAverage()
        {
            decimal readingAccuracy = 93.0M;
            decimal readingSpeed = 95.0M;
            decimal readingComprehension = 90.0M;

            Console.WriteLine();
            Console.WriteLine("Testing Reading Score (A)");
            Console.WriteLine(ReadingScore.GetReadingScore(readingAccuracy, readingSpeed, readingComprehension));
        }

        public static void TestBAverage()
        {
            decimal readingAccuracy = 83.0M;
            decimal readingSpeed = 85.0M;
            decimal readingComprehension = 80.0M;

            Console.WriteLine();
            Console.WriteLine("Testing Reading Score (B)");
            Console.WriteLine(ReadingScore.GetReadingScore(readingAccuracy, readingSpeed, readingComprehension));
        }

        public static void TestCAverage()
        {
            decimal readingAccuracy = 73.0M;
            decimal readingSpeed = 75.0M;
            decimal readingComprehension = 70.0M;

            Console.WriteLine();
            Console.WriteLine("Testing Reading Score (C)");
            Console.WriteLine(ReadingScore.GetReadingScore(readingAccuracy, readingSpeed, readingComprehension));
        }
    }
}
