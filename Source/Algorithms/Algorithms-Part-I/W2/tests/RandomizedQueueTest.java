import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class RandomizedQueueTest {

    @Test
    public void isEmpty() {
        RandomizedQueue<Integer> queue = new RandomizedQueue<>();
        assertEquals(0, queue.size());
        assertTrue(queue.isEmpty());
    }

    @Test
    public void enqueue() {
        RandomizedQueue<Integer> queue = new RandomizedQueue<>();
        queue.enqueue(5);

        assertEquals(1, queue.size());
        assertFalse(queue.isEmpty());

        assertEquals(5, queue.sample().intValue());
        assertFalse(queue.isEmpty());
        assertEquals(1, queue.size());
    }

    @Test
    public void dequeue() {
        RandomizedQueue<Integer> queue = new RandomizedQueue<>();
        queue.enqueue(4);

        assertEquals(4, queue.dequeue().intValue());
        assertTrue(queue.isEmpty());
        assertEquals(0, queue.size());
    }

    @Test
    public void test() {
        RandomizedQueue<Integer> queue = new RandomizedQueue<>();
        queue.enqueue(297);
        queue.enqueue(421);
        queue.enqueue(22);

        System.out.println(queue.dequeue());

        queue.enqueue(118);

        System.out.println(queue.dequeue());
        System.out.println(queue.dequeue());
    }

}
