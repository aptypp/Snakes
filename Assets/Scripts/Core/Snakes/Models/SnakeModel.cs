using System;
using System.Collections.Generic;
using System.Linq;
using Core.Food;
using Core.Food.Views;
using Core.Snakes.Views;
using UnityEngine;
using Object = UnityEngine.Object;

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
        private readonly Func<Vector3, TailView> _createTailView;

        public SnakeModel(
                FoodPool foodPool,
                Func<Vector3, TailView> createTailView)
        {
            _foodPool = foodPool;
            _createTailView = createTailView;
        }

        public void AteFood(
                FoodView foodView)
        {
            IncreaseTailsCount();

            _foodPool.Remove(foodView);

            Object.Destroy(foodView.gameObject);
        }

        public void IncreaseTailsCount()
        {
            var tailPosition = Tails.Count == 0 ? TargetPosition : Tails.Last().transform.position;

            var tailView = _createTailView(tailPosition);

            Tails.Add(tailView);
        }

        public void DecreaseTailsCount()
        {
            var tailView = Tails.Last();

            Tails.Remove(tailView);

            Object.Destroy(tailView.gameObject);
        }

        public void Move(
                Vector3 direction)
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