using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeUi : MonoBehaviour
{
    [SerializeField] CanvasGroup titleCanvasGroup;

    public void FadeTitleScreen()
    {
        titleCanvasGroup.DOFade( 0, 2 );
    }
}
