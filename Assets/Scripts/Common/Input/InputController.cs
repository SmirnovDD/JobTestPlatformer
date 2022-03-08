namespace JobTest.Input
{
    public class InputController : IInputController
    {
        public InputControls InputControls
        {
            get
            {
                if (!_initialized)
                    Init();
                return _inputControls;
            }
        }
        
        private InputControls _inputControls;
        private bool _initialized;


        private void Init()
        {
            _inputControls = new InputControls();
            _inputControls.Gameplay.Enable();
            _inputControls.UI.Enable();
            
            _initialized = true;
        }
    }
}