using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameControl : MonoBehaviour
{
    public static event Action ButtonPressed = delegate { };

    [SerializeField]
    private Text MoneyText;

    [SerializeField]
    private Row[] rows;

    [SerializeField]
    private Transform button;

    private int moneyValue;

    private bool resultsChecked = false;

    // Update is called once per frame
    void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            moneyValue = 0;
            MoneyText.enabled = false;
            resultsChecked = false;
        }
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            CheckResults();
            MoneyText.enabled = true;
            MoneyText.text = "money: $" + moneyValue;
        }
    }

    private void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            StartCoroutine("PressButton");
        }
    }

    private IEnumerator PressButton()
    {
        for (int i = 0; i < 15; i += 5)
        {
            button.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }

        ButtonPressed();

        for (int i = 0; i < 15; i += 5)
        {
            button.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CheckResults()
    {
        if (rows[0].stoppedSlot == "Grape"
            && rows[1].stoppedSlot == "Grape"
            && rows[2].stoppedSlot == "Grape")
        {
            moneyValue = 200;
        }

        else if (rows[0].stoppedSlot == "Lemon"
            && rows[1].stoppedSlot == "Lemon"
            && rows[2].stoppedSlot == "Lemon")
        {
            moneyValue = 400;
        }

        else if (rows[0].stoppedSlot == "Pineapple"
            && rows[1].stoppedSlot == "Pineapple"
            && rows[2].stoppedSlot == "Pineapple")
        {
            moneyValue = 600;
        }

        else if (rows[0].stoppedSlot == "Strawberry"
            && rows[1].stoppedSlot == "Strawberry"
            && rows[2].stoppedSlot == "Strawberry")
        {
            moneyValue = 800;
        }

        else if (rows[0].stoppedSlot == "Watermelon"
            && rows[1].stoppedSlot == "Watermelon"
            && rows[2].stoppedSlot == "Watermelon")
        {
            moneyValue = 1000;
        }

        else if (rows[0].stoppedSlot == "Wild"
            && rows[1].stoppedSlot == "Wild"
            && rows[2].stoppedSlot == "Wild")
        {
            moneyValue = 5000;
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[0].stoppedSlot == "Grape"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "Grape"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[1].stoppedSlot == "Grape")))
        {
            moneyValue = 100;
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[0].stoppedSlot == "Lemon"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "Lemon"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[1].stoppedSlot == "Lemon")))
        {
            moneyValue = 300;
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[0].stoppedSlot == "Pineapple"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "Pineapple"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[1].stoppedSlot == "Pineapple")))
        {
            moneyValue = 500;
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[0].stoppedSlot == "Strawberry"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "Strawberry"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[1].stoppedSlot == "Strawberry")))
        {
            moneyValue = 700;
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[0].stoppedSlot == "Watermelon"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "Watermelon"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[1].stoppedSlot == "Watermelon")))
        {
            moneyValue = 900;
        }

        else if (((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[0].stoppedSlot == "Wild"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "Wild"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[1].stoppedSlot == "Wild")))
        {
            moneyValue = 3000;
        }

        resultsChecked = true;
    }
}
