using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerAnimatorStates
{
    isRun, isJump, isClawAttack
}

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;

    private string runStr = "isRun";
    private string jumpStr = "isJump";
    private string attack1Str = "isAttack1";
    private string attack2Str = "isAttack2";
    private string strongattackStr = "isStrongAttack";
    private string clawattackStr = "isClawAttack";

    private bool jKeyPressed;
    private float jKeyTimer;

    // Start is called before the first frame update

    void Start()
    {
        //自身のAinmatorを習得する
        this.animator = GetComponent<Animator>();
    }


    // Update is called once per frame

    void Update()
    {
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow)))//移動
        {

            this.animator.SetBool(runStr, true);

        }
        else
        {

            this.animator.SetBool(runStr, false);

        }


        if (Input.GetKeyDown(KeyCode.Space))//ジャンプ
        {

            this.animator.SetBool(jumpStr, true);

        }
        else
        {

            this.animator.SetBool(jumpStr, false);

        }


        /*        if (Input.GetKeyDown(KeyCode.J))//攻撃パターン1
                {

                    this.animator.SetBool(attack1Str, true);

                }
                else
                {

                    this.animator.SetBool(attack1Str, false);

                }*/

        if (Input.GetKeyUp(KeyCode.J) || Input.GetMouseButtonUp(0))//攻撃パターン2
        {

            this.animator.SetBool(attack2Str, true);

        }
        else
        {

            this.animator.SetBool(attack2Str, false);

        }


        /*        if (Input.GetKey(KeyCode.J))//長押しでため攻撃
                {

                    this.animator.SetBool(strongattackStr, true);

                }
                else
                {

                    this.animator.SetBool(strongattackStr, false);

                }*/



        if (Input.GetKeyDown(KeyCode.K) || Input.GetMouseButtonUp(1))//爪飛ばし攻撃
        {

            this.animator.SetBool(clawattackStr, true);

        }
        else
        {

            this.animator.SetBool(clawattackStr, false);

        }
    }
}