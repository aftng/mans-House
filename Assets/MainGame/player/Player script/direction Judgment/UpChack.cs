using UnityEngine;

public class UpChack : MonoBehaviour
{
    private string UpChackTag = "statue";
    private bool isUpChack = false;
    private bool isUpChackEnter, isUpChackExit;
    public bool IsUpChack()
    {
        //ê⁄êGîªíË 
        if (isUpChackEnter)
        {
          isUpChack = true;
        }
        else if (isUpChackExit)
        {
          isUpChack = false;
        }
        isUpChackEnter = false;
        isUpChackExit = false;
        return isUpChack;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == UpChackTag)
        {
            isUpChackEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == UpChackTag)
        {
            isUpChackExit = true;
        }
    }
}
