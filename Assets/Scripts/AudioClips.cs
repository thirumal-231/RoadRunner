using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipSO")]
public class AudioClips : ScriptableObject
{
    public AudioClip titleClip;
    public AudioClip moveSound;
    public AudioClip carSound;
    public AudioClip coinSound;
    public AudioClip gameOverSound;
    public AudioClip jumpSound;
}
