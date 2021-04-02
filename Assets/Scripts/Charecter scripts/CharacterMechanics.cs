using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    //Основные параметры
    public float speed;// скорость персонажа
    public float jumpPow;//сила прыжка
    public float sensivity;// сокрость поворота персонажа с помощью мыши
    
    //Параметры геймплея для персонажа
    private float gravForce;//гравитация персонажа
    private Vector3 moveVector;//направление движения пресонажа

    //Ссылки на компонетны
    private CharacterController ch_controller;
    private Animator ch_animator;

    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        //ch_animator = GetComponent<Animator>();
    }

    void Update()
    { 
        /*if (Input.anyKey == false)
        {
            return;
        }*/
        GamingGravity();
        
        CharacterMove();
    }
    private void CharacterMove() 
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.z = Input.GetAxis("Vertical") * speed;
        moveVector.y = gravForce;
        ch_controller.Move(moveVector * Time.deltaTime);//метод движения по направлению
    }
    //метод гравитации
    private void GamingGravity() 
    {
        if (!ch_controller.isGrounded)
        {
            gravForce -= 100f * Time.deltaTime;
        }
        else 
        {
             gravForce = -1f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded) 
        {
             gravForce = jumpPow;
        }
    }
}
