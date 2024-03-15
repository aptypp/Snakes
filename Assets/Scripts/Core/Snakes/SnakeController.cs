using Core.Snakes.Models;
using Core.Snakes.Views;
using UnityEngine;

namespace Core.Snakes
{
    public class SnakeController
    {
        public SnakeView SnakeView => _snakeView;

        private readonly SnakeView _snakeView;
        private readonly SnakeModel _snakeModel;
        private readonly SnakesConfig _snakesConfig;

        public SnakeController(
            SnakeView snakeView,
            SnakeModel snakeModel,
            SnakesConfig snakesConfig)
        {
            _snakeView = snakeView;
            _snakeModel = snakeModel;
            _snakesConfig = snakesConfig;
        }

        public void SetTargetRotation(
            Quaternion targetRotation)
        {
            _snakeModel.Rotation = targetRotation;
        }

        public void UpdateView()
        {
            _snakeView.transform.position = Vector3.Lerp(
                _snakeView.transform.position,
                _snakeModel.Position,
                _snakesConfig.MoveSmoothDelta * Time.deltaTime);

            _snakeView.transform.rotation = Quaternion.Lerp(
                _snakeView.transform.rotation,
                _snakeModel.Rotation,
                _snakesConfig.RotationSmoothDelta * Time.deltaTime);
        }

        public void MoveForward()
        {
            _snakeModel.Position += _snakeView.transform.forward * _snakesConfig.MoveSpeed * Time.deltaTime;
        }

        public void SetPositionInstantly(
            Vector3 position)
        {
            _snakeModel.Position = position;
            _snakeView.transform.position = position;
        }
    }
}