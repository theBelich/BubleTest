using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Color _color => gameObject.GetComponent<SpriteRenderer>().color;
    public System.Action<GameObject> onDestroy;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeColor();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Bubble" || collision.tag == "PlayersBubble"))
        {
            var color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            if (CheckColor(color))
            {
                try
                {
                    if(gameObject.tag == "Bubble")
                    {
                        var rb = gameObject.AddComponent<Rigidbody2D>();
                        rb.constraints = RigidbodyConstraints2D.FreezeAll;
                        tag = "PlayersBubble";
                        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                    }

                    Destroy(collision.GetComponent<Rigidbody2D>());
                    //Destroy(collision.gameObject);
                    StartCoroutine(LateDestroy(gameObject));
                }
                catch (System.Exception)
                {

                }

            }
            else
            {
                if (collision.tag == "PlayersBubble")
                {
                    //var bubble = Instantiate(collision.gameObject, collision.gameObject.transform.position, Quaternion.identity);
                    Destroy(collision.GetComponent<Rigidbody2D>());
                    collision.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
                    collision.transform.SetParent(gameObject.transform.GetComponentInParent<Transform>());
                    collision.tag = "Bubble";
                    //Destroy(collision.gameObject);
                }
            }
        }
    }

    private void OnDestroy()
    {
        onDestroy?.Invoke(gameObject);
    }

    private void RandomizeColor()
    {
        int rand = Random.Range(0, 100);
        if (rand >= 0 && rand < 33)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            return;
        }

        if (rand >= 33 && rand < 66)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            return;
        }

        if (rand >= 66 && rand <= 100)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private IEnumerator LateDestroy(GameObject collision)
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
        Destroy(collision);
    }

    private bool CheckColor(Color color)
    {
        if (color == _color)
        {
            return true;
        }
        return false;
    }
}
