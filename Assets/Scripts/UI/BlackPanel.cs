using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BlackPanel : MonoBehaviour
{
    #region Open Animation Component
    [Header("Open Animation Component")]
    public Animator anim;
    #endregion Open Animation Component

    #region Open Animation Paramaters name
    private readonly string anim_name = "Open";

    #endregion Open Animation Paramaters name

    private void OnEnable()
    {
        InitAnimator();
    }
    void InitAnimator()
    {
        anim.SetTrigger(anim_name);
    }
    void OnClickOtherPanel()
    {
        Destroy(this.gameObject);
    }
}
