using UnityEngine;

namespace Core.Snakes.Models
{
    public class SnakeModel
    {
        public int TailsCount;
        public float MoveSpeed;
        public float RotationSmoothDelta;
        public Vector3 Position;
        public Quaternion Rotation;
    }
}