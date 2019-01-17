using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

	[SerializeField] GameObject [ ] _item = null;
	[SerializeField] GameObject [ ] _item_pos = null;
	[SerializeField] GameObject [ ] _empty_pos = null;

	[SerializeField] float _item_reset_timer = 0;
	const float ITEM_RESET_TIME = 5;

	// Use this for initialization
	void Start( ) {
		_item_reset_timer = ITEM_RESET_TIME;
		_empty_pos = new GameObject [ transform.childCount ];
		_item_pos = new GameObject [ transform.childCount ];

		for ( int i = 0; i < transform.childCount; i++ ) {
			_empty_pos [ i ] = transform.GetChild( i ).gameObject;
			_item_pos [ i ] = null;
		}
	}

	// Update is called once per frame
	void Update( ) {
		_item_reset_timer -= Time.deltaTime;

		if ( _item_reset_timer <= 0 ) {
			int item_no = Random.Range( 0, _item.Length );
			int empty_pos_no = Random.Range( 0, transform.childCount );

			if ( _item_pos[ empty_pos_no ] == null ) {
				_item_pos[ empty_pos_no ] = 
					Instantiate( _item [ item_no ], _empty_pos [ empty_pos_no ].transform.position, Quaternion.identity );
			}
				_item_reset_timer = ITEM_RESET_TIME;
		}
	}

}
