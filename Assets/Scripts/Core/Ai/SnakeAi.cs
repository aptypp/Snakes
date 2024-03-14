using Core.Food;
using Core.Snakes;
using UnityEngine;

namespace Core.Ai
{
    public class SnakeAi
    {
        private readonly FoodPool _foodPool;
        private readonly SnakeController _snakeController;

        public SnakeAi(
            FoodPool foodPool,
            SnakeController snakeController)
        {
            _foodPool = foodPool;
            _snakeController = snakeController;
        }

        public void RotateToClosestFood()
        {
            var snakePosition = _snakeController.SnakeView.transform.position;

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

            _snakeController.SetTargetRotation(targetRotation);
        }

        public void UpdateView()
        {
            _snakeController.UpdateView();
        }

        public void MoveForward()
        {
            _snakeController.MoveForward();
        }
    }
}