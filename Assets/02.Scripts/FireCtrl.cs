#pragma warning disable IDE0052, CS0108

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public Transform firePos; // 총알을 생성할 위치
    public GameObject bulletPrefab; // Bullet 프리팹을 저장할 변수
    public AudioClip fireSfx; // 총 발사 사운드 파일을 저장할 변수

    [HideInInspector]
    public MeshRenderer muzzleFlash;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.Find("MuzzleFlash").GetComponent<MeshRenderer>();
        muzzleFlash.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // 총알을 생성
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        // 총소리를 발생
        audio.PlayOneShot(fireSfx, 0.8f);
        // 총구 화염 효과
        StartCoroutine(ShowMuzzleFlash());
    }

    // 코루틴 Co-routine
    IEnumerator ShowMuzzleFlash()
    {
        // 텍스처를 교환 - Offset 변경
        /*
            난수 발생
            Random.Range(min, max)
            Random.Range(0, 10)       -> 0, ..., 9
            Random.Range(0,0f, 10.0f) -> 0.0f , ... , 10.0f
        */

        /*
            (0,0)
            (0.5, 0)
            (0.5, 0.5)
            (0, 0.5)
        */

        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        muzzleFlash.material.mainTextureOffset = offset;

        // 텍스처의 크기를 변경
        float scale = Random.Range(1.0f, 3.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale; // new Vector3(scale, scale, scale);

        // 텍스처를 회전
        Quaternion rot = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));
        muzzleFlash.transform.localRotation = rot;

        // MuzzleFlash 활성화
        muzzleFlash.enabled = true;

        // Waiting...
        // yield return [~까지]
        yield return new WaitForSeconds(0.2f);

        // MuzzleFlash 비활성화
        muzzleFlash.enabled = false;
    }
}


/*
    Quaternion 쿼터니언 (사원수) - 복소수 사차원 벡터 (x, y, z, w)

    Euler Rotation 오일러 회전 (0 ~ 360)
    X -> Y -> Z

    Gimbal Lock (짐벌락, 김벌락)

    Quaternion rot = Quaternion.LookRotation(벡터)
    Quaternion rot1 = Quaternion.Euler(30, 45, 100)
*/

/*
    Animation Type

    1. Legacy  : 가볍다. , 코드기반으로 컨트롤
    2. Mecanim : Node Visual Editor, 복잡도가 증가하는 단점
        - Generic : Retargetting X
        - Humanoid : 2족 보행하는 모델에 적용, 필수본(Born) 15개를 충족, Retargetting(모션캡쳐 애니메이션을 사용)


*/

/*
    A*PathFinding

    Navigation 

*/