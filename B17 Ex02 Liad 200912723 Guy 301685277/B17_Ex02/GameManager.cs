using System;
using Ex02.ConsoleUtils;

namespace B17_Ex02
{
    class GameManager
    {
        private Game m_Game;
        private Board m_Board;
        private bool m_IsPlaying;

        public GameManager(int i_NumberOfGuesses)
        {
            m_Game = new Game(i_NumberOfGuesses);
            m_Board = new Board(i_NumberOfGuesses);
            m_IsPlaying = true;
        }

        public void StartGame()
        {
            while (m_IsPlaying)
            {
                m_Board.PrintBoard();
                while (m_Game.AttemptsCounter < m_Game.TotalNumberOfGuesses && !m_Game.IsWin)
                {
                    string userGuess = UI.getUserGuess();
                    string guessStatus = (m_Game.getChoicesStatus(userGuess));
                    Screen.Clear();
                    m_Board.buildRow(userGuess, guessStatus, m_Game.AttemptsCounter);
                    m_Board.PrintBoard();
                    m_Game.AttemptsCounter++;
                }
                if (m_Game.IsWin)
                {
                    Console.WriteLine("You guessed after {0} steps!", m_Game.AttemptsCounter);
                }
                else
                {
                    Console.WriteLine("No more guesses allowed. You Lost.");
                    Console.WriteLine("The Word is --> {0}", m_Game.RandomWord);
                }
                RestartGame();
            }
        }
        public void RestartGame()
        {
            m_IsPlaying = UI.gameRestart();
            if (m_IsPlaying)
            {
                Screen.Clear();
                int numberOfGuesses = UI.getUserNumberOfGuesses();
                m_Game = new Game(numberOfGuesses);
                m_Board = new Board(numberOfGuesses);
            }
        }
    }
}
