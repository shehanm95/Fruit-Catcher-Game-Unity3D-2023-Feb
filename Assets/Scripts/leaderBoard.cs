using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class leaderBoard: MonoBehaviour
    {

    string finalText;
    public TextMeshProUGUI scoreDetails , logMessage , playerScoreText;
    [SerializeField] float LogMessagePopUpInterval;
    [SerializeField] Color[] messageColors;
    bool presed = false;
    [SerializeField] GameObject winMusic , lostMusic;
    // Start is called before the first frame update
    void Start ( )
        {
        
        //print ( gameManager.sci [ 0 ] );

        if (gameManager.GotHighScre)
            {
            StartCoroutine ( displySocreMessage ( ) );
            winMusic.SetActive ( true );
            }
        else
            {
            lostMusic.SetActive ( true );
            }
        finalText = $"1. {gameManager.sci [ 0 ]} From {gameManager.sc [ 0 ]}. \n2. {gameManager.sci [ 1 ]} From {gameManager.sc [ 1 ]}.\n3. {gameManager.sci [ 2 ]} From {gameManager.sc [ 2 ]}.\n4. {gameManager.sci [ 3 ]} From {gameManager.sc [ 3 ]}.\n5. {gameManager.sci [ 4 ]} From {gameManager.sc [ 4 ]}.";
        scoreDetails.text = finalText;

        playerScoreText.text = $"Your Score Is,\n{gameManager.score}";



        }

    // Update is called once per frame
    void Update ( )
        {

        }

    public void goToGame ( ) {
        presed = true;
        SceneManager.LoadScene ( "game" );
        }
    public void goToleaderboard ( ) => SceneManager.LoadScene ( "leaderboard" );

    IEnumerator displySocreMessage ( )
     {
        while (presed == false)
            {
            yield return new WaitForSeconds ( LogMessagePopUpInterval );
            logMessage.text = "Your Name Is Getting High in The Leader Bord";
            logMessage.color = messageColors [ Random.Range ( 0,messageColors.Length - 1 ) ];
            yield return new WaitForSeconds ( LogMessagePopUpInterval );
            }
     }

    }
