using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    
    // reference au pb de food
    [SerializeField] private ProgressBar pb;

    [SerializeField] private int itemVal = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            pb.Val += itemVal;
            audioSource.Play();
            StartCoroutine(DestroyItem());

        }
    }

    IEnumerator DestroyItem()
    {
        // desactivons le rigidbody (en rendant l'objet isKenematic) et le collider
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
