namespace prove_06;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then display "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze {
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap) {
        _mazeMap = mazeMap;
    }

    // Todo Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, then display "Can't go that way!"
    /// </summary>
    public void MoveLeft() {
        // Check if the current location allows moving left (index 0)
        if (!_mazeMap.ContainsKey((_currX, _currY)) || !_mazeMap[(_currX, _currY)][0]) {
            Console.WriteLine("Can't go that way!");
            return;
        }
        // Check if the destination exists in the maze
        if (!_mazeMap.ContainsKey((_currX - 1, _currY))) {
            Console.WriteLine("You shalt not go that way!");
            return;
        }
        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, then display "Can't go that way!"
    /// </summary>
    public void MoveRight() {
        // Check if the current location allows moving right (index 1)
        if (!_mazeMap.ContainsKey((_currX, _currY)) || !_mazeMap[(_currX, _currY)][1]) {
            Console.WriteLine("Can't go that way!");
            return;
        }
        // Check if the destination exists in the maze
        if (!_mazeMap.ContainsKey((_currX + 1, _currY))) {
            Console.WriteLine("You may not pass");
            return;
        }
        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, then display "Can't go that way!"
    /// </summary>
    public void MoveUp() {
        // Check if the current location allows moving up (index 2)
        if (!_mazeMap.ContainsKey((_currX, _currY)) || !_mazeMap[(_currX, _currY)][2]) {
            Console.WriteLine("Don't go that way!");
            return;
        }
        // Check if the destination exists in the maze
        if (!_mazeMap.ContainsKey((_currX, _currY - 1))) {
            Console.WriteLine("You definitely cannot go that way");
            return;
        }
        _currY--;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, then display "Can't go that way!"
    /// </summary>
    public void MoveDown() {
        // Check if the current location allows moving down (index 3)
        if (!_mazeMap.ContainsKey((_currX, _currY)) || !_mazeMap[(_currX, _currY)][3]) {
            Console.WriteLine("Can't go that way!");
            return;
        }
        // Check if the destination exists in the maze
        if (!_mazeMap.ContainsKey((_currX, _currY + 1))) {
            Console.WriteLine("Can't go that way!");
            return;
        }
        _currY++;
    }

    public void ShowStatus() {
        Console.WriteLine($"Current location (x={_currX}, y={_currY})");
    }
}