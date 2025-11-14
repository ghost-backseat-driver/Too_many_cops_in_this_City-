using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//에너미, 머니 스포너 따로 하려고 했는데,
//어차피 랜덤위치 스폰되는거 같으니까, 공용으로 쓸 수 있게 만들자
public class Object_Spawner : MonoBehaviour
{
    [Header("스폰할 프리팹")] //공용으로 쓰고 있으니까, 그냥 각 객체의 비하이비어를 참조하게 하자.
    [SerializeField] private MonoBehaviour spawnPrefab;

    [Header("초기 풀 생성 개수")]
    [SerializeField] private int startPoolCount = 10;

    [Header("스폰 간격")]
    [SerializeField] private float spawnInterval = 2.0f;

    [Header("랜덤 스폰 최소/최대 좌표->스포너 위치기준 X,Z 축에 쓰일거")]
    [SerializeField] private Vector3 minPos;
    [SerializeField] private Vector3 maxPos;

    //씬에 활성화된 현재 프리팹 개수 저장용
    private int curCount = 0;

    //씬 시작 시에 풀을 생성, 그리고? 인터벌 만큼 반복할거 코루틴? 인보크?
    private void Start()
    {
        //초기 생성 개수 만큼 지정 프리팹 생성
        GameManager.Pool.CreatePool(spawnPrefab, startPoolCount);

        //인보크로 SpawnPrefab 무한반복, 1초후 실행, 이후 지정 스폰 간격으로 실행 
        InvokeRepeating(nameof(SpawnPrefab), 1.0f, spawnInterval);
    }
    
    //스폰에 필요한거-랜덤 좌표, 풀에서 가져오기
    private void SpawnPrefab()
    {
        //현재 스폰수 >= 초기설정 최대수 . 무시-
        if (curCount >= startPoolCount) return;

        //최소 최대 영역 좌표 xz에 넣어주고,높이는 0, 스포너 높이 잘 조정해야된디
        Vector3 spawnPos = new Vector3(Random.Range(minPos.x, maxPos.x),0.0f,Random.Range(minPos.z, maxPos.z));

        //풀에서 가져오고(없으면 생성, 있으면 재사용)
        MonoBehaviour obj = GameManager.Pool.GetFromPool(spawnPrefab);

        //위치 정해주고
        obj.transform.position = spawnPos;
        //생성 후 비활성화 된거 활성화용
        obj.gameObject.SetActive(true);

        curCount++; //일단 임시로 맥스치 제한 두긴 했는데, 이걸 충돌했을때 줄여줘야해. 콜백써야되나?
    }
}
