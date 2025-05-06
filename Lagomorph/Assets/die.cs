using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public bunnyTeleport teleporter;
    public Transform player;
    private bool inRange;
    public float followPlayerRange;
    [SerializeField] private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= followPlayerRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (inRange)
	{
	    _animator.SetBool("ISDEAD", true);
	    teleporter.teleport();
	    StartCoroutine(SelfDestruct());
	}
    }

    IEnumerator SelfDestruct()
    {
	yield return new WaitForSeconds(3.5f);
	Destroy(gameObject);
    }
}