using Core.Snakes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Scopes
{
    public class ProjectScope : LifetimeScope
    {
        [SerializeField]
        private SnakesConfig _snakesConfig;

        protected override void Configure(
            IContainerBuilder builder)
        {
            builder.RegisterInstance(_snakesConfig);
        }
    }
}