using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class MoveScript : MonoBehaviour
{
    private Ease linearMove = Ease.Linear;

    public GameObject hero;
    public GameObject cam;
    public GameObject dayLight;

    void Start()
    {
        StartCoroutine(Move()); 
    }

    void Update()
    {
        
    }

    IEnumerator Move()
    {
        //Transitioning light from day to night using rotation on x axis
        StartCoroutine(RotateLight());

        //Activate the virtual cinemachine camera that is behind the hero 
        ActivateCamera(true);
        yield return new WaitForSeconds(3f);

        //Move the hero in a linear way
        hero.transform.DOMoveZ(1.60f, 8).SetEase(linearMove);
        yield return new WaitForSeconds(8f);

        //Flip the hero to the oposite direction
        hero.transform.DORotate(new Vector3 (hero.transform.rotation.x, 180, hero.transform.rotation.z), 4f);

        //Move the hero to the beggining of him movement
        yield return new WaitForSeconds(4f);
        hero.transform.DOMoveZ(-6.56f, 8f).SetEase(linearMove);
    }

    IEnumerator RotateLight()
    {
        /*DUVIDA
        oi professor eu tentei fazer a rota��o apenas do eixo x, mas eu n�o consegui fazer isso, voce sabe dizer o que aconteceu aqui? quando est� 
        sendo feita a rota��o da luz(queria que fosse do x 494f para o 335f), os demais eixos y e z est�o sendo rotacionados tambem, mas isso n�o ocorreu com a rota��o do heroi na cena*/

        dayLight.transform.DORotate(new Vector3(335f, dayLight.transform.rotation.y, dayLight.transform.rotation.z), 15f);
        yield return new WaitForSeconds(3f);
    }

    private void ActivateCamera(bool activate)
    {
        var heroCamera = cam.GetComponent<CinemachineVirtualCamera>();
        heroCamera.gameObject.SetActive(activate);
    }
}
