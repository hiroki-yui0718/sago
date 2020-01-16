using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Photon.Pun;

public class ShotBullet : MonoBehaviour
{
    public GameObject bullet;
    public float shotSpeed;
    private int Intarval;
    private new PhotonView photonView;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public async void Update()
    {
        if (Anim.Look == true && (Anim.x == 0 && Anim.z == 0))
        {
            Intarval += 5;
            if (Intarval % 60 == 0)
            {
                GameObject bullets = PhotonNetwork.Instantiate("Bullet", transform.position, Quaternion.identity) as GameObject;
                bullets.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
                await Task.Delay(1000);
                PhotonNetwork.Destroy(bullets);
            }
        }
    }

    public void Shot()
    {

    }
}
