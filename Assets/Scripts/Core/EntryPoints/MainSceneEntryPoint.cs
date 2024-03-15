using Core.Cameras;
using Core.Food;
using Core.Simulations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.EntryPoints
{
    public class MainSceneEntryPoint : IStartable, ITickable
    {
        private readonly FoodPool _foodPool;
        private readonly FoodConfig _foodConfig;
        private readonly FoodFactory _foodFactory;
        private readonly CameraFactory _cameraFactory;
        private readonly SnakesSimulator _snakesSimulator;

        [Inject]
        public MainSceneEntryPoint(
            FoodPool foodPool,
            FoodConfig foodConfig,
            FoodFactory foodFactory,
            CameraFactory cameraFactory,
            SnakesSimulator snakesSimulator)
        {
            _foodPool = foodPool;
            _foodConfig = foodConfig;
            _foodFactory = foodFactory;
            _cameraFactory = cameraFactory;
            _snakesSimulator = snakesSimulator;
        }

        public void Start()
        {
            InitializeFood();

            _snakesSimulator.CreateSnakes();

            _cameraFactory.Create();
        }

        public void Tick()
        {
            _snakesSimulator.SimulateSnakes();
        }

        private void InitializeFood()
        {
            for (var foodIndex = 0; foodIndex < _foodConfig.FoodCount; foodIndex++)
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