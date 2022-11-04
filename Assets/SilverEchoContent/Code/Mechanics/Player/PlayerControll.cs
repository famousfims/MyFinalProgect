using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{

    

    public GameObject camera_game_object; //Камера
    public float camera_hight=0.5f;
    public CharacterController char_controller;// Фізичне тіло гравця



   
    public float min_cam, max_cam;//Чувствивтельность камеры.
   
   
    public AudioClip hevy_breath_a_clip;
    public float hevy_breath_cooldown_timer = 5f;
    public AudioSource source;
    public int footstep_counter = 0;
    public Image stamina_img;



    [Header("Статусы персонажа")]
    public float speed, sprint_multipliyer; //скорость передвижения персонажа
    public float jump_force; // сила прыжка персонажа
    public bool isGrounded, isRunning;
    public float stamina, stamina_max;// Выносливость
    public bool isHidden;

    RaycastHit _hitInfo;
    public  float gravity_velocity;

    [Header("Переменные для свайпа")]
    public float delta_hor;
    public float delta_vertical;
    public float swipe_speed;


    [Header("Кнопки")]
    public FloatingJoystick left_joystick;
    public VirtualButton sprint;
    public VirtualButton jump;
    public VirtualButton trow;

    [Header("Ввод пользователя")]
    public Vector2 scr_joy_input, gamepad_joy_input;


    void UpdateSenvityFromSettings()
    {
        
        

         

    }
    /*
    public void PlayFootSteps()
    {
        footstep_cooldown -= Time.deltaTime;
        if (footstep_cooldown < 0)
        {
            source.PlayOneShot(footsteps[footstep_counter]);
            footstep_counter++;
            footstep_cooldown = footstep_delay / footsteps_speed /sprint_multipliyer;
        }
        if (footstep_counter > 1) footstep_counter = 0;

    }
    */

    // Use this for initialization
    void Start()
    {
        UpdateSenvityFromSettings();
    
    }

    public void SwipeRotation() // Функция которая отвечает за трасировку нажатий и поворот камеры относительно смещения нажатий
    {
        Vector2 mouse_input;
        mouse_input.x = Input.GetAxis("Mouse X");
        mouse_input.y = Input.GetAxis("Mouse Y");

        if (mouse_input != Vector2.zero && Input.touchCount == 0) // Якщо дотиків немає, і є імпульси від мишки.
        {
            delta_hor += mouse_input.x * swipe_speed/2  /* Time.deltaTime*/;
            delta_vertical -= mouse_input.y * swipe_speed/2   /* Time.deltaTime*/;
            transform.localEulerAngles = new Vector3(0f, delta_hor, 0f);
            camera_game_object.transform.localEulerAngles = new Vector3(ClampAngle(delta_vertical, min_cam, max_cam), 0f, 0f);
        }


        if (Input.touchCount == 1) // Если нажатие только одно
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2) // Если первое нажатие было с правой стороны.
            {
                delta_hor += Input.GetTouch(0).deltaPosition.x * swipe_speed * Time.deltaTime;
                delta_vertical -= Input.GetTouch(0).deltaPosition.y * swipe_speed *Time.deltaTime;
                transform.localEulerAngles = new Vector3(0f, delta_hor, 0f);
                camera_game_object.transform.localEulerAngles = new Vector3(ClampAngle(delta_vertical, min_cam, max_cam), 0f, 0f);
            }
        }

        if (Input.touchCount == 2)// Если нажатие не одно
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)// Если первое нажатие с правой стороны (а второе с левой)
            {

                delta_hor += Input.GetTouch(0).deltaPosition.x * swipe_speed * Time.deltaTime;
                delta_vertical -= Input.GetTouch(0).deltaPosition.y * swipe_speed  *Time.deltaTime;
                transform.localEulerAngles = new Vector3(0f, delta_hor, 0f);
                camera_game_object.transform.localEulerAngles = new Vector3(ClampAngle(delta_vertical, min_cam, max_cam), 0f, 0f);
            }

            if (Input.GetTouch(1).position.x > Screen.width / 2) // Если 
            {

                delta_hor += Input.GetTouch(1).deltaPosition.x * swipe_speed * Time.deltaTime;
                delta_vertical -= Input.GetTouch(1).deltaPosition.y * swipe_speed* Time.deltaTime;
                transform.localEulerAngles = new Vector3(0f, delta_hor, 0f);
                camera_game_object.transform.localEulerAngles = new Vector3(ClampAngle(delta_vertical, min_cam, max_cam), 0f, 0f);
            }
           


        }

      


    }

    bool GroundCheck()
    {
        int l_mask = 1 << 9; l_mask = ~l_mask;
        var temp = Physics.SphereCast(transform.position, 0.5f, -transform.up, out _hitInfo, 1, l_mask);
        Debug.DrawLine(transform.position, transform.position - transform.up * 10, Color.red);
        isGrounded = temp;
        return temp;
    }


    float ClampAngle(float angle, float from, float to) // Функция которая держит угол наклона в определенном промежутке (чтоб камера не крутилась на 360*  по оси x)
    {

        if (angle > 180) angle -= 360;
        angle = Mathf.Clamp(angle, from, to);
        return angle;
    }





    private void LateUpdate()
    {
        SwipeRotation();

    }
    // Update is called once per frame
    public void MoveCharacter() 
    {

        
        scr_joy_input.x = left_joystick.Horizontal;
        scr_joy_input.y = left_joystick.Vertical;
        gamepad_joy_input.x = Input.GetAxis("Horizontal");
        gamepad_joy_input.y = Input.GetAxis("Vertical");

        var temp_vel = new Vector3(0, gravity_velocity, 0); //создаем енерцию персонажа (в какую сторону его "тянет")
        // Налаштовуємо вектор напрямку виходячи з введення клавіатури або джойстиків.
         if (scr_joy_input != Vector2.zero)
            {
            //******* зчитування з сенсорного вводу. 
                temp_vel.x = scr_joy_input.x; // переменная h принимает значение от -1 до 1 в зависимости от нажатых клавиш A или D
                temp_vel.z = scr_joy_input.y; // тоже самое только с клавишами W и S
            }
         else
            {
            //******* зчитування з фізичного(клавіатура/ фіз.джойстик.) вводу. 
            temp_vel.x = gamepad_joy_input.x; // переменная h принимает значение от -1 до 1 в зависимости от нажатых клавиш A или D
            temp_vel.z = gamepad_joy_input.y; // тоже самое только с клавишами W и S
            }
        temp_vel.x *= speed * sprint_multipliyer;
        temp_vel.z *= speed * sprint_multipliyer;




        temp_vel.y = temp_vel.y * speed; // робимо гравітацію.
        gravity_velocity -= 5f * Time.deltaTime;
        if (gravity_velocity < -6) gravity_velocity = -6;
        // Якщо зажали кнопку спрінта, автоматом біжимо з більшою швидкістью
        if (sprint.is_pressed || Input.GetKey(KeyCode.LeftShift))
        {
           isRunning = true; 

        }
        else
        {
            isRunning = false;
        }
        // Якщо персонаж біжить - виконується механіка бігу
        if (isRunning)
        {
            hevy_breath_cooldown_timer -= Time.deltaTime;
            if (stamina > 0.35)
            {
                temp_vel.z = speed * sprint_multipliyer; // тоже самое только с клавишами W и S
                sprint_multipliyer = 2.5f;
            }
            else 
            {
                if (hevy_breath_cooldown_timer <= 0) 
                {
                    hevy_breath_cooldown_timer = 5f;
                    source.PlayOneShot(hevy_breath_a_clip);
                }
                sprint_multipliyer = 0;
            }
            stamina -= Time.deltaTime;
               

        }
        else 
        {
            sprint_multipliyer = 1;
          
            if (stamina <= stamina_max) stamina += Time.deltaTime;
            
        }
        if (stamina < 0) stamina = 0; //Обрізаємо стаміну, щоб не уходила в мінус
        //Якщо ми на землі, і натиснули кнопку прижка  на клавіатурі або екрані - пригаємо
        if (isGrounded && (Input.GetButtonDown("Jump") || jump.is_pressed))
        {
           gravity_velocity = jump_force;

        }
        char_controller.Move(transform.TransformDirection(temp_vel)*Time.deltaTime);

    }
   

    void Update()
    {
        UpdateSenvityFromSettings();
        GroundCheck();
        MoveCharacter();
        float stamina_percent = (stamina * 100) / stamina_max;
        stamina_img.fillAmount = stamina_percent / 100;

    }
}
