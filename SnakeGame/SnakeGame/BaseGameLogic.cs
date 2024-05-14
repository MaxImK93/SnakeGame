using System;
using static SnakeGame.ConsoleInput;

namespace SnakeGame
{
    public abstract class BaseGameLogic : IArrowListener
    {
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
    }
}
