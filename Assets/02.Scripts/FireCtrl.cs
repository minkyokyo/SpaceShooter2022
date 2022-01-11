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

        // MuzzleFlash 활성화
        muzzleFlash.enabled = true;

        // Waiting...
        // yield return [~까지]
        yield return new WaitForSeconds(0.2f);

        // MuzzleFlash 비활성화
        muzzleFlash.enabled = false;
    }
}
