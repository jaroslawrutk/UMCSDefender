using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarbarianController : MonoBehaviour {

    public Image currentHealthbar;
    public float maxhitPoint = 150f;
    public float hitPoint = 150f;
    private float ratio;
    public GameObject healthbar;

    CharacterController characterController;
    int speed = 2;
    float rot = 0f;
    private int targetindex=0;
    public Transform rotate;
    public Transform End;

    public float atackValue = 200;
    Animator animator;
    private Transform Target;
    HouseScript house;
    private Collider Axe;
    // Use this for initialization
    void Start () {
        characterController = new CharacterController();
        animator = GetComponent<Animator>();
        End = GameObject.Find("Start").transform;
        Axe = gameObject.transform.Find("Main/DeformationSystem/Axe_M").GetComponent<CapsuleCollider>();
        Target = Waypoints.points[0];
        house = (HouseScript)Target.GetComponent<HouseScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, Target.position) >= 2.4f && Target != null)
        {

            Vector3 direction = Target.position - transform.position;
            direction.y = 0f;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            transform.TransformDirection(direction);
            Quaternion lookrotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(rotate.rotation, lookrotation, Time.deltaTime * 10).eulerAngles;
            rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            animator.SetInteger("idz", 1);
        }
        else
        {
            if (Target.gameObject.active == true)
                Atack();
            else
            {
                GetNextWaypoint();
                animator.SetInteger("atack", 0);
            }

        }
    }

    void GetNextWaypoint()
    {
        if (targetindex >= Waypoints.points.Length - 1)
        {
            Target = End;
            return;
        }
        if (Target == End && Vector3.Distance(transform.position, Target.position) <= 3.0f)
        {
            Destroy(gameObject);
        }
        targetindex++;
        Target = Waypoints.points[targetindex];
        house = (HouseScript)Target.GetComponent<HouseScript>();
    }


    private void Atack()
    {
        animator.SetInteger("idz", 0);
        animator.SetInteger("atack", 1);
        
        Collider[] colls = Physics.OverlapBox(Axe.bounds.center, Axe.bounds.extents, Axe.transform.rotation, LayerMask.GetMask("HitBox"));

        foreach (Collider c in colls)
        {
            if (c != null)
            {
                c.SendMessage("TakeDamage", Time.deltaTime * atackValue);
            }
        }
    }

    void UpdateHealthBar()
    {
        ratio = maxhitPoint/hitPoint;
        Debug.Log(ratio +" "+hitPoint+" "+maxhitPoint);

        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        if (ratio < 1)
            healthbar.SetActive(true);
        if(ratio>0.5)
            currentHealthbar.color = Color.green;
        if (ratio <= 0.5 && ratio >= 0.25)
            currentHealthbar.color = Color.yellow;
        if (ratio < 0.25)
            currentHealthbar.color = Color.red;

    }
    public void TakeDamage(float damage)
    {
        maxhitPoint -= damage;
        if (maxhitPoint < 0)
        {
            Destroy(gameObject);
            Money.money += 400;
            maxhitPoint = 0;
            Debug.Log("House was Destroyed");
        }
        UpdateHealthBar();
    }

}
