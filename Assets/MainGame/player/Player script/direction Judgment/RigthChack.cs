using UnityEngine;

public class RigthChack : MonoBehaviour
{
    private string RigthChackTag = "statue";
    private bool isRigthChack = false;
    private bool isRigthChackEnter, isRigthChackExit;
    public bool IsRigthChack()
    {
        //ê⁄êGîªíË
        if (isRigthChackEnter )
        {
            isRigthChack = true;
        }
        else if (isRigthChackExit)
        {
            isRigthChack = false;
        }

        isRigthChackEnter = false;
        isRigthChackExit = false;
        return isRigthChack;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == RigthChackTag)
        {
            isRigthChackEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == RigthChackTag)
        {
            isRigthChackExit = true;
        }
    }
}
