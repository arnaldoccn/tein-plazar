using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImageAnimationPlayer : MonoBehaviour
{
    public List<Sprite> animationFrames; // Lista de frames da animação
    public Image targetImage; // Imagem onde a animação será exibida
    public float framesPerSecond = 10f; // Frames por segundo da animação

    private void Start()
    {
        // Inicia a animação ao iniciar o script
        StartAnimation();
    }

    public void StartAnimation()
    {
        // Inicia a corotina para reproduzir a animação
        StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        // Verifica se há imagens na lista
        if (animationFrames == null || animationFrames.Count == 0 || targetImage == null)
        {
            Debug.LogWarning("A lista de frames de animação ou a imagem de destino não está configurada.");
            yield break;
        }

        // Calcula o tempo de espera entre cada frame com base no framerate
        float frameInterval = 1f / framesPerSecond;

        // Loop infinito para reproduzir a animação em loop
        while (true)
        {
            // Loop para reproduzir cada frame da animação
            foreach (Sprite frame in animationFrames)
            {
                // Atualiza a imagem alvo com o próximo frame da animação
                targetImage.sprite = frame;

                // Aguarda o tempo correspondente ao framerate
                yield return new WaitForSeconds(frameInterval);
            }
        }
    }
}
