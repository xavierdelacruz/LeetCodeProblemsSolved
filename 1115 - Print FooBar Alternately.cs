using System.Threading;

public class FooBar {
    private int n;
    private AutoResetEvent firstJob;
    private AutoResetEvent secondJob;
    public FooBar(int n) {
        this.n = n;
        firstJob = new AutoResetEvent(false);
        secondJob = new AutoResetEvent(false);
    }

    public void Foo(Action printFoo) {
        
        for (int i = 0; i < n; i++) {

        	printFoo();
            
            // Now set it after it prints to signal in the other method
            // that it has finished execution.
            firstJob.Set();
            
            // It will now wait for bar to finish before going to the next iteration.
            secondJob.WaitOne();
        }
    }

    public void Bar(Action printBar) {
        
        for (int i = 0; i < n; i++) {
            
            // This will unblock once we receive a signal from Foo
            firstJob.WaitOne();
            
            
        	printBar();
            
            // We now send a signal to the foo that we are done printing bar.
            secondJob.Set();
        }
    }
}