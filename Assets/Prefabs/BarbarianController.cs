using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianController : MonoBehaviour {

    CharacterController characterController;
    int speed = 2;
    float rot = 0f;

    public Transform rotate;
    public Transform End;

    public float atackValue = 100;
    Animator animator;
    private Transform Target;
    HouseScript house;
    // Use this for initialization
    void Start () {
        characterController = new CharacterController();
        animator = GetComponent<Animator>();
        End = GameObject.Find("Start").transform; 

        if (HouseTarget.houseTarget <= Waypoints.points.Length - 1)
            Target = Waypoints.points[HouseTarget.houseTarget];

        if (Target == null)
            Target = End;

        house = (HouseScript)Target.GetComponent<HouseScript>();
    }

    // Update is called once per frame
    void Update() {
        if (HouseTarget.houseTarget <= Waypoints.points.Length - 1)
        {
            if (house != null)
            {
                if (Vector3.Distance(transform.position, Target.position) >= 3.5f)
                {
                    Vector3 direction = Target.position - transform.position;
                    direction.y = (float)0.5;
                    transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
                    transform.TransformDirection(direction);
                    Quaternion lookrotation = Quaternion.LookRotation(direction);
                    Vector3 rotation = Quaternion.Lerp(rotate.rotation, lookrotation, Time.deltaTime * 10).eulerAngles;
                    rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                    animator.SetInteger("idz", 1);
                }
                else
                {
                    animator.SetInteger("idz", 0);
                    animator.SetInteger("atack", 1);
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName("atack") && !animator.IsInTransition(0) &&
                        animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && house.currentHealth > 0f)
                    {
                        animator.SetInteger("atack", 0);
                        if (house.currentHealth > 0)
                        {
                            house.currentHealth -= atackValue;
                            house.text1.text = house.currentHealth.ToString();
                            house.HP.fillAmount = 1f - atackValue / house.currentHealth;
                            if(house.HP.fillAmount<=0.5f)
                                house.HP.color = Color.red;

                            Debug.Log(house.currentHealth);
                        }
                        if (house.currentHealth <= 0)
                        {
                            Destroy(Target.gameObject);
                            HouseTarget.houseTarget++;
                            Debug.Log("Im attack now house of number: "+HouseTarget.houseTarget++);

                            if (HouseTarget.houseTarget > Waypoints.points.Length - 1)
                            {
                                Destroy(this.gameObject);
                            }
                           
                                Target = Waypoints.points[HouseTarget.houseTarget];
                                house = (HouseScript)Target.GetComponent<HouseScript>();
                            
                                
                        }
                    }
                }
            }
        }
        //else
        //   Destroy(this.gameObject);

    }
}
