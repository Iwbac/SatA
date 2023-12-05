using UnityEngine;
using UnityEngine.AI;
public class EnemyHaikai : MonoBehaviour
{
    CharacterController controller;

    NavMeshAgent myAgent;

    Vector3 NextPosition;

    float min = 3f;
    float max = 8f;
    int PlusMinus;
    void Start()
    {
        // Nav Mesh Agentのコンポーネントを取得。
        myAgent = GetComponent<NavMeshAgent>();

        controller = GetComponent<CharacterController>();

        NextPosition = this.transform.position;
    }


    void Update()
    {
        if(myAgent.remainingDistance < 0.5f)
        {

            // 今の自分の位置に加算する乱数を決める。
            float RandamX = Random.Range(min, max);
            float RandamZ = Random.Range(min, max);

            //XとZそれぞれに2分の1の確率で-1を掛け算する。
            PlusMinus = Random.Range(1, 3);
            if (PlusMinus == 2)
            {
                RandamX = RandamX * (-1);
            }
            PlusMinus = Random.Range(1, 3);
            if (PlusMinus == 2)
            {
                RandamZ = RandamZ * (-1);
            }

            // 今の位置に乱数を加算し次の位置を決める。
            NextPosition.x = this.transform.position.x + RandamX;
            NextPosition.y = 0;
            NextPosition.z = this.transform.position.z + RandamZ;
        }


        var nextPoint = myAgent.steeringTarget;
        Vector3 targetDir = nextPoint - this.transform.position;

        if (targetDir.magnitude >= 0.01)
        {
            transform.rotation = Quaternion.LookRotation(targetDir);
            controller.Move(transform.forward * 5.0f * Time.deltaTime);
        }


        //次の位置に向かって移動する
        myAgent.SetDestination(NextPosition);
        myAgent.nextPosition = transform.position;
    }


}