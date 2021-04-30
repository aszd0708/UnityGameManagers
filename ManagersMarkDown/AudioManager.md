#### PlaySound
```
public void PlaySound(string clipName, Vector3 pos, Transform parent = null, float pitch = 1f)
    {
        //clips에 있는 모든 AudioClip을 순환하며, 전달받은 clipName과 같은 이름의 클립을 찾아줌
        foreach (AudioClip ac in clips)
        {
            if (ac.name == clipName)
            {
                //찾은 소리를 실제로 재생해달라고 패러미터 넘겨줌
                PlaySound(ac, pos, parent, pitch);
            }
        }
    }
```
파일 이름으로 플레이 하거나
이름들을 넘겨 랜덤으로 플레이를 해줍니다.

소리나는 위치, 부모로 둘 오브젝트, 피치를 변경하여 넣을 수 도 있습니다.

```
public void PlaySound(AudioClip audioClip, Vector3 pos, Transform parent = null, float pitch = 1f)
    {
        //오디오 재생용 프리팝 생성
        AudioSource audioInstance = Instantiate(audioPrefab, pos, Quaternion.identity);

        //소리를 내는 사물을 따라가야 하는 경우, 그 사물의 자식으로 넣어줌
        if (parent != null)
            audioInstance.transform.SetParent(parent);

        audioInstance.clip = audioClip;     //클립을 바꿔주고
        audioInstance.pitch = pitch;        //피치값 설정
        audioInstance.volume = PlayerPrefs.GetInt("EffectSound", 1);
        audioInstance.Play();               //재생

        Destroy(audioInstance.gameObject, audioClip.length);       //오디오클립을 재생 후 인스턴스 삭제
        PoolingManager.Instance.SetPool(audioInstance.gameObject, "Audio", audioClip.length);       // 만약 PoolingManager를 사용하고 있다면 위에 Destroy를 지운뒤 이것 사용
    }
```
실질적인 사운드를 플레이 하는 함수 입니다.
