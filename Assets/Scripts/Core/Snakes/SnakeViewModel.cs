using Core.Snakes.Models;
using Core.Snakes.Views;
using UnityEngine;

namespace Core.Snakes
{
    public class SnakeViewModel
    {
        public SnakeView SnakeView => _snakeView;

        private readonly SnakeView _snakeView;
        private readonly SnakeModel _snakeModel;

        public SnakeViewModel(
            SnakeView snakeView,
            SnakeModel snakeModel)
        {
            _snakeView = snakeView;
            _snakeModel = snakeModel;
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
                _snakeModel.MoveSmoothDelta * Time.deltaTime);

            _snakeView.transform.rotation = Quaternion.Lerp(
                _snakeView.transform.rotation,
                _snakeModel.Rotation,
                _snakeModel.RotationSmoothDelta * Time.deltaTime);
        }

        public void MoveForward()
        {
            _snakeModel.Position += _snakeView.transform.forward * _snakeModel.MoveSpeed * Time.deltaTime;
        }

        public void SetPositionInstantly(
            Vector3 position)
        {
            _snakeModel.Position = position;
            _snakeView.transform.position = position;
        }
    }
}