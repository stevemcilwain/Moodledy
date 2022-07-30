
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(SpriteResolver))]
public class SpriteChooser : MonoBehaviour
{

    [SerializeField] protected PersonSpriteCategoriesAsset categories;

    protected SpriteResolver _resolver;
    protected string _category;
    protected List<string> _labels;

    private void Awake()
    {
        _resolver = GetComponent<SpriteResolver>();
        _category = _resolver.GetCategory();
        _labels = new List<string>();
        _labels.AddRange(_resolver.spriteLibrary.spriteLibraryAsset.GetCategoryLabelNames(_category));
    }

    public void Choose()
    {
        string label = _labels[Random.Range(0, _labels.Count)];
        _resolver.SetCategoryAndLabel(_category, label);
    }
}
