using Core.Ai;
using Core.Food;
using Core.Snakes;
using UnityEngine;
using VContainer;

namespace Core.Simulations
{
    public class SnakesSimulator
    {
        private SnakeAi[] _snakes;

        private readonly FoodPool _foodPool;
        private readonly SnakesConfig _snakesConfig;
        private readonly SnakeFactory _snakeFactory;

        [Inject]
        public SnakesSimulator(
            FoodPool foodPool,
            SnakesConfig snakesConfig,
            SnakeFactory snakeFactory)
        {
            _foodPool = foodPool;
            _snakesConfig = snakesConfig;
            _snakeFactory = snakeFactory;
        }

        public void CreateSnakes()
        {
            _snakes = new SnakeAi[_snakesConfig.SnakesCount];

            for (var snakeIndex = 0; snakeIndex < _snakes.Length; snakeIndex++)
            {
                var snakeController = _snakeFactory.Create();

                var position = Vector3.zero;

                position.x = Random.Range(
                    _snakesConfig.MinSpawnPosition.x,
                    _snakesConfig.MaxSpawnPosition.x);

                position.z = Random.Range(
                    _snakesConfig.MinSpawnPosition.y,
                    _snakesConfig.MaxSpawnPosition.y);

                snakeController.SetPositionInstantly(position);

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