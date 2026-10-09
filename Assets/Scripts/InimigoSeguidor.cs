using UnityEngine;

public class InimigoSeguidorSimples : MonoBehaviour
{
    [SerializeField] private Transform jogador;
    [SerializeField] private float velocidade = 4f;

    private void Update()
    {
        if (jogador == null) return;

        // Faz o inimigo olhar na direção do jogador
        transform.LookAt(jogador);

        // Move o inimigo em linha reta até o jogador
        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            jogador.localPosition,
            velocidade * Time.deltaTime
        );
    }
}