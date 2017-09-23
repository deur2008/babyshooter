using UnityEngine;
using System.Collections;

//雷射的子彈
public class BulletLaser : MonoBehaviour {

    public int damagePerShot = 3;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.


    float timer;                                    // A timer to determine when to fire.
    Ray shootRay;                                   // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    ParticleSystem gunParticles;                    // Reference to the particle system.
    LineRenderer gunLine;                           // Reference to the line renderer.
    AudioSource gunAudio;                           // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.
    public Light faceLight;                             // Duh
    float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.


    void Awake()
    {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask("Shootable");

        // Set up the references.
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        faceLight = GetComponentInChildren<Light> ();
    }


    void Update()
    {
        

        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }
        else
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;
            //發射時更新顯示位置，避免造成Delay
            if(gunLine.enabled==true)
                gunLine.SetPosition(0, transform.position);
            //更新最終位置
            //設定射線最長的長度是這個樣子
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
       
    }


    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        faceLight.enabled = false;
        gunLight.enabled = false;
    }

    //射擊，如果有射到救回傳true
    //然後直接從裡面去取得敵人扣血
    public bool Shoot()
    {
        // Reset the timer.
        timer = 0f;

        // Play the gun shot audioclip.
        gunAudio.Play();

        // Enable the lights.
        gunLight.enabled = true;
        faceLight.enabled = true;

        // Stop the particles from playing if they were, then start the particles.
        gunParticles.Stop();
        gunParticles.Play();

        // Enable the line renderer and set it's first position to be the end of the gun.
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // 如果RayCast有碰到東西
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //取的敵人的弱點
            WeakPoint weakpoint = shootHit.collider.GetComponent<WeakPoint>();
            //如果確定有敵人
            if (weakpoint != null)
            {
                //扣血
                //一發子彈扣一滴血 : )
                weakpoint.SetDamage(damagePerShot);
            }

            //設定射線長度就是在槍到人物，不會超過
            //gunLine.SetPosition(1, shootHit.point);
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
        else
        {
            //設定射線最長的長度是這個樣子
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            return false;
        }
        return false;
    }
}
