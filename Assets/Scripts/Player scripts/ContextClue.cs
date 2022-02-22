using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{

    public GameObject contextClue;
    Animation clueAnim;

    public void Start()

    {
        clueAnim = contextClue.GetComponent<Animation>();
    }

    public void Enable()
    {
        contextClue.SetActive(true);
        clueAnim.Play();
    }

    public void Disable()
    {
        contextClue.SetActive(false);
    }
}
