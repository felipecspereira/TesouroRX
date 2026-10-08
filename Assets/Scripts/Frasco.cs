using UnityEngine;

public class Frasco : MonoBehaviour
{
    private Transform frascoTransform;
    [SerializeField] private float velocidadeRotacao = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frascoTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
        transform.position = new Vector3(frascoTransform.position.x, frascoTransform.position.y + Mathf.Sin(Time.time) * 0.002f, frascoTransform.position.z);

    }
}
