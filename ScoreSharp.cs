using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreSharp
{
    class ScoreSharp
    {
        static public double score(string word, string abbrv, double fuzzines = 0)
        {
            double total_char_score = 0, abbrv_size = abbrv.Length,
                fuzzies = 1, final_score, abbrv_score;
            int word_size = word.Length;
            bool start_of_word_bonus = false;

            //If strings are equal, return 1.0
            if (word == abbrv) return 1.0;

            int index_in_string,
                index_char_lowercase,
                index_char_uppercase,
                min_index;
            double char_score;
            string c;
            for (int i = 0; i < abbrv_size; i++)
            {
                c = abbrv[i].ToString();
                index_char_uppercase = word.IndexOf(c.ToUpper());
                index_char_lowercase = word.IndexOf(c.ToLower());
                min_index = Math.Min(index_char_lowercase,index_char_uppercase);

                //Finds first valid occurrence
                //In upper or lowercase
                index_in_string = min_index > -1 ?
                    min_index : Math.Max(index_char_lowercase, index_char_uppercase);

                //If no value is found
                //Check if fuzzines is allowed
                if (index_in_string == -1)
                {
                    if (fuzzines > 0)
                    {
                        fuzzies += 1 - fuzzines;
                        break;
                    }
                    else return 0;
                }
                else
                    char_score = 0.1;

                //Check if current char is the same case
                //Then add bonus
                if (word[index_in_string].ToString() == c) char_score += 0.1;

                //Check if char matches the first letter
                //And add bonnus for consecutive letters
                if (index_in_string == 0)
                {
                    char_score += 0.6;

                    //Check if the abbreviation
                    //is in the start of the word
                    start_of_word_bonus = i == 0;
                }

                // Acronym Bonus
                // Weighing Logic: Typing the first character of an acronym is as if you
                // preceded it with two perfect character matches.
                if (word.ElementAtOrDefault(index_in_string - 1).ToString() == " ") char_score += 0.8;


                //Remove the start of string, so we don't reprocess it
                word = word.Substring(index_in_string + 1);

                //sum chars scores
                total_char_score += char_score;
            }

            abbrv_score = total_char_score / abbrv_size;

            //Reduce penalty for longer words
            final_score = ((abbrv_score * (abbrv_size/word_size)) + abbrv_score) / 2;
            
            //Reduce using fuzzies;
            final_score = final_score / fuzzies;

            //Process start of string bonus
            if (start_of_word_bonus && final_score <= 0.85)
                final_score += 0.15;
            
            return final_score;
        }

        static public string[] sorter(string[] arr, string match)
        {
            Array.Sort(arr,new CompareScore(match));
            return arr;
        }

    }
}
