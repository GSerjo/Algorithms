import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Serjo on 25/05/2017.
 */
class DequeTest {

    @Test
    void isEmpty() {
        assertEquals(0, new Deque<Integer>().size());
    }

    @Test
    void addFirstAndRemoveFirst() {
        Deque<Integer> deque = new Deque<>();
        deque.addFirst(1);
        deque.addFirst(2);

        assertEquals(2, deque.removeFirst().intValue());
        assertEquals(1, deque.size());
        assertFalse(deque.isEmpty());

        assertEquals(1, deque.removeLast().intValue());
        assertTrue(deque.isEmpty());
    }

    @Test
    void addLast() {
        Deque<Integer> deque = new Deque<>();
        deque.addLast(1);
        deque.addLast(2);
        deque.addLast(3);

        assertEquals(1, deque.removeFirst().intValue());
        assertEquals(2, deque.size());

        assertEquals(3, deque.removeLast().intValue());
        assertEquals(1, deque.size());
        assertFalse(deque.isEmpty());
    }
}