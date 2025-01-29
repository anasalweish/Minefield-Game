public class GridService : IGridService
{
    private readonly List<Position> _mines;  
    public int GridSize { get; }

    public GridService(int gridSize, int numMines)
    {
        GridSize = gridSize;
        _mines = new List<Position>();  
        PlaceMines(numMines);
    }

    private void PlaceMines(int numMines)
    {
        Random random = new();
        int placedMines = 0;

        while (placedMines < numMines)
        {
            int row = random.Next(GridSize);
            int col = random.Next(GridSize);

            var minePosition = new Position(row, col);

            // Check if the mine is already placed or it's the start position (0, 0)
            if (!_mines.Contains(minePosition) && (row != 0 || col != 0))
            {
                _mines.Add(minePosition);
                placedMines++;
            }
        }
    }

    public void DisplayGrid(Position playerPosition, int lives, int moves)
    {
        Console.WriteLine("Lives: {0}, Moves: {1}", lives, moves);

        for (int row = 0; row < GridSize; row++)
        {
            for (int col = 0; col < GridSize; col++)
            {
                if (row == playerPosition.Row && col == playerPosition.Col)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("* "); 
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(". "); 
                }
            }
            Console.WriteLine();
        }
    }

    public bool TryMove(Position currentPosition, string direction, out Position newPosition)
    {
        newPosition = new Position(currentPosition.Row, currentPosition.Col);

        switch (direction.ToLower())
        {
            case "up": newPosition.Row--; break;
            case "down": newPosition.Row++; break;
            case "left": newPosition.Col--; break;
            case "right": newPosition.Col++; break;
            default: return false;
        }

        return newPosition.Row >= 0 && newPosition.Row < GridSize &&
               newPosition.Col >= 0 && newPosition.Col < GridSize;
    }

    public bool HasMine(Position position)
    {
        return _mines.Contains(position); 
    }
}