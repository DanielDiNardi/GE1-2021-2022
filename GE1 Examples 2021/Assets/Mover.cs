using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Mover : MonoBehaviour
{
    private static StringBuilder message = new StringBuilder();

    public float speed = 5f;

    public float time = 10f;

    public Transform target;

    public void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "" + message);
        if (Event.current.type == EventType.Repaint)
        {
            message.Length = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        Vector3 toTarget = target.position - transform.position;
        float distance1 = toTarget.magnitude;
        toTarget = Vector3.Normalize(toTarget);

        // if(distance1 > 0.1f){
        //     toTarget = Vector3.Normalize(toTarget);
        //     // transform.position = transform.position + (toTarget * speed * Time.deltaTime);
        //     transform.position = transform.position + (toTarget * (distance1 / time) * Time.deltaTime);
        // }
        // message.Append(Time.timeSinceLevelLoad);

        // transform.LookAt(target);
        // transform.Translate(0, 0, speed * Time.deltaTime);

        float dot = Vector3.Dot(transform.forward, toTarget);
        float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;
        // Debug.Log(theta);
        // Debug.Log((dot > 0) ? "in front" : "behind");
        if(theta < 45){
            Debug.Log("in FOV");
        }
        else{
            Debug.Log("outside FOV");
        }

        float angle1 = Vector3.Angle(toTarget, transform.forward);

        float angle3 = Vector3.SignedAngle(toTarget, transform.forward, Vector3.up);

    }
}
