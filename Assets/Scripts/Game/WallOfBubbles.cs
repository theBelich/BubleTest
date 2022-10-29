using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfBubbles : MonoBehaviour
{
    [SerializeField] private float _timeBeforeWallDown;
    [SerializeField] private float _timeToWallGoingDown;
    [SerializeField] private float _wallSpeed;

    private bool _isWallGoingDown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownTheWall());
    }

    private IEnumerator DownTheWall()
    {
        yield return new WaitForSeconds(_timeBeforeWallDown);
        _isWallGoingDown = true;
        yield return new WaitForSeconds(_timeToWallGoingDown);
        _isWallGoingDown = false;
        StartCoroutine(DownTheWall());
        CheckIfWallIsEmpty();
    }

    private void CheckIfWallIsEmpty()
    {
        if (transform.childCount <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void FixedUpdate()
    {
        if (_isWallGoingDown)
        {
            transform.Translate(0, -1 * _wallSpeed, 0);
        }
        if (transform.childCount <=0)
        {
            Destroy(gameObject);
        }
    }
}
