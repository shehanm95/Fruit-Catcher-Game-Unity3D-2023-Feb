using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class catcher : MonoBehaviour
{
    
    public TextMeshProUGUI chancesText , gameOver , youWin;
    public GameObject backSound;
    bool gameOverbool = false;
    // Start is called before the first frame update
    void Start()
    {
        chancesText.text = $"Chances: {gameManager.chances}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D ( Collider2D collision )
        {

        if (gameOverbool == false)
            {

            if (collision.gameObject.tag == "fruit")
                {
                SoundManager.SoundPlay ( Sound.missed );
                gameManager.chances--;
                Destroy ( collision.gameObject,3f );
                collision.gameObject.layer = 6;
                collision.gameObject.tag = "fall";
                }

            if (gameManager.chances == 0)
                {
                gameOverbool = true;
                GameObject.Find ( "player" ).GetComponent<player> ( ).enabled = false;
                Destroy ( GameObject.Find ( "fruitSpawner" ) );
                if (gameManager.chances >= 0) chancesText.text = $"Chances: {gameManager.chances}";
                gameManager.SettingHighScres ( );

                backSound.SetActive ( false );

                if (!gameManager.GotHighScre)
                    {
                    SoundManager.SoundPlay ( Sound.lost );
                    gameOver.gameObject.SetActive ( true );
                    StartCoroutine ( gameover ( 5f ) );
                    }
                else
                    {
                    SoundManager.SoundPlay ( Sound.win );
                    youWin.gameObject.SetActive ( true );
                    StartCoroutine ( gameover ( 9f ) );
                    }

                Destroy ( GameObject.Find ( "fruitSpawner" ) );
                GameObject[] fruits = GameObject.FindGameObjectsWithTag("fruit");
                foreach (GameObject obj in fruits)
                    {
                    Destroy ( collision.gameObject );

                    }
                }
            else
                {
                if (gameManager.chances >= 0) chancesText.text = $"Chances: {gameManager.chances}";
                }

            }
        }


     IEnumerator gameover ( float waitTime )
        {
        yield return new WaitForSeconds ( waitTime );
        GoogleAdMobController.Instance.ShowInterstitialAd ( );
        gameManager.gameover ( );
        } 


    }



