using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainPlay : MonoBehaviour
{
    public GameObject nameSetPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainPlayButton ( )
        {
        if (gameManager.playerName == "Your Name")
            {
            nameSetPanel.SetActive ( true );
            }
        else
            {

            SceneManager.LoadScene ( "game" );
            }
        }

    public void MoreGames ( ) => Application.OpenURL ( "https://play.google.com/store/apps/dev?id=4845380326082321253&hl=en_US&gl=US" );
    }
