import static java.util.Objects.isNull;


public class Selection {
    private Selection() {
    }

    public static void sort(Comparable[] items) {
        if (isNull(items)) {
            throw new NullPointerException();
        }
        if (items.length == 0) {
            return;
        }
        for (int i = 0; i < items.length; i++) {
            int min = i;
            for (int j = i + 1; j < items.length; j++) {
                if (less(items[j], items[i])) {
                    min = j;
                }
            }
            swap(items, i, min);
        }
    }

    public static boolean isSorted(Comparable[] items) {
        if (isNull(items)) {
            throw new NullPointerException();
        }
        if (items.length < 2) {
            return true;
        }
        for (int i = 1; i < items.length; i++) {
            if (less(items[i - 1], items[i]) == false) {
                return false;
            }
        }
        return true;
    }

    private static boolean less(Comparable a, Comparable b) {
        return a.compareTo(b) < 0;
    }

    private static void swap(Comparable[] items, int i, int j) {
        if (i == j) {
            return;
        }
        Comparable temp = items[i];
        items[i] = items[j];
        items[j] = temp;
    }

}
