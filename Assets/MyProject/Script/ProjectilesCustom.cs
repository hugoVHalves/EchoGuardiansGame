using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesCustom : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask enemiesD;

    //Status
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    public int explosionDamage;
    public float explosionRange;

    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physics_mat;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Setup();
    }
    private void Update()
    {
        //quando explodir
        if (collisions > maxCollisions) Explode();
        //maximo de tempo de acao
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();
    }
    private void Explode()
    {
        //instantiate
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //verifica os inimigos
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, enemiesD);
        for (int i = 0; i < enemies.Length; i++)
        {
            //chamar o componente do inimigo e invocar takeDamage

            Invoke("Delay", 1f);
        }
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //nao conta colisao com outra bala
        if (collision.collider.CompareTag("Bullet")) return;

        //conta as colisoes
        collisions++;

        //explode se atingir um inimigo diretamente e explodeOnTouch estiver habilitado
        if (collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
    }
    private void Setup()
    {
        //cria um novo material de fisica
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //setar o material no collider
        GetComponent<SphereCollider>().material = physics_mat;

        //setar a gravidade
        rb.useGravity = useGravity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
