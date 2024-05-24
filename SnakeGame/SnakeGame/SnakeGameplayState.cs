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
        const char circleSymbol = 'o';

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

        public bool gameOver;

        private float timeToMove = 0f;

        Cell apple = new Cell();

        Random random = new Random();

        public bool hasWon;

        public int level; 

        public void SetDirection(SnakeDir Direction)
        {
            currentDir = Direction;
        }

        public override void Reset()
        {
            apple = new Cell(2, 2);

            Body.Clear();

            var middleY = fieldHeight / 2;
            var middleX = fieldWidth / 2;

            currentDir = SnakeDir.Left;
            Body.Add(new Cell(middleX, middleY));
          
            timeToMove = 0f;

            gameOver = false;

            hasWon = false; 
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            foreach (var cell in Body)
            {
                renderer.SetPixel(cell._X, cell._Y, symbol, 3);
            }

            renderer.SetPixel(apple._X, apple._Y, circleSymbol, 2);

            renderer.DrawString($"Level: {level}", 120, 0, ConsoleColor.Blue);
            renderer.DrawString($"Score: {Body.Count - 1}", 120, 1, ConsoleColor.Blue);
        }

        public void GenerateApple()
        {
            Cell cell;

            cell._X = random.Next(fieldWidth);
            cell._Y = random.Next(fieldHeight);

            if (Body[0].Equals(cell))
            {
                if (cell._Y > fieldHeight/2)
                {
                    cell._Y--;
                }
                else
                {
                    cell._Y++;
                }
            }

            apple = cell; 
        }


        public override void Update(float deltaTime)
        {

            timeToMove -= deltaTime;

            if (timeToMove > 0f || gameOver)
                return;

            timeToMove = 1f / (4f + level);

            Cell head = Body[0];

            Cell nextCell = ShiftTo(head, currentDir);

            if (nextCell._X == apple._X & nextCell._Y == apple._Y)
            {
                Body.Insert(0, apple);
                hasWon = Body.Count >= level + 2;
                GenerateApple();
                return;
            }

            if (nextCell._X < 0 || nextCell._Y < 0 || nextCell._X >= fieldWidth || nextCell._Y >= fieldHeight)
            {
                gameOver = true;
                return;
            }


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

        public override bool IsDone()
        {
            return gameOver || hasWon;
        }
    }

    
}
