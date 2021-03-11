using UnityEngine;

//��� ������� ����������� ��� ��� ������ �� ��������� ���� �� ������ ����� ������������� ��������� Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    // �.�. ������ �������� ���������� �� ��������� ������� � ����� ����������� ��������
    public float Speed = 5f;

    public float JumpForce = 300f;

    //��� �� ��� ���������� �������� �������� ��� "Ground" �� ���� ����������� �����
    private bool _isGrounded;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        //�������� �������� ��� ��� �������� � ������� 
        //���������� ������ � FixedUpdate, � �� � Update
        JumpLogic();

        // � ����� ������ ��������� ������������ ��� �����, �� ����� � � Update.
        // �� ��� �� �������� �����, �� 
        // ������� ����� ��������� ��������� fixedDeltaTim� 
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ��� �� �������� ���� ���������� � ����� ������
        // � �������� ��� �� �������� �� FixedUpdate �� �������� �� fixedDeltaTim�
        transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                // �������� �������� ��� � ����� �� ������ Vector3.up � �� �� ������ transform.up
                // ���� ��� �������� ��� ��� -- ��� up ����� ���� � ��� ����� � ���� � ����� � ������. 
                // �� ��� ����� ������ ������ �����! ������ � Vector3.up
                _rb.AddForce(Vector3.up * JumpForce);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}