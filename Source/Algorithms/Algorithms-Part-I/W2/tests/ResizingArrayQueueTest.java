import org.junit.jupiter.api.Test;

/**
 * Created by Serjo on 28/05/2017.
 */
public class ResizingArrayQueueTest {

    @Test
    public void test() {
        ResizingArrayQueue<Integer> queue = new ResizingArrayQueue<>();

        queue.enqueue(1);
        queue.enqueue(2);
        queue.enqueue(3);

        queue.dequeue();
        queue.enqueue(4);
        queue.enqueue(5);
        queue.enqueue(6);
        queue.enqueue(7);
    }
}
