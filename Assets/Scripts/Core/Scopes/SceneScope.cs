using Core.Cameras;
using Core.EntryPoints;
using Core.Food;
using Core.Food.Views;
using Core.Simulations;
using Core.Snakes;
using Core.Snakes.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using FoodSimulator = Core.Food.FoodSimulator;

namespace Core.Scopes
{
    public class SceneScope : LifetimeScope
    {
        [SerializeField]
        private FoodParent _foodParent;

        [SerializeField]
        private SnakesParent _snakesParent;

        protected override void Configure(
            IContainerBuilder builder)
        {
            builder.RegisterInstance(_foodParent);
            builder.RegisterInstance(_snakesParent);

            builder.Register<FoodPool>(Lifetime.Singleton);

            builder.Register<FoodFactory>(Lifetime.Singleton);

            builder.Register<SnakeFactory>(Lifetime.Singleton);

            builder.Register<CameraFactory>(Lifetime.Singleton);

            builder.Register<FoodSimulator>(Lifetime.Transient);

            builder.Register<SnakesSimulator>(Lifetime.Transient);

            builder.RegisterEntryPoint<MainSceneEntryPoint>();
        }
    }
}