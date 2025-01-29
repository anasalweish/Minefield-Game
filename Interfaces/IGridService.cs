public interface IGridService
{
    int GridSize { get; }
    void DisplayGrid(Position playerPosition, int lives, int moves);
    bool TryMove(Position currentPosition, string direction, out Position newPosition);
    bool HasMine(Position position);
}

