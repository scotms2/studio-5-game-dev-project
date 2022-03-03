using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    [SerializeField] private Vector3 movementSpeed;

    [SerializeField] private Space space;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
     }
}
