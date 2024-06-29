using System.Collections.Generic;
using Core.Snakes.Views;
using UnityEngine;

namespace Core.Snakes.Models
{
    public class SnakeModel
    {
        public float MoveSpeed;
        public float MoveSmoothDelta;
        public float RotationSmoothDelta;
        public Vector3 Position;
        public Quaternion Rotation;
        public List<TailView> Tails;
    }
}