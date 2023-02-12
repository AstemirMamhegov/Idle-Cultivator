using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private Image _iconField;

    public void Render(IItemVisual itemVisual)
    {
        _nameField.text = itemVisual.Name;
        _iconField.sprite = itemVisual.Visual;
    }
}


