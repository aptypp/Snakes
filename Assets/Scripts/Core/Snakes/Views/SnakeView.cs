using System;
using Core.Food.Views;
using UnityEngine;

namespace Core.Snakes.Views
{
    public class SnakeView : MonoBehaviour
    {
        public event Action<FoodView> AteFood;

        private void OnTriggerEnter(
            Collider other)
        {
            if (!other.TryGetComponent(out FoodView foodView)) return;

            AteFood?.Invoke(foodView);
        }
    }
}