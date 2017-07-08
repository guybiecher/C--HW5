using System;
using System.Text;

namespace B17_Ex02
{
    class Board
    {
        private const int k_BoardWidth = 2;
        private const string k_BoardTitle = ":Pins:    :Result::";
        private const string k_BoardSubTitle = ": # # # # :       :";
        private const string k_Delimiter = ":=========:=======:";
        private const string k_RowPattern = ":         :       :";

        private int m_BoardHeight;
        private int m_TableSize;
        private string[] m_Table;

        public Board(int i_BoardHeight)
        {
            m_BoardHeight = i_BoardHeight;
            m_TableSize = (i_BoardHeight + 2) * 2;
            m_Table = new string[m_TableSize];
            buildTableDelimiters();
            BuildTableTitle();
        }

        public void PrintBoard()
        {
            Console.WriteLine("Current board Status:\n");
            for (int i = 0; i < m_TableSize; i++)
            {
                Console.WriteLine(m_Table[i]);
            }
        }

        public void buildRow(string i_Guess, string i_GuessOutput, int i_RowFill)
        {
            StringBuilder guessBuilder = new StringBuilder();
            StringBuilder guessOutputBuilder = new StringBuilder();
            int tableIndex = (i_RowFill * 2) + 4;
            guessBuilder.AppendFormat(": {0} {1} {2} {3} :", i_Guess[0], i_Guess[1], i_Guess[2], i_Guess[3]);
            guessOutputBuilder.AppendFormat("{0} {1} {2} {3}:", i_GuessOutput[0], i_GuessOutput[1], i_GuessOutput[2], i_GuessOutput[3]);
            m_Table[tableIndex] = guessBuilder.Append(guessOutputBuilder.ToString()).ToString();
        }


        private void BuildTableTitle()
        {
            m_Table[0] = k_BoardTitle;
            m_Table[2] = k_BoardSubTitle;
        }

        private void buildTableDelimiters()
        {

            for (int i = 1; i < m_TableSize; i++)
            {
                if (i % 2 != 0)
                {
                    m_Table[i] = k_Delimiter;
                }
                else
                {
                    m_Table[i] = k_RowPattern;
                }
            }
        }
    }
}
