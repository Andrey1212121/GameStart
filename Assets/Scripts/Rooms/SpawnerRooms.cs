using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRooms : MonoBehaviour
{
    public Direction direction;
    public enum Direction{
        Top,
        Bottom,
        Left,
        Right,
        startRoom,
        None,
    }

    private RoomVariants variants;
    private int rand;
    private bool spawned = false;
    private float waitTime = 3f;
   

    private void Start() {
        
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.2f);
    
    }

    public void Spawn(){
        Debug.Log("spawn");
        if (!spawned){
            switch(direction){
                case Direction.Top:
                    rand = Random.Range(0, variants.topRooms.Length);
                    Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
                    break;
                case Direction.Bottom:
                     rand = Random.Range(0, variants.dawnRooms.Length);
                    Instantiate(variants.dawnRooms[rand], transform.position, variants.dawnRooms[rand].transform.rotation);
                    break;
                case Direction.Left:
                    rand = Random.Range(0, variants.leftRooms.Length);
                    Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
                    break;
                case Direction.Right:
                     rand = Random.Range(0, variants.rightRooms.Length);
                    Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
                    break;
                case Direction.startRoom:
                Instantiate(variants.startRoom, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            }
         
            
        }
        //Destroy(gameObject, waitTime);
        spawned = true;
    }

    //
    private void OnTriggerEnter(Collider other) {
        Debug.Log("ggg");
        //if (other == null) return; // Проверка на null для other
        //SpawnerRooms spawnerRooms = other.GetComponent<SpawnerRooms>();
        if (other.CompareTag("RoomPoint") && other.GetComponent<SpawnerRooms>().spawned) {
            Debug.Log(gameObject);
            Destroy(gameObject);
            }
        }
        
    }

