namespace B17_Ex02
{
    class Program
    {
        public static void Main()
        {
            int numberOfGuesses = UI.getUserNumberOfGuesses();
            GameManager gameManager = new GameManager(numberOfGuesses);
            gameManager.StartGame();
        }
    }
}