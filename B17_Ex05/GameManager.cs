using System;
using B17_Ex02;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace B17_Ex05
{
    class GameManager
    {
        private Game m_Game;
        private FormGame m_Board;
        private Dictionary<Color, Game.CharOptions> m_MappingFromUIToLogic = new Dictionary<Color, Game.CharOptions>();

        public GameManager()
        {
            m_Board = new FormGame();
            m_Board.UserSelection += UserSelectionHandler;
            m_Board.UserNumberOfChoices += GetNumberOfChancesHandler;
            m_Game = new Game();
            InitMapping();
            Console.WriteLine("The answer " + m_Game.RandomWord);
            m_Board.StartGame();
        }

        private void GetNumberOfChancesHandler(int i_NumberOfChances)
        {
            Console.WriteLine("Number of Chances " + i_NumberOfChances);
            m_Game.TotalNumberOfGuesses = i_NumberOfChances;
        }

        private void UserSelectionHandler(List<Color> i_UserSelection)
        {
            string choicesStatus = m_Game.getChoicesStatus(ConvertUserChoicesToGameLogic(i_UserSelection));
            Console.WriteLine(choicesStatus);
            List<Color> resultConvertedToColors = ConvertResultToColor(choicesStatus);

            if (m_Game.IsWin)
            {
                m_Board.ExecuteWinStep(resultConvertedToColors);
            }
            else
            {
                m_Board.ExecuteNextStep(resultConvertedToColors);
            }

        }

        public void InitMapping()
        {
            int i = 0;
            foreach (Game.CharOptions currentCharOption in Enum.GetValues(typeof(Game.CharOptions)))
            {
                Console.WriteLine(currentCharOption.ToString());
                Console.WriteLine(m_Board.ColorsCollectionForm.Colors[i]);
                m_MappingFromUIToLogic.Add(m_Board.ColorsCollectionForm.Colors[i], currentCharOption);
                i++;
            }
        }

        public string ConvertUserChoicesToGameLogic(List<Color> i_UserChoices)
        {
            StringBuilder userChoicesAsString = new StringBuilder();
            foreach (Color colorChoice in i_UserChoices)
            {
                m_MappingFromUIToLogic.TryGetValue(colorChoice, out Game.CharOptions convertToEnum);
                userChoicesAsString.Append(convertToEnum.ToString());
                Console.WriteLine(convertToEnum.ToString());
            }
            return userChoicesAsString.ToString();
        }

        public List<Color> ConvertResultToColor(string i_UserChoicesStatus)
        {
            Console.WriteLine(i_UserChoicesStatus);
            List<Color> userCohicesConvertToColor = new List<Color>();
            for (int i = 0; i < i_UserChoicesStatus.Length; i++)
            {
                char currentResult = i_UserChoicesStatus[i];
                if (currentResult == 'V')
                {
                    userCohicesConvertToColor.Add(Color.Black);
                }
                else if (currentResult == 'X')
                {
                    userCohicesConvertToColor.Add(Color.Yellow);
                }
            }
            return userCohicesConvertToColor;
        }
    }
}
