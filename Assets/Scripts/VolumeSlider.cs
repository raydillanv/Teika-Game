using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    Slider Slider;

    void Start()
    {
        Slider = GetComponent<Slider>();
        Slider.value = Mathf.Sqrt(MusicController.Instance.Source.volume);
        Slider.onValueChanged.AddListener(MusicController.Instance.SetVolume);
    }
}
