using Core.Cameras;
using Core.Food;
using Core.Simulations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.EntryPoints
{
    public class MainSceneEntryPoint : IStartable, ITickable, IInitializable
    {
        private readonly FoodSimulator _foodSimulator;
        private readonly CameraFactory _cameraFactory;
        private readonly SnakesSimulator _snakesSimulator;

        [Inject]
        public MainSceneEntryPoint(
                FoodSimulator foodSimulator,
                CameraFactory cameraFactory,
                SnakesSimulator snakesSimulator)
        {
            _foodSimulator = foodSimulator;
            _cameraFactory = cameraFactory;
            _snakesSimulator = snakesSimulator;
        }

        public void Initialize()
        {
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
        }

        public void Start()
        {
            _foodSimulator.CreateFood();

            _snakesSimulator.CreateSnakes();

            _cameraFactory.Create();
        }

        public void Tick()
        {
            _snakesSimulator.SimulateSnakes();
        }
    }
}