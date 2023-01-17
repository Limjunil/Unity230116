using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
    public GameManager gameManager;
    // 이동에 사용할 리지디바디 컴포넌트
    private Rigidbody playerRigidbody = default;

    private const float PLAYER_SPEED = 8.0f; // 이동 속력

    // Start is called before the first frame update
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당한다.
        playerRigidbody = gameObject.GetComponent<Rigidbody>();

        // Vector3 firstPoint = new Vector3(100f, 0f, 0f);
        // Vector3 secondPoint = new Vector3(500f, 0f, 0f);

        // // 두 점 사이의 거리 -> magnitude
        // float distance = (secondPoint - firstPoint).magnitude;

        // Debug.Log($"두 점 사이의 거리는 : {distance} 이다.");
    }

    // Update is called once per frame
    void Update()
    {
        // 수평 축과 수직 축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * PLAYER_SPEED;
        float zSpeed = zInput * PLAYER_SPEED;
        
        // Vector3 속도를 (xSpeed, 0.0f, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0.0f, zSpeed);

        // 리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;


        
    }   // Update()


    //! 이전에 움직이던 방식을 캐싱해 놓은 함수
    private void LegacyMove()
    {
        if(Input.GetKey(KeyCode.UpArrow) == true)
        {
            // 위쪽 방향키 입력 감지 된 경우 z 방향에 힘주기
            playerRigidbody.AddForce(new Vector3(0.0f, 0.0f, PLAYER_SPEED));
        }

        if(Input.GetKey(KeyCode.DownArrow) == true)
        {
            // 아래쪽 방향키 입력 감지 된 경우 -z 방향에 힘주기
            playerRigidbody.AddForce(new Vector3(0.0f, 0.0f, -PLAYER_SPEED));
        }

        if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            // 오른쪽 방향키 입력 감지 된 경우 x 방향에 힘주기
            playerRigidbody.AddForce(new Vector3(PLAYER_SPEED, 0.0f, 0.0f));
        }

        if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // 왼쪽 방향키 입력 감지 된 경우 -x 방향에 힘주기
            playerRigidbody.AddForce(new Vector3(-PLAYER_SPEED, 0.0f, 0.0f));
        }

    }

    //! 플레이어가 사망했을 때 호출하는 함수
    public void Die()
    {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        // 가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();


    }   // Die()
}
