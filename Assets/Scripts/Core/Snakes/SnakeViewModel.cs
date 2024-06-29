using Core.Snakes.Models;
using Core.Snakes.Views;
using UnityEngine;

namespace Core.Snakes
{
    public class SnakeViewModel
    {
        public readonly SnakeView View;
        public readonly SnakeModel Model;

        public SnakeViewModel(
            SnakeView view,
            SnakeModel model)
        {
            View = view;
            Model = model;
        }

        public void MoveSmoothly()
        {
            View.transform.position = Vector3.Lerp(
                View.transform.position,
                Model.TargetPosition,
                Model.MoveSmoothDelta * Time.deltaTime);
        }

        public void RotateSmoothly()
        {
            View.transform.rotation = Quaternion.Lerp(
                View.transform.rotation,
                Model.TargetRotation,
                Model.RotationSmoothDelta * Time.deltaTime);
        }
    }
}