using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float master)
    {
        audioMixer.SetFloat("master",master);
    }
    public void SetVolumeBGM(float bgm)
    {
        audioMixer.SetFloat("bgm", bgm);
    }
    public void SetVolumeSFX(float sfx)
    {
        audioMixer.SetFloat("sfx", sfx);
    }
}
