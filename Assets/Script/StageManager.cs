using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{

    //{house = 0, road1 = 1, subway = 2, road2 = 3, cafe = 4, road3 = 5}
     public GameObject[] stage; //Inspector에서 등록해주세요.
     public GameManager.MapType stageType = GameManager.getStageType();
     public int stageNum = GameManager.stageNum;

    void Start()
    {
        //일단 전부 비활성화
        for (int i = 0; i < stage.Length; i++)
            stage[i].SetActive(false);
        
        //해당하는 맵오브젝트 활성화
        switch(stageType)
        {
            case GameManager.MapType.house:
                Debug.LogError("하우스는 안만들었거든요!");
                break;
            case GameManager.MapType.road1:
                stage[1].SetActive(true);
                break;
            case GameManager.MapType.subway:
                stage[2].SetActive(true);
                break;
            case GameManager.MapType.road2:
                stage[3].SetActive(true);
                break;
            case GameManager.MapType.cafe:
                stage[4].SetActive(true);
                break;
            case GameManager.MapType.road3:
                stage[5].SetActive(true);
                break;
            default:
                Debug.LogError("존재하지 않은 맵타입입니다!");
                SceneManager.LoadScene("StartScene");
                break;
        }


    }

    void StageClear()
    {
        //클리어 메시지
        GameManager.stageNum++;
        SceneManager.LoadScene("SelectStage");
    }
}
