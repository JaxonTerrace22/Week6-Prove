using System;
using System.Collections.Generic;

namespace Week6_Prove
{
    public class Maze
    {
        private readonly Dictionary<(int, int), bool[]> _mazeMap;
        private int _currX = 1;
        private int _currY = 1;

        public Maze(Dictionary<(int, int), bool[]> mazeMap)
        {
            _mazeMap = mazeMap;
        }

        public void MoveLeft()
        {
            if (!_mazeMap.ContainsKey((_currX, _currY)) || !_mazeMap[(_currX, _currY)][0])
            {
                Console.WriteLine("Can't go that way!");
                return;
            }
            _currX--;
        }

        public void MoveRight()
        {
            if (!_mazeMap.ContainsKey((_currX, _currY)) || !_mazeMap[(_currX, _currY)][1])
            {
                Console.WriteLine("Can't go that way!");
                return;
            }
            _currX++;
        }

        public void MoveUp()
        {
            if (!_mazeMap.ContainsKey((_currX, _currY)) || !_mazeMap[(_currX, _currY)][2])
            {
                Console.WriteLine("Can't go that way!");
                return;
            }
            _currY--;
        }

        public void MoveDown()
        {
            if (!_mazeMap.ContainsKey((_currX, _currY)) || !_mazeMap[(_currX, _currY)][3])
            {
                Console.WriteLine("Can't go that way!");
                return;
            }
            _currY++;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Current location (x={_currX}, y={_currY})");
        }
    }
}