using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edge : MonoBehaviour
    {

    GameObject player;
    // Start is called before the first frame update
    void Start ( )
        {
        player = GameObject.Find ( "player" );
        }

    // Update is called once per frame
    void Update ( )
        {
        transform.position = player.transform.position;
        }

    
       
    }

