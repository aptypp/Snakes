using Core.Cameras;
using Core.Food;
using Core.Food.Views;
using Core.Simulations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.EntryPoints
{
    public class MainSceneEntryPoint : IStartable, ITickable
    {
        private readonly FoodParent _foodParent;
        private readonly FoodConfig _foodConfig;
        private readonly FoodPool _foodPool;
        private readonly CameraConfig _cameraConfig;
        private readonly SnakesSimulator _snakesSimulator;

        [Inject]
        public MainSceneEntryPoint(
            FoodParent foodParent,
            FoodConfig foodConfig,
            FoodPool foodPool,
            CameraConfig cameraConfig,
            SnakesSimulator snakesSimulator)
        {
            _foodParent = foodParent;
            _foodConfig = foodConfig;
            _foodPool = foodPool;
            _cameraConfig = cameraConfig;
            _snakesSimulator = snakesSimulator;
        }

        public void Start()
        {
            InitializeFood();

            _snakesSimulator.SpawnSnakes();

            Object.Instantiate(_cameraConfig.CameraViewPrefab); //TODO: Make factory for camera
        }

        public void Tick()
        {
            _snakesSimulator.SimulateSnakes();
        }

        private void InitializeFood()
        {
            const int foodCount = 5;

            for (var foodIndex = 0; foodIndex < foodCount; foodIndex++)
            {
                var foodView = Object.Instantiate(
                    _foodConfig.FoodViewPrefab,
                    Vector3.zero,
                    Quaternion.identity,
                    _foodParent.transform);

                _foodPool.Add(foodView);
            }
        }
    }
}