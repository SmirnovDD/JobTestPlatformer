using JobTest.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace JobTest.Misc
{
    public class Door : MonoBehaviour
    {
        private IWindowManager _windowManager;

        [Inject]
        public void Init(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player.Player>();
            if (player)
                SceneManager.LoadScene(0); //for this test only
        }
    }
}