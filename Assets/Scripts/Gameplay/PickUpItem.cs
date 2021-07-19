using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform _player;
    [SerializeField] float _speed = 5f;
    [SerializeField] float _pickUpDist = 1.5f;
    [SerializeField] float _tTL = 10f;

    WasteManager wasteManager;

    public Item _item;
    public int _amount = 1;

    private void Start()
    {
        _player = GameManager.instance.player.transform;

        wasteManager = GameObject.Find("Game Manager").GetComponent<WasteManager>();
    }

    private void Update()
    {
        _tTL -= Time.deltaTime;
        if(_tTL < 0) { Destroy(gameObject); }

        float _myDist = Vector3.Distance(transform.position, _player.position);
        if (_myDist > _pickUpDist)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);

        if (_myDist < 1)
        {
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(_item, _amount);
            }
            else
            {
                Debug.LogWarning("No inventory container attached to the Game Manager");
            }

            wasteManager.WasteCollected();

            Destroy(gameObject);
        }
    }

}
