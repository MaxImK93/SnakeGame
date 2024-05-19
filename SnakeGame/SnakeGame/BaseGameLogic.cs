using System;
using static SnakeGame.ConsoleInput;

namespace SnakeGame
{
    public abstract class BaseGameLogic : IArrowListener
    {
        public BaseGameState currentState { get; private set; }

        public int screenWidth;
        public float time;
        public int screenHeight;

        public virtual void OnArrowDown()
        {
            throw new NotImplementedException();
        }

        public virtual void OnArrowLeft()
        {
            throw new NotImplementedException();
        }

        public virtual void OnArrowRight()
        {
            throw new NotImplementedException();
        }

        public virtual void OnArrowUp()
        {
            throw new NotImplementedException();
        }

        public void InitializeInput(ConsoleInput input)
        {
            input.Subscribe(this);
        }

        public abstract void Update(float deltaTime);

        public void ChangeState(BaseGameState state)
        {
            currentState.Reset();

            currentState = state;

            
        }

        public void DrawNewState(float deltaTime, ConsoleRenderer renderer)
        {
            time += deltaTime;
            screenWidth = renderer.width;
            screenHeight = renderer.height;

            currentState.Update(deltaTime);
            currentState.Draw(renderer);

            Update(deltaTime);
        }

        public abstract ConsoleColor[] CreatePallet();
    }
}
