using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPoint : MonoBehaviour
{
    // reference pour le text dans l'info point
    [TextArea]
    public string TxtInfoPoint;

    [SerializeField] private Text txt;

    // reference du panel
    [SerializeField] private GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {
        txt.text = TxtInfoPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }
}
