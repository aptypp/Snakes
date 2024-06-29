using System.Collections.Generic;
using Core.Food;
using Core.Snakes;
using UnityEngine;
using VContainer;

namespace Core.Simulations
{
    public class SnakesSimulator
    {
        private List<SnakeViewModel> _snakes;

        private readonly SnakesConfig _snakesConfig;
        private readonly SnakeFactory _snakeFactory;

        [Inject]
        public SnakesSimulator(
                FoodPool foodPool,
                SnakesConfig snakesConfig,
                SnakeFactory snakeFactory)
        {
            _snakesConfig = snakesConfig;
            _snakeFactory = snakeFactory;

            foodPool.FoodIsOver += DecreaseSnakesSize;
        }

        public void CreateSnakes()
        {
            _snakes = new List<SnakeViewModel>(_snakesConfig.SnakesCount);

            for (var snakeIndex = 0; snakeIndex < _snakesConfig.SnakesCount; snakeIndex++)
            {
                var position = Vector3.zero;

                position.x = Random.Range(
                    _snakesConfig.MinSpawnPosition.x,
                    _snakesConfig.MaxSpawnPosition.x);

                position.z = Random.Range(
                    _snakesConfig.MinSpawnPosition.y,
                    _snakesConfig.MaxSpawnPosition.y);
                
                var snakeViewModel = _snakeFactory.Create(position);

                _snakes.Add(snakeViewModel);
            }
        }

        public void SimulateSnakes()
        {
            foreach (var snake in _snakes)
            {
                snake.Model.RotateToClosestFood();
                snake.Model.Move(snake.View.transform.forward);
            }

            foreach (var snake in _snakes)
            {
                snake.MoveViewSmoothly();
                snake.RotateViewSmoothly();
                snake.MoveTailsSmoothly();
            }
        }

        private void DecreaseSnakesSize()
        {
            for (var snakeIndex = _snakes.Count - 1; snakeIndex >= 0; snakeIndex--)
            {
                var snake = _snakes[snakeIndex];

                if (snake.Model.Tails.Count == 0)
                {
                    _snakes.Remove(snake);
                    Object.Destroy(snake.View.gameObject);

                    continue;
                }

                snake.Model.DecreaseTailsCount();
            }
        }
    }
}