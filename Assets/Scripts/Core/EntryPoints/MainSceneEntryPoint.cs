using Core.Cameras;
using Core.Food;
using Core.Simulations;
using VContainer;
using VContainer.Unity;

namespace Core.EntryPoints
{
    public class MainSceneEntryPoint : IStartable, ITickable
    {
        private readonly FoodPool _foodPool;
        private readonly FoodSimulator _foodSimulator;
        private readonly CameraFactory _cameraFactory;
        private readonly SnakesSimulator _snakesSimulator;

        [Inject]
        public MainSceneEntryPoint(
            FoodPool foodPool,
            FoodSimulator foodSimulator,
            CameraFactory cameraFactory,
            SnakesSimulator snakesSimulator)
        {
            _foodPool = foodPool;
            _foodSimulator = foodSimulator;
            _cameraFactory = cameraFactory;
            _snakesSimulator = snakesSimulator;

            _foodPool.FoodIsOver += _foodSimulator.CreateFood;
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