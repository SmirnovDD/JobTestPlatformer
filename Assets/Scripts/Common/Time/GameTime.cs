using System;

namespace JobTest.Time
{
    public class GameTime : IGameTime
    {
        public float DeltaTime => _isPaused ? 0 : UnityEngine.Time.deltaTime;
        private bool _isPaused;
        public event Action<bool> OnPauseToggle;
        
        public void TogglePause(bool force = false, bool forceValue = false)
        {
            if (!force)
                _isPaused = !_isPaused;
            else
                _isPaused = forceValue;
            
            OnPauseToggle?.Invoke(_isPaused);
        }

    }
}