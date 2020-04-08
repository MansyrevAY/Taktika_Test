using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ClickOnTower : MonoBehaviour
{
    private Controls inputs;

    private void Awake()
    {
        inputs = new Controls();
        inputs.Player.Clickmap.performed +=  ctx => ClickOnMap();
    }

    private void OnEnable() => inputs.Enable();
    private void OnDisable() => inputs.Disable();

    private void ClickOnMap()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        if (UIWasClicked(mousePos))
            return;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);

        if (!hit)
            return;

        if(hit.transform.tag == "Tower")
        {
            Click(hit);
        }
        
    }

    private bool UIWasClicked(Vector2 mousePos)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = new Vector2(mousePos.x, mousePos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);

        foreach (RaycastResult res in results)
        {
            if (res.gameObject.layer == 5)
                return true;
        }

        return false;
    }

    private void Click(RaycastHit2D hit)
    {
        Tower tower = hit.transform.GetComponent<Tower>();

        tower.OnTowerUpgraded();
    }
}
