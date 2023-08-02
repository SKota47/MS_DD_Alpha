using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    private float main_player_impact = 30.0f;

    public void ColliderDataInput(Collider a_collider, GameObject a_object, ref Vector3 a_vector)
    {
        if (a_collider.gameObject.tag == "Player")
        {
            a_vector.Set(a_object.transform.position.x - a_collider.transform.position.x, 0f, a_object.transform.position.z - a_collider.transform.position.z);
            a_vector.Normalize();
            a_vector *= main_player_impact;
        }
        else
        {
            a_vector.Set(0f, 0f, 0f);
        }
    }

    public void MainPlayerColliderSet(float a_impact)
    {
        main_player_impact = a_impact;
    }
}