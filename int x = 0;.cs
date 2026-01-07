int x = 0;
for(int i = 0; i < 2; i++)
{
    x += 1;
}
Console.WriteLine(x); 

public class Example : MonoBehaviour {
    private void Update () {
        PrintMessage();
    }
    private void PrintMessage () {
        Debug.Log(“hello world”);
    }

private void Start () {
    PrintMessage(10);
}
    private void PrintMessage (int x) {
        Debug.Log(“x = ” + x);
}
private void Start () {
    PrintMessage(10);
}
    private void PrintMessage (int x) {
        Debug.Log(“x = ” + x);
}
