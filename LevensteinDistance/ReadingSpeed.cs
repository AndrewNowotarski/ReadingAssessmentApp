using System;

namespace ReadingScoreCalculation
{
    /// <summary>
    /// Methods related to reading speed calculation.
    /// Source: https://codereview.stackexchange.com/questions/9972/syllable-counting-function
    /// </summary>
    public static class ReadingSpeed
    {
        /// <summary>
        /// Estimates the number of words in a phase.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static int SyllableCount(string word)
        {
            word = word.ToLower().Trim();
            int count = System.Text.RegularExpressions.Regex.Matches(word, "[aeiouy]+").Count;
            if ((word.EndsWith("e") || (word.EndsWith("es") || word.EndsWith("ed"))) && !word.EndsWith("le"))
                count--;
            return count;
        }

        /// <summary>
        /// Method that splits a phase into words, and estimates the total number of syllables.
        /// </summary>
        /// <param name="phrase">A phrase.</param>
        /// <returns>Estimated number of syllables.</returns>
        public static int EstimateSyllablesInPhase(string phrase)
        {
            /* Normalize the phrase, stripping out punctuation. */
            phrase = phrase.NormalizeText();
            var words = phrase.Split(' ');

            int estimatedSyllableCount = 0;

            /* Iterate through each word and add the estimated word syllable count to the  */
            foreach(var word in words)
                estimatedSyllableCount += SyllableCount(word.Trim());

            return estimatedSyllableCount;
        }

        /// <summary>
        /// Method to grade a users time to read.
        /// </summary>
        /// <param name="timeToRead">Users time to read in ms.</param>
        /// <param name="totalSyllablesToRead">Total number of syllables in the text to read.</param>
        /// <returns></returns>
        public static decimal CalculateReadingSpeedScore(int timeToReadMS, int totalSyllablesToRead)
        {
            /* We will estimate that a syllable takes 1/3 of a second to read, or 333 ms. */
            var timePerSyllable = 333;
            var benchmarkTimeToReadMS = totalSyllablesToRead * timePerSyllable;

            /* Determine how much longer in ms the user took to read the passage when compared to the benchmark. */
            var timeOverBenchmark = timeToReadMS - benchmarkTimeToReadMS;

            /* If the user read the passage in less time than the benchmark, then score them at 100.
               The user will get a deduction for going over in proportion to the time they went over.  
               Once the users time is twice that of the benchmark, their score is a 0%. */
            return timeOverBenchmark <= 0 ? 1.0M : Math.Max((1.00M - ((decimal)timeOverBenchmark / benchmarkTimeToReadMS)), 0.0M);
        }

    }
}
