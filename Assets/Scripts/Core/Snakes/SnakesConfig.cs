using Core.Snakes.Views;
using UnityEngine;

namespace Core.Snakes
{
    [CreateAssetMenu(
        fileName = nameof(SnakesConfig),
        menuName = "Game/Configs/" + nameof(SnakesConfig))]
    public class SnakesConfig : ScriptableObject
    {
        [field: SerializeField]
        public SnakeView SnakeViewPrefab { get; private set; }
    }
}