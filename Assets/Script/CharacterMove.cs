using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMove : MonoBehaviour

{
    public float movementSpeed = 1.5f;
    private Vector3 origionalPosition;
    private bool canMove = true;
    private BoxCollider2D Collider;

    public float knockBackDistence;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        origionalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, movementSpeed * Time.deltaTime);
                animator.SetInteger("Direction", -1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -movementSpeed * Time.deltaTime);
                animator.SetInteger("Direction", 1);
            }
            else animator.SetInteger("Direction", 0);
        }
    }

    private IEnumerator KnockBack()
    {
        Collider.enabled = false;
        canMove = false;
        Vector3 KnockBackDest = transform.position - new Vector3(0, knockBackDistence);

        while(transform.position.y > KnockBackDest.y)
        {
            transform.position -= new Vector3(0, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        }
        Debug.Log("AAAA");
        Collider.enabled = true;
        canMove = true;
        yield return null;
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            transform.position = origionalPosition;
            ScoreController.Singleton.IncrementPlayer1Score();
        }

        if (collision.gameObject.tag == "Car")
        {
            StartCoroutine(KnockBack());
        }
    }
}
