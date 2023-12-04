using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cornStalkScript : MonoBehaviour
{

    [SerializeField] private Animator animationController;
    [SerializeField] private AnimationClip clip;
    private GameObject Player;
    [SerializeField] private Transform playerTransform;
    




    void Awake()
    {        
        this.GetComponent<Collider>().isTrigger = true;


        //animationController.enabled = false;
        //Player = GameObject.Find("FPSController");
        //playerTransform = Player.GetComponent<Transform>();
    }

    void Update()
    {
        //transform.LookAt(playerTransform);
        //transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {

        //print("trigger Enter");
        if (other.CompareTag("Player"))
        {
            //animationController.enabled = true;
            //print("trigger Player Enter");
            animationController.SetBool("Play", true);
            StartCoroutine(animationPlay());
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //print("trigger Exit");
        if (other.CompareTag("Player"))
        {
            //print("trigger Player Exit");
            animationController.SetBool("Play", false);
            //animationController.enabled = false;
        }
    }

    IEnumerator animationPlay()
    {
        yield return new WaitForSeconds(.5f);
        print(clip.length);
        animationController.SetBool("Play", false);
        //print("animation Done");
    }
}
