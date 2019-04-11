using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreationLib {
    /// <summary>
    /// Used to prettify enum literals
    /// </summary>
    public class EnumPrettify {

        /// <summary>
        /// Capitalizes first letter of word. Used to display enums prettier
        /// </summary>
        /// <param name="word">Word to capitalize</param>
        /// <returns>Word with first letter capitalized</returns>
        public static string FirstCharToUpper(string word) {
            if (string.IsNullOrEmpty(word)) {
                return string.Empty;
            }
            string endOfWord = word.Substring(1);
            return char.ToUpper(word[0]) + endOfWord.ToLower();
        }

        /// <summary>
        /// Replaces enum literal with prettier word
        /// </summary>
        /// <param name="word">Enum literal</param>
        /// <returns>Pretty enum</returns>
        public static string Prettify(string word) {
            string prettyEnum = EnumPrettify.FirstCharToUpper(word);
            return EnumPrettify.ReplaceUnderscore(prettyEnum);
        }

        /// <summary>
        /// Replaces underscores with spaces. Used to display enums prettier
        /// </summary>
        /// <param name="word">Word to replace</param>
        /// <returns>Word with underscores replaced with spaces</returns>
        public static string ReplaceUnderscore(string word) {
            string newWord = "";
            foreach (char letter in word) {
                if (letter.Equals('_')) {
                    newWord += ' ';
                } else {
                    newWord += letter;
                }
            }
            return newWord;
        }

    }
}
