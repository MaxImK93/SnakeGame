using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public enum SnakeDir
    {
        Up,
        Down,
        Right,
        Left
    }

    internal class SnakeGameplayState : BaseGameState
    {
        const char symbol = '■';

        public struct Cell
        {
            public int _X;
            public int _Y;

            public Cell(int x, int y)
            {
                _X = x;
                _Y = y;
            }

        }

        public int fieldWidth { get; set; }
        public int fieldHeight { get; set; }

        public List<Cell> Body = new();
        public SnakeDir currentDir = SnakeDir.Left;

        private float timeToMove = 0f;


        public void SetDirection(SnakeDir Direction)
        {
            currentDir = Direction;
        }

        public override void Reset()
        {
            Body.Clear();

            var middleY = fieldHeight / 2;
            var middleX = fieldWidth / 2;

            currentDir = SnakeDir.Left;
            Body.Add(new Cell(middleX, middleY));
          
            timeToMove = 0f;
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            foreach (var cell in Body)
            {
                renderer.SetPixel(cell._X, cell._Y, symbol, 3);
            }
        }


        public override void Update(float deltaTime)
        {

            timeToMove -= deltaTime;

            if (timeToMove > 0f)
                return;

            timeToMove = 1f / 4f;

            Cell head = Body[0];

            Cell nextCell = ShiftTo(head, currentDir);

            if (nextCell._X < 0 || nextCell._X >= fieldWidth || nextCell._Y < 0 || nextCell._Y >= fieldHeight)
            {
                Reset(); 
                return;
            }

            Body.RemoveAt(Body.Count - 1);

            Body.Insert(0, nextCell);

        }

        public Cell ShiftTo(Cell from, SnakeDir dir)
        {

            switch (dir)
            {
                case SnakeDir.Up:
                    return new Cell(from._X, from._Y - 1);
                case SnakeDir.Down:
                    return new Cell(from._X, from._Y + 1);
                case SnakeDir.Right:
                    return new Cell(from._X + 1, from._Y);
                case SnakeDir.Left:
                    return new Cell(from._X - 1, from._Y);

            }

            return from;
        }

    }

    
}
