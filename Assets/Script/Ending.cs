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
                message.text = "���۱� K - �濪�� ��! \n���� Ȯ���� 0�� �޼�!!";
            }
            else
            {
                message.text = "���۱� �濪 ����... \nȮ���� " + GameManager.covidWeight + "�� ����!";
            }
            // ���� �غ� �ڷ�ƾ ȣ��
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
        // ���� �غ�
        mVideoPlayer.Prepare();

        // ������ �غ�Ǵ� ���� ��ٸ�
        while (!mVideoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(0.5f);
        }

        // VideoPlayer�� ��� texture�� RawImage�� texture�� �����Ѵ�
        mScreen.texture = mVideoPlayer.texture;
    }

    public void PlayVideo()
    {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared)
        {
            // ���� ���
            mVideoPlayer.Play();
        }
    }

    public void StopVideo()
    {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared)
        {
            // ���� ����
            mVideoPlayer.Stop();
        }
    }
}