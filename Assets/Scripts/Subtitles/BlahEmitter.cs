using System;
using System.Collections;
using UnityEngine;

public class BlahEmitter : MonoBehaviour
{
    public VoicePresetSO voicePreset;
    private AudioSource _source;

    public Action<VoicePresetSO> EventLoadPreset;

    private bool _emitterEnabled;
    private float _currentVoiceRate;

    private void Awake() {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        SubtitleController.OnSubtitleStarted    += StartBlahEmitter;
        SubtitleController.OnSUbtitleEnded      += StopBlahEmitter;
    }

    private void OnDisable() {
        SubtitleController.OnSubtitleStarted    -= StartBlahEmitter;
        SubtitleController.OnSUbtitleEnded      -= StopBlahEmitter;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          
    }

    private void StartBlahEmitter(){
        _emitterEnabled = true;
        StartCoroutine(PlayBlahSequence());
    }

    private void StopBlahEmitter(){
        _emitterEnabled = false;
    }

    private IEnumerator PlayBlahSequence(){

        while(_emitterEnabled){
            _source.Stop();
            _source.PlayOneShot(voicePreset.voiceClip);
            RandomChangePitch();
            RandomChangeVoiceRate();
            yield return new WaitForSeconds(voicePreset.voiceRate);
        }

        yield return null;
    }

    private void RandomChangePitch(){
        _source.pitch = UnityEngine.Random.Range(
            voicePreset.defaultPitch - voicePreset.pitchRange.x, 
            voicePreset.defaultPitch + voicePreset.pitchRange.y
        );
    }

    private void RandomChangeVoiceRate(){
        _currentVoiceRate = UnityEngine.Random.Range(
            voicePreset.voiceRate - voicePreset.voiceRateVariation.x, 
            voicePreset.voiceRate - voicePreset.voiceRateVariation.y
        );
    }

    private void LoadVoicePreset(VoicePresetSO voicePreset){
        this.voicePreset = voicePreset;
        _source.pitch = voicePreset.defaultPitch;
        _currentVoiceRate = voicePreset.voiceRate;
    }
}
