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

    public float TimeToMovePeople = 5;

    public int StartCombinationIndex = 0;

    void Awake()
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
        foreach(CrowdPerson Person in CrowdPeople)
        {
            Debug.Log("This is: " + Person.Name);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        TimeElapsed += Time.deltaTime;
    
        if (TimeElapsed > TimeToMovePeople)
        {
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
