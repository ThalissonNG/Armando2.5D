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
        UpdateTimer();
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
    private void UpdateTimer()
    {
        if (IsFollow)
        {
            CurrentTimer -= Time.deltaTime;
            if (CurrentTimer <= 0)
            {
                _PlayerControl.Life = 0;
            }
        }
        else
        {
            CurrentTimer = StartTimer;
        }
    }
    private void FollowPlayer()
    {
        if (IsFollow)
        {
            _NavMeshAgent.SetDestination(Player.position);
            _NavMeshAgent.stoppingDistance = 2;
            _NavMeshAgent.speed = 10;
        }
        else
        {
            _NavMeshAgent.SetDestination(CurrentPoint.position);
            _NavMeshAgent.stoppingDistance = 0;
            _NavMeshAgent.speed = 2;
        }
    }
}