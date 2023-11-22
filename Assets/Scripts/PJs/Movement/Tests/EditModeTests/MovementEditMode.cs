using UnityEngine;
using NUnit.Framework;
using UnityEngine.UIElements;

[TestFixture]
public class MovementPjTests
{
    private GameObject pj;
    private Rigidbody rb;
    private bool isMoving;

    [SetUp]
    public void SetUps ()
    {
        pj = new GameObject();
        pj.AddComponent<Rigidbody>();
        rb = pj.GetComponent<Rigidbody>();
    }

    [TestCase(5, -20)]
    [TestCase(-15, 50)]
    [TestCase(200, -576)]
    public void start_Moving_InputMousePosition(float x, float z)
    {
        RaycastHit hit;
        Ray ray = new Ray(pj.transform.position, new Vector3(x, 0, z) - pj.transform.position);
        if (Physics.Raycast(ray, out hit))
        {
            isMoving = true;
        }
        Assert.IsNotNull(hit.point);
        Assert.IsTrue(isMoving);
        Assert.IsFalse(rb.isKinematic);
    }

    [Test]
    public void start_Moving_NotMove()
    {
        isMoving = false;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            isMoving = true;
        } else
        {
            rb.isKinematic = true;
            Assert.AreEqual(Vector3.zero, hit.point);
        }
        Assert.IsFalse(isMoving);
        Assert.IsTrue(rb.isKinematic);
    }

    [TestCase(5.0f)]
    [TestCase(1.0f)]
    [TestCase(22.0f)]
    public void moving_Speed(float speed)
    {
        Vector3 result = new Vector3 (0, 0, 1 * speed);
        rb.velocity = Vector3.forward * speed;
        Assert.AreEqual(rb.velocity, result);
    }

    [TestCase(5.0f, 10, -20)]
    [TestCase(1.0f, 5, 15)]
    [TestCase(22.0f, 200, -576)]
    public void moving_Destiny(float speed, float x, float z)
    {
        Vector3 destiny = new Vector3(x, 1, z);
        Vector3 direction = destiny - rb.position;
        direction.Normalize();
        rb.velocity = direction * speed;
        // Equal
        Vector3 result = (destiny - rb.position).normalized * speed;
        Assert.AreEqual(rb.velocity, result);
    }

    [TestCase(5, -20)]
    [TestCase(-15, 50)]
    [TestCase(200, -576)]
    public void moving_Rotation(float x, float z)
    {
        float speedRotation = 10f;
        Vector3 destiny = new Vector3(x, 1, z);
        Vector3 direction = destiny - rb.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        Quaternion pjRotation = Quaternion.Slerp(pj.transform.rotation, rotation, Time.deltaTime * speedRotation);
        pjRotation.Normalize();
        rotation.Normalize();
        Assert.NotNull(pjRotation);
    }

    [TestCase(5, -20)]
    [TestCase(-15, 50)]
    [TestCase(200, -576)]
    public void stop_Moving(float x, float z)
    {
        isMoving = true;
        Vector3 destiny = new Vector3(x, 1, z);
        Vector3 direction = destiny - new Vector3(x - 1, 1, z - 1);
        if (direction.magnitude < 2f)
        {
            isMoving = false;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        Assert.IsFalse(isMoving);
        Assert.AreEqual(rb.velocity, Vector3.zero);
        Assert.IsTrue(rb.isKinematic);
    }

    [TestCase(5, -20)]
    [TestCase(-15, 50)]
    [TestCase(200, -576)]
    public void stop_Not_Moving(float x, float z)
    {
        isMoving = true;
        rb.velocity = new Vector3(x, 1, z);
        Vector3 destiny = new Vector3(x, 1, z);
        Vector3 direction = destiny - rb.position;
        if (direction.magnitude < 2f)
        {
            isMoving = false;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        Assert.IsTrue(isMoving);
        Assert.AreNotEqual(rb.velocity, Vector3.zero);
        Assert.IsFalse(rb.isKinematic);
    }
}
