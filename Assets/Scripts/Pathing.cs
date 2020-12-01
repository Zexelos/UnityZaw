using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System.Collections.Generic;

public class Pathing : MonoBehaviour
{
    [SerializeField] GameObject path;
    public Transform[] points;
    [SerializeField] int destPoint = 0;
    [SerializeField] NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        points = path.GetComponentsInChildren<Transform>();

        List<Transform> tList= points.ToList();
        tList.RemoveAt(0);
        points = tList.ToArray();

        for (int i = 0; i < points.Length; i++)
        {
            Debug.Log(points[i].position.ToString());
        }

        agent.autoBraking = false;

        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= 0.5f)
            GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }
}
