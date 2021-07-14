using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;


public class BottomLeftPresenter : MonoBehaviour
{
    [SerializeField] private Image _selectedImage;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _sliderBackground;
    [SerializeField] private Image _sliderFillImage;

    private IDisposable _healthUpdater;
    private ISelectable _selected;
    
    [Inject] private IObservable<ISelectable> _selectedValues;

    private void Start()
    {
        _selectedValues.Subscribe(onSelected);
    }
    
    private void onSelected(ISelectable selected)
    {
        if (_healthUpdater != null)
        {
            _healthUpdater.Dispose();
            _healthUpdater = null;
        }
        
        _selectedImage.enabled = selected != null;
        _healthSlider.gameObject.SetActive(selected != null);
        _text.enabled = selected != null;

        if (selected != null)
        {
            _selectedImage.sprite = selected.Icon;
            _healthSlider.minValue = 0;
            _healthSlider.maxValue = selected.MaxHealth;
            _healthUpdater = selected.Health.Subscribe(currentHealth =>
            {
                _text.text = $"{(int)currentHealth}/{selected.MaxHealth}";
                _healthSlider.value = currentHealth;
                var color = Color.Lerp(Color.red, Color.green, currentHealth / (float)selected.MaxHealth);
                _sliderBackground.color = color * 0.5f;
                _sliderFillImage.color = color;
            });
        }
    }
    
    
}
