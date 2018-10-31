using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using TMPro;

[RequireComponent(typeof(Interactable))]
public class W_Minigame : MonoBehaviour
{
    [SerializeField]
    private List<MeshRenderer> list;
    private IEnumerator coroutine;
    private int rnd;
    private float probability;
    private float waitTime = 1.0f;

    public Kandooz.IntField scoreValue;
    public TextMeshPro score;

    private void Start()
    {
        var count = transform.childCount;
        list = new List<MeshRenderer>();
        for (int i = 0; i < count; i++)
        {
            list.Add(transform.GetChild(i).GetComponent<MeshRenderer>());
        }
        coroutine = RandomButton();
        StartCoroutine(coroutine);
    }
    private void Update()
    {
        waitTime -= Time.deltaTime;
    }
    private IEnumerator RandomButton()
    {
        while (true)
        {
            rnd = Random.Range(0, list.Count);
            probability = Random.Range(0.0f, 1.0f);
            if (probability < 0.7)
            {
                list[rnd].material.color = Color.red;
            }
            else
            {
                list[rnd].material.color = Color.green;
            }
            yield return new WaitForSeconds(waitTime);           
        }
    }
    public void ButtonDown(GameObject pressedObject)
    {
        if (pressedObject.GetComponent<MeshRenderer>().material.color == Color.green)
        {
            scoreValue.Value += 1;
            score.text = scoreValue.Value.ToString();
        }
        else
        {
            if (scoreValue.Value >0)
            {
                scoreValue.Value -= 1;
            }
            score.text = scoreValue.Value.ToString();
        }
    }
    public void ButtonUp(GameObject pressedObject)
    {
        pressedObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
