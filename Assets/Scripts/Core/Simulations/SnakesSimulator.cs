using Core.Food;
using Core.Snakes;
using UnityEngine;
using VContainer;

namespace Core.Simulations
{
    public class SnakesSimulator
    {
        private SnakeBehaviour[] _snakes;

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
            _snakes = new SnakeBehaviour[_snakesConfig.SnakesCount];

            for (var snakeIndex = 0; snakeIndex < _snakes.Length; snakeIndex++)
            {
                var snakeViewModel = _snakeFactory.Create();

                var position = Vector3.zero;

                position.x = Random.Range(
                    _snakesConfig.MinSpawnPosition.x,
                    _snakesConfig.MaxSpawnPosition.x);

                position.z = Random.Range(
                    _snakesConfig.MinSpawnPosition.y,
                    _snakesConfig.MaxSpawnPosition.y);

                snakeViewModel.SetPositionInstantly(position);

                _snakes[snakeIndex] = new SnakeBehaviour(
                    _foodPool,
                    snakeViewModel);
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