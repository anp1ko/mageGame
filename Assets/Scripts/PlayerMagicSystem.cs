using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    public IceShowerSpell iceShowerSpell;
    public MeteoriteShowerSpell meteoriteShowerSpell;

    public Camera cam;

    public PlayerMana playerMana;

    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && iceShowerSpell.manaCost <= playerMana.currentMana)
        {
            iceShowerSpell.CastSpell(cam);
            playerMana.currentMana -= iceShowerSpell.manaCost;
        }
        
        if (Input.GetKeyDown(KeyCode.M) && meteoriteShowerSpell.manaCost <= playerMana.currentMana)
        {
            meteoriteShowerSpell.CastSpell(cam);
            playerMana.currentMana -= meteoriteShowerSpell.manaCost;
        }

    }
}
