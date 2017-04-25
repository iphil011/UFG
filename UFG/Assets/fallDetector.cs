using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallDetector : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public int player1Stock;
    public int player2Stock;
    public Vector2 p1Pos;
    public Vector2 p2Pos;
	public static string winner;

    // Use this for initialization
    void Start()
    {
        player1Stock = 3;
        player2Stock = 3;
        p1Pos = new Vector2(-3, 0);
        p2Pos = new Vector2(3, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            player1Stock -= 1;
            player1.transform.position = p1Pos;
        }
        if (collision.gameObject.tag == "Player2")
        {
            player2Stock -= 1;
            player2.transform.position = p2Pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
		if (player1Stock == 0) {
			Application.LoadLevel (6);
			winner = "PLAYER 2";
		}

		if (player2Stock == 0) {

			Application.LoadLevel (7);
			winner = "PLAYER 1";
		}
	}
}
