using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SliderBar : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void SetValue(float min, float max, float value)
    {
        _image.fillAmount = Mathf.InverseLerp(min, max, value);
    }
}
