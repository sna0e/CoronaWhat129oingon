using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    //private
    public Text nowStageText; //test용 
    public GameObject phoneButton;
    public GameObject phoneUI;
    public GameObject phoneHomeUI;
    public GameObject phoneCallUI;
    public GameObject phoneMessageUI;
    public GameObject phoneQRUI;
    public GameObject maskButton;

    public GameObject InfoPage;

    public bool isMask = false; // 마스크 착용 여부

    private bool isInfo = false;

    private bool qrOn = false;
    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "StartScene")
        {
            InfoPage = GameObject.Find("InfoPage").gameObject;
            InfoPage.SetActive(false);
        }

        GameManager.isPause = false;
        if(SceneManager.GetActiveScene().name == "StageSelect")
            nowStageText.text = "현재 스테이지 : " + GameManager.stageNum;

        if(SceneManager.GetActiveScene().name == "MainStage" ||
            SceneManager.GetActiveScene().name == "TestSceneJihun")//테스트용
        {
            phoneButton = GameObject.Find("PhoneButton").gameObject;
            phoneUI = GameObject.Find("PhoneUI").gameObject;
            ChangePhoneInfo();
            phoneUI.SetActive(false);
            maskButton = GameObject.Find("MaskButton").gameObject;
            isMask = false;
            phoneHomeUI = phoneUI.transform.Find("Phone").Find("PhoneHomeUI").gameObject;
            phoneMessageUI = phoneUI.transform.Find("Phone").Find("PhoneMessageUI").gameObject;
            phoneQRUI = phoneUI.transform.Find("Phone").Find("PhoneQRUI").gameObject;
            phoneCallUI = phoneUI.transform.Find("Phone").Find("PhoneCallUI").gameObject;
            phoneHomeUI.SetActive(true);
            phoneMessageUI.SetActive(false);
            phoneQRUI.SetActive(false);
            phoneCallUI.SetActive(false);
        }
        isInfo = false;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "StartScene")) //Escape to Exit
        {
            Application.Quit();
        }
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E)) 
            && SceneManager.GetActiveScene().name == "MainStage") //E and Escape == phone
        {
            if (GameManager.isPause)
                Resume();
            else
                Pause();
        }
        if (!GameManager.isPause)
        {
            //if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name == "MainStage") //R == Mask
                //Mask();
            
        }
    }



    //Button Function

    public void StartGame() //StartScene->StartButton
    {
        Debug.Log("게임 시작");
        /*
        //shuffle
        for(int i = 0; i < GameManager.maxStage; i++)
        {
            int r = Random.Range(0, GameManager.maxStage);
            GameManager.mapType temp = GameManager.stageType[r];
            GameManager.stageType[r] = GameManager.stageType[i];
            GameManager.stageType[i] = temp;
        }
        */
        GameManager.stageNum = 0;
        GameManager.socialDisLevel = 4;
        GameManager.covidWeight = 0;

        SceneManager.LoadScene("MainStage");
    }
    public void InfoButton() //StartScene->InfoButton
    {
        //게임 설명 함수
        if(isInfo)
        {
            InfoPage.SetActive(false);
            isInfo = false;
        } else
        {
            InfoPage.SetActive(true);
            isInfo = true;
        }
        
    }

    public void GotoStage() //StageSelect-> 
    {
        Debug.Log("씬이동");
        SceneManager.LoadScene("MainStage");
    }
    public void AddStage() //test
    {
        GameManager.stageNum += 1;
        Debug.Log("스테이지 변경" + GameManager.stageNum);
        nowStageText.text = "현재 스테이지 : " + GameManager.stageNum + "\n";
        for (int i = 0; i < GameManager.maxStage; i++)
            nowStageText.text += GameManager.stageType[i] + " ";

    }

    public void Pause() //MainStage->Canvas->PhoneButton
    {
        GameManager.isPause = true;
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        phoneUI.SetActive(true);
        phoneButton.SetActive(false);
        maskButton.SetActive(false);

        phoneHomeUI.SetActive(true);
        phoneMessageUI.SetActive(false);
        phoneQRUI.SetActive(false);
        phoneCallUI.SetActive(false);

        phoneHomeUI.transform.GetChild(0).GetComponent<Text>().text = GameManager.timer;
    }
    public void Resume() //MainStage->Canvas->PhoneUI->Resume
    {
        GameManager.isPause = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        phoneUI.SetActive(false);
        phoneButton.SetActive(true);
        maskButton.SetActive(true);
    }

    public void GoHome() //MainStage->Canvas->PhoneUI->Resume
    {
        Resume();
        SceneManager.LoadScene("StartScene");
    }
    public void CallButton()
    {
        phoneHomeUI.SetActive(false);
        phoneMessageUI.SetActive(false);
        phoneQRUI.SetActive(false);
        phoneCallUI.SetActive(true);
        qrOn = false;
    }
    public void Call112()
    {
        Debug.Log("112전화");
    }

    public void MessageButton()
    {
        phoneHomeUI.SetActive(false);
        phoneMessageUI.SetActive(true);
        phoneQRUI.SetActive(false);
        phoneCallUI.SetActive(false);
        qrOn = false;
    }
    public void QRButton()
    {
        phoneHomeUI.SetActive(false);
        phoneMessageUI.SetActive(false);
        phoneQRUI.SetActive(true);
        phoneCallUI.SetActive(false);
        qrOn = true;
    }
    public void QRCheck()
    {
        if (GameManager.isPause)
            Resume();

        if (!qrOn)
            Debug.Log("QR코드를 인식시켜주세요.");
        else
        {
            Debug.Log("인증되었습니다");
            qrOn = false;
        }

    }

    public void HomeButton()
    {
        phoneHomeUI.SetActive(true);
        phoneMessageUI.SetActive(false);
        phoneQRUI.SetActive(false);
        phoneCallUI.SetActive(false);
        qrOn = false;
    }
    public void Mask() //MainStage->Canvas->MaskButton
    {
        if (isMask)
        {
            isMask = false;
            maskButton.transform.GetChild(0).gameObject.SetActive(false);
            maskButton.transform.GetChild(1).gameObject.SetActive(true);
            maskButton.GetComponent<Button>().targetGraphic = maskButton.transform.GetChild(1).GetComponent<Image>();
            //마스크 카운트 초기화
            GameManager.maskOn = true;
        } else
        {
            isMask = true;
            maskButton.transform.GetChild(1).gameObject.SetActive(false);
            maskButton.transform.GetChild(0).gameObject.SetActive(true);
            maskButton.GetComponent<Button>().targetGraphic = maskButton.transform.GetChild(0).GetComponent<Image>();
            //마스크 카운트 시작
            GameManager.maskOn = false;
        }
    }

    private void ChangePhoneInfo()
    {
        GameObject phoneHome = GameObject.Find("PhoneHomeUI").gameObject;
        Text title = phoneHome.transform.GetChild(1).GetComponent<Text>();
        Text todo = phoneHome.transform.GetChild(2).GetComponent<Text>();
        Debug.Log(GameManager.stageNum);
        switch(GameManager.stageNum)
        {
            case 1:
                //load1 text
                break;
            case 2:
                //subway text
                break;
            case 3:
                //load2 text
                break;
            case 4:
                //cafe text
                title.text = "할 일! (카페)";
                todo.text = "- 줄 서기\n\n- 음료수 주문하기\n\n- 자리에 앉기\n\n- 시원한 음료수 마시기\n\n- 친구랑 대화하기";
                break;
            case 5:
                //load3 text
                break;
            default:
                break;
        }
    }

}
