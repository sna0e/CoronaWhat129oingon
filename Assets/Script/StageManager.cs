using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{

    //{house = 0, road1 = 1, subway = 2, road2 = 3, cafe = 4, road3 = 5}
     public GameObject[] stage; //Inspector���� ������ּ���.
     public GameManager.MapType stageType = GameManager.getStageType();
     public int stageNum = GameManager.stageNum;

    void Start()
    {
        //�ϴ� ���� ��Ȱ��ȭ
        for (int i = 0; i < stage.Length; i++)
            stage[i].SetActive(false);
        
        //�ش��ϴ� �ʿ�����Ʈ Ȱ��ȭ
        switch(stageType)
        {
            case GameManager.MapType.house:
                Debug.LogError("�Ͽ콺�� �ȸ�����ŵ��!");
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
                Debug.LogError("�������� ���� ��Ÿ���Դϴ�!");
                SceneManager.LoadScene("StartScene");
                break;
        }


    }

    void StageClear()
    {
        //Ŭ���� �޽���
        GameManager.stageNum++;
        SceneManager.LoadScene("SelectStage");
    }
}
