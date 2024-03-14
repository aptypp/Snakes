using UnityEngine;

namespace Core.Cameras
{
    [CreateAssetMenu(
        fileName = nameof(CameraConfig),
        menuName = "Game/Configs/" + nameof(CameraConfig))]
    public class CameraConfig : ScriptableObject
    {
        [field: SerializeField]
        public CameraView CameraViewPrefab { get; private set; }
    }
}