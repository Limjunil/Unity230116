using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;   // Ui 관련 라이브러리
using TMPro;
using UnityEngine.SceneManagement;  // 씬 관리 관련 라이브러리

public class GameManager : MonoBehaviour
{
    // 게임 오버시 활성화할 텍스트 게임 오브젝트
    public GameObject gameOverTxtObj = default;

    //!< 생존 시간을 표시할 텍스트
    public TMP_Text timeTxt = default;

    //!< 최고 기록을 표시할 텍스트
    public TMP_Text recordTxt = default;


    private const string SCENE_NAME = "PlayScene";
    private const string BEST_RECORD = "BestTime";
    // 생존시간
    private float surviveTime = default;
    // 게임 오버 상태
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        // 생존 시간과 게임오버 상태 초기화
        surviveTime = 0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(isGameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SCENE_NAME);
            } // if : R 키 입력 시 재시작

            if(Input.GetKeyDown(KeyCode.Q))
            {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif

            } // if : Q 키 입력 시 종료
        }   // if : 게임 오버인 경우

        // { 생존 시간을 갱신한다.
        surviveTime = surviveTime + Time.deltaTime;
        timeTxt.text = $"Time : {Mathf.FloorToInt(surviveTime)}";
        // } 생존 시간을 갱신한다.
    }

    //! 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        isGameOver = true;
        // gameOverTxtObj.SetActive(true);
        gameOverTxtObj.transform.localScale = Vector3.one;

        // BestTime 키로 저장된 이전까지의 최고 기록 가져오기

        float bestTime = PlayerPrefs.GetFloat(BEST_RECORD);

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 긴 경우
        if(bestTime < surviveTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat(BEST_RECORD, bestTime);
        } // if : 현재 

        // 최고 기록을 텍스트에 갱신한다.
        recordTxt.text = $"Best Time : {Mathf.FloorToInt(bestTime)}";

    }
}
