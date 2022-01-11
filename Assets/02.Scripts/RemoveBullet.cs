using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BULLET") // component.tag  gameObject.tag
        {
            //총알을 삭제
            Destroy(coll.gameObject);

            ContactPoint cp = coll.GetContact(0);
            //충돌지점(좌표)
            Vector3 hitPoint = cp.point;
            //충돌지점의 법선벡터
            Vector3 hitNormal = -cp.normal;
            //법선벡터를 쿼터니언 타입으로 변환
            Quaternion rot = Quaternion.LookRotation(hitNormal);

            //스파크를 생성
            GameObject obj = Instantiate(sparkEffect, hitPoint, rot);
            //스파크 삭제
            Destroy(obj, 0.5f);
        }
    }
}


/* 충돌콜백함수 (Colision Callback Function) 이벤트(Event)
    OnCollisionEnter()  : 1
    OnCollisionStay()   : n
    OnCollisionExit()   : 1
    IsTrigger 언체크


    OnTriggerEnter()    : 1
    OnTriggerStay()     : n
    OnTriggerExit()     : 1
    IsTrigger 체크

    충돌콜백함수 발생조건
    1) 양쪽 다 Collider Components 
    2) 이동하는 객체에는 Rigidbody Component
*/

/*

    AudioListener : 소리를 듣는 역할, 씬에 유일하게 - 1개 존재

    AudioSource   : 소리를 발생시키는 역할 - n개 존재

*/












// 법선벡터 (Normalized Vector)