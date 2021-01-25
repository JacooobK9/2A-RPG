using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;
    bool isRunning = false;
    [SerializeField] GameObject[] skillParticles;
    private IEnumerator coroutine;

    void Start()
    {
        animator = GetComponent<Animator>();
        for (int i = 0; i < skillParticles.Length; i++)
        {
            skillParticles[i].SetActive(false);
        }
    }

    void Update()
    {
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        if (Input.GetKeyUp(KeyCode.Space)) Jump();
        if (Input.GetKeyUp(KeyCode.LeftShift)) Run(false);
        if (Input.GetKeyDown(KeyCode.LeftShift)) Run(true);
        if (Input.GetKeyUp(KeyCode.Alpha1)) UseSkill(1);
        if (Input.GetKeyUp(KeyCode.Alpha2)) UseSkill(2);
        if (Input.GetKeyUp(KeyCode.Alpha3)) UseSkill(3);
        if (Input.GetKeyUp(KeyCode.Alpha4)) UseSkill(4);
        if (Input.GetKeyUp(KeyCode.Alpha5)) UseSkill(5);
    }

    void UseSkill(int skillNumber)
    {
        animator.SetTrigger("Skill" + skillNumber);
        skillParticles[skillNumber - 1].SetActive(true);

        switch(skillNumber)
        {
            case 1:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 2);
                break;
            case 2:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 2.5f);
                break;
            case 3:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 2.5f);
                break;
            case 4:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 2.5f);
                break;
            case 5:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 2.5f);
                break;
        }

        StartCoroutine(coroutine);
    }

    IEnumerator WaitToEnableObject(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);


    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }
    public void Run(bool startMovement)
    {
        isRunning = startMovement;
        animator.SetBool("isRunning", isRunning);
    }
}


