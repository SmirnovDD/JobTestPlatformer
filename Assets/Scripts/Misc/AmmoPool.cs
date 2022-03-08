using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace JobTest.Ammo
{
    public class AmmoPool
    {
        private ObjectPool<GameObject> _pool;
        
        public AmmoPool()
        {
            GameObject CreateFunc()
            {
                var playerAmmo = Object.Instantiate(Resources.Load<PlayerAmmo>("PlayerAmmo"));
                playerAmmo.SetPool(_pool);
                return  playerAmmo.gameObject;
            }

            void OnGet(GameObject gameObject) => gameObject.SetActive(true);
            void OnRelease(GameObject gameObject) => gameObject.SetActive(false);
            
            
            _pool = new(CreateFunc, OnGet, OnRelease, Object.Destroy, false, 10, 10);
        }

        public GameObject GetAmmo()
        {
            return _pool.Get();
        }
    }
}