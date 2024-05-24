using System;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        private const float targetFrameTime = 1f / 60f;

        public static void Main(string[] args)
        {

            SnakeGameLogic gameLogic = new SnakeGameLogic();

            ConsoleColor[] pallette = gameLogic.CreatePalette();

            ConsoleRenderer renderer0 = new ConsoleRenderer(pallette);
            ConsoleRenderer renderer1 = new ConsoleRenderer(pallette);

            ConsoleInput input = new ConsoleInput();
            gameLogic.InitializeInput(input);

            ConsoleRenderer prevRenderer = renderer0;
            ConsoleRenderer currRenderer = renderer1;
            DateTime lastFrameTime = DateTime.Now;

            while (true)
            {

                DateTime frameStartTime = DateTime.Now;

                float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;

                input.Update();

                gameLogic.DrawNewState(deltaTime, currRenderer);
                lastFrameTime = frameStartTime;

                if (!currRenderer.Equals(prevRenderer)) currRenderer.Render();

                ConsoleRenderer temp = prevRenderer;
                prevRenderer = currRenderer;
                currRenderer = temp;
                currRenderer.Clear();

                var nextFrameTime = frameStartTime + TimeSpan.FromSeconds(targetFrameTime);

                DateTime endFrameTime = DateTime.Now;

                if (nextFrameTime > endFrameTime)
                {
                    Thread.Sleep((int)(nextFrameTime - endFrameTime).TotalMilliseconds);
                }
            }


        }
    }
}