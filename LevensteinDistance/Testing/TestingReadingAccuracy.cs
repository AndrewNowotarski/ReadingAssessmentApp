using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingScoreCalculation.Testing
{
    public static class TestingReadingAccuracy
    {
        public static void TestDifferentStrings()
        {
            var string1 = "The quick brown fox went through the woods";
            var string2 = "Quick fox went through wood";

            Console.WriteLine();
            Console.WriteLine("Two different strings.");
            Console.WriteLine($"First String: {string1}");
            Console.WriteLine($"Second String: {string2}");
            Console.WriteLine($"Operations to transform: {ReadingAccuracy.ComputeLevenshteinDistance(string1, string2)}");
            Console.WriteLine($"Similarity percentage: {ReadingAccuracy.CalculateSimilarityScore(string1, string2)}");
        }

        public static void TestSameStrings()
        {
            var string1 = "The quick brown fox went through the woods";
            var string2 = "The quick brown fox went through the woods";

            Console.WriteLine();
            Console.WriteLine("The exact same string to prove they are 100% similar.");
            Console.WriteLine($"First String: {string1}");
            Console.WriteLine($"Same Exact String: {string1}");
            Console.WriteLine($"Operations to transform: {ReadingAccuracy.ComputeLevenshteinDistance(string1, string2)}");
            Console.WriteLine($"Similarity percentage: {ReadingAccuracy.CalculateSimilarityScore(string1, string2)}");
        }


        public static void SemanticallyIdenticalStringsNotNormalized()
        {
            var string1 = "I will not eat them Sam I am I will not eat green eggs and ham!";
            var string2 = "i will not eat them sam i am i will not eat green eggs and ham";

            Console.WriteLine();
            Console.WriteLine("Two identical strings (word wise), not normalized.");
            Console.WriteLine($"First String: {string1}");
            Console.WriteLine($"Same Exact String: {string2}");
            Console.WriteLine($"Operations to transform: {ReadingAccuracy.ComputeLevenshteinDistance(string1, string2)}");
            Console.WriteLine($"Similarity percentage: {ReadingAccuracy.CalculateSimilarityScore(string1, string2)}");
        }

        public static void SemanticallyIdenticalStringsNormalized()
        {
            var string1 = "I will not eat them Sam I am I will not eat green eggs and ham!";
            var string2 = "i will not eat them sam i am i will not eat green eggs and ham";

            Console.WriteLine();
            Console.WriteLine("Two identical strings (word wise), normalized.");
            Console.WriteLine($"First String: {string1}");
            Console.WriteLine($"Same Exact String: {string2}");
            Console.WriteLine($"Operations to transform: {ReadingAccuracy.ComputeLevenshteinDistance(string1.NormalizeText(), string2.NormalizeText())}");
            Console.WriteLine($"Similarity percentage: {ReadingAccuracy.CalculateSimilarityScore(string1.NormalizeText(), string2.NormalizeText())}");

        }
    }
}
