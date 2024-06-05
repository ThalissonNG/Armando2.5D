using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiEnemys : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _NavMeshAgent;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform CurrentPoint;
    [SerializeField] private Transform Point1;
    [SerializeField] private Transform Point2;

    [SerializeField] private bool IsFollow;

    void Start()
    {
        CurrentPoint = Point2;
        _NavMeshAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Debug.Log("Current Point: " + CurrentPoint.name);
        FollowPlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsFollow = true;
        }
        else if (other.CompareTag("Point1"))
        {
            Debug.Log("colidiu");
            CurrentPoint = Point2;
        }
        else if (other.CompareTag("point2"))
        {
            CurrentPoint = Point1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsFollow = false;
        }
    }
    private void FollowPlayer()
    {
        if (IsFollow)
        {
            _NavMeshAgent.SetDestination(Player.position);
        }
        else
        {
            _NavMeshAgent.SetDestination(CurrentPoint.position);
        }
    }
}
