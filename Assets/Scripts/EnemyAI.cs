using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public enum EnemyState
    {
        Patrolling,
        Chasing,
        Searching
    }

    public EnemyState currentState;

    private NavMeshAgent _AIAgent;
    [SerializeField] Transform[] _patrolPoints;


    void Awake()
    {
        _AIAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.Patrolling;
        SetRandomPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
            break;

            case EnemyState.Chasing:
                Chase();

            break;
            case EnemyState.Searching:
                Search();

            break;
        }
    }


    void Patrol()
    {
        if(_AIAgent.remainingDistance < 0.1f)
        {
            SetRandomPatrolPoint();
        }
    }

    void Chase()
    {

    }

    void Search()
    {

    }

    void SetRandomPatrolPoint()
    {
        _AIAgent.destination = _patrolPoints[Random.Range(0, _patrolPoints.Length)].position;

    }
}
