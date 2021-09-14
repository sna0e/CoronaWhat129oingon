using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue
{

    //기본적으로 생성한 모든 함수를 한번에 실행해주는 Init 함수"void Init()"
    public static void Init()
    {
        first();
        friend_t();
        order_t();
        st();
        cf();
        sub();
        text();
    }

    //게임 종료후 얻은 모든 점수를 0으로 초기화해주는 ResetScore함수 "void ResetScore()"

    public static Dictionary<string, string> phone = new Dictionary<string, string>();
    static void first()
    {
        phone.Add("a_p", "5시 20분에 학교 앞 카페에서 보자! 늦지마!");//첫번째 길거리 시작전 문자
        phone.Add("b_p", "지하철 도착 3분 전"); //길거리 1 끝났을 때(지하철 넘어가기 전)
        phone.Add("c_p", "숭실대 입구역에 도착했습니다, 승하차 알람을 종료합니다.");//지하철 끝났을 때(두번째 길거리 가기전)
        phone.Add("d_p", "엄마: 집에 오고 있지? 조심해서 와~");//세번째 길거리 시작 전 문자
    }



    public static Dictionary<string, string> friend = new Dictionary<string, string>();// 카페에서 친구들과 대화 내용
    static void friend_t()
    {
        //1
        friend.Add("a_f", "우리 진짜 오랜만이다. 잘 지냈어?");
        friend.Add("b_f", "아 참, 뉴스 봤어? 거리두기 4단계 연장한대!");
        //2
        friend.Add("c_f", "근데 요즘 돌아다니다 보면 방역수칙이 잘 지켜지지 않는 것 같아.");
        friend.Add("d_f", "그치, 특히 음식점에서도 그렇고, 길거리에서도!");
        friend.Add("e_f", "내가 모르고 넘어가는 방역수칙도 꽤 많았어!");
        //3
        friend.Add("f_f", "코로나 확산이 진정됐으면 좋겠어...");
        friend.Add("g_f", "나는 해외여행이나 국내여행 실컷 다니고싶어!");
        friend.Add("h_f", "난 그런 거보다 마스크나 빨리 벗었으면 좋겠어! 너무 답답해.");
        friend.Add("i_f", "그런 날이 곧 오겠지?");
        //카페 나온 뒤 마지막 대화 (세번째 길거리로 넘어가기 전)
        friend.Add("j_f", "오늘 오랜만에 너무 즐거웠어!");
        friend.Add("k_f", "응, 얼마 못 만나서 아쉽지만 즐거웠어!");
        friend.Add("l_f", "잘 가!");
    }
    

    public static Dictionary<string, string> order = new Dictionary<string, string>();//카페에서 알바생과 대화 내용
    static void order_t()
    {
        //큐알체크 전 카페 알바생과 대화 
        order.Add("a_o", "안녕하세요~ 별다방입니다~ 주문하시겠어요?");
        order.Add("b_o", "아이스 아메리카노 한잔이요!");
        order.Add("c_o", "드시고 가시나요?");
        order.Add("d_o", "네!");
        //큐알체크 안내 문구(70% 확률로)
        order.Add("e_o", "드시고 가시면 오른쪽에 QR 체크인 부탁드리겠습니다!");

    }


    public static Dictionary<int, string> street_rule = new Dictionary<int, string>(); // 길거리 방역 지침
    public static List<int> street_score = new List<int>();
    static void st()
    {
        street_score.Add(0);
        street_rule.Add(1, "거리두기 하며 걷기!");
        street_score.Add(0);
        street_rule.Add(2, "시위하는 사람 신고하기!");
        street_score.Add(0);
        street_rule.Add(3, "집합금지 기준에 맞지 않는 사람 신고하기!");
        street_score.Add(0);

    }

    

    public static Dictionary<int, string> cafe_rule = new Dictionary<int, string>(); //카페 방역 지침
    public static List<int> cafe_score = new List<int>();
    static void cf()
    {
        cafe_score.Add(0);
        cafe_rule.Add(1, "거리두기!");
        cafe_score.Add(0);
        cafe_rule.Add(2, "취식제외 마스크 착용!");
        cafe_score.Add(0);
        cafe_rule.Add(3, "QR 체크인!");
        cafe_score.Add(0);
    }


    public static Dictionary<int, string> subway_rule = new Dictionary<int, string>(); // 지하철 방역 지침
    public static List<int> subway_score = new List<int>();
    static void sub()
    {
        subway_score.Add(0);
        subway_rule.Add(1, "거리두기!");
        subway_score.Add(0);
        subway_rule.Add(2, "자리 띄워 앉기!");
        subway_score.Add(0);
        subway_rule.Add(3, "통화하는 사람 피하기!");
        subway_score.Add(0);
    }


    public static Dictionary<int, string> isolation_text = new Dictionary<int, string>(); //자가격리 문자 내용

    static void text()
    {
        isolation_text.Add(1, "안녕하십니까. ○○ 보건소입니다. 귀하는 코로나 확진자 관련 자가격리 대상자임을 통보드립니다.");
        isolation_text.Add(2, "자가격리 기간은 2주이며 검사 결과와 상관없이 바깥 외출이 금지됩니다.");
    }

    

}