using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex02
{
    class Game
    {
        protected internal enum CharOptions { A, B, C, D, E, F, G, H };
        private enum GuessStatus { CharAndPosition = 'V', CharOnly = 'X', BadChoice = ' ' }

        private string m_RandomWord;
        private int m_TotalNumberOfGuesses;
        private int m_AttemptsCounter;
        private bool m_IsWin;
        private const int k_LengthOfWord = 4;
        private const string k_WinPattern = "VVVV";

        public int AttemptsCounter { get => m_AttemptsCounter; set => m_AttemptsCounter = value; }
        public bool IsWin { get => m_IsWin; set => m_IsWin = value; }
        public int TotalNumberOfGuesses { get => m_TotalNumberOfGuesses; }
        public string RandomWord { get => m_RandomWord; }

        public Game(int i_TotalNumberOfGuesses)
        {
            m_RandomWord = generateRandomWord();
            m_TotalNumberOfGuesses = i_TotalNumberOfGuesses;
            AttemptsCounter = 0;
            IsWin = false;
        }

        public String getChoicesStatus(string i_UserChoice)
        {
            StringBuilder result = new StringBuilder();
            int numberOfSpaces = 0;
            for (int i = 0; i < k_LengthOfWord; i++)
            {
                int indexOfChar = RandomWord.IndexOf(i_UserChoice[i]);

                if (indexOfChar == i)
                {
                    result.Insert(0, (Char)GuessStatus.CharAndPosition);
                }
                else if (indexOfChar != -1)
                {
                    result.Append((Char)GuessStatus.CharOnly);
                }
                else
                {
                    numberOfSpaces++;
                }
            }
            while (numberOfSpaces > 0)
            {
                result.Append((Char)GuessStatus.BadChoice);
                numberOfSpaces--;
            }
            if (result.ToString().Equals(k_WinPattern))
            {
                m_IsWin = true;
            }
            return result.ToString();
        }

        private string generateRandomWord()
        {
            StringBuilder randomWord = new StringBuilder();
            List<int> randomNumbers = generateDifferentNumbers();

            foreach (int randomNumber in randomNumbers)
            {
                CharOptions selectedChar = (CharOptions)randomNumber;
                randomWord.Append(selectedChar.ToString());
            }
            return randomWord.ToString();
        }

        private List<int> generateDifferentNumbers()
        {
            List<int> randomNumbers = new List<int>();
            Random random = new Random();

            for (int i = 0; i < k_LengthOfWord; i++)
            {
                int randomNumber = 0;
                bool isUnique = false;
                while (!isUnique)
                {
                    randomNumber = random.Next(0, 7);
                    if (!randomNumbers.Contains(randomNumber))
                    {
                        isUnique = true;
                    }
                }
                randomNumbers.Add(randomNumber);
            }
            return randomNumbers;
        }

    }
}
