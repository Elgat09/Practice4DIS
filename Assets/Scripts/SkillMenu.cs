using UnityEngine;

public class SkillMenu : MonoBehaviour
{
    public int numSides;
    public float attackPower; 
    public float speedPower; 
    public float defensePower; 
    public float healthPower; 
    public float manaPower; 
    public float strengthPower; 
    public Vector3 centerPoint;
    public Material skillDisplayMaterial;
    public int scaleFactor;
    private float maxSkillPower = 100;

    void Start()
    {
        GenerateSkillMesh();
    }

    void GenerateSkillMesh()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "Procedural Skill Mesh";

        Vector3[] vertices = new Vector3[numSides + 1];
        int[] triangles = new int[numSides * 3];

        float angleBetween = 360f / numSides;

        for (int i = 0; i < numSides; i++)
        {
            float angle = angleBetween * i * Mathf.Deg2Rad;

            float skillPower = Mathf.Clamp(GetSkillPower(i), 0f, maxSkillPower);
            float x = centerPoint.x + Mathf.Cos(angle) * skillPower / maxSkillPower * scaleFactor;
            float y = centerPoint.y + Mathf.Sin(angle) * skillPower / maxSkillPower * scaleFactor;

            vertices[i] = new Vector3(x, y, centerPoint.z);

            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = (i + 2) % numSides;
        }

        vertices[numSides] = centerPoint;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

        GetComponent<MeshRenderer>().material = skillDisplayMaterial;
    }

    float GetSkillPower(int index)
    {
        switch (index)
        {
            case 0: return attackPower;
            case 1: return speedPower;
            case 2: return defensePower;
            case 3: return healthPower;
            case 4: return manaPower;
            case 5: return strengthPower;
            default: return 0f;
        }
    }
}
