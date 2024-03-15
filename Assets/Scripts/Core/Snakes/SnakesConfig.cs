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
        public int SnakesCount { get; private set; }

        [field: SerializeField]
        public float MoveSpeed { get; private set; }

        [field: SerializeField]
        public float MoveSmoothDelta { get; private set; }

        [field: SerializeField]
        public float RotationSmoothDelta { get; private set; }

        [field: SerializeField]
        public Vector2 MinSpawnPosition { get; private set; }

        [field: SerializeField]
        public Vector2 MaxSpawnPosition { get; private set; }

        [field: SerializeField]
        public SnakeView SnakeViewPrefab { get; private set; }
    }
}