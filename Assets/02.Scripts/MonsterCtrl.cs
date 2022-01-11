using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;

    public Transform playerTr;
    public float traceDist = 10.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 주인공과 몬스터간의 거리를 계산
        float distance = Vector3.Distance(playerTr.position, transform.position);

        if (distance <= traceDist)
        {
            agent.isStopped = false; //이동가능
            anim.SetBool("IsTrace", true);
            agent.SetDestination(playerTr.position);
        }
        else
        {
            anim.SetBool("IsTrace", false);
            agent.isStopped = true; //정지
        }
    }
}
