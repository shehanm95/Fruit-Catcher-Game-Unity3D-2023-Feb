using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    bool moveLeft , moveRight;
    public float maxPosition;
    public TextMeshProUGUI Score , GetReady , levelText , levelUptext ,waitTimer;
    Vector2 place;
    int level =1 , spriteNumber;
    public GameObject reviewPanel;
    List<Sprite> backs = new List<Sprite>();
    public SpriteRenderer backgeoundImage;

    // Start is called before the first frame update
    void Start()
    {
       
        gameManager.playerSpeed = PlayerPrefs.GetInt ( "playerSpeed",16 );
        gameManager.chances = 10;
        gameManager.Catched = 0;
        gameManager.waitTime = 1.9f;
        GetReady.gameObject.SetActive ( true );
        setPlace ( );
        Invoke( "readyfalser" ,2f );
        updatelevelnumText ( );
        gameManager.GotHighScre = false;
        
        for (int i = 1 ; i <= 10 ; i++)backs.Add ( Resources.Load<Sprite> ( $"b ({i})" ) );
           


    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
            {
            if (transform.position.x > -maxPosition) transform.position = transform.position + new Vector3( -gameManager.playerSpeed *Time.deltaTime,0,0 );
            else transform.position = new Vector3 ( Mathf.Clamp ( transform.position.x,-maxPosition,maxPosition ),transform.position.y,0 );

            }
        if (moveRight)
            {
            if(transform.position.x < maxPosition) transform.position = transform.position + new Vector3 ( gameManager.playerSpeed * Time.deltaTime,0,0 );
            else transform.position = new Vector3 ( Mathf.Clamp ( transform.position.x,-maxPosition,maxPosition ),transform.position.y,0 );
            }
        if(!moveLeft && !moveRight) transform.position = place;
        
        
    }

    public void onLeftDown ( ) => moveLeft = true;
    public void onRightDown ( )=> moveRight = true;
    public void onLeftUp ( )
        {
        moveLeft = false;
        setPlace ( );
        }
    public void onRightup ( )
        {
        moveRight = false;
        setPlace ( );
        }



    public void Fruitcatched ( )
        {
        SoundManager.SoundPlay (Sound.catched );
        gameManager.Catched++;
        //if (gameManager.Catched == gameManager.reviwerOpenedin && gameManager.reviewd == 0) reviewPanel.SetActive ( true );
        Score.text = $"Score : {gameManager.Catched}";
        if (gameManager.Catched % gameManager.toCompleatelevel == 0)
            {
            level++;
            spriteNumber = (level % 10);
            backgeoundImage.sprite = backs [ spriteNumber ];
            if (level < 15)gameManager.chances += 5;
            StartCoroutine ( levelup ( ) );
            updatelevelnumText ( );
            }

     }


    void setPlace ( )
        {
        place = new Vector2 ( transform.position.x,transform.position.y );
        }

    void readyfalser ( ) => GetReady.gameObject.SetActive ( false );


    IEnumerator levelup ( )
        {
        fritSpawner fr = GameObject.FindObjectOfType<fritSpawner>( );
        fr.invoker ( );
        levelUptext.gameObject.SetActive ( true );
        yield return new WaitForSeconds ( 2f );
        levelUptext.gameObject.SetActive ( false );
        gameManager.waitTime = gameManager.waitTime - 0.1f;
        waitTimer.text = $"wait : {gameManager.waitTime}";
        }

    void updatelevelnumText ( )=> levelText.text = $"Level : {level}";
        
    }