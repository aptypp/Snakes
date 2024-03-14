using Core.Ai;
using Core.Food;
using Core.Snakes;
using VContainer;

namespace Core.Simulations
{
    public class SnakesSimulator
    {
        private SnakeAi[] _snakes;

        private readonly FoodPool _foodPool;
        private readonly SnakeFactory _snakeFactory;

        [Inject]
        public SnakesSimulator(
            FoodPool foodPool,
            SnakeFactory snakeFactory)
        {
            _foodPool = foodPool;
            _snakeFactory = snakeFactory;
        }

        public void SpawnSnakes()
        {
            const int snakesCount = 10;

            _snakes = new SnakeAi[snakesCount];

            for (var snakeIndex = 0; snakeIndex < snakesCount; snakeIndex++)
            {
                var snakeController = _snakeFactory.Create();

                _snakes[snakeIndex] = new SnakeAi(
                    _foodPool,
                    snakeController);
            }
        }

        public void SimulateSnakes()
        {
            foreach (var snake in _snakes)
            {
                snake.RotateToClosestFood();
                snake.MoveForward();
            }

            foreach (var snake in _snakes)
            {
                snake.UpdateView();
            }
        }
    }
}