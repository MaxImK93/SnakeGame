﻿using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public class SnakeGameplayState : BaseGameState
    {

        public List<Cell> Body = new List<Cell>();

        public SnakeDir currentDir;

        public float timeToMove;

        public int fieldWidth;
        public int fieldHeight;

        private int middleY;
        private int middleX;

        private const char symbol = '@';

        public SnakeGameplayState()
        {
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            renderer.SetPixel(middleX, middleY, symbol, 0);
        }

        public override void Reset()
        {
            Body.Clear();

            middleY = fieldHeight / 2;
            middleX = fieldWidth / 2; 

            currentDir = SnakeDir.Up;

            Body.Add(new Cell(middleX,middleY));

            timeToMove = 0; 
        }

        public void SetDirection(SnakeDir Direction)
        {
           currentDir = Direction;
        }

        public override void Update(float deltaTime)
        {
            timeToMove -= deltaTime;

            if (timeToMove > 0)
                return;

            timeToMove = 1f / 5f;

            Cell head = Body[0];

            Cell nextCell = head.ShiftTo(currentDir);

            Body.RemoveAt(Body.Count - 1);

            Body.Insert(0, nextCell);

            nextCell = Body[0];

        }

    }

    public struct Cell
    {
        private int _X;
        private int _Y;

        public Cell(int x, int y)
        {
            _X = x;
            _Y = y;
        }

        public Cell ShiftTo(SnakeDir dir)
        {

            switch (dir)
            {
                case SnakeDir.Up:
                    return new Cell(_X, _Y - 1);
                case SnakeDir.Down:
                    return new Cell(_X, _Y + 1);
                case SnakeDir.Right:
                    return new Cell(_X + 1, _Y);
                case SnakeDir.Left:
                    return new Cell(_X - 1, _Y);
                default:
                    return this;

            }

        }

        public override string ToString()
        {
            return $"X: {_X}, Y: {_Y}"; 
        }

    }

    public enum SnakeDir
    {
        Up,
        Down,
        Right,
        Left
    }
}
