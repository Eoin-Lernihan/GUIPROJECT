using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
public class GliderVoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    // Start is called before the first frame update
    void Start()
    {
        SpeechSetup(LANG_CODE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpeechSetup(string langCode)
    {
        SpeechToText.instance.Setting(langCode);
    }
}
