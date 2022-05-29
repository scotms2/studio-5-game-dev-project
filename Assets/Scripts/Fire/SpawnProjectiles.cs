using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Invector.vCharacterController
{
    public class SpawnProjectiles : MonoBehaviour
    {
        [HideInInspector] public vThirdPersonController cc;
        public GameObject firePoint;
        public List<GameObject> vfx = new List<GameObject>();
        public RotateToMouse rotateToMouse;
        public float timeBetweenFires;

        private GameObject effectToSpawn;
        // Start is called before the first frame update
        void Start()
        {
            effectToSpawn = vfx[0];

            cc = transform.root.GetComponent<vThirdPersonController>();

            //if (cc != null)
            //  cc.Init();
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                //SpawnVFX();
                StartCoroutine(FireRoutine());
                cc.Punch(true);
            }
            else
            {
                cc.Punch(false);
            }

        }

        public void SpawnVFX()
        {
            GameObject vfx;

            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if (rotateToMouse != null)
            {
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }

        }
        public void Fire(bool val)
        {
            if (val == true)
            {
                SpawnVFX();
                Debug.Log("aaaaaaaaaa");
            }
        }

        public IEnumerator FireRoutine()
        {

            if (firePoint != null)
            {
                SpawnVFX();
            }
            else
            {
                Debug.Log("No Fire Point");
            }

            yield return new WaitForSeconds(timeBetweenFires);
        }
    }
}


