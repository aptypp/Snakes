using Core.Food.Views;
using UnityEngine;
using VContainer;

namespace Core.Food
{
    public class FoodFactory
    {
        private readonly FoodParent _foodParent;
        private readonly FoodConfig _foodConfig;

        [Inject]
        public FoodFactory(
            FoodParent foodParent,
            FoodConfig foodConfig)
        {
            _foodParent = foodParent;
            _foodConfig = foodConfig;
        }

        public FoodView Create(
            Vector3 position)
        {
            var foodView = Object.Instantiate(
                _foodConfig.FoodViewPrefab,
                position,
                Quaternion.identity,
                _foodParent.transform);

            return foodView;
        }
    }
}