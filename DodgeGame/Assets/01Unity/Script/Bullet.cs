using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 8.0f;    // 탄알 이동 속력
    private Rigidbody bulletRgBody = default; // 이동에 사용할 리지드바디 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        // 게임 오브젝트에서 리지드바디 컴포넌트를 찾아 bulletRgBody에 할당
        bulletRgBody = gameObject.GetComponent<Rigidbody>();

        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRgBody.velocity = transform.forward * bulletSpeed;

        // 3초 뒤에 스스로 파괴되는 코드
        Destroy(gameObject, 3.0f);
    }   // Start()


    // Update is called once per frame
    void Update()
    {
        
    }

    //! 총알이 무언가와 부딪쳤을 경우 실행되는 함수
    public void OnTriggerEnter(Collider other) {
        //
        if(other.tag.Equals("Player"))
        {
            // PlayerController 가져오기
            PlayerController player = other.GetComponent<PlayerController>();

            if(player == null || player == default)
            {
                return;
            }

            // 플레이어의 컨트롤을 정상적으로 가져온 경우
            // 총알을 맞은 플레이어는 죽는다.
            player.Die();

        }   // if : 태그가 플레이어인 경우
    }   // OnTriggerEnter()
}
