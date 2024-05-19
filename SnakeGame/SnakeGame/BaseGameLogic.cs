using System;
using static SnakeGame.ConsoleInput;

namespace SnakeGame
{
    internal abstract class BaseGameLogic : ConsoleInput.IArrowListener
    {
        protected BaseGameState? currentState { get; private set; }
        protected float time { get; private set; }
        protected int screenWidth { get; private set; }
        protected int screenHeight { get; private set; }

        public abstract ConsoleColor[] CreatePalette();

        public virtual void OnArrowDown()
        {
        }

        public virtual void OnArrowLeft()
        {
        }

        public virtual void OnArrowRight()
        {
        }

        public virtual void OnArrowUp()
        {
        }

        public void InitializeInput(ConsoleInput input)
        {
            input.Subscribe(this);
        }

        public abstract void Update(float deltaTime);

        public void ChangeState(BaseGameState state)
        {
            currentState?.Reset();

            currentState = state;

        }

        public void DrawNewState(float deltaTime, ConsoleRenderer renderer)
        {
            time += deltaTime;
            screenWidth = renderer.width;
            screenHeight = renderer.height;

            currentState?.Update(deltaTime);
            currentState?.Draw(renderer);

            Update(deltaTime);
        }
    }
}
