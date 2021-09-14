using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {

    }
    public enum MapType
    {
        house = 0, road1 = 1, subway = 2, road2 = 3, cafe = 4, road3 = 5
    }

    public static int socialDisLevel = 4; //기본 거리두기 4단계
    public static int covidWeight = 0; //점수 관리
    public static int maxStage = 5; //스테이지 개수
    public static int contact_count = 0;//접촉한 사람들 수

    public static int stageNum = 4; //현재 스테이지 관리

    public static bool isPause = false;
    public static bool isSit = false;
    public static string timer;

    public static bool maskOn = true;


    //현재 스테이지 타입
    public static MapType[] stageType = { MapType.road1, MapType.subway, MapType.road2, MapType.cafe, MapType.road3 };

    private void Awake()
    {
        instance = this;
    }

    public static MapType getStageType(int stage = -1)
    {
        if (stage == -1)
            return stageType[stageNum];
        return stageType[stage];
    }
}
