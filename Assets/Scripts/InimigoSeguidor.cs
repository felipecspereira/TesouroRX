using UnityEngine;

public class InimigoSeguidorSimples : MonoBehaviour
{
    [SerializeField] private Transform jogador;
    [SerializeField] private float velocidade = 4f;

    private void Update()
    {
        

        float distancia = Vector3.Distance(transform.position, jogador.position);

        if (distancia > 1.5f) // Só anda se estiver a mais de 1.5m do jogador
        {
            if (jogador == null) return;

            // 1. Calcula a posição do alvo mantendo a mesma altura (Y) do inimigo
            Vector3 posicaoAlvo = new Vector3(jogador.position.x, transform.position.y, jogador.position.z);

            // 2. Aponta para o alvo sem tombar para cima ou para baixo
            transform.LookAt(posicaoAlvo);

            // 3. Move no espaço global do mundo (usando position ao invés de localPosition)
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicaoAlvo,
                velocidade * Time.deltaTime
            );
        }



    }
}