using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _09_07_Lerp : MonoBehaviour
{
    /*
     
    �������� : �߰����� �����ϴ� �� (���� ��ϴ� ���� ������Ʈ�� ������ �ð��� ����ʿ� ���� b�� a (x��ǥ)���� �����ϴµ�, t�ʵ��� ����
    t�� 0�� �Ǹ� ����� a, �ð��� 0�� �� x ��ǥ��a�� �ִ�
    t�� �����ϸ� �ִ��� 1��
    t�� 0.1�̸� b�� 0.1, a�� 0.9
    b������ 0.1��ŭ ������ a�� ���忡���� 0.1�� �پ��� ��

    t : �ð� // �ð��� ����ʿ� ���� b��a���� �����ϴµ�,
    a : ����� b : ������

    ��� = bt + (1-t)a  // (1-t)a + bt
    �ð���0�� �� x�� ��ǥ�� a �� ����
    t�� �����ϰ� �Ǹ�, �������� 1
    �߰����� �����ϴ� ��
     
     
     */

    // animate the game object from -1 to +1 and back
    public float minimum = -1.0F;
    public float maximum = 1.0F;

    // starting value for the Lerp
    static float t = 0.0f;

    void Update()
    {
        // animate the position of the game object...
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;                                 //t�� �����ϸ� a�� ���� ���� �پ���

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
