using System;
using static SnakeGame.ConsoleInput;

namespace SnakeGame
{
    internal class SnakeGameLogic : BaseGameLogic
    {
        SnakeGameplayState gameplayState = new SnakeGameplayState();

        public void GotoGameplay()
        {

            gameplayState.fieldHeight = screenHeight;
            gameplayState.fieldWidth = screenWidth;

            ChangeState(gameplayState);
            gameplayState.Reset();
        }

        public override void OnArrowUp()
        {
            if (currentState != gameplayState) return;
            gameplayState.SetDirection(SnakeDir.Up);
        }

        public override void OnArrowDown()
        {
            if (currentState != gameplayState) return;
            gameplayState.SetDirection(SnakeDir.Down);
        }

        public override void OnArrowRight()
        {
            if (currentState != gameplayState) return;
            gameplayState.SetDirection(SnakeDir.Right);
        }

        public override void OnArrowLeft()
        {
            if (currentState != gameplayState) return;
            gameplayState.SetDirection(SnakeDir.Left);
        }

        public override void Update(float deltaTime)
        {
            if (currentState != gameplayState)
            {
                GotoGameplay();
            }
                
        }

        public override ConsoleColor[] CreatePalette()
        {
            return new ConsoleColor[]
            {
                ConsoleColor.Black,
                ConsoleColor.Gray,
                ConsoleColor.Red,
                ConsoleColor.Blue

            };
        }
    }
}
