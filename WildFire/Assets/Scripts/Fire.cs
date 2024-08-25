using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] int live = 1;
    [SerializeField] GameObject explosion;
    Transform player;
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        if(tree.instance.live == 0)
        {
            tree.instance.Over();
            CancelInvoke("TreeDie");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lance")
        {
            HealthManager.instance.Heal(4);
            live--;
            if (live <= 0)
            {
                AudioGame.instance.PlayDamageClip();
                GameManager.instance.increasePoint();
                CancelInvoke("TreeDie");
                StartCoroutine("SetGameObject");
                //Destroy(gameObject, 0.1f);
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            InvokeRepeating("TreeDie", 0, 1);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CancelInvoke("TreeDie");
        }
    }

    void TreeDie()
    {
        tree.instance.Die();
    }

    IEnumerator SetGameObject()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
    
}
