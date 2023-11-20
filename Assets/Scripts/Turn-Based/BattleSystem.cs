﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ACTIONCHOSEN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    private PlayerManager player;
    public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public GameObject combatButtons;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(player);
        state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        dialogueText.text = "\"???\"";
        yield return new WaitForSeconds(3f);

        dialogueText.text = enemyUnit.unitName + " gets corrupted!";
        yield return new WaitForSeconds(3f);

        dialogueText.text = "\"I guess we're doing this.\"";
        yield return new WaitForSeconds(3f);

        state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);

        dialogueText.text = playerUnit.unitName + " tells the truth!";
		state = BattleState.ACTIONCHOSEN;

        yield return new WaitForSeconds(3f);

        dialogueText.text = enemyUnit.unitName + " takes " + playerUnit.damage + " damage!";

        yield return new WaitForSeconds(3f);

        dialogueText.text = "\"Disgusting.\"";
        yield return new WaitForSeconds(3f);

        if (isDead)
		{
            state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
        combatButtons.SetActive(false);

        dialogueText.text = enemyUnit.unitName + " tries to hug you";
        yield return new WaitForSeconds(3f);

        dialogueText.text = playerUnit.unitName + " takes " + enemyUnit.damage + " damage!";
        yield return new WaitForSeconds(3f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

        dialogueText.text = "\"1 l0v3 y0u!\"";
        yield return new WaitForSeconds(3f);

        if (isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		} else
		{
            state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
            dialogueText.text = "\"I guess I get to live to see another day.\"";
        } else if (state == BattleState.LOST)
		{
			dialogueText.text = "\"Ev3n after de4th, y0u're m1ne\" ";
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "\"What should I do?\"";
        combatButtons.SetActive(true);
    }

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "\"I feel a bit more like myself.\"";
		state = BattleState.ACTIONCHOSEN;

		yield return new WaitForSeconds(3f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}
