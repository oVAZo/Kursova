using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerControllerTests
{
    [UnityTest]
    public IEnumerator PlayerMovesTowardsTargetPosition()
    {
        GameObject playerObject = new GameObject();
        PlayerController playerController = playerObject.AddComponent<PlayerController>();
        playerController.moveSpeed = 1f;

        Vector3 initialPosition = playerObject.transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(1, 0, 0); // Move to the right

        playerController.UpdateInput(new Vector2(1, 0));
        yield return playerController.Move(targetPosition);

        Assert.AreEqual(targetPosition, playerObject.transform.position);
    }

    [UnityTest]
    public IEnumerator PlayerCannotMoveThroughWalls()
    {
        GameObject playerObject = new GameObject();
        PlayerController playerController = playerObject.AddComponent<PlayerController>();
        playerController.moveSpeed = 5f;

        Vector3 initialPosition = playerObject.transform.position;
        Vector2 input = new Vector2(1f, 0f); // Moving to the right

        playerController.UpdateInput(input);

        yield return null; // Wait for one frame to allow Update to be called

        Assert.AreEqual(initialPosition, playerObject.transform.position);
    }
}
