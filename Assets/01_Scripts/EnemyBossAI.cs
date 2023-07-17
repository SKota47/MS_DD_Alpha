using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBossAI : MonoBehaviour
{

    public float patrolSpeed = 3f;
    public float patrolWaitTime = 0.5f;
    public Transform patrolWayPoints;

    public NavMeshAgent agent;
    private float patrolTimer = 0f;
    private int wayPointIndex = 0;

    public float chaseSpeed = 6f;
    public float chaseWaitTime = 5f;
    private float chaseTimer = 0f;
    public float sqrPlayerDistance = 4f;
    private bool chase = false;

    public float shootRotSpeed = 4f;
    public float attackFreezeTime = 2f;
    private float attackTimer = 0f;
    private float attackBoxOffTimer = 0f;
    public float attackBoxOffTime = 1f;

    private EnemySight enemySight;
    private Transform player;


    public EnemyHPScript EnemyHP;
    private float EnemyHpSave;

    public GameObject _attackBox;
    [System.NonSerialized] public bool isAttack = false;

    public GameObject _menuCanvas;

    private Rigidbody _rb;
    [System.NonSerialized] public bool _isKnockback;
    private float _knockBackTime;

    private float _patrolSpeedSave;
    private float _chaseSpeedSave;
    private float _shootSpeedSave;
    private float _patrolWaitSave;
    private float _chaseWaitSave;

    [System.NonSerialized] public int _isKinematicOnFrame;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemySight = transform.Find("EnemySight").GetComponent<EnemySight>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyHP = GetComponent<EnemyHPScript>();

        _patrolSpeedSave = patrolSpeed;
        _chaseSpeedSave = chaseSpeed;
        _chaseSpeedSave = shootRotSpeed;
        _patrolWaitSave = patrolWaitTime;
        _chaseWaitSave = chaseWaitTime;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(EnemyHP._currentHP < EnemyHpSave)
        //{
        //    chase = true;
        //}
        //Debug.Log(enemySight.playerInSight);

        _menuCanvas = GameObject.Find("MenuCanvas");

        if (enemySight.playerInSight)
        {
            Attacking();
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
        if (isAttack)
        {
            agent.isStopped = true;
            attackBoxOffTimer += Time.deltaTime;
        }

        if (attackBoxOffTimer > attackBoxOffTime)
        {
            _attackBox.gameObject.SetActive(false);
            isAttack = false;
        }
        //Debug.Log(_knockBackTime);

        if (_isKnockback)
        {
            _knockBackTime += Time.deltaTime;
            //patrolSpeed = 0;
            //chaseSpeed = 0;
            //shootRotSpeed = 0;
            //chaseWaitTime = 0;
            //patrolWaitTime = 0;
        }
        if (_knockBackTime >= 1)
        {
            //patrolSpeed = _patrolSpeedSave;
            //chaseSpeed = _chaseSpeedSave;
            //shootRotSpeed = _shootSpeedSave;
            //chaseWaitTime = _chaseWaitSave;
            //patrolWaitTime = _patrolWaitSave;
            agent.enabled = true;
            //_rb.isKinematic = true;
            _isKinematicOnFrame = Time.frameCount;
            _isKnockback = false;
        }

        //EnemyHpSave = EnemyHP._currentHP;
    }
    void Attacking()
    {
        Vector3 lookPos = player.position;
        lookPos.y = transform.position.y;

        Vector3 targetDir = lookPos - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDir), Mathf.Min(1f, Time.deltaTime * shootRotSpeed));
        agent.isStopped = true;
        //Debug.Log(attackBoxOffTimer);

        if (Vector3.Angle(transform.forward, targetDir) < 2)
        {
            if (attackTimer > attackFreezeTime && !isAttack)
            {
                _attackBox.gameObject.SetActive(true);
                isAttack = true;
                attackBoxOffTimer = 0f;
                attackTimer = 0f;
            }
            // if (isAttack) { attackBoxOffTimer += Time.deltaTime; }
            //
            // if (attackBoxOffTimer > attackBoxOffTime)
            // {
            //     _attackBox.gameObject.SetActive(false);
            //     isAttack = false;
            // }
            attackTimer += Time.deltaTime;
        }

    }
    void Chasing()
    {
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
