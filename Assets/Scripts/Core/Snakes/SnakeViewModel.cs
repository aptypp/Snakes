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

        public void MoveViewSmoothly()
        {
            View.transform.position = Vector3.Lerp(
                View.transform.position,
                Model.TargetPosition,
                Model.MoveSmoothDelta * Time.deltaTime);
        }

        public void RotateViewSmoothly()
        {
            View.transform.rotation = Quaternion.Lerp(
                View.transform.rotation,
                Model.TargetRotation,
                Model.RotationSmoothDelta * Time.deltaTime);
        }

        public void MoveTailsSmoothly()
        {
            void MoveTailSmoothly(
                    TailView tailView,
                    Vector3 from,
                    Vector3 to)
            {
                tailView.transform.position = Vector3.Lerp(
                    from,
                    to,
                    Model.MoveSmoothDelta * Time.deltaTime);
            }

            for (var tailIndex = Model.Tails.Count - 1; tailIndex >= 0; tailIndex--)
            {
                var currentTail = Model.Tails[tailIndex];

                if (tailIndex == 0)
                {
                    MoveTailSmoothly(
                        currentTail,
                        currentTail.transform.position,
                        View.transform.position);

                    continue;
                }

                var nextTail = Model.Tails[tailIndex - 1];

                MoveTailSmoothly(
                    currentTail,
                    currentTail.transform.position,
                    nextTail.transform.position);
            }
        }
    }
}