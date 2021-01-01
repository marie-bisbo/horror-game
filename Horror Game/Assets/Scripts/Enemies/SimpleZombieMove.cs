using UnityEngine;
using UnityEngine.AI;

public class SimpleZombieMove : MonoBehaviour
{

    public GameObject destination;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(destination.transform.position);
    }
}
