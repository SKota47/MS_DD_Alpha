using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    private float main_player_impact = 30.0f; // タスク１

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

/*
    [規則]
    p_ 外部アクセス
    m_ メンバー変数
    l_ ローカル変数
    a_ 引数
    e_ 列挙型

    [説明]

    [バージョン]
    2021-01-28　吹き飛ばし機能の実装

    [タスク]
    タスク１　戦闘開始時にMainPlayerColliderSetでステータスを反映させる
*/