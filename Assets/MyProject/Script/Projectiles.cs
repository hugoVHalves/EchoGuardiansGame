using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectiles : MonoBehaviour
{
    //bala
    public GameObject bullet;

    //força da bala
    public float shootForce, upwardForce;

    //Status da arma
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int projectilesLeft, projectilesShot;

    public Rigidbody playerRB;
    public float recoilForce;

    bool shooting, readyToShoot, reloading;

    //Referencia

    public Camera fpsCam;
    public Transform attackPoint;

    //evitar bug

    public bool allowInvoke = true;

    private void Awake()
    {
        projectilesLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        PrInput();

        //Mostra o display de projeteis, se existir

    }

    private void PrInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Recarregando
        if (Input.GetKeyDown(KeyCode.R) && projectilesLeft < magazineSize && !reloading) Reload();
        //Recarrega automaticamente se tentar disparar sem municao
        if (readyToShoot && shooting && !reloading && projectilesLeft <= 0) Reload();

        //Atirando
        if (readyToShoot && shooting && !reloading && projectilesLeft > 0)
        {
            projectilesShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Achar a posição exata de onde acertou usando raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //raio até o meio da tela
        RaycastHit hit;

        Vector3 targetPoint = ray.GetPoint(5f);
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //um ponto longe do jogador

        //Calcular direção do ponto de ataque ate o alvo do ataque
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calcular spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        float z = Random.Range(-spread, spread);

        //Calcular new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, z);


         
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //Rotacionar projetil até a posicao q foi atirado
        currentBullet.transform.forward = directionWithoutSpread.normalized;

        //Adicionar força ao projetil
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        

        projectilesLeft--;
        projectilesShot++;

        //Invoke funcao resetShot (se ja nao tiver sido invocada)
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            playerRB.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }
    }

    private void ResetShot()
    {
        //permite atirar e invocar novamente
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        projectilesLeft = magazineSize;
        reloading = false;
    }
}
