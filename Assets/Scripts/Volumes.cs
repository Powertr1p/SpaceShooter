using UnityEngine;
using UnityEngine.UI;

public class Volumes : MonoBehaviour
{
    private Slider slide;

    private void Start()
    {
        slide = GetComponent<Slider>();
    }

    public float ChangeVolume()
    {
        return slide.value;
    }


}
