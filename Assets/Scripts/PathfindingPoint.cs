using UnityEngine;

public class PathfindingPointn : MonoBehaviour
{
    public Collider MovingObject;
    public GameObject NextTarget;
    public SentientPotMoveSimple MovingObjectScript;
    public bool SingleCollision;
    private bool CollisionSpent = false;

    // Detector de colis�o com o centro do ponto
    private void OnTriggerEnter(Collider other)
    {
        if (other == MovingObject && SingleCollision == false) // Se for o objeto certo e n�o for um ponto de colis�o unica muda de cor e muda o alvo
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            MovingObjectScript.target = NextTarget;
        }
        else if (other == MovingObject && CollisionSpent == false)  // Se for o objeto certo e for um ponto de colis�o unica muda de cor, muda o alvo e garante que este ponto n�o rodara mais o script
        {
            CollisionSpent = true;
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            MovingObjectScript.target = NextTarget;
        }
    }
}
