using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public SpriteRenderer sR;

    public Sprite Pistol;
    public Sprite Revolver;
    public Sprite DoubleBarrel;
    public Sprite MachineGun; 
    public Sprite LazerGun; 
   // public Sprite MachineGun; 

    public float fireRate = 5f; 
    public float Damange = 10f;
    public LayerMask notToHit;
    
    public Transform BulletTrailPrefab;
    public Transform LazerTrailPrefab; 

    ZombieAi zombie;

    float lastShot; 
    float timeToFire = 0f;
    Transform firePoint;
    Transform firepoint2; 

    bool showGun;
    bool Melee; 

    float travDist; 
    int maxBul;
    int Maximum; 

    bool canShoot;
   
    public GUISkin skin; 

	// Use this for initialization
	void Start () {
        sR.sprite = null; 
        maxBul = 50;
        Melee = true;

        ChangeGun(6); 

        firepoint2 = transform.FindChild("FirePoint2"); 
        firePoint = transform.FindChild("FirePoint");
        zombie = GameObject.FindGameObjectWithTag("Zombie").GetComponent<ZombieAi>(); 
        showGun = false;

        MaximumBul(maxBul); 
	}
	
	// Update is called once per frame
	void Update () {
        CountBullets();
       
        // Remember to Remove this 

        if (Input.GetKeyDown(KeyCode.R))
        {
            
        }

        if (sR.sprite != null)
        {
            showGun = true; 
        }

        if (!showGun)
        {
            canShoot = false; 
        }
        else
        {
            canShoot = true; 
        }

        if (Melee)
        {
            if (fireRate == 0)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Q))
                {
                    Shoot();
                }

            }
        }

        if (canShoot)
        {
            if (showGun)
            {
                CountBullets(); 
                sR.enabled = true;
            }
            else
            {
                sR.enabled = false;
            }

            if (sR.sprite != MachineGun)
            {
            
                if (fireRate == 0)
                {
                    if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Q))
                    {
                        CountBullets();
                        Shoot();
                    }
                        
                }
            }
            else
            {
                if (fireRate != 0)
                {
               
                    if (Input.GetButton("Fire1") && Time.time > timeToFire + lastShot)
                    {
                        Shoot();
                        lastShot = Time.time;
                    }
                } 
            }

        }
	}


    #region  Bullet Atributes
    void CountBullets()
    {
        if (maxBul <= 0)
        { 
            canShoot = false; 
        }
        if (maxBul >= 0)
        {
            canShoot = true;
        }
    }
    

    public void AddBullets(int bul)
    {
        maxBul = maxBul + bul; 
    }

    public void MaximumBul(int bul)
    {
        Maximum = Maximum + bul; 
    }

    public void ChangeGun(int gunNum)
    {
        if (gunNum == 1)
        {
            canShoot = true;
            Melee = false; 
            sR.sprite = Pistol;
            travDist = 20f;
            fireRate = 0; 
            Damange = 5f; 
        }
        if (gunNum == 2)
        {
            canShoot = true;
            Melee = false; 
            sR.sprite = Revolver;
            travDist = 20f;
            fireRate = 0; 
            Damange = 10f; 
        }
        if (gunNum == 3)
        {
            canShoot = true;
            Melee = false;
            sR.sprite = DoubleBarrel;
            Damange = 50;
            fireRate = 0; 
            travDist = 3f; 
        }
        if (gunNum == 4)
        {
            canShoot = true; 
            Melee = false;
            sR.sprite = LazerGun;
            Damange = 8f;
            fireRate = 0; 
            travDist = 20f; 
        }
        if (gunNum == 5)
        {
            canShoot = true; 
            Melee = false; 
            fireRate = 0.5f;
            sR.sprite = MachineGun;
            Damange = 8;
            travDist = 20f; 
        }
        if (gunNum == 6)
        {
            canShoot = false; 
            Melee = true;
            Damange = 2f;
            fireRate = 0;
            travDist = .5f;
            print("HAnd Huns");
        }
    }

    #endregion




    public void Show()
    {
        showGun = false;
        sR.sprite = null;
        ChangeGun(6); 
    }
    public void oShow(bool shw)
    {
        showGun = shw; 
    }

    void Shoot()
    {
        if (canShoot)
        {
           

            maxBul = maxBul - 1;

            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition).y));
            Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

            RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, travDist, notToHit);
            Effect();


            Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);
    
            if (hit.rigidbody.GetComponent<Rigidbody2D>() != null)
            {

                Debug.DrawLine(firePointPosition, hit.point, Color.red);
                Debug.Log("you hit " + hit.collider.name); 


                EnemyHealth health = hit.rigidbody.GetComponent<Collider2D>().GetComponent<EnemyHealth>();
                health.TakeDamage(Damange);

            }
            if (hit.collider.tag == "Cyclops")
            {
                CyclopsAI cyclops = hit.collider.GetComponent<CyclopsAI>();
                cyclops.Passiveness(); 

            }
        }

        if (Melee)
        {
            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition).y));
            Vector2 firePointPosition = new Vector2(firepoint2.position.x, firepoint2.position.y);
            
            RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, travDist, notToHit);

            Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);

            if (hit.rigidbody.GetComponent<Rigidbody2D>() != null)
            {
                Debug.Log(hit.rigidbody.name); 
                Debug.DrawLine(firePointPosition, hit.point, Color.red);

                Debug.Log(hit.distance); 
                EnemyHealth health = hit.collider.GetComponent<Collider2D>().GetComponent<EnemyHealth>();
                health.TakeDamage(Damange);

            }
        }
       
    }
    void Effect()
    {
        if (canShoot)
        {
            if (Application.loadedLevel == 1)
            {
                if (sR.sprite != LazerGun)
                {
                    GetComponent<AudioSource>().Play();
                    Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
                }
                else
                {
                    Instantiate(LazerTrailPrefab, firePoint.position, firePoint.rotation);
                }
            }
            if (Application.loadedLevel == 2)
            {
                if (sR.sprite != LazerGun)
                {
                    GetComponent<AudioSource>().Play();
                    Network.Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation,0);
                }
                else
                {
                    Network.Instantiate(LazerTrailPrefab, firePoint.position, firePoint.rotation,0);
                }
            }
        }
        
    }

    void OnGUI()
    {
        if (canShoot)
        {
            GUI.skin = skin;
            GUI.Box(new Rect(Screen.width - 150, Screen.height - 70, 100, 50), maxBul.ToString() + " / " + Maximum.ToString(), skin.GetStyle("GunCount"));
        }
    }
}
