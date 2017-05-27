import edu.princeton.cs.algs4.StdIn;
import edu.princeton.cs.algs4.StdOut;

public class Permutation {

    public static void main(String[] args){

        int k = Integer.parseInt(args[0]);
        String[] items = StdIn.readAllStrings();
        RandomizedQueue<String> queue = new RandomizedQueue<>();
        int rest = items.length - k;

        for (int i = 0; i < k; i++){
            queue.enqueue(items[i]);
        }

        for (int i = 0; i < k; i++){
            StdOut.print(queue.dequeue());
            if(rest > 0){
                queue.enqueue(items[k + rest - 1]);
                rest--;
            }
        }
        
    }
}
