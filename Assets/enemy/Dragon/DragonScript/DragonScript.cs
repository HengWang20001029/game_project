using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragonScript : MonoBehaviour
{
    public GameObject fire;//������ص�������

    public GameObject character;//���ǹ��ص�������

    private bool attackMode;//����ģʽ

    private int random;//���ʽ��빥��״̬

    private Animator animator;//���ظýű�������Ķ�����

    private Vector2 character_pos;//Ҫ����������λ��

    private Vector2 fire_cur_pos;//������ʼλ��

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        attackMode = false;
        animator = GetComponent<Animator>();
        fire_cur_pos = transform.position;
        speed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(0, 10);
        //���ù�������Ϊ20%
        if(random>=8)
        {
            attackMode = true;
            animator.SetBool("Attack", attackMode);//���빥��ģʽ

            character_pos = character.transform.position;//��������λ��


            GameObject new_fire = GameObject.Instantiate(fire,fire.transform);

            
            Move(new_fire, character,fire_cur_pos, character_pos);//�����ƶ�


            attackMode = !attackMode;//�˳�����ģʽ
            animator.SetBool("Attack", attackMode);
        }
    }

    private void Move(GameObject g,GameObject charac,Vector2 src,Vector2 dest)
    {
        Vector3 direction = (dest - src).normalized;
       while(g.transform.position!=charac.transform.position)
        {
            g.transform.position += speed  * direction * Time.deltaTime;
        }
    }
}
