public class MinefieldGame(IGridService gridService, IInputService inputService) : IMinefieldGame
{
    private readonly IGridService _gridService = gridService;
    private readonly IInputService _inputService = inputService;
    private int _moves = 0;
    private Position _playerPosition = new(0, 0);

    public int Lives = 3;

    public void Play()
    {
        Console.WriteLine("Welcome to the Minefield Game!");
        Console.WriteLine("Navigate to the other side while avoiding mines.");

        while (Lives > 0 && _playerPosition.Row != _gridService.GridSize - 1)
        {
            _gridService.DisplayGrid(_playerPosition, Lives, _moves);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter your move (up, down, left, right): ");
            Console.ForegroundColor = ConsoleColor.White;

            var direction = _inputService.GetInput();

            if (_gridService.TryMove(_playerPosition, direction, out var newPosition))
            {
                _playerPosition = newPosition;
                _moves++;

                if (_gridService.HasMine(_playerPosition))
                {
                    Lives--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You hit a mine! Lives left: {0}", Lives);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }

        _gridService.DisplayGrid(_playerPosition, Lives, _moves);

        if (Lives > 0)
        {
            Console.WriteLine("Congratulations! You reached the other side in {0} moves.", _moves);
        }
        else
        {
            Console.WriteLine("Game over! You ran out of lives.");
        }
    }
}