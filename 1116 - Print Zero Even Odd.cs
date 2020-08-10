using System.Threading;

public class ZeroEvenOdd {
    private int n;
    private AutoResetEvent zeroJob;
    private AutoResetEvent evenJob;
    private AutoResetEvent oddJob;
    
    private bool printedEven;
    private bool printedOdd;
    
    public ZeroEvenOdd(int n) {
        this.n = n;
       
        this.zeroJob = new AutoResetEvent(false);
        this.evenJob = new AutoResetEvent(false);
        this.oddJob = new AutoResetEvent(false);
       
        printedEven = false;
        printedOdd = false;
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber) {        
        for (int i = 0; i < n; i++) {                  
            printNumber(0);
 
            // Initial case, none have been set.
            if (!printedEven && !printedOdd) {
                oddJob.Set();
            } else if (printedEven) {
                // If we just printed an even number
                // Send a signout to tell that we are printing again
                oddJob.Set();
            } else {
                // If we just printed an odd number
                // Then send a signal out to indicate that we are printing even
                evenJob.Set();
            }
            
            zeroJob.WaitOne(); 
        }
    }

    public void Even(Action<int> printNumber) {     
        var i = 2;
        while (i <= n) {
            
            // If we have not printed an odd number, then wait.
            evenJob.WaitOne();
            printNumber(i);
            i = i + 2;
            printedEven = true;
            printedOdd = false;
            zeroJob.Set();
        }    
    }

    public void Odd(Action<int> printNumber) {
        
        var i = 1;
        while (i <= n) {            
            // If we have not printed an even number, block.
            oddJob.WaitOne();
            printNumber(i);
            i = i + 2;
            printedEven = false;
            printedOdd = true;
            zeroJob.Set();
        }    
    }
}