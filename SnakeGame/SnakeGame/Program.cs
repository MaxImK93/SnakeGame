using System;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        public static DateTime lastFrameTime;
        public static DateTime frameStartTime;
        public static float deltaTime;

        public static ConsoleColor[] pallette;

        public static ConsoleRenderer renderer0;
        public static ConsoleRenderer renderer1;

        public static ConsoleRenderer prevRenderer;
        public static ConsoleRenderer currRenderer;

        public static ConsoleRenderer temp;

        public const float targetFrameTime = 1 / 60f;

        public static DateTime nextFrameTime;
        public static DateTime endFrameTime;

        public static void Main(string[] args)
        {
            SnakeGameLogic gameLogic = new SnakeGameLogic();

            pallette = gameLogic.CreatePallet();

            renderer0 = new ConsoleRenderer(pallette);
            renderer1 = new ConsoleRenderer(pallette);

            prevRenderer = renderer0;
            currRenderer = renderer1;

            ConsoleInput input = new ConsoleInput();

            gameLogic.InitializeInput(input);

            lastFrameTime = DateTime.Now;

            while (true)
            {

                frameStartTime = DateTime.Now;

                deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;

                input.Update();

                lastFrameTime = frameStartTime;

                gameLogic.DrawNewState(deltaTime, currRenderer);

                if (currRenderer != prevRenderer)
                    currRenderer.Render();

                prevRenderer = temp;
                prevRenderer = currRenderer;
                currRenderer = temp;
                currRenderer.Clear();

                nextFrameTime = frameStartTime.AddSeconds(targetFrameTime);

                endFrameTime = DateTime.Now;

                if (nextFrameTime > endFrameTime)
                    Thread.Sleep(nextFrameTime.Millisecond - endFrameTime.Millisecond);
            }


        }
    }
}
