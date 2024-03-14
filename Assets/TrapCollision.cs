using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other) {

        

        if (!other.gameObject.CompareTag("Player")){ 
                Debug.Log("WrongTag");
            }


        
        other.GetComponent<StatManager>().DoDamage();
    }







}
