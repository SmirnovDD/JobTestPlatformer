using UnityEngine;

namespace JobTest.Killable
{
    public class DeathWall : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var killable = other.GetComponent<IKillable>();
            if (killable != null)
                killable.Kill();
        }
    }
}