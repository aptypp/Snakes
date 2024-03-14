using Core.Snakes;
using VContainer.Unity;

namespace Core.EntryPoints
{
    public class MainSceneEntryPoint : IStartable
    {
        private readonly SnakeFactory _snakeFactory;

        public MainSceneEntryPoint(
            SnakeFactory snakeFactory)
        {
            _snakeFactory = snakeFactory;
        }

        public void Start()
        {
            _snakeFactory.Create();
        }
    }
}