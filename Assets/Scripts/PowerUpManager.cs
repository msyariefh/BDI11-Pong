using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public Vector2 maxArea;
    public Vector2 minArea;
    public int maxPowerUpAmount;
    public List<GameObject> templatePowerUpList;
    private List<GameObject> powerUpList;
    public int spawnInterval;
    public float PULongerDuration;
    public float PUFasterDuration;
    private float timer;


    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < spawnInterval) return;

        if (powerUpList.Count >= maxPowerUpAmount) RemovePowerUp(powerUpList[0]);

        GenerateRandomPowerUp();
        timer -= spawnInterval;

    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(minArea.x, maxArea.x), 
            Random.Range(minArea.y, maxArea.y)));
    }
    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount) return;
        if (position.x < minArea.x) return;
        if (position.x > maxArea.x) return;
        if (position.y < minArea.y) return;
        if (position.y > maxArea.y) return;

        int randomIndex = Random.Range(0, templatePowerUpList.Count);
        GameObject powerUp = Instantiate(templatePowerUpList[randomIndex], 
            new Vector3(position.x, position.y, templatePowerUpList[randomIndex].transform.position.z), 
            Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);

    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }
    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }

    public void AddPaddleLongerEffect(GameObject go, int multiplier)
    {
        StartCoroutine(PULongerPaddleActivation(go.transform, multiplier));
    }
    IEnumerator PULongerPaddleActivation(Transform objectTransform, int multiplier) 
    {
        Vector3 normalScale = objectTransform.localScale;
        objectTransform.localScale = new Vector3(normalScale.x, normalScale.y * multiplier, normalScale.z);
        yield return new WaitForSeconds(PULongerDuration);
        objectTransform.localScale = normalScale;
    }

    public void AddPaddleFasterEffect(GameObject go, int multiplier)
    {
        StartCoroutine(PUFasterPaddleActivation(go.GetComponent<PaddleController>(), multiplier));
    }
    IEnumerator PUFasterPaddleActivation(PaddleController controller, int multiplier)
    {
        int initialSpeed = controller.speed;
        
        controller.speed *= multiplier;
        yield return new WaitForSeconds(PUFasterDuration);
        controller.speed = initialSpeed;
    }
}
