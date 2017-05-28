import edu.princeton.cs.algs4.StdIn;
import edu.princeton.cs.algs4.StdOut;

public class Permutation {

    public static void main(String[] args) {

        int k = Integer.parseInt(args[0]);

        RandomizedQueue<String> queue = new RandomizedQueue<>();
        for (int i = 1; !StdIn.isEmpty(); i++) {
            String s = StdIn.readString();
            if (i <= k) {
                queue.enqueue(s);
            } else if (Math.random() < (double) k / i) {
                queue.dequeue();
                queue.enqueue(s);
            }
        }

        while (!queue.isEmpty()) {
            StdOut.println(queue.dequeue());
        }
    }
}
