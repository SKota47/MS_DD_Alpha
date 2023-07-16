using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CenterMobEnemy : MonoBehaviour
{
    private GameObject m_script_manager;
    private ColliderManager m_collider_manager;

    private GameObject[] m_pop_point = new GameObject[5];
    private GameObject[] m_end_point = new GameObject[5];

    private NavMeshAgent m_navmesh_agent;
    private Rigidbody m_rigidbody;
    private Animator m_animator;

    private Vector3 m_impact_vector;

    private float m_time_count = 0.0f;

    private int m_transition = 0;
    private int m_iskinematic_change_frame = 0;

    enum STATE
    {
        WAIT,
        MOVE,
        DIE,
        IMPACT
    }; STATE e_state;

    private void FixedUpdate()
    {
        switch (e_state)
        {
            case STATE.WAIT:
                m_time_count += Time.deltaTime;

                if (m_time_count > 1.0f)
                {
                    //m_animator.SetBool("animation_move", true);
                    m_navmesh_agent.SetDestination(m_end_point[0].transform.position); // タスク１
                    e_state = STATE.MOVE;
                }
                break;

            case STATE.MOVE:

                break;

            case STATE.DIE:
                m_time_count += Time.deltaTime;

                if (m_time_count > 2.0f)
                {
                   // m_animator.SetBool("animation_die", false);
                    MobState(false);
                }
                break;

            case STATE.IMPACT:
                if (m_transition == 0)
                {
                    m_transition = 1;
                    m_iskinematic_change_frame = Time.frameCount; // 補足２
                    m_navmesh_agent.enabled = false;
                    m_rigidbody.isKinematic = false;
                    m_rigidbody.AddForce(m_impact_vector, ForceMode.Impulse);
                }

                if ((m_transition == 1) && (m_rigidbody.IsSleeping()))
                {
                    m_transition = 0;
                    m_iskinematic_change_frame = Time.frameCount; // 補足２
                    m_navmesh_agent.enabled = true;
                    m_rigidbody.isKinematic = true;
                    m_navmesh_agent.SetDestination(m_end_point[0].transform.position); // タスク１
                    e_state = STATE.MOVE;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider a_collider)
    {
        if ((e_state == STATE.WAIT) || (e_state == STATE.DIE) || (m_iskinematic_change_frame == Time.frameCount)) return; // 補足２

        m_collider_manager.ColliderDataInput(a_collider, this.gameObject, ref m_impact_vector);

        if (m_impact_vector != Vector3.zero)
        {
            m_transition = 0;
            e_state = STATE.IMPACT;
        }

        if (a_collider.gameObject.tag == "Finish")
        { // タスク２
            m_navmesh_agent.enabled = true;
            m_rigidbody.isKinematic = true;
            m_animator.SetBool("animation_move", false);
            m_animator.SetBool("animation_die", true);
            m_time_count = 0.0f;
            e_state = STATE.DIE;
        }
    }

    public void Initialize()
    {
        m_script_manager = GameObject.Find("ScriptManager");
        m_collider_manager = m_script_manager.GetComponent<ColliderManager>();

        m_navmesh_agent = GetComponent<NavMeshAgent>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
        m_pop_point[0] = GameObject.Find("PopPoint"); // タスク３
        m_end_point[0] = GameObject.Find("Goal"); // タスク３
    }

    public void MobState(bool a_bool)
    {
        if (a_bool)
        {
            this.gameObject.transform.position = m_pop_point[0].transform.position; // タスク１
            m_navmesh_agent.enabled = true; // 補足１
            m_time_count = 0.0f;
            e_state = STATE.WAIT;
        }
        else
        {
            m_navmesh_agent.enabled = false; // 補足１
            this.gameObject.SetActive(false);
        }
    }
}

/*
    [規則]
    p_ 外部アクセス
    m_ メンバー変数
    l_ ローカル変数
    a_ 引数

    [説明]
    補足１　真だと座標移動時に障害物が干渉して初期位置にズレが発生する
    補足２　IsKinematic切り替え時と同フレームのコライダー判定を無視する

    [バージョン]
    2020-12-12　プーリングとナビゲーション
    2021-01-03　アセットストアのモデル反映とアニメーション
    2021-01-28　吹き飛ばし機能の実装

    [タスク]
    タスク１　拠点の占拠状態で分岐が必要
    タスク２　プーリング動作確認用のため消去する
    タスク３　沸く場所全ての設定が必要
*/