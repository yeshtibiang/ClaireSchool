using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Pause : MonoBehaviour
{

    private Image imPause;
    [SerializeField] private bool onPause = false;

    [SerializeField] private AudioClip sndPause, sndUnPause;
    
    void Awake()
    {
        // on récupère l'image de notre pause
        imPause = transform.Find("ImPause").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onPause = !onPause;
            if (onPause)
            {
                GetComponent<AudioSource>().PlayOneShot(sndPause);
                imPause.enabled = true;
                Time.timeScale = 0;
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(sndUnPause);
                imPause.enabled = false;
                Time.timeScale = 1;
            }
        }
    }
}
