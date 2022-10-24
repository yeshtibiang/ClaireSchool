using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KayaScript : MonoBehaviour
{
    private NavMeshAgent kayaAgent;
    private Transform target;
    private Animator kayaAnimator;
    private AudioSource kayaAudioSource;
    
    // pour gérer les distance pour les mouvements
    [SerializeField] private float idleDistance = 10f, walkDistance = 7f, attackDistance = 1f;
    
    // pour les dégat de coup
    [SerializeField] private AudioClip sndClaireHurt, sndPop;
    public float kayaDamage = 10f;
    public ProgressBar pbHealth;
    
    // particule
    private GameObject particule;
    
    // Start is called before the first frame update
    void Start()
    {
        kayaAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        kayaAnimator = GetComponent<Animator>();
        kayaAudioSource = GetComponent<AudioSource>();
        particule = transform.Find("explode").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (kayaAgent.remainingDistance > walkDistance)
        {
            kayaAgent.speed = 0;
            kayaAnimator.SetBool("walk", false);
            kayaAnimator.SetBool("attack", false);
            // idle
            if (kayaAgent.remainingDistance > idleDistance)
            {
                kayaAnimator.SetBool("idle", false);
            }
            else
            {
                kayaAnimator.SetBool("idle", true);
            }
        }
        else
        {
            kayaAgent.speed = 1f;
            kayaAnimator.SetBool("walk", true);
            kayaAnimator.SetBool("attack", false);
            kayaAnimator.SetBool("idle", true);
            // attack
            if (kayaAgent.remainingDistance <= attackDistance)
            {
                //kayaAnimator.SetBool("walk", false);
                kayaAnimator.SetBool("attack", true);
                kayaAgent.speed = 0;
            }
        }
        
        kayaAgent.SetDestination(target.position);
    }
    
    // pour les damages
    public void DamageToClaire()
    {
        // decrementer la progressbar
        pbHealth.Val -= kayaDamage;
        kayaAudioSource.PlayOneShot(sndClaireHurt);

        if (pbHealth.Val == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ClaireController>().ClaireDead();
            
            // tableau contenant les kaya
            GameObject[] kayas = GameObject.FindGameObjectsWithTag("kaya");

            foreach (var kaya in kayas)
            {
                kaya.GetComponent<KayaScript>().enabled = false;
                kayaAnimator.SetBool("walk", false);
                kaya.GetComponent<Animator>().SetBool("attack", false);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            particule.SetActive(true);
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            kayaAudioSource.PlayOneShot(sndPop);
            Destroy(gameObject, sndPop.length);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            kayaAnimator.SetBool("attack", true);
            kayaAnimator.SetBool("walk", false);
            kayaAgent.speed = 0;
        }
    }

    /*float DBetweenPlayerEnemy()
    {
        float distance = 0;
        // distance en vector 3 ou float
    }*/
}
