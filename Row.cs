using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;

    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        GameControl.ButtonPressed += StartRotating;
    }

    private void StartRotating()
    {
        stoppedSlot = "";
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.025f;

        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y <= -7.5f)
            {
                transform.position = new Vector2(transform.position.x, 8.0f);
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.50f);

            yield return new WaitForSeconds(timeInterval);
        }

        randomValue = Random.Range(60, 100);

        switch (randomValue % 6)
        {
            case 1:
                randomValue += 5;
                break;
            case 2:
                randomValue += 4;
                break;
            case 3:
                randomValue += 3;
                break;
            case 4:
                randomValue += 2;
                break;
            case 5:
                randomValue += 1;
                break;
        }

        for (int i = 0; i < randomValue; i++)
        {
            if (transform.position.y <= -7.5f)
            {
                transform.position = new Vector2(transform.position.x, 8.0f);
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.50f);

            if (i > Mathf.RoundToInt(randomValue * 0.25f))
            {
                timeInterval = 0.05f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
            {
                timeInterval = 0.1f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
            {
                timeInterval = 0.15f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
            {
                timeInterval = 0.2f;
            }

            yield return new WaitForSeconds(timeInterval);
        }

        if (transform.position.y == -7.5f)
        {
            stoppedSlot = "Grape";
        }
        else if (transform.position.y == 8.0f)
        {
            stoppedSlot = "Lemon";
        }
        else if (transform.position.y == -1.0f)
        {
            stoppedSlot = "Pineapple";
        }
        else if (transform.position.y == 5.0f)
        {
            stoppedSlot = "Strawberry";
        }
        else if (transform.position.y == 2.0f)
        {
            stoppedSlot = "Watermelon";
        }
        else if (transform.position.y == -4.0f)
        {
            stoppedSlot = "Wild";
        }

        rowStopped = true;
    }

    private void OnDestroy()
    {
        GameControl.ButtonPressed -= StartRotating;
    }
}
