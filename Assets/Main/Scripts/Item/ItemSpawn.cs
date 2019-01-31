using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    [SerializeField] GameObject[] _item = null;

    [SerializeField] GameObject[] _item_pos = null;

    [SerializeField] GameObject[] _empty_pos = null;

    [SerializeField]
    int _blinkingIntervel = 0;
    GameObject _hurryUp;
    
    int _item_no = 0;
    const int APPEAR_LIMIT = 14;

    // Use this for initialization
    void Start()
    {
        _hurryUp = GameObject.FindWithTag("HurryUpText");
        _hurryUp.SetActive(false);

        _empty_pos = new GameObject[transform.childCount];
        _item_pos = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _empty_pos[i] = transform.GetChild(i).gameObject;
        }

        itemSet();
    }

    private void FixedUpdate()
    {
        if (!HasItem())
        {
            if (_blinkingIntervel > 10)
            {
                _hurryUp.SetActive(!_hurryUp.activeSelf);
                _blinkingIntervel = 0;
            }
            else
                _blinkingIntervel++;
        }
    }
    
    void itemSet()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int empty_pos_no = Random.Range(0, transform.childCount);

            while (_item_pos[empty_pos_no] != null)
            {
                empty_pos_no = Random.Range(0, transform.childCount);
            }
            _item_pos[empty_pos_no] = Instantiate(_item[_item_no % _item.Length], _empty_pos[empty_pos_no].transform.position, Quaternion.identity);
        }
        _item_no++;
    }

    bool HasItem()
    {
        bool tmp = false;

        for (int i = 0; i < _item_pos.Length; i++)
        {
            if (_item_pos[i] != null)
            {
                tmp = true;
            }
        }
        return tmp;
    }
}