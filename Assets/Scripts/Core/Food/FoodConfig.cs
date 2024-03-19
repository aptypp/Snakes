using Core.Food.Views;
using UnityEngine;

namespace Core.Food
{
    [CreateAssetMenu(
        fileName = nameof(FoodConfig),
        menuName = "Game/Configs/" + nameof(FoodConfig))]
    public class FoodConfig : ScriptableObject
    {
        [field: SerializeField]
        public int MinFoodCount { get; private set; }

        [field: SerializeField]
        public int MaxFoodCount { get; private set; }

        [field: SerializeField]
        public Vector2 MinFoodPosition { get; private set; }

        [field: SerializeField]
        public Vector2 MaxFoodPosition { get; private set; }

        [field: SerializeField]
        public FoodView FoodViewPrefab { get; private set; }
    }
}