using Core.Cameras;
using Core.Food;
using Core.Snakes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Scopes
{
    public class ProjectScope : LifetimeScope
    {
        [SerializeField]
        private FoodConfig _foodConfig;

        [SerializeField]
        private SnakesConfig _snakesConfig;

        [SerializeField]
        private CameraConfig _cameraConfig;

        protected override void Configure(
            IContainerBuilder builder)
        {
            builder.RegisterInstance(_foodConfig);
            builder.RegisterInstance(_snakesConfig);
            builder.RegisterInstance(_cameraConfig);
        }
    }
}