using UnityEngine;
using TMPro;
using System.Collections;

public class SubtitleManager : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;
    public float fadeDuration = 1f;   // 페이드아웃 속도 (1초)

    public void ShowSubtitle(string text, float stayTime = 3f)
    {
        StopAllCoroutines();
        StartCoroutine(SubtitleRoutine(text, stayTime));
    }

    IEnumerator SubtitleRoutine(string text, float stayTime)
    {
        // 텍스트 표시
        subtitleText.text = text;
        subtitleText.alpha = 1f;

        // 유지 시간
        yield return new WaitForSeconds(stayTime);

        // 페이드아웃
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);

            subtitleText.alpha = alpha;
            yield return null;
        }

        subtitleText.text = "";
    }
}
