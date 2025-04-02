using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AddRoom : MonoBehaviour
{
   [Header("Walls")]
   public GameObject walls;
   public GameObject door;

   [Header("Enemies")]
   public GameObject[] enemyTypes;
   public Transform[] enemySpawners;

   [Header("Props")]
    [SerializeField] private GameObject[] propsTypes;
   [SerializeField] private Transform[] PropsSpawners;

   [HideInInspector] public List<GameObject> enemies;

   private bool spawned;
   private bool wallsDestroyed;

   private void Start(){
    //variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
    foreach(Transform spawner in PropsSpawners){
        GameObject propsType = propsTypes[Random.Range(0, propsTypes.Length)];
        GameObject props = Instantiate(propsType, spawner.position, Quaternion.identity) as GameObject;
        props.transform.parent = transform;
    }
   }
   
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !spawned){
            spawned = true;

            foreach(Transform spawner in enemySpawners){
                GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = transform;
                enemies.Add(enemy);
            }
            StartCoroutine(CheckEnemies());
            Debug.Log("Destroy Walls");
        }
    }

    IEnumerator CheckEnemies(){
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => enemies.Count == 0);
        DestroyWalls();
       
    }
    public void DestroyWalls(){
        Debug.Log("void Destroy Walls");
          Destroy(walls);
        wallsDestroyed = true;
        
    }

 /*  private void OnTriggerStay2D(Collider2D other) {
        if (wallsDestroyed && other.CompareTag("Wall")){
            Destroy(other.gameObject);
        }
    }
   */
}
