
var gridService = new GridService(gridSize: 8, numMines: 10);
var inputService = new InputService();
var game = new MinefieldGame(gridService, inputService);

game.Play();