using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ProgressBar pbHealth, pbEnergy, pbFood;
    
    // Hunger
    [SerializeField] private float decreaseFood = 1f, decreaseRate = .5f;
    
    // Energy
    [SerializeField] private float walkEnergy = 0.025f, runEnergy = 0.25f;
    private bool dead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DecreaseHunger());
    }

    // Update is called once per frame
    void Update()
    {
        // Hunger
        if (Input.GetAxis("Vertical") != 0 && !dead)
        {
            pbEnergy.Val -= walkEnergy;
            if (pbEnergy.Val == 0)
            {
                dead = true;
                CallDeathClaire();
            }
        }
        if (Input.GetAxis("Vertical") != 0 && Input.GetKey(KeyCode.LeftControl) && !dead)
        {
            pbEnergy.Val -= runEnergy;
            if (pbEnergy.Val == 0)
            {
                dead = true;
                CallDeathClaire();
            }
        }

        
        
    }

    IEnumerator DecreaseHunger()
    {
        // on diminue la valeur de pbfood à chaque decreaseRate. 
        while (pbFood.Val > 0)
        {
            pbFood.Val -= decreaseFood;
            yield return new WaitForSeconds(decreaseRate);
        }
        
        // quand pbFood est inferieur à zero on applique le dead de notre personnage. 
        CallDeathClaire();
    }

    private void CallDeathClaire()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ClaireController>().ClaireDead();
    }
    
    
}
