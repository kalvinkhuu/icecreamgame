using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CrowdCombination
{
    public Vector3[] PlacesToGoTo;
}
public class Crowd : MonoBehaviour
{
    private CrowdPerson[] CrowdPeople;

    public CrowdCombination[] Combinations;

    private float TimeElapsed;

    private int CrowdPeopleIndex;

    public int StartCombinationIndex;
    
    int PossibleTimeToMove;

    void OnValidate()
    {
        CrowdPeople = GetComponentsInChildren<CrowdPerson>();
        int index = 0;
        foreach (CrowdPerson Person in CrowdPeople)
        {
            Person.transform.localPosition = Combinations[StartCombinationIndex].PlacesToGoTo[index];
            index++;
        }
    }

    void Start()
    {
        PossibleTimeToMove = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        TimeElapsed += Time.deltaTime;
    
        if (TimeElapsed > PossibleTimeToMove)
        {
            PossibleTimeToMove = Random.Range(1, 10);

            int index = 0;
            int combinationIndex = Random.Range(0, Combinations.Length - 1);
            foreach (CrowdPerson Person in CrowdPeople)
            {
                Person.ChangeToAlternatePosition(Combinations[combinationIndex].PlacesToGoTo[index]);
                index++;
            }
            TimeElapsed = 0.0f;
        }
    }
}
