using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloading : MonoBehaviour
{
    GameObject player;
    public AudioSource Reloadfx;

    public void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        MoveGameObject();
    }
    public void MoveGameObject()
    {
           transform.position = player.transform.position + new Vector3(0, 1.5f, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Reloadfx.PlayDelayed(0.2f);

        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

    }
}
