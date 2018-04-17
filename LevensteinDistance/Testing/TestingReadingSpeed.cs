using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingScoreCalculation.Testing
{
    public static class TestingReadingSpeed
    {
        public static void TestGreatSpeed()
        {
            Console.WriteLine();
            Console.WriteLine("Testing Great Speed (Better than Benchmark)");

            int mySpeedInMS = 1500;
            int syllables = 6; // 6 syllables = about 2 seconds or 2000 ms         

            Console.WriteLine(ReadingSpeed.CalculateReadingSpeedScore(mySpeedInMS, syllables));
        }

        public static void TestExactReadingSpeed()
        {
            Console.WriteLine();
            Console.WriteLine("Testing Exact Speed (Equal to Benchmark)");

            int mySpeedInMS = 1998;
            int syllables = 6; // 6 syllables = about 2 seconds or 2000 ms         

            Console.WriteLine(ReadingSpeed.CalculateReadingSpeedScore(mySpeedInMS, syllables));
        }

        public static void TestAverageSpeed()
        {
            Console.WriteLine();
            Console.WriteLine("Testing Average Speed (Below but not double Benchmark)");

            int mySpeedInMS = 3000;
            int syllables = 6; // 6 syllables = about 2 seconds or 2000 ms         

            Console.WriteLine(ReadingSpeed.CalculateReadingSpeedScore(mySpeedInMS, syllables));
        }

        public static void TestBadSpeed()
        {
            Console.WriteLine();
            Console.WriteLine("Testing Bad Speed (Below or equal to double Benchmark)");

            int mySpeedInMS = 4000;
            int syllables = 6; // 6 syllables = about 2 seconds or 2000 ms         

            Console.WriteLine(ReadingSpeed.CalculateReadingSpeedScore(mySpeedInMS, syllables));
        }
    }
}
