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
    private enum MaterialColor{ red, green, normal};
    private MaterialColor currentColor;

    public Kandooz.IntField scoreValue;
    public TextMeshPro score;

    private void Start()
    {
        currentColor = MaterialColor.normal;
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
        //waitTime -= Time.deltaTime;
    }
    private IEnumerator RandomButton()
    {
        while (true)
        {
            rnd = Random.Range(0, list.Count);
            probability = Random.Range(0.0f, 1.0f);
            if (probability < 0.7)
            {
                list[rnd].material.color = Color.green;
                currentColor = MaterialColor.green;
            }
            else
            {
                list[rnd].material.color = Color.red;
                currentColor = MaterialColor.red;
            }
            yield return new WaitForSeconds(waitTime);           
        }
    }
    public void ButtonDown(GameObject pressedObject)
    {
        if (currentColor == MaterialColor.green)
        {
            scoreValue.Value += 1;
            score.text = scoreValue.Value.ToString();
        }
        else
        {
            if (scoreValue.Value > 0)
            {
                scoreValue.Value -= 1;
            }
            score.text = scoreValue.Value.ToString();
        }
    }
    public void ButtonUp(GameObject pressedObject)
    {
        pressedObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        currentColor = MaterialColor.normal;
    }
}
