using System;
using static SnakeGame.ConsoleInput;

namespace SnakeGame
{
    internal class SnakeGameLogic : BaseGameLogic
    {
        SnakeGameplayState gameplayState = new SnakeGameplayState();
        bool newGamePending = false;
        int currentLevel;
        ShowTextState showTextState = new(2f);

        public void GotoGameplay()
        {
            gameplayState.level = currentLevel;

            gameplayState.fieldHeight = screenHeight;
            gameplayState.fieldWidth = screenWidth;

            ChangeState(gameplayState);
            gameplayState.Reset();
        }

        public void GoToGameOver()
        {
            currentLevel = 0;
            newGamePending = true;
            showTextState.text = "GAME OVER";
            ChangeState(showTextState);
        }

        public void GoToNextLevel()
        {
            currentLevel++;
            newGamePending = false;
            showTextState.text = $"Level {currentLevel}";
            ChangeState(showTextState);
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
            if (currentState != null && !currentState.IsDone())
                return;
            if (currentState == null || currentState == gameplayState && !gameplayState.gameOver)
            {
                GoToNextLevel();
            }
            else if (currentState == gameplayState && gameplayState.gameOver)
            {
                GoToGameOver();
            }
            else if (currentState != gameplayState && newGamePending)
            {
                GoToNextLevel();
            }
            else if (currentState != gameplayState && !newGamePending)
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
