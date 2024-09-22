using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackandFront : MonoBehaviour
{
    public float speed = 6.0f;
    public float maxZ = 5;
    public float minZ = -5;
    private int direct = 1;



    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, direct * speed * Time.deltaTime);
        bool bounce = false;
        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            direct = -direct;
            bounce = true;
        }
        if (bounce)
        {
            transform.Translate(0, 0, direct * speed * Time.deltaTime);

        }
    }
}