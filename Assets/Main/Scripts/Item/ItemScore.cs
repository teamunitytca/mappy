﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScore : Item {
	const int RADIO_SCORE         = 100;
	const int TV_SCORE            = 200;
	const int MICROCOMPUTER_SCORE = 300;
	const int MONARISA_SCORE      = 400;
	const int SAFE_SCORE          = 500;

	NowScore _score;
	LifeCounter _life_counter;
	AudioSource _item_se;

	// Use this for initialization
	void Start ( ) {
		_score = GameObject.Find( "NowScoreText" ).GetComponent<NowScore>( );
		_item_se = GameObject.Find( "Item_SE" ).GetComponent<AudioSource>( );
		_life_counter = GameObject.FindGameObjectWithTag( "LifeCounter" ).GetComponent<LifeCounter>( );
	}

	// Update is called once per frame
	void Update ( ) {

	}
	void OnDestroy ( ) {
		if ( _item_se ) {
			_item_se.PlayOneShot( _item_se.clip );
		}
		if ( _life_counter.isDead( ) ) {
			return;
		}
		switch ( tag ) {
			case "Radio":
				_score.addScore( RADIO_SCORE );
				break;
			case "TV":
				_score.addScore( TV_SCORE );
				break;
			case "MicroComputer":
				_score.addScore( MICROCOMPUTER_SCORE );
				break;
			case "Monarisa":
				_score.addScore( MONARISA_SCORE );
				break;
			case "Safe":
				_score.addScore( SAFE_SCORE );
				break;
		}
	}
}
