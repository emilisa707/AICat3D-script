using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    Animator animator;
    UIControl uiControl;
    LoadData loadData;

    public int angryValue;

    public enum State
    {
        hungry,
        goOut,
        thristy,
        licking,
        sleeping,
        observing,
        eat,
        dontWantEat,
        pee,
        pup,
        play,
        disturbed,
        med,
        drink,
        bath,
        died,
        sick
    }

    public State state;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        uiControl = FindObjectOfType<UIControl>();
        loadData = FindObjectOfType<LoadData>();
;
    }

    public void SetAnimationState(State state)
    {
        switch (state)
        {
            case State.hungry:
                animator.SetInteger("isSleep", 6);
                animator.SetInteger("Playing", 4);
                animator.SetBool("isHungry", true);
                animator.SetBool("isLicking", false);
                break;

            case State.goOut:
                animator.SetInteger("isSleep", 6);
                animator.SetInteger("Playing", 4);
                animator.SetBool("isHungry", false);
                animator.SetBool("isPlaying", false);
                animator.SetTrigger("goOut");
                break;

            case State.thristy:
                animator.SetInteger("isSleep", 6);
                animator.SetInteger("Playing", 4);
                animator.SetBool("isThristy", true);
                animator.SetBool("isLicking", false);
                break;

            case State.licking:
                animator.SetInteger("isSleep", 6);
                animator.SetInteger("Playing", 4);
                animator.SetBool("isLicking", true);
                animator.SetBool("isHungry", false);
                break;

            case State.sleeping:
                animator.SetBool("isLicking", false);
                animator.SetBool("observing", false);
                animator.SetInteger("Playing", 4);
                break;

            case State.observing:
                animator.SetInteger("isSleep", 6);
                animator.SetInteger("Playing", 4);
                animator.SetBool("isOberving", true);
                break;

            case State.eat:
                    animator.SetTrigger("toEat");
                    animator.SetBool("isHungry", false);
                break;

            case State.dontWantEat:
                animator.SetTrigger("dontWantEat");
                break;

            case State.pee:
                animator.SetInteger("isSleep", 6);
                animator.SetInteger("Playing", 4);
                animator.SetTrigger("pooping");
                animator.SetBool("isPoo", false);
                break;

            case State.pup:
                animator.SetInteger("isSleep", 6);
                animator.SetInteger("Playing", 4);
                animator.SetTrigger("poop");
                animator.SetBool("isPoo", false);
                break;

            case State.play:
                Debug.Log("ayo main yuk");
                animator.SetInteger("isSleep", 6);
                if (!loadData.playingWithToy)
                {
                    animator.SetInteger("Playing", 0);
                }
                else
                {
                    //animator.SetInteger("Playing", 1);
                }
                break;

            case State.disturbed:
                if (uiControl.angryValue < 5)
                {
                    animator.SetTrigger("disturbed");
                }
                else
                {
                    animator.SetTrigger("angry");
                }
                break;

            case State.med:
                animator.SetTrigger("toMed");
                break;

            case State.drink:
                animator.SetTrigger("drinking");
                animator.SetBool("isThristy", false);
                break;

            case State.bath:
                animator.SetTrigger("bath");
                break;

            case State.died:
                Debug.Log("iam dyiiiiiiing");
                animator.SetBool("isDead", true);
                animator.SetInteger("isSleep", 6);
                animator.SetInteger("Playing", 4);
                //uiControl.interactionButton.enabled = false;
                uiControl.diedPanel.SetActive(true);
                break;

            case State.sick:
                Debug.Log("lemesssss");
                animator.SetInteger("Playing", 4);
                animator.SetBool("isSick", true);
                break;

            default:
                break;
        }
    }

    
}
