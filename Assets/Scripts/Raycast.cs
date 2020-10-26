using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public static float health = 5;
    public static float money = 0;
    [SerializeField] public Text healthText;
    [SerializeField] public Text purseText;

    // Update is called once per frame
    void Update()
    {
        // Text format
        healthText.text = "" + health;
        purseText.text = "000" + money;

        if(money > 9)
        {
            purseText.text = "00" + money;
        }

        // 1. Test for mouse click
        if (Input.GetMouseButtonUp(0))
        {
            // 2. Get mouse position in world space
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));

            // 3. Get direction vector from camera position to mouse position in world space
            Vector3 direction = worldMousePosition - Camera.main.transform.position;

            RaycastHit hit;

            // 4. Cast a ray from the camera to the direction
            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);
                // Decrease health
                health--;

                // If health is 0 destroy enemy
                if (health == 0)
                {
                    money =+ 10;
                    Destroy(hit.collider.gameObject);
                }
            }
            else
            {
                Debug.DrawLine(Camera.main.transform.position, worldMousePosition, Color.red, 0.5f);
            }

        }
    }
}
