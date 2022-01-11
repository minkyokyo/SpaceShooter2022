#pragma warning disable IDE0052, CS0108

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public Transform firePos; // 총알을 생성할 위치
    public GameObject bulletPrefab; // Bullet 프리팹을 저장할 변수
    public AudioClip fireSfx; // 총 발사 사운드 파일을 저장할 변수

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 총알을 생성
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
