using Microsoft.JSInterop;

public class JsSample
{
    [JSInvokable("AddTwoNumbers")]
    public static int Sum(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber; 
    }
}