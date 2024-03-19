using UnityEngine;
using VContainer;

namespace Core.Food
{
    public class FoodSimulator
    {
        private readonly FoodPool _foodPool;
        private readonly FoodConfig _foodConfig;
        private readonly FoodFactory _foodFactory;

        [Inject]
        public FoodSimulator(
            FoodPool foodPool,
            FoodConfig foodConfig,
            FoodFactory foodFactory)
        {
            _foodPool = foodPool;
            _foodConfig = foodConfig;
            _foodFactory = foodFactory;
        }

        public void CreateFood()
        {
            var foodCount = Random.Range(
                _foodConfig.MinFoodCount,
                _foodConfig.MaxFoodCount);

            for (var foodIndex = 0; foodIndex < foodCount; foodIndex++)
            {
                var position = Vector3.zero;

                position.x = Random.Range(
                    _foodConfig.MinFoodPosition.x,
                    _foodConfig.MaxFoodPosition.x);

                position.z = Random.Range(
                    _foodConfig.MinFoodPosition.y,
                    _foodConfig.MaxFoodPosition.y);

                var foodView = _foodFactory.Create(position);

                _foodPool.Add(foodView);
            }
        }
    }
}