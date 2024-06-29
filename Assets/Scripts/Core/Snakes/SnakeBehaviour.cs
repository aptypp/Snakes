using Core.Food;
using Core.Food.Views;
using UnityEngine;

namespace Core.Snakes
{
    public class SnakeBehaviour
    {
        private readonly FoodPool _foodPool;
        private readonly SnakeViewModel _snakeViewModel;

        public SnakeBehaviour(
            FoodPool foodPool,
            SnakeViewModel snakeViewModel)
        {
            _foodPool = foodPool;
            _snakeViewModel = snakeViewModel;

            _snakeViewModel.SnakeView.AteFood += OnAteFood;
        }

        public void RotateToClosestFood()
        {
            var snakePosition = _snakeViewModel.SnakeView.transform.position;

            if (!_foodPool.TryGetClosestFood(
                    snakePosition,
                    out var foodView))
            {
                return;
            }

            var directionToFood = foodView.transform.position - snakePosition;

            var targetRotation = Quaternion.LookRotation(
                directionToFood,
                Vector3.up);

            _snakeViewModel.SetTargetRotation(targetRotation);
        }

        public void UpdateView()
        {
            _snakeViewModel.UpdateView();
        }

        public void MoveForward()
        {
            _snakeViewModel.MoveForward();
        }

        private void OnAteFood(
            FoodView foodView)
        {
            _foodPool.Remove(foodView);

            Object.Destroy(foodView.gameObject);
        }
    }
}