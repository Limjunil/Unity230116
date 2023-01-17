using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSpawner : MonoBehaviour
{
    public GameObject bulletProfab; // 생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; // 최초 생성 주기
    public float spawnRateMax = 3.0f; // 최대 생성 주기

    public Transform targetTransf = default; // 발사할 대상 찾기
    private float spawmRate = default; // 생성 주기
    private float timeAfterSpawn = default; // 최근 생성 시점에서 지난 시간

    // Start is called before the first frame update
    void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        // 탄알 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
        spawmRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn = timeAfterSpawn + Time.deltaTime;

        if(spawmRate <= timeAfterSpawn)
        {
            // Reset point
            timeAfterSpawn = 0f;

            spawmRate = Random.RandomRange(spawnRateMin, spawnRateMax);

            GameObject bullet = Instantiate(bulletProfab, 
                transform.position, transform.rotation);

            bullet.transform.LookAt(targetTransf);

            transform.LookAt(targetTransf);

        }   // if : 일정시간마다 1번씩 실행하는 조건문
    }
}
