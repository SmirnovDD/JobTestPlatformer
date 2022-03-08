using System;

namespace JobTest.Time
{
    public interface IGameTime
    {
        float DeltaTime { get; }
        void TogglePause(bool force = false, bool forceValue = false);
        event Action<bool> OnPauseToggle;
    }
}