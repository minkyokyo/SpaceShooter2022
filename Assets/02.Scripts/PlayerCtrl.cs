using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float v;
    private float h;
    private float r;

    [System.NonSerialized]  //C#
    [HideInInspector]       //Unity API
    public Animation anim;

    public float speed = 20.0f;

    // 1회 호출
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>(); // 제너릭 타입(Generic Type)
        anim.Play("Idle");
    }

    // 매 프레임 마다 호출, 화면을 랜더링하는 주기, 호출간격이 불규칙
    void Update()
    {
        v = Input.GetAxis("Vertical"); //Up, Down, W, S // -1.0f ~ 0.0f ~ +1.0f
        h = Input.GetAxis("Horizontal");// -1.0f ~ 0.0f ~ +1.0f
        r = Input.GetAxis("Mouse X");

        // transform.Translate(방향 * 속도 * 변위)
        // transform.Translate(Vector3.forward * 0.1f * v); //전진/후진
        // transform.Translate(Vector3.right * 0.1f * h);   //좌/우

        // 벡터의 덧셈 연산
        // Vector3 moveDir = (전후진벡터) + (좌우벡터)
        // 이동처리
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        transform.Translate(moveDir.normalized * Time.deltaTime * speed);

        //회전처리
        transform.Rotate(Vector3.up * Time.deltaTime * 80.0f * r);

        // 애니메이션 처리
        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        if (v >= 0.1f) // 전진
        {
            anim.CrossFade("RunF", 0.25f);
        }
        else if (v <= -0.1f) // 후진
        {
            anim.CrossFade("RunB", 0.25f);
        }
        else if (h >= 0.1f) // 오른쪽
        {
            anim.CrossFade("RunR", 0.25f);
        }
        else if (h <= -0.1f) // 왼쪽
        {
            anim.CrossFade("RunL", 0.25f);
        }
        else
        {
            anim.CrossFade("Idle", 0.1f);
        }
    }
}
