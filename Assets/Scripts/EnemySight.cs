using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public float fieldOfView = 100f;
    public bool playerInSight = false;
    public Vector3 playerLastSight;
    public Vector3 resetPos = Vector3.back;

    private BoxCollider col;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerLastSight = resetPos;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
            Vector3 dir = other.transform.position - transform.position;
            float angle = Vector3.Angle(dir, transform.forward);
            if(angle < fieldOfView * 0.5)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position + transform.up,dir.normalized,out hit, col.size.z))
                {
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        playerLastSight = player.transform.position;
                        Debug.Log("Find Player");
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
