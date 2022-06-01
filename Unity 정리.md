## Unity 정리

### LifeCycle

- Satrt() : 처음에 한번
- Update(): 살아가며 계속 움직이는 경우



### 6차시

- pulic 변수로 사용하면 유니티에서 변수 편집이 가능하다.

- Scene : 파일이 아니다 

- Project : 실제 파일들 (Scene을 Project로 옮기면 파일로 만들수 있다:prefab)

  **[총알 발사]**

  ```c#
  public GameObject bulletFactory;
  public GameObject firePosition;
  
  void Update()
  {
      // 1. 사용자가 마우스 왼쪽 버튼을 누르면
      if (Input.GetButtonDown("Fire1"))
      {
          // 2. 총알공장에서 총알을 만들어서
          GameObject bullet = Instantiate(bulletFactory);
          // 3. 총구 위치에 가져다 놓고싶다.
          bullet.transform.position = firePosition.transform.position;
  
      }
  }
  
  ```

  - Instantiate() : GameObject를 다시 Prefab으로 만들어주는 함수  ==> 다시 Scene에 표현

  - 기지모: 색깔을 바꿔준다. (개발 환경에서만 구분 가능하도록)

    **[적 이동]**

    ```C#
    public class Enemy : MonoBehaviour
    {
        // -방향
        Vector3 dir;
        
        // -속력
        public float speed = 5;
        // Start is called before the first frame update
        void Start()
        {
            // 태어날 때
            // 1. 30% 확률로 플레이어 방향, 나머지 확률로 아래방향으로 정하고
            int result = UnityEngine.Random.Range(0, 10);
            if (result < 3)
            {
                // 플레이어 방향,
                GameObject target = GameObject.Find("Player");
                // target - me :
                dir = target.transform.position - transform.position;
                dir.Normalize();
            }
            else
            {
                // 아래방향
                dir = Vector3.down;
            }
            
        }
    
        // Update is called once per frame
        void Update()
        {
            // 살아가면서 그 방향으로 계속 이동하고 싶다.
            transform.position += dir * speed * Time.deltaTime;
            
        }
    }
    ```

    - GameObject.Find("Player") => Player를 찾을 수 있다.
    - 백터의 뺄셈 Target - me : 방향을 구할 수 있다.



