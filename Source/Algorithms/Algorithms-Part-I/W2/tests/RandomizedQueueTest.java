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

}
