using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MeshController : MonoBehaviour
{

    public GameObject Target;
    private NavMeshAgent agent;

    bool isWalking = true;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking)
        {
            agent.destination = Target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        }



        

}
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Dragon")
        {
            isWalking = false;
            animator.SetTrigger("Attacking");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("Walking");
        }
    }
}
