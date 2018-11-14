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

	// Use this for initialization
	void Start ( ) {
		_score = GameObject.Find( "NowScoreText" ).GetComponent<NowScore>( );
	}

	// Update is called once per frame
	void Update ( ) {

	}

	void OnDestroy ( ) {
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