using UnityEngine;

[CreateAssetMenu(fileName = "VoicePreset", menuName = "Voice/VoicePresetSO")]
public class VoicePresetSO : ScriptableObject
{
    public AudioClip voiceClip;
    public float voiceRate;
    [VectorLabels("MIN", "MAX")]
    public Vector2 voiceRateVariation;
    public float defaultPitch;
    [VectorLabels("MIN", "MAX")]
    public Vector2 pitchRange;
}
