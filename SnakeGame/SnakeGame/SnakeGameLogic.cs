using System;
using static SnakeGame.ConsoleInput;

namespace SnakeGame
{
    public class SnakeGameLogic : BaseGameLogic
    {
        SnakeGameplayState gameplayState = new SnakeGameplayState();

        public override void OnArrowUp()
        {
            if (currentState != gameplayState)
                return;

            gameplayState.SetDirection(SnakeDir.Up);
            
        }

        public override void OnArrowDown()
        {
            if (currentState != gameplayState)
                return;

            gameplayState.SetDirection(SnakeDir.Down);
        }

        public override void OnArrowRight()
        {
            if (currentState != gameplayState)
                return;

            gameplayState.SetDirection(SnakeDir.Right);
        }

        public override void OnArrowLeft()
        {
            if (currentState != gameplayState)
                return;

            gameplayState.SetDirection(SnakeDir.Left);
        }

        public override void Update(float deltaTime)
        {
            if (currentState != gameplayState)
                GotoGameplay();
        }

        public void GotoGameplay()
        {
            gameplayState.Reset();

            gameplayState.fieldHeight = screenHeight;
            gameplayState.fieldWidth = screenWidth;

            ChangeState(gameplayState);

        }

        public override ConsoleColor[] CreatePallet()
        {
            return new ConsoleColor[]
            {
                ConsoleColor.Black,
                ConsoleColor.Gray,
                ConsoleColor.Red,
                ConsoleColor.White,
                ConsoleColor.Magenta

            };

        }
    }
}
