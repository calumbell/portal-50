using UnityEngine;

public class FloatingHintScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GameObject player;

    public FloatValue hintActivateDistance;
    public FloatValue hintBounceMax;
    public FloatValue hintBounceRate;

    private float distance;

    private Vector3 position;

    private float bounceRate;
    private float bounceMax;

    private void OnEnable()
    {
        position = gameObject.transform.position;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");

        distance = hintActivateDistance.value;
        bounceRate = hintBounceRate.value;
        bounceMax = hintBounceMax.value;
    }

    void Update()
    {
        if (!sprite || !player) return;

        if (Vector3.Distance(position, player.transform.position) < distance)
        {
            sprite.enabled = true;
        }

        else
        {
            sprite.enabled = false;
            return;
        }

        transform.position = new Vector3(
            position.x,
            transform.position.y + bounceRate * Time.deltaTime,
            position.z);

        if (transform.position.y > position.y + bounceMax ||
            transform.position.y < position.y - bounceMax)
        {
            float y = bounceRate > 0 ? position.y + bounceMax : position.y - bounceMax;
            transform.position = new Vector3(position.x, y, position.z);
            bounceRate *= -1;
        }


    }
}
