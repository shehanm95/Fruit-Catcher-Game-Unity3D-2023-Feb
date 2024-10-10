using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class reviewPanel : MonoBehaviour
{
    
    private Sprite coloredStar , blackstar;
    public GameObject log;
    public Transform starHolder;

    // Start is called before the first frame update
    void Start()
    {
        coloredStar = Resources.Load<Sprite> ( "str" );
        blackstar = Resources.Load<Sprite> ( "s-02" );
        Time.timeScale = 0;
        }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Done ( )
        {
        gameManager.reviewd = 1;
        PlayerPrefs.SetInt ( "rev",1 );
        Time.timeScale = 1;

        }

    public void ButtonClicked ( )
        {
        int num  = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
        print ( num );
        for(int i = 0 ; i < starHolder.childCount ; i++ )
            {
            if (i <= num) starHolder.GetChild(i).GetComponent<Image>( ).sprite = coloredStar;
            else starHolder.GetChild ( i ).GetComponent<Image> ( ).sprite = blackstar;
            }

        if( num == 4)Application.OpenURL ( "https://play.google.com/store/apps/dev?id=4845380326082321253&hl=en_US&gl=US" );
        log.SetActive ( true );
        }



}
