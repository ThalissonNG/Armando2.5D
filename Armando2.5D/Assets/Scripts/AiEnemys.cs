using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiEnemys : MonoBehaviour
{
    #region Variables
    [SerializeField] private NavMeshAgent _NavMeshAgent;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform CurrentPoint;
    [SerializeField] private Transform Point1;
    [SerializeField] private Transform Point2;

    [SerializeField] public bool IsFollow;
    private float StartTimer = 2;
    [SerializeField] private float CurrentTimer;

    [SerializeField] private PlayerControl _PlayerControl;
    #endregion

    void Start()
    {
        CurrentTimer = StartTimer;
        CurrentPoint = Point2;
        _NavMeshAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        FollowPlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point1"))
        {
            CurrentPoint = Point2;
        }
        else if (other.CompareTag("Point2"))
        {
            CurrentPoint = Point1;
        }
    }
    private void FollowPlayer()
    {
        if (IsFollow)
        {
            _PlayerControl.Life = 0;
        }
        else
        {
            _NavMeshAgent.SetDestination(CurrentPoint.position);
        }
    }
}