namespace HangmanSix
{
    /// <summary>
    /// Main engine class in the application holding Main() method
    /// </summary>
    public static class HangmanSix
    {
        public static void Main()
        {
            Player newPlayer = Player.Instance;
            var console = new ConsoleWrapper();
            GameEngine newGame = new GameEngine(newPlayer, console);
            newGame.InitializeData();
        }
    }
}
