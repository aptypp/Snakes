using System.Collections.Generic;
using Core.Food.Views;
using UnityEngine;
using VContainer;

namespace Core.Food
{
    public class FoodPool
    {
        private readonly List<FoodView> _food;

        [Inject]
        public FoodPool()
        {
            _food = new List<FoodView>();
        }

        public void Add(
            FoodView foodView)
        {
            _food.Add(foodView);
        }

        public void Remove(
            FoodView foodView)
        {
            _food.Remove(foodView);
        }

        public bool TryGetClosestFood(
            Vector3 position,
            out FoodView foodView)
        {
            foodView = null;

            var shortestDistance = float.MaxValue;

            foreach (var food in _food)
            {
                var distance = (food.transform.position - position).magnitude;

                if (distance > shortestDistance) continue;

                shortestDistance = distance;
                foodView = food;
            }

            return foodView is not null;
        }
    }
}