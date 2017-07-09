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
            m_Board.StartGame();
            
            InitMapping();
            
        }

        private void GetNumberOfChancesHandler(int i_NumberOfChances)
        {
            Console.WriteLine("Number of Chances " + i_NumberOfChances);
            m_Game.TotalNumberOfGuesses = i_NumberOfChances;
        }

        private void UserSelectionHandler(List<Color> i_UserSelection)
        {
            Console.WriteLine(m_Game.getChoicesStatus(ConvertUserChoicesToGameLogic(i_UserSelection)));
        }

        public void InitMapping()
        {
            int i = 0;
            foreach (Game.CharOptions currentCharOption in Enum.GetValues(typeof(Game.CharOptions)))
            {
                m_MappingFromUIToLogic.Add(m_Board.ColorsCollectionForm.Colors[i],currentCharOption);
                i++;
            }

        }

        public string ConvertUserChoicesToGameLogic(List<Color> i_UserChoices)
        {
            StringBuilder userChoicesAsString = new StringBuilder();
            foreach(Color colorChoice in i_UserChoices)
            {
                m_MappingFromUIToLogic.TryGetValue(colorChoice,out Game.CharOptions convertToEnum);
                userChoicesAsString.Append(convertToEnum.ToString());
            }

            return userChoicesAsString.ToString();

        }
    }
}
