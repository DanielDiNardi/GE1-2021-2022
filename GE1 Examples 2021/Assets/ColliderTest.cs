using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    private bool deathTrigger = false;
    public float jumpSpeed = 25f;

    System.Collections.IEnumerator Die()
    {
        while(true)
        {
            
            if(deathTrigger == true){
                transform.GetChild(1).gameObject.GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().velocity = transform.up * jumpSpeed;

                yield return new WaitForSeconds(4);

                transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;
                transform.GetChild(2).gameObject.GetComponent<BoxCollider>().enabled = false;
                transform.GetChild(3).gameObject.GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().drag = 1;

                yield return new WaitForSeconds(1);

                Destroy(gameObject);
            }
            else{
                yield return null;
            }
        }
    }

    public void OnEnable()
    {
        StartCoroutine(Die());
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Bullet"){
            deathTrigger = true;
        }
    }
}
