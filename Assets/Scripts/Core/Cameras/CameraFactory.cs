using UnityEngine;
using VContainer;

namespace Core.Cameras
{
    public class CameraFactory
    {
        private readonly CameraConfig _cameraConfig;

        [Inject]
        public CameraFactory(
            CameraConfig cameraConfig)
        {
            _cameraConfig = cameraConfig;
        }

        public CameraView Create()
        {
            return Object.Instantiate(_cameraConfig.CameraViewPrefab);
        }
    }
}