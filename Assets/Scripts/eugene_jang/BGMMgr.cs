using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMgr : MonoBehaviour
{

    public AudioSource audioSource;

    public int preIdx;

    public AudioClip[] audios = new AudioClip[33];
    void Start()
    {

    }

    void Update()
    {
        int curIdx = BetaDocentMgr.Instance.idx;

        if (preIdx != curIdx)
        {
            preIdx = curIdx;
            if( curIdx < 10)
            {
                PlayFixedAudio(audios, curIdx);

            }
        }
    }
    // idx의 Audio resource가 null 이 아니라면 
    // Audio를 재생
    // bgm 먼저 깔리고.. 
    // 도슨트 재생.. 

    public void PlayFixedAudio(AudioClip[] clips, int idx)
    {
        Debug.Log("if 문 직전");
        if (audioSource != null)
        {
            AudioSource[] audioSources = GetComponents<AudioSource>();
            Debug.Log("destroy 되기 직전...두근두근");
            foreach (AudioSource audioSource in audioSources)
            {
                Destroy(audioSource);
            }
            print("잘 자요");
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clips[idx];
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

}
