using System.Collections;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    public FloatValue bounceForce;

    private bool willBounce;

    private void Start()
    {
        willBounce = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        CharacterController controller = other.gameObject.GetComponent<CharacterController>();

        if (controller == null) return;


        StartCoroutine(BounceCoroutine(bounceForce.value, other.GetComponent<Rigidbody>().velocity, controller));

    }

    IEnumerator BounceCoroutine(float force, Vector3 velocity, CharacterController controller)
    {
        // FPSController mvmt code is a little wonky bc it's rb is kinematic

        float currentForce = force;

        while (currentForce > 0)
        {
            Vector3 move = new Vector3(0, currentForce, 0) * Time.deltaTime;
            controller.Move(move);
            currentForce -= 0.6f;
            yield return null;
        }
    }
}
