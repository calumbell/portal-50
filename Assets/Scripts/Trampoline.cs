using System.Collections;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    public FloatValue bounceForce;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (!other.gameObject.CompareTag("Player"))
            return;
        Debug.Log("Is tagged Player");

        CharacterController controller = other.gameObject.GetComponent<CharacterController>();
        if (controller == null) return;

        Debug.Log("Has Controller");

        Debug.Log(bounceForce.value);

        StartCoroutine(BounceCoroutine(bounceForce.value, other.GetComponent<Rigidbody>().velocity, controller));

    }

    IEnumerator BounceCoroutine(float force, Vector3 velocity, CharacterController controller)
    {
        float currentForce = force;

        while (currentForce > 0)
        {
            Vector3 move = new Vector3(velocity.x, currentForce, velocity.z) * Time.deltaTime;
            controller.Move(move);
            currentForce -= 0.1f;
            yield return null;
        }
    }
}
