using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTankSpawner : MonoBehaviour
{
    public GameObject enemyTank;
    float min = -40;
    float max = 40;
    public int enemyCounter = 0;

    System.Collections.IEnumerator spawnEnemyTank(){

        while(true){
            if(enemyCounter < 5){
                float x = Random.Range(min, max);
                float z = Random.Range(min, max);
                GameObject newEnemyTank = Instantiate(enemyTank, new Vector3(x, transform.position.y, z), Quaternion.identity);
                enemyCounter++;
                yield return new WaitForSeconds(1);
            }
            else{
                yield return null;
            }
        }
    }

    public void OnEnable(){
        StartCoroutine(spawnEnemyTank());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCounter = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
