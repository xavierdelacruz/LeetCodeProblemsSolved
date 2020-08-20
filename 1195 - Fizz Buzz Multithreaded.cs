using System;
using System.Threading;

public class FizzBuzz {
    private int n;
    private int counter;
    
    private Barrier barrier;
    
    public FizzBuzz(int n) {
        this.n = n;
        this.counter = 1;
        
        // 4 Participants
        // Barriers are used for phase based participation.
        // This means that the 4 threads (A, B, C and D)
        // will not proceed to the next phase until all have reached
        // the end phase. aka, everyone has called SignalAndWait.
        // This means that it is guaranteed that it will execute a fizz buzz action concurrently.
        this.barrier = new Barrier(4);
    }

    // printFizz() outputs "fizz".
    public void Fizz(Action printFizz) {
        while (counter <= n) {
            if (counter % 3 == 0 && counter % 5 != 0) {
                printFizz();
                counter++;               
            }
            barrier.SignalAndWait(counter);
        } 
    }

    // printBuzzz() outputs "buzz".
    public void Buzz(Action printBuzz) {
        while (counter <= n) {
            if (counter % 3 != 0 && counter % 5 == 0) {
                printBuzz();
                counter++;        
            }
            barrier.SignalAndWait(counter);
        } 
        
    }

    // printFizzBuzz() outputs "fizzbuzz".
    public void Fizzbuzz(Action printFizzBuzz) {
        while (counter <= n) {
            if (counter % 3 == 0 && counter % 5 == 0) {
                printFizzBuzz();
                counter++;               
            }
            barrier.SignalAndWait(counter);
        }
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Number(Action<int> printNumber) {
        while (counter <= n) {
            if (counter % 3 != 0 && counter % 5 != 0) {
                printNumber(counter);
                counter++;            
            }
            barrier.SignalAndWait(counter);
        }
    }
}