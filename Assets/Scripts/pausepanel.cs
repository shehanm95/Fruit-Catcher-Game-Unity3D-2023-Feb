using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class pausepanel : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI speedText;
    int temp;
    [SerializeField] GameObject backmusic;
    // Start is called before the first frame update
    void Start()
    {
        temp = gameManager.playerSpeed;
        print ( temp );
        slider.value = gameManager.playerSpeed;
        speedText.text = $"Speed : {gameManager.playerSpeed}";

        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeValue ( )
        {
       gameManager.playerSpeed= (int)slider.value  ;
        speedText.text = $"Speed : {gameManager.playerSpeed}";

        }

    public void resume ( )
        {
        Time.timeScale = 1;
        if (gameManager.playerSpeed != slider.value)
            {
            PlayerPrefs.SetInt ( "playerSpeed",( int )slider.value );
            gameManager.playerSpeed = ( int )slider.value;
            }
            this.gameObject.SetActive ( false );

        }
    public void exit ( )
        {
        Application.Quit ( );
        }

    public void MoreGames ( ) => Application.OpenURL ( "https://play.google.com/store/apps/dev?id=4845380326082321253&hl=en_US&gl=US" );


    private void OnEnable ( )=>backmusic.SetActive ( false );
        

    private void OnDisable ( )=> backmusic.SetActive ( true );
       
    }
