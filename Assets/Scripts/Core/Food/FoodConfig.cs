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
        public FoodView FoodViewPrefab { get; private set; }
    }
}