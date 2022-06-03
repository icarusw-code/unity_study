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



### 7차시 - 물리엔진과 충돌 시스템

**Unity 물리체계**

- 움직이지 않는 물체 (Static Object) 와 움직이는 물체(**Dynamic Object**)로 구분한다.
- Dynamic Object에 대해서만 충돌 검사를 한다 -> 실제로 움직이는 물체만이 충돌이 가능하다.
- 실행할때 Static과 Dynamic을 구분하여 물리시스템을 구성하며, 실행중 Static 물체가 움직이면 물리시스템을 다시 구성한다.
- 따라서, Static 물체를 움직이게 되면 큰 시스탬 과부하가 내부적으로 생긴다 
- ==> 이를 위헤 **움직이는 물체는 Rigidbody 컴포넌트**를 붙여 움직이는 물체라는 것을 표시한다.

- 컴포넌트 추가 => Physics => Rigidbody

  ![image-20220601224246044](C:\Users\CHOI\AppData\Roaming\Typora\typora-user-images\image-20220601224246044.png)

GetComponet를 통해서 컴포넌트를 가져올 수 있다.

```c#
// PlayerFire 가져옴
PlayerFire pFire = other.GetComponent<PlayerFire>();
```



### 11차시

- Lerp(선형보간) => 함수가 제공됨

  0: nearPosition, 1:farPosition

​        Vector3 camPosition = Vector3.Lerp(nearPosition, farPosition, wheelValue);

- wheelValue = Mathf.Clamp(wheelValue, 0, 1.0f); => 범위를 제한 할 수 있다.



### 12차시

- FSM(유한상태머신, Finite State Machine)
  - 상태(State): 객체의 행동
  - 전이(Transrate): 상태의 이동
  - 조건(Condition): 전이하기 위한 조건



### 13차시

- 코루틴(Coroutine)
  - 루틴이란 함수와 같은 개념
  - 함께 동작하는 함수 즉, 동시에 실행되는 함수를 의미한다.
  - 여러개의 진입점을 가진다.

![image-20220603191143599](C:\Users\CHOI\AppData\Roaming\Typora\typora-user-images\image-20220603191143599.png)



싱글톤패턴

- 단 하나의 객체를 생성해서 사용하는 디자인패턴
