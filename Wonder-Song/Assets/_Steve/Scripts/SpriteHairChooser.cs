using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SpriteHairChooser : SpriteChooser
{

    [SerializeField] private SpriteResolver bangsResolver;

    public void ChooseHairAndBangs()
    {
        string label = _labels[Random.Range(0, _labels.Count)];
        bangsResolver.SetCategoryAndLabel(categories.BANGS_CATEGORY, label);

        // 50% chance to have long hair
        if (Random.value <= 0.5f)
        {
            _resolver.SetCategoryAndLabel(categories.HAIR_CATEGORY, label);
        }

    }

}
