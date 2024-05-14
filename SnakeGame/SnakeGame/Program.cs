using System;

namespace SnakeGame
{
    class Program
    {
        public static DateTime lastFrameTime;
        public static DateTime frameStartTime;
        public static float deltaTime;

        public static void Main(string[] args)
        {
            SnakeGameLogic gameLogic = new SnakeGameLogic();

            ConsoleInput input = new ConsoleInput();

            gameLogic.InitializeInput(input);

            lastFrameTime = DateTime.Now;

            gameLogic.GotoGameplay();

            while (true)
            {
                input.Update();

                frameStartTime = DateTime.Now;

                deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;

                gameLogic.Update(deltaTime);

                lastFrameTime = frameStartTime;
            }


        }
    }
}
