namespace CoreDomain.Scripts.Services.AudioService
{
    public interface IAudioService
    {
        void InitEntryPoint();
        void PlayAudio(AudioClipType audioClipType, AudioChannelType audioChannelType, AudioPlayType audioPlayType = AudioPlayType.OneShot);
        void StopAllAudio();
        void AddAudioClips(AudioClipsScriptableObject audioClipsScriptableObject);
        void RemoveAudioClips(AudioClipsScriptableObject audioClipsScriptableObject);

    }
}