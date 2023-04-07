using UnityEngine;

public class PathfindingPointn : MonoBehaviour
{
    public Collider MovingObject;
    public GameObject NextTarget;
    public SentientPotMoveSimple MovingObjectScript;
    public bool SingleCollision;
    private bool CollisionSpent = false;

    // Detector de colisão com o centro do ponto
    private void OnTriggerEnter(Collider other)
    {
        if (other == MovingObject && SingleCollision == false) // Se for o objeto certo e não for um ponto de colisão unica muda de cor e muda o alvo
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            MovingObjectScript.target = NextTarget;
        }
        else if (other == MovingObject && CollisionSpent == false)  // Se for o objeto certo e for um ponto de colisão unica muda de cor, muda o alvo e garante que este ponto não rodara mais o script
        {
            CollisionSpent = true;
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            MovingObjectScript.target = NextTarget;
        }
    }
}
