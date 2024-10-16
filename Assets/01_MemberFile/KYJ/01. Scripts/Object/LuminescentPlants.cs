using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuminescentPlants : MonoBehaviour
{
    [Header("Player Input")]
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GameObject _hotkey;

    public bool _isReach;
    public bool _isHold;

    public  Action OnPlants;
    private Rigidbody2D _rigidCompo;


    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HoldPlants(_playerTrm);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _hotkey.gameObject.SetActive(true);
            _isReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _hotkey.gameObject.SetActive(false);
        _isReach = false;
    }

    private void HoldPlants(Transform parent)
    {
        if (_isReach == true && !_isHold && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.SetParent(parent);
            _rigidCompo.bodyType = RigidbodyType2D.Kinematic;
            _hotkey.gameObject.SetActive(false);
            _isHold = true;
        }
/*        else if (_isHold == true && Input.GetKeyDown(KeyCode.K))
        {
            gameObject.transform.SetParent(null);
            _rigidCompo.bodyType = RigidbodyType2D.Dynamic;
            _isHold = false;
        }*/

        if (_isHold == true)
        {
            OnPlants?.Invoke();
        }
    }
}
