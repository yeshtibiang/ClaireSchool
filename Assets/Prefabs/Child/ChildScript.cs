using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChildScript : MonoBehaviour
{

    private GameObject particle;
    private NavMeshAgent agentChild;
    private Animator animatorChild;
    private bool inCage = true;
    
    // target de l'enfant. 
    [SerializeField] private Transform target;
    private AudioSource audioSourcChild;
    // transform du player
    [SerializeField] private AudioClip sndExplosion;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        particle = transform.Find("Particle").gameObject;
        agentChild = GetComponentInChildren<NavMeshAgent>();
        animatorChild = GetComponentInChildren<Animator>();
        audioSourcChild = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inCage)
        {
            agentChild.SetDestination(player.position);
            agentChild.speed = 0f;
        }
        else
        {
            animatorChild.SetBool("run", true);
            agentChild.SetDestination(target.position);
            agentChild.speed = 5f;
            
            // pour arrêter l'enfant quand il arrive à destination
            if (agentChild.remainingDistance <= agentChild.stoppingDistance)
            {
                // on arrête l'agent
                agentChild.isStopped = true;
                //agentChild.speed = 0;
                animatorChild.SetBool("run", false);
                agentChild.transform.rotation = target.rotation;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            inCage = false;
            // on détruit la cage
            audioSourcChild.PlayOneShot(sndExplosion);
            particle.SetActive(true);
            Destroy(transform.Find("Cage").gameObject);
            // desactiver le collider sur le child
            GetComponent<BoxCollider>().enabled = false;
            
            // ajouter le sprite dans le slot
            GameObject.Find("GameManager").GetComponent<UIslot>().insertChildInSlot();
        }
    }
}
