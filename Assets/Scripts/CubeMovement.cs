using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class CubeMovement : MonoBehaviour
{
    public Animator animator;
    public float timeBetweenInputs = 0.5f;
    public AudioSource audioSource;
    public AudioClip sonido;

    string Input = "";
    float lastinput;

    void Update()
    {
        var k = Keyboard.current;

        if (k.upArrowKey.wasPressedThisFrame) Addc("U");
        if (k.downArrowKey.wasPressedThisFrame) Addc("D");
        if (k.qKey.wasPressedThisFrame) Addc("Q");
        if (k.aKey.wasPressedThisFrame) Addc("A");

        if (Input != "" && Time.time - lastinput > timeBetweenInputs)
        {
            if (Input == "UUDDQA") DoAnimation("FrontFlip");
            if (Input == "UUUDQA") DoAnimation("Jump");
            if (Input == "UUU") DoAnimation("BackFlip");
            Input = "";
        }
    }

    void Addc(string t)
    {
        Input += t;
        lastinput = Time.time;
    }

    void DoAnimation(string trigger)
    {
        animator.SetTrigger(trigger);
        audioSource.PlayOneShot(sonido);
    }
}
