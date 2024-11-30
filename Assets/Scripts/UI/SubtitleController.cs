using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SubtitleController : MonoBehaviour
{
    private TextMeshProUGUI subtitleText;
    private Animator _anim;
    private bool _printingSubtitle;

    private void Awake() {
        subtitleText = GetComponentInChildren<TextMeshProUGUI>();
        _anim = GetComponent<Animator>();
    }

    public void AddSubtitle(string subtitle, float time){
        if(_printingSubtitle) return; 

        _anim.SetBool("subsEnabled", true);
        subtitleText.text = String.Empty;
        StartCoroutine(PrintSubtitle(subtitle));
        StartCoroutine(SubtitleTimer(time));
    }

    private IEnumerator PrintSubtitle(string subtitle){
        for(int i = 0; i < subtitle.Length; i++){
            subtitleText.text += subtitle[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return null;
    }

    private IEnumerator SubtitleTimer(float time){
        _printingSubtitle = true;
        yield return new WaitForSeconds(time);
        _printingSubtitle = false;
        _anim.SetBool("subsEnabled", false);
    }

}
