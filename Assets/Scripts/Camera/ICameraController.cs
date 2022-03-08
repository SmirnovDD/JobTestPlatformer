using UnityEngine;

namespace JobTest.CameraControl
{
    public interface ICameraController
    {
        Camera Camera { get; }
        Transform CameraTransform { get; }
        void SetTargetToFollow(Transform targetToFollow);
    }
}