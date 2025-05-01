using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public bunnyTeleport teleporter;
    private Transform target;
    public float targetDistance;
    [SerializeField] private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
	target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) < targetDistance)
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