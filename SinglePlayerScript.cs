using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class SinglePlayerScript : MonoBehaviour {

    private PlayerStats playStat;
    private HeadGear headGear; 

    public Transform vehicle;
    bool KeyboardControl = false;
    public SpriteRenderer spriteRend;
    public Collider2D coll;
    public Rigidbody2D ME;
   // public Transform myPos; 
    public float speed = 1f;
    float run = 2f;
    public bool running; 
    bool PlayerControl = true;
    private Projectile projectile; 
    
    // gui elements
    public GUISkin skin; 
    bool showText;
    int curText;
    List<string> dialog = new List<string>();
    Vector3 myPos;
    string text = "Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test"; 

    void Start()
    {
        showText = false;

        myPos = new Vector3(transform.position.x, transform.position.y); 


        headGear = transform.FindChild("HeadGear").GetComponent<HeadGear>(); 
        playStat = GetComponent<PlayerStats>(); 
        projectile = transform.FindChild("Hands").GetComponent<Projectile>();
        running = false;

        if (spriteRend.enabled == true)
        {
            projectile.oShow(true); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevel == 2)
        {
            if (GetComponent<NetworkView>().isMine)
            {
                InputMovement();
            }
        }
        if (Application.loadedLevel == 1)
        {
            InputMovement();  
        }
        else
        {
            InputMovement(); 
        }
        

    }

    void InputMovement()
    {
        if (PlayerControl == true)
        {
            if (KeyboardControl == false)
            {
                Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);        //Mouse position
                Vector3 objpos = Camera.main.WorldToViewportPoint(transform.position);        //Object position on screen
                Vector2 relobjpos = new Vector2(objpos.x - 0.5f, objpos.y - 0.5f);            //Set coordinates relative to object
                Vector2 relmousepos = new Vector2(mouse.x - 0.5f, mouse.y - 0.5f) - relobjpos;
                float angle = Vector2.Angle(Vector2.up, relmousepos);    //Angle calculation
                if (relmousepos.x > 0)
                    angle = 360 - angle;
                Quaternion quat = Quaternion.identity;
                quat.eulerAngles = new Vector3(0, 0, angle); //Changing angle
                transform.rotation = quat;


                if (Input.GetKey(KeyCode.W))
                {
                    playStat.Stamina(); 
                    GetComponent<Rigidbody2D>().AddForce(relmousepos);
                    
                    GetComponent<Rigidbody2D>().velocity = relmousepos.normalized * speed;

                }
                else if (Input.GetKey(KeyCode.S))
                {
                    GetComponent<Rigidbody2D>().velocity = -1 * relmousepos.normalized * speed;
                    playStat.Stamina(); 
                }
               
                else
                {
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                }

                if (running)
                {


                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        speed = run;
                    }
                    else
                    {
                        speed = 1f;
                    }
                }
                else
                {
                    speed = 1f; 
                }

            }
        }
    }

    public void RunBool(bool pRun)
    {

        if (pRun)
        {
            running = true;
        }
        else
        {
            running = false; 
        }
    }

    void KeyBoardControl()
    {


        if (KeyboardControl)
        {

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-1 * Vector2.up * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(-1 * Vector3.forward * 3);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.forward * 3);
            }
            if (running)
            {


                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = run;
                }
                else
                {
                    speed = 1f;
                }
            }
            else
            {
                speed = 1f;
            }
        }

    }




    public void Hide()
    {

        headGear.Hide(); 
        transform.parent = vehicle;

        //speed = 5f; 
        spriteRend.enabled = false;
        ME.GetComponent<Rigidbody2D>().isKinematic = true;
        PlayerControl = false;
        KeyboardControl = false;
        coll.enabled = false;
    }

    public void Show()
    {

        headGear.Show();
        transform.parent = null;
        ME.GetComponent<Rigidbody2D>().isKinematic = false;
        spriteRend.enabled = true;
        PlayerControl = true;
        ExitVehicle(5);
        coll.enabled = true;
    }

    IEnumerator ExitVehicle(float time)
    {
        GetComponent<Collider2D>().enabled = false; 

        yield return new WaitForSeconds(time); 
    }
    
    public void StatSet(float gSpeed)
    {
        speed = gSpeed; 
    }

    void OnGUI()
    {
        GUI.skin = skin;  
        if (showText)
        {

            // left, top, width, height
            GUI.Box(new Rect(Screen.width / 2 + 10, Screen.height / 2 + 10, text.Length * 10, 50), text, skin.GetStyle("ChatSkin"));
            
        }
    }
    public void Speak(string text, bool shwText)
    {
        showText = shwText;
        dialog.Add(text);

        if (!shwText)
        {
            dialog.Clear(); 
        }
    }

    void NewSkin()
    {
        if (Application.loadedLevel == 2)
        {

        }
    }
}
