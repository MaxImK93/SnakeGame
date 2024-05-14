using System;
using static SnakeGame.ConsoleInput;

namespace SnakeGame
{
    public class SnakeGameLogic : BaseGameLogic
    {
        SnakeGameplayState gameplayState = new SnakeGameplayState();

        public override void OnArrowUp()
        {
            gameplayState.SetDirection(SnakeDir.Up);
        }

        public override void OnArrowDown()
        {
            gameplayState.SetDirection(SnakeDir.Down);
        }

        public override void OnArrowRight()
        {
            gameplayState.SetDirection(SnakeDir.Right);
        }

        public override void OnArrowLeft()
        {
            gameplayState.SetDirection(SnakeDir.Left);
        }

        public override void Update(float deltaTime)
        {
            gameplayState.Update(deltaTime);
        }

        public void GotoGameplay()
        {
            gameplayState.Reset();
        }
    }
}
