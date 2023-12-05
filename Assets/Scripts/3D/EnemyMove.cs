using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    // 目的地となるGameObjectをシリアル化。
    [SerializeField] Transform targetObject;
    CharacterController controller;


    NavMeshAgent myAgent;


    void Start()
    {
        // Nav Mesh Agentのコンポーネントを取得。
        myAgent = GetComponent<NavMeshAgent>();
        
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
       EnemyMoving();
    }

    public void EnemyMoving()
    {
        // 次に目指すべき位置を取得
        var nextPoint = myAgent.steeringTarget;
        Vector3 targetDir = nextPoint - this.transform.position;

        if (targetDir.magnitude >= 0.01)
        {
            transform.rotation = Quaternion.LookRotation(targetDir);
            controller.Move(transform.forward * 5.0f * Time.deltaTime);
        }

        myAgent.SetDestination(targetObject.position);
        myAgent.nextPosition = transform.position;
    }

}