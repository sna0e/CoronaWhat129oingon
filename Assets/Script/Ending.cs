using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Ending : MonoBehaviour
{
    public RawImage mScreen = null;
    public VideoPlayer mVideoPlayer = null;
    public VideoClip vid_suc = null;

    public Text message = null;

    void Start()
    {
        if (mScreen != null && mVideoPlayer != null)
        {
            if(GameManager.covidWeight == 0)
            {
                mVideoPlayer.clip = vid_suc;
                message.text = "동작구 K - 방역의 힘! \n일일 확진자 0명 달성!!";
            }
            else
            {
                message.text = "동작구 방역 실패... \n확진자 " + GameManager.covidWeight + "명 증가!";
            }
            // 비디오 준비 코루틴 호출
            StartCoroutine(PrepareVideo());
        }
    }

    private void Update()
    {
        if(Input.anyKeyDown && mVideoPlayer.isPrepared)
        {
            Application.Quit();
        }
    }

    protected IEnumerator PrepareVideo()
    {
        // 비디오 준비
        mVideoPlayer.Prepare();

        // 비디오가 준비되는 것을 기다림
        while (!mVideoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(0.5f);
        }

        // VideoPlayer의 출력 texture를 RawImage의 texture로 설정한다
        mScreen.texture = mVideoPlayer.texture;
    }

    public void PlayVideo()
    {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared)
        {
            // 비디오 재생
            mVideoPlayer.Play();
        }
    }

    public void StopVideo()
    {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared)
        {
            // 비디오 멈춤
            mVideoPlayer.Stop();
        }
    }
}