using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour
{
    public Transform player;
    public float height = 20f; // Altura da câmara em relação ao chão

    void LateUpdate()
    {
        if (player != null)
        {
            // Acompanha a posição X e Z do Player, mantendo a rotação e altura fixas
            transform.position = new Vector3(player.position.x, player.position.y + height, player.position.z);
        }
    }
}