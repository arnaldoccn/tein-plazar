using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFader : MonoBehaviour
{
    public Image imageToFade;
    public Image imageToFadeIn; // Primeiro objeto Image
    public Image imageToFadeOut; // Segundo objeto Image
    public float fadeDuration = 1f; // Duração do fade (em segundos)
    public float initialDelay = 5f; // Atraso inicial antes do primeiro fade
    public float switchDelay  = 0.5f; // Intervalo entre cada repetição dos fades

    public float repeatInterval = 3f;

    private bool isFading = false; // Flag para controlar se o ciclo de fades está em progresso

    void Start()
    {
        if (imageToFadeIn != null)
        {
            imageToFadeIn.canvasRenderer.SetAlpha(0f);
        }


        imageToFade.canvasRenderer.SetAlpha(0f);
        
    }

    public void StartImageFade()
    {
        StartCoroutine(RepeatedImageFade());
    }

    public void DesactiveLetsGoButton()
    {
        StopCoroutine(RepeatedImageFade());
        StopCoroutine("ExecuteFade");
        imageToFadeIn.gameObject.SetActive(false);
        imageToFadeOut.gameObject.SetActive(false);
    }

    IEnumerator RepeatedImageFade()
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            // Executa o ciclo de fades apenas se nenhum ciclo estiver em andamento
            if (!isFading)
            {
                isFading = true;

                // Inicia o fade in na primeira imagem e o fade out na segunda imagem
                StartCoroutine(ExecuteFade(imageToFadeIn, imageToFadeOut));

                // Aguarda a conclusão do ciclo de fades
                yield return new WaitForSeconds(fadeDuration + switchDelay);

                // Inverte os papéis das imagens para o próximo ciclo
                SwapImages();

                // Aguarda um intervalo antes de iniciar o próximo ciclo
                yield return new WaitForSeconds(switchDelay);
            }

            yield return null;
        }
    }

    IEnumerator ExecuteFade(Image fadeInImage, Image fadeOutImage)
    {
        // Configura a opacidade da imagem de fade in para 0
        fadeInImage.canvasRenderer.SetAlpha(0f);

        // Executa o fade in na imagem de fade in
        fadeInImage.CrossFadeAlpha(1f, fadeDuration, true);

        // Executa o fade out na imagem de fade out
        fadeOutImage.CrossFadeAlpha(0f, fadeDuration, true);

        // Aguarda a conclusão dos fades
        yield return new WaitForSeconds(fadeDuration);

        // Indica que o ciclo de fades foi concluído
        isFading = false;
    }

    void SwapImages()
    {
        // Troca as referências das imagens
        Image temp = imageToFadeIn;
        imageToFadeIn = imageToFadeOut;
        imageToFadeOut = temp;
    }

    public void StartSingleImageFade()
    {
        StartCoroutine(RepeatedSingleImageFade());
    }

    public void DesactiveHighlight()
    {
        StopCoroutine(RepeatedSingleImageFade());
        StopCoroutine("RepeatedSingleImageFade");
        imageToFade.gameObject.SetActive(false);
    }


    IEnumerator RepeatedSingleImageFade()
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            // Executa o ciclo de fades apenas se nenhum ciclo estiver em andamento
            if (!isFading)
            {
                isFading = true;

                // Executa o fade in e fade out alternadamente no mesmo objeto Image
                StartCoroutine(ExecuteFadeInAndOut(imageToFade));

                // Aguarda o intervalo entre os fades antes de repetir
                yield return new WaitForSeconds(repeatInterval);
            }

            yield return null;
        }
    }

    IEnumerator ExecuteFadeInAndOut(Image image)
    {
        // Inicia com opacidade zero (totalmente transparente)
        image.canvasRenderer.SetAlpha(0f);

        // Executa o fade in (opacidade vai para 1)
        image.CrossFadeAlpha(1f, fadeDuration, true);

        // Aguarda a duração do fade in
        yield return new WaitForSeconds(fadeDuration);

        // Executa o fade out (opacidade vai para 0)
        image.CrossFadeAlpha(0f, fadeDuration, true);

        // Aguarda a duração do fade out
        yield return new WaitForSeconds(fadeDuration);

        // Indica que o ciclo de fades foi concluído
        isFading = false;
    }
}
