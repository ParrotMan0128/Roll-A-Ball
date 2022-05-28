using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public float rotateSpeed;
    void Update()
    {
        transform.Rotate(new Vector3(0.5f, 1, 0) * rotateSpeed * Time.deltaTime);
    }
}
