using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIslot : MonoBehaviour
{

    [SerializeField] private Sprite slotWithChild;
    [SerializeField] private Image[] slots;

    [SerializeField] private GameObject EndPointParticle;

    public bool slotComplete = false;
    
    // int pour gérer le numéro des slots
    private int i = 0;

    public void insertChildInSlot()
    {
        slots[i].GetComponent<Image>().sprite = slotWithChild;
        i++;
        i = Mathf.Clamp(i, 0, 3);


        if (i == slots.Length)
        {
            slotComplete = true;
            EndPointParticle.SetActive(true);
        } 
    }
    
    // TODO: tester les slotas avec quatre joueurs pour voir le comportement. 

    private void Awake()
    {
        // on desactive à l'awake pour éviter de le désactiver lorque le jeu n'est pas encore lancé car on ne peut pas le retrouver
        EndPointParticle = GameObject.Find("ExitPoint");
        EndPointParticle.SetActive(false);
    }
}
