import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;


class SelectionTest {
    @Test
    void sort() {
        Integer[] items = { 2, 3, 1, 6, 5};
        Selection.sort(items);
        assertTrue(Selection.isSorted(items));
    }

}