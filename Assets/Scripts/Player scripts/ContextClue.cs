using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{

    public GameObject contextClue;
    public bool contextActive = false;
    Animation clueAnim;

    public void Start()

    {
        clueAnim = contextClue.GetComponent<Animation>();
    }

    //public void Enable()
    //{
    //    contextClue.SetActive(true);
    //    clueAnim.Play();
    //}

    //public void Disable()
    //{
    //    contextClue.SetActive(false);
    //}

    public void CheckContext()
    {
        contextActive = !contextActive;
        if (contextActive)
        {
            contextClue.SetActive(true);
            clueAnim.Play();
        }
        else
        {
            contextClue.SetActive(false);
        }
    }
}
