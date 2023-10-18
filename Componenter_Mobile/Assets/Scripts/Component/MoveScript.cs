using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public ComponentManager componentScript;
    private InputScript inputScript; // �Է�
    private Rigidbody2D rigid; // ������ٵ�
    private Animator animator; // �ִϸ�����
    public GameObject[] Canvases;

    public float moveSpeed = 5f;
    public ParticleSystem moveDust;

    void Awake()
    {
        inputScript = GetComponent<InputScript>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (componentScript)
        {
            rigid.velocity = new Vector2(moveSpeed * inputScript.move * componentScript.MoveComponent, rigid.velocity.y);//�ӵ�

            if (inputScript.move * componentScript.MoveComponent != 0)
            {
                animator.SetFloat("isWalk", Mathf.Abs(inputScript.move * componentScript.MoveComponent));//�ִϸ��̼�
                transform.localScale = inputScript.move > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1); //������ȯ

                for (int i = 0; i < Canvases.Length; i++)
                {
                    Canvases[i].transform.localScale = inputScript.move > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1); //ĵ������ �ݴ�� ������ȯ
                }
                if (animator.GetBool("isGrounded")) moveDust.Play(); else moveDust.Stop(); //��ƼŬ
            }
            else
            {
                animator.SetFloat("isWalk", 0);
                moveDust.Stop();
            }
        }
        else
        {
            rigid.velocity = new Vector2(moveSpeed * inputScript.move, rigid.velocity.y);//�ӵ�
            if (inputScript.move != 0)
            {
                animator.SetFloat("isWalk", Mathf.Abs(inputScript.move));//�ִϸ��̼�
                transform.localScale = inputScript.move > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1); //������ȯ

                for (int i = 0; i < Canvases.Length; i++)
                {
                    Canvases[i].transform.localScale = inputScript.move > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1); //ĵ������ �ݴ�� ������ȯ
                }
                if (animator.GetBool("isGrounded")) moveDust.Play(); else moveDust.Stop(); //��ƼŬ
            }
            else
            {
                animator.SetFloat("isWalk", 0);
                moveDust.Stop();
            }
        }

        
    }
}