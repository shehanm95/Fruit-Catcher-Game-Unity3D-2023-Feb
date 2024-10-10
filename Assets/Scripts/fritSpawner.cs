using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fritSpawner : MonoBehaviour
{
    public GameObject[] fruites;
    public float MaxXpos , starttime;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
        invoker ( );
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void invoker ( )
        {
        CancelInvoke ( );
        InvokeRepeating ( "spawnFruit",starttime,gameManager.waitTime );
        }


    public void spawnFruit ( )
        {
        
        int fruitindex = Random.Range(0, fruites.Length);
        Instantiate ( fruites [ fruitindex ],new Vector3 ( Random.Range ( -MaxXpos,MaxXpos ),transform.position.y,0 ),Quaternion.identity );
        
        }
}
