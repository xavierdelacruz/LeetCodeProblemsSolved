using System.Threading;

public class Foo {

    private AutoResetEvent first;
    private AutoResetEvent second;
    
    public Foo() {
        first = new AutoResetEvent(false);
        second = new AutoResetEvent(false);    
    }

    public void First(Action printFirst) {
        
        // printFirst() outputs "first". Do not change or remove this line.
        printFirst();
        first.Set();
    }

    public void Second(Action printSecond) {
        first.WaitOne();
        // printSecond() outputs "second". Do not change or remove this line.
        printSecond();
        second.Set();
    }

    public void Third(Action printThird) {
        second.WaitOne();
        // printThird() outputs "third". Do not change or remove this line.
        printThird();
    }
}