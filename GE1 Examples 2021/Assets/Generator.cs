using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject dodecha;
    public float radius = 1.1f;
    public int points = 6;
    public int cycles = 10;
    void Start()
    {
        for (int j = 0 ; j < cycles; j ++)
        {
            float theta  = (Mathf.PI * 2.0f) / (float) points;
            for (int i = 0 ; i < points ; i ++)
            {
                float angle = theta * i;
                Vector3 position = new Vector3(
                    Mathf.Sin(angle) * radius,
                    Mathf.Cos(angle) * radius,
                    0
                );
                Debug.Log(position);
                GameObject obj = GameObject.Instantiate(dodecha, position, Quaternion.identity);
                obj.transform.parent = transform;
            }

            radius += 1.1f;
            points += 6;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
