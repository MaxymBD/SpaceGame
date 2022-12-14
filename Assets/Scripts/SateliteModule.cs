using UnityEngine;

[CreateAssetMenu(fileName = "SateliteModule", menuName = "ScriptableObjects/SateliteModule")]
public class SateliteModule : ScriptableObject
{
    public string Name;
    public int Price;
    public string Description;
    public bool Bought;
    public int Index;
}
