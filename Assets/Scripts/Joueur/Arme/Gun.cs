using UnityEngine;

public class Gun : MonoBehaviour

{
    public GameObject bullet;
    public GameObject pump;
    public GameObject cannon;

    private bool isPlayable = false;
    public bool boss = false;

    private bool shoot;

    private float bulletRate = 0.3f;
    private float nextBulletFire;
    private float pumpRate = 1f;
    private float nextPumpFire;

    private float cannonRate = 5f;
    private float nextCannonFire;

    public int weaponNumber = 1;

    private Animator animator;
    
    Transform myTransform;
    
    void Start()
    {
        animator = GetComponent<Animator>();

        nextCannonFire = Time.time + 10f;
    }

    void Update()
    {
        Vector2 pos = transform.position;

        transform.position = pos;
        if (!boss)
        {
            if (pos.x >= -5)
            {
                isPlayable = true;
            }

            if (isPlayable)
            {
                shoot = Input.GetKeyDown(KeyCode.Mouse0);

                if (shoot & weaponNumber % 2 == 0 && Time.time > nextPumpFire)
                {
                    shoot = false;
                    nextPumpFire = Time.time + pumpRate;
                    ShotGun();
                }
                else if (shoot & weaponNumber % 2 == 1 && Time.time > nextBulletFire || shoot & weaponNumber % 2 == -1 && Time.time > nextBulletFire)
                {
                    shoot = false;
                    nextPumpFire = Time.time + bulletRate;
                    MachineGun();
                }

                if (Input.GetAxis("Mouse ScrollWheel") != 0)
                {
                    weaponNumber += Mathf.FloorToInt(Input.GetAxis("Mouse ScrollWheel") * 10);
                    if (weaponNumber % 2 == 0)
                    {
                        animator.SetFloat("changement", -1);
                    }
                    else
                    {
                        animator.SetFloat("changement", 1);
                    }
                }
            }
        }

        else
        {
            if (Time.time > nextCannonFire)
            {
                nextCannonFire = Time.time + cannonRate;
                Canon();
            }
        }
    }

    public void MachineGun()
    {
        GameObject go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
    } 

    public void ShotGun()
    {
        GameObject go0 = Instantiate(pump, transform.position, Quaternion.Euler(0, 0, 0));
        GameObject go1 = Instantiate(pump, transform.position, Quaternion.Euler(0, 0, 15));
        GameObject go2 = Instantiate(pump, transform.position, Quaternion.Euler(0, 0, 30));
        GameObject go3 = Instantiate(pump, transform.position, Quaternion.Euler(0, 0, 45));
        GameObject go4 = Instantiate(pump, transform.position, Quaternion.Euler(0, 0, -15));
        GameObject go5 = Instantiate(pump, transform.position, Quaternion.Euler(0, 0, -30));
        GameObject go6 = Instantiate(pump, transform.position, Quaternion.Euler(0, 0, -45));
    }
    public void Canon()
    {
        GameObject go0 = Instantiate(cannon, transform.position, Quaternion.Euler(0, 0, 0));
        GameObject go1 = Instantiate(cannon, transform.position, Quaternion.Euler(0, 0, 15));
        GameObject go2 = Instantiate(cannon, transform.position, Quaternion.Euler(0, 0, 30));
        GameObject go3 = Instantiate(cannon, transform.position, Quaternion.Euler(0, 0, 45));
        GameObject go4 = Instantiate(cannon, transform.position, Quaternion.Euler(0, 0, -15));
        GameObject go5 = Instantiate(cannon, transform.position, Quaternion.Euler(0, 0, -30));
        GameObject go6 = Instantiate(cannon, transform.position, Quaternion.Euler(0, 0, -45));
    }
}
