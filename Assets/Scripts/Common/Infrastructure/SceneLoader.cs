using UnityEngine;
using UnityEngine.SceneManagement;

namespace JobTest.Common.Infrastructure
{
    public class SceneLoader : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene(1);
        }
    }
}