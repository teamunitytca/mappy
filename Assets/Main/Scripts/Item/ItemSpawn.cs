using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour {

	[SerializeField] GameObject [ ] _item = null;
	[SerializeField] GameObject [ ] _item_pos = null;
	[SerializeField] GameObject [ ] _empty_pos = null;


	// Use this for initialization
	void Start( ) {
		_empty_pos = new GameObject [ transform.childCount ];
		_item_pos = new GameObject [ transform.childCount ];

		for ( int i = 0; i < transform.childCount; i++ ) {
			_empty_pos [ i ] = transform.GetChild( i ).gameObject;
		}
		itemSet( );
	}

	// Update is called once per frame
	void Update( ) {

	}

	void itemSet( ) {

		for ( int i = 0; i < transform.childCount; i++ ) {
			int item_no = Random.Range( 0, _item.Length );
			int empty_pos_no = Random.Range( 0, transform.childCount );
			while ( _item_pos [ empty_pos_no ] != null ) {
				empty_pos_no = Random.Range( 0, transform.childCount );
			}
			_item_pos [ empty_pos_no ] = Instantiate( _item [ item_no ], _empty_pos [ empty_pos_no ].transform.position, Quaternion.identity );
		}
	}
}




