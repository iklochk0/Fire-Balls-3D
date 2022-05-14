using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] TMP_Text _sizeView;
    [SerializeField] Tower _tower;

    private void OnEnable()
    {
        _tower.sizeUpdated += OnSizeUpdated;
    }

    private void OnDisable()
    {
        _tower.sizeUpdated -= OnSizeUpdated;
    }

    void OnSizeUpdated(int size)
    {
        _sizeView.text = size.ToString();
    }
}
