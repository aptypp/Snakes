using System.Collections.Generic;
using Core.Food;
using Core.Food.Views;
using Core.Snakes.Views;
using UnityEngine;

namespace Core.Snakes.Models
{
    public class SnakeModel
    {
        public float MoveSpeed;
        public float MoveSmoothDelta;
        public float RotationSmoothDelta;
        public Vector3 TargetPosition;
        public Quaternion TargetRotation;
        public List<TailView> Tails;

        private readonly FoodPool _foodPool;

        public SnakeModel(
            FoodPool foodPool)
        {
            _foodPool = foodPool;
        }

        public void AteFood(
            FoodView foodView)
        {
            _foodPool.Remove(foodView);

            Object.Destroy(foodView.gameObject);
        }

        public void Move(Vector3 direction)
        {
            TargetPosition += direction * MoveSpeed * Time.deltaTime;
        }

        public void RotateToClosestFood()
        {
            if (!_foodPool.TryGetClosestFood(
                    TargetPosition,
                    out var foodView))
            {
                return;
            }

            var directionToFood = foodView.transform.position - TargetPosition;

            var targetRotation = Quaternion.LookRotation(
                directionToFood,
                Vector3.up);

            TargetRotation = targetRotation;
        }
    }
}