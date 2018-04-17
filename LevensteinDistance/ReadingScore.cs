using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingScoreCalculation
{
    /// <summary>
    /// Class to calculate a users reading score.
    /// </summary>
    public static class ReadingScore
    {
        /// <summary>
        /// Method that calculates a reading score off of three reading 'grades'.
        /// </summary>
        /// <param name="readingAccuracy">0-100; how closely does what the user read match the text?</param>
        /// <param name="readingSpeed">0-100; how quickly does the user read the text? </param>
        /// <param name="readingComphrehension">0-100; how accurately does the yser</param>
        /// <returns></returns>
        public static decimal GetReadingScore(decimal readingAccuracy, decimal readingSpeed, decimal readingComphrehension)
        {
            /* There are three key metrics in a reading assessment;
               1)  Reading accuracy - how closely is the read passage equivilent to the actual passage?
               2)  Reading speed - how long does the user take to read the passage of text?
               3)  Reading comprehension - how well does the reader comprehend and remember what they just read? 
             
                The reading score weights each metric evenly so that readingScore = (readingAccuracy + readingSpeed + readingComprehension) / 3.
             */

            return (readingAccuracy + readingSpeed + readingComphrehension) / 3.0M;
        }
    }
}
