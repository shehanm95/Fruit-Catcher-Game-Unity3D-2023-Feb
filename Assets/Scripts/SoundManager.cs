using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public enum Sound { win, lost, catched, missed, backMusic };

public class SoundManager: MonoBehaviour
    {
   
    // Start is called before the first frame update

    static AudioSource ac;
   
    public static AudioClip win , lost , catched , missed , backMusic;
   

    void Start()
    {
        ac = GetComponent<AudioSource> ( );

        win = Resources.Load<AudioClip> ( "sound/win" );
        lost = Resources.Load<AudioClip> ( "sound/lost" );
        catched = Resources.Load<AudioClip> ( "sound/catch" );
        missed = Resources.Load<AudioClip> ( "sound/missing" );
        backMusic = Resources.Load<AudioClip> ( "sound/backMusic" );
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SoundPlay (Sound clip)
        {
        switch (clip)
            {
            case Sound.backMusic:
                ac.PlayOneShot ( backMusic );
                break;
            case Sound.catched:
                ac.PlayOneShot ( catched );
                break;
            case Sound.lost:
                ac.PlayOneShot ( lost );
                break;
            case Sound.missed:
                ac.PlayOneShot (missed );
                break;
            case Sound.win:
                ac.PlayOneShot ( win );
                break;

            }
        }
}
