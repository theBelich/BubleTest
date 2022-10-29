using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPlayerBubble;
    [SerializeField] private Transform _spawnPlayersBubblePosition;

    [SerializeField] private Transform _wallContainer;

    [SerializeField] private LayerMask _needLayer;
    [SerializeField] private float _bubbleSpeed;

    public Action OnGameWon;

    private bool _isSpawned = false;
    
    private GameObject bubble;
    private Dictionary<GameObject, Vector3> _bubbleMoveToward = new Dictionary<GameObject, Vector3>();

    void Update()
    {

        if (_wallContainer.childCount <= 0)
        {
            OnGameWon?.Invoke();
        }

        if (!_isSpawned)
        {
            StartCoroutine(SpawnBubble());
        }

        if (Input.GetMouseButtonUp(0) && bubble != null && _isSpawned)
        {

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            //bubble.transform.position = worldPosition;

            bubble.GetComponent<Bubble>().onDestroy += OnDestroyPlayersBubble;
            _bubbleMoveToward.Add(bubble, worldPosition);
            _isSpawned = false;
        } 
    }

    private void FixedUpdate()
    {
        foreach (var bubble in _bubbleMoveToward)
        {
            try
            {
                //bubble.Key.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
                bubble.Key.GetComponent<Rigidbody2D>().AddForce(bubble.Value * _bubbleSpeed);
            }
            catch (System.Exception)
            {

            }
            //bubble.Key.transform.position = Vector2.MoveTowards(bubble.Key.transform.position, bubble.Value, _bubbleSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);   
    }

    private void OnDestroyPlayersBubble(GameObject bubble)
    {
        _bubbleMoveToward.Remove(bubble);
    }

    private IEnumerator SpawnBubble()
    {
        _isSpawned = true;
        yield return new WaitForSeconds(0.2f);
        bubble = Instantiate(_spawnPlayerBubble, _spawnPlayersBubblePosition);
    }
}
