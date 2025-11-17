using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    [Header("사용할 오디오클립 불러오기")]
    [SerializeField] private AudioClip[] preloadClips;

    private Dictionary<string, AudioClip> audioClipsDic; //이름으로 오디오 클립 찾기위한 dic

    [SerializeField] private AudioSource bgmSource; //BGM 재생용
    [SerializeField] private AudioSource effectSource; // EFFECT 재생용

    protected override void Awake()
    {
        base.Awake(); //싱글톤 초기화 -중복방지

        //클립 딕셔너리 초기화
        audioClipsDic = new Dictionary<string, AudioClip>();
        foreach (var clip in preloadClips)
        {
            audioClipsDic.Add(clip.name, clip); //이름으로 찾은거->클립으로
        }

        //씬 로드 시 BGM 자동 교체 이벤트 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //sceneLoaded 에서 OnSceneLoaded 제거 -자동교체 중복방지
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //BGM 재생 함수
    public void PlayBGM(string clipName)
    {
        //디버그용 하나 만들고
        if (!audioClipsDic.TryGetValue(clipName, out var clip))
        {
            Debug.LogWarning($"BGM {clipName} not found!");
            return;
        }

        //이미 재생중이면 내비둬
        if (bgmSource.clip == clip && bgmSource.isPlaying) return;

        bgmSource.clip = clip; //클립 가져오고,
        bgmSource.Play(); //재생
    }

    //BGM 정지 함수
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    //EFFECT 재생 함수 loop아니니까 정지는 필요없음
    public void PlayEffect(string clipName)
    {
        if (!audioClipsDic.TryGetValue(clipName, out var clip))
        {
            //이펙트 사운드 못찾았을때
            Debug.LogWarning($"Effect {clipName} not found!");
            return;
        }
        effectSource.PlayOneShot(clip); //한번 재생
    }

    //씬 전환시 BGM 자동 변경해줄 함수
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //씬 이름에 따라 BGM 자동 변경
        switch (scene.name)
        {
            case "SampleScene":
                PlayBGM("mapleBadGuys-BGM");
                break;
            default:
                StopBGM();
                break;
        }
    }
}
