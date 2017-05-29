import edu.princeton.cs.algs4.StdIn;
import edu.princeton.cs.algs4.StdOut;
import edu.princeton.cs.algs4.StdRandom;

public class Permutation {

    public static void main(String[] args) {

        int k = Integer.parseInt(args[0]);
        if (k == 0) {
            return;
        }

        RandomizedQueue<String> queue = new RandomizedQueue<>();
        for (int i = 1; !StdIn.isEmpty(); i++) {
            String item = StdIn.readString();
            if (i <= k) {
                queue.enqueue(item);
            } else if ((double) k / i > StdRandom.uniform()) {
                queue.dequeue();
                queue.enqueue(item);
            }
        }

        while (!queue.isEmpty()) {
            StdOut.println(queue.dequeue());
        }
    }
}
