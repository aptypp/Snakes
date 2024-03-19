using Core.Snakes.Models;
using Core.Snakes.Views;
using UnityEngine;
using VContainer;

namespace Core.Snakes
{
    public class SnakeFactory
    {
        private readonly SnakesConfig _config;
        private readonly SnakesParent _snakesParent;

        [Inject]
        public SnakeFactory(
            SnakesConfig config,
            SnakesParent snakesParent)
        {
            _config = config;
            _snakesParent = snakesParent;
        }

        public SnakeController Create()
        {
            var snakeModel = new SnakeModel();

            var moveSpeed = Random.Range(
                _config.MoveSpeedMin,
                _config.MoveSpeedMax);

            var rotationSmoothDelta = Random.Range(
                _config.RotationSmoothDeltaMin,
                _config.RotationSmoothDeltaMax);

            snakeModel.MoveSpeed = moveSpeed;
            snakeModel.RotationSmoothDelta = rotationSmoothDelta;

            var snakeView = Object.Instantiate(
                _config.SnakeViewPrefab,
                Vector3.zero,
                Quaternion.identity,
                _snakesParent.transform);

            var snakeController = new SnakeController(
                snakeView,
                snakeModel,
                _config);

            return snakeController;
        }
    }
}