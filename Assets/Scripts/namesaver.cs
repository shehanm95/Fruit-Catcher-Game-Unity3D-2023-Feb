using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class namesaver : MonoBehaviour
{
    
    public TextMeshProUGUI input, countryinput, logs;
    public GameObject playMusic;
    public Color werning , good;
    string namesuccess = "Your details are added Sucsessfullly.";
    string weningmessage = "Please Enter your details correctly.";
    // Start is called before the first frame update
    void Start()
    {
        if (gameManager.countryName != "Your Country") countryinput.text = gameManager.countryName;
    }
    public void Submit ( )
        {
        gameManager.playerName = input.text;
        gameManager.countryName = countryinput.text;

        if ((gameManager.playerName.Length > 3 && gameManager.playerName != "Your Name") && (gameManager.countryName.Length > 2 && gameManager.countryName != "Your Country"))
            {
            logs.color = good;
            logs.text = namesuccess;
            var namechar= gameManager.playerName.ToCharArray();
            namechar [ 0 ] = char.ToUpper ( namechar [ 0 ] );
            gameManager.playerName = namechar.ArrayToString ( );
            //print ( gameManager.playerName );
            
            PlayerPrefs.SetString ( "playerName",gameManager.playerName );

            // name sett ================================================================================================

            var countrychar= gameManager.countryName.ToCharArray();
            countrychar [ 0 ] = char.ToUpper ( countrychar [ 0 ] );
            gameManager.countryName = countrychar.ArrayToString ( );
            //print ( gameManager.playerName );
           
            PlayerPrefs.SetString ( "countryName",gameManager.countryName );

            // country set ===============================================================================================

            playMusic.SetActive ( false );
            Invoke ( "goToleaderBoard",1f );
            }
        // else wernings
        else {
            logs.color = werning;
            logs.text = weningmessage;
            
            }

        }


    void goToleaderBoard ( )
        {
        SceneManager.LoadScene ( "game" );
        }
    }
