using Core.Snakes.Views;
using UnityEngine;

namespace Core.Snakes
{
    public class SnakeFactory
    {
        private readonly SnakesConfig _config;
        private readonly SnakesParent _snakesParent;

        public SnakeFactory(
            SnakesConfig config,
            SnakesParent snakesParent)
        {
            _config = config;
            _snakesParent = snakesParent;
        }

        public SnakeView Create()
        {
            return Object.Instantiate(_config.SnakeViewPrefab);
        }
    }
}