using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour

{
    public static MusicController Instance { get; private set; }
    public AudioSource Source;
    public Slider Slider;
    bool Muted = false;

    void Awake()
    {
        // We want to make the music audio source persistent across the levels so we dont destroy it on scene change. 
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Slider.value = Mathf.Sqrt(Source.volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMute()
    {
        Muted = !Muted;
        Source.mute = Muted;
        // print("Muted called");
    }


    public void SetVolume(float value)
    {
        Source.volume = Mathf.Pow(value, 2); // normally id use an audio mixer but thats not needed since its so simple
    }



}
