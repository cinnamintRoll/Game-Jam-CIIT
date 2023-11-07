using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] inputText;
    private int currentLine = 0;
    private bool triggered = false;
    private bool displayDialogue = false;
    public float fadeInSpeed = 1.0f;
    public float fadeOutSpeed = 1.0f;

    public float lineDuration = 5.0f;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeInAndDisplayDialogue());
            triggered = true;
            displayDialogue = true;
        }
    }

    public IEnumerator FadeInAndDisplayDialogue()
    {
        text.text = inputText[0];
        StartCoroutine(FadeIn(text));

        while (currentLine < inputText.Length)
        {
            yield return new WaitForSeconds(lineDuration);
            currentLine++;

            if (currentLine < inputText.Length)
            {
                text.text = inputText[currentLine];
            }
            else
            {
                StartCoroutine(FadeOut(text));
            }
        }
    }

    public IEnumerator FadeIn(Graphic obj)
    {
        obj.enabled = true;
        float targetAlpha = 1.0f;
        float currentAlpha = obj.color.a;

        while (currentAlpha < targetAlpha)
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, Time.deltaTime * fadeInSpeed);
            obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, currentAlpha);
            yield return null;
        }
    }

    public IEnumerator FadeOut(Graphic obj)
    {
        float targetAlpha = 0.0f;
        float currentAlpha = obj.color.a;

        while (currentAlpha > targetAlpha)
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, Time.deltaTime * fadeOutSpeed);
            obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, currentAlpha);
            yield return null;
        }

        obj.enabled = false;
    }
}
