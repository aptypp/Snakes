using Core.EntryPoints;
using Core.Snakes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Scopes
{
    public class SceneScope : LifetimeScope
    {
        [SerializeField]
        private SnakesParent _snakesParent;

        protected override void Configure(
            IContainerBuilder builder)
        {
            builder.RegisterInstance(_snakesParent);

            builder.Register<SnakeFactory>(Lifetime.Singleton);

            builder.RegisterEntryPoint<MainSceneEntryPoint>();
        }
    }
}