using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Globalization;

public class gameManager : MonoBehaviour
{
    public static int Catched , missing, playerSpeed , chances = 10, reviewd , toCompleatelevel = 20 ,reviwerOpenedin = 25 , score;
    public static float waitTime = 1.7f;
    public static List<String> sc = new List<string>();
    public static List<int> sci = new List<int>();

    string[] tempnames = new string[]{"Hamed" , "Akbar" , "Creed" , "Thomas" , "Martin"};
    string[] tempCountries = new string[]{"Morocco" , "Pakistan" , "England" , "United State" , "German"};
    int[] tempscores = new int[]{2850 , 2060 ,1140 , 930 , 590};
    public static string countryName , playerName;

    
    public static bool GotHighScre = false ;
   

    string myplayer;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        
        //PlayerPrefs.DeleteAll ( );
        reviewd = PlayerPrefs.GetInt ( "rev",0 );
        RefeshingLists ( );
        settingCountry ( );
        playerName = PlayerPrefs.GetString ( "playerName","Your Name" );

     }

    // Update is called once per frame
    void Update()
    {
    }


    public static void gameover ( )
        {
        SceneManager.LoadScene (1);
        }

    public void pausegame ( ) => Time.timeScale = 0;


    public void RefeshingLists ( )
        {

        sc.Clear ( );
        sci.Clear ( );
        for (int i = 0 ; i < 5 ; i++)
            {
            myplayer = PlayerPrefs.GetString ( $"sc{i}",$"{tempnames [ i ]} From {tempCountries [ i ]}" );
            sc.Add ( myplayer );
            }

        for (int i = 0 ; i < 5 ; i++)
            {
            num = PlayerPrefs.GetInt ( $"sci{i}",tempscores [ i ] );
            sci.Add ( num );
            }
        }

    void settingCountry ( )
        {
        countryName = PlayerPrefs.GetString ( "countryName","Your Country" );
        if (countryName == "Your Country")
            {
            try
                {
                string country = RegionInfo.CurrentRegion.EnglishName;

                }
            catch (Exception e)
                {
                string error = e.Message;
                countryName = "Your Country";
                }
            }
        }


    public static void SettingHighScres ()
        {
        gameManager.score = gameManager.Catched * 10;
        int replaseIndex = 0;
        if (score > sci [ 4 ]) { 
            GotHighScre = true;
            
            foreach (int i in sci)
                {
                if (i < score)
                    {
                    replaseIndex = sci.IndexOf ( i );
                    break;
                    }
                }

            sci.Insert ( replaseIndex,score );
            sc.Insert ( replaseIndex,$"{gameManager.playerName} From {gameManager.countryName}" );
            for (int i = 0 ; i < 5 ; i++)
                {
                PlayerPrefs.SetString ( $"sc{i}",$"{sc[i]}" );
                
                }

            for (int i = 0 ; i < 5 ; i++)
                {
                PlayerPrefs.SetInt ( $"sci{i}",sci[ i ] );
                
                }

            }
        }

    }

