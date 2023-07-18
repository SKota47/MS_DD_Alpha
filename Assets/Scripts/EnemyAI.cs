using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public float patrolSpeed = 3f;
    public float patrolWaitTime = 0.5f;
    public Transform patrolWayPoints;

    private NavMeshAgent agent;
    private float patrolTimer = 0f;
    private int wayPointIndex = 0;

    public float chaseSpeed = 6f;
    public float chaseWaitTime = 5f;
    private float chaseTimer = 0f;
    public float sqrPlayerDistance = 4f;
    private bool chase = false;

    public float shootRotSpeed = 4f;
    public float shootFreezeTime = 2f;
    private float shootTimer = 0f;

    private EnemySight enemySight;
    private Transform player;

    public Rigidbody bullet;

    public EnemyHPScript EnemyHP;
    private float EnemyHpSave;

    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemySight = transform.Find("EnemySight").GetComponent<EnemySight>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyHP = GetComponent<EnemyHPScript>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(EnemyHP._currentHP < EnemyHpSave)
        //{
        //    chase = true;
        //}
        if (enemySight.playerInSight)
        {
            Shooting();
            chase = true;
        }
        else if (chase)
        {
            Chasing();
        }
        else
        {
            Patrolling();
        }
        //EnemyHpSave = EnemyHP._currentHP;
    }
    void Shooting()
    {
        _animator.SetBool("isWalk", false);
        Vector3 lookPos = player.position;
        lookPos.y = transform.position.y;

        Vector3 targetDir = lookPos - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDir), Mathf.Min(1f, Time.deltaTime * shootRotSpeed));
        agent.isStopped = true;
        if (Vector3.Angle(transform.forward, targetDir) < 2)
        {
            if (shootTimer > shootFreezeTime)
            {
                Instantiate(bullet, transform.position, Quaternion.LookRotation(player.position - transform.position));
                shootTimer = 0f;
                _animator.SetBool("isAttack", true);
            }
            else _animator.SetBool("isAttack", false);
            shootTimer += Time.deltaTime;
        }
    }
    void Chasing()
    {
        _animator.SetBool("isWalk", true);
        agent.isStopped = false;
        Vector3 sightDeltPos = enemySight.playerLastSight - transform.position;
        if (sightDeltPos.sqrMagnitude > sqrPlayerDistance)
            agent.destination = enemySight.playerLastSight;
        agent.speed = chaseSpeed;
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            chaseTimer += Time.deltaTime;
            if (chaseTimer > chaseWaitTime)
            {
                chase = false;
                chaseTimer = 0f;
            }
        }
        else
            chaseTimer = 0f;
    }
    void Patrolling()
    {
        _animator.SetBool("isWalk", true);
        agent.isStopped = false;
        agent.speed = patrolSpeed;
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;
            if (patrolTimer > patrolWaitTime)
            {
                if (wayPointIndex == patrolWayPoints.childCount - 1)
                    wayPointIndex = 0;
                else
                    wayPointIndex++;
                patrolTimer = 0;
            }
        }
        else
            patrolTimer = 0;
        agent.destination = patrolWayPoints.GetChild(wayPointIndex).position;
    }
}
