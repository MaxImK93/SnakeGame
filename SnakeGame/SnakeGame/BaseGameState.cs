﻿using System;
namespace SnakeGame
{
    public abstract class BaseGameState
    {
        public abstract void Update(float deltaTime);

        public abstract void Reset();

    }
}