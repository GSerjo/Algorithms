import edu.princeton.cs.algs4.StdRandom;

import java.util.Iterator;
import java.util.NoSuchElementException;

public class RandomizedQueue<Item> implements Iterable<Item> {

    private int size = 0;
    private Item[] items;

    public RandomizedQueue() {
        items = (Item[]) new Object[2];
    }

    public boolean isEmpty() {
        return size == 0;
    }

    public int size() {
        return size;
    }

    public void enqueue(final Item item) {
        if (item == null) {
            throw new NullPointerException();
        }
        if (size == items.length) {
            resize(size * 2);
        }
        items[size++] = item;
    }

    public Item dequeue() {
        if (isEmpty()) {
            throw new NoSuchElementException();
        }
        int index = StdRandom.uniform(size);
        Item result = items[index];
        items[index] = items[--size];
        items[size] = null;
        if (size > 0 && size == items.length / 4) {
            resize(items.length / 2);
        }
        return result;
    }

    public Item sample() {
        if (isEmpty()) {
            throw new NoSuchElementException();
        }
        int index = StdRandom.uniform(size);
        return items[index];
    }

    private void resize(int newSize) {
        Item[] newItems = (Item[]) new Object[newSize];

        for (int i = 0; i < items.length; i++) {
            newItems[i] = items[i];
        }
        items = newItems;
    }

    public Iterator<Item> iterator() {
        return new DequeIterator();
    }

    private class DequeIterator implements Iterator<Item> {

        private final Item[] iterator;
        private int sizeIterator = size;

        DequeIterator() {
            iterator = (Item[]) new Object[size];
            for (int i = 0; i < size; i++) {
                iterator[i] = items[i];
            }
            StdRandom.shuffle(iterator);
        }

        public boolean hasNext() {
            return sizeIterator > 0;
        }

        public Item next() {
            if (!hasNext()) {
                throw new NoSuchElementException();
            }
            Item result = iterator[--sizeIterator];
            iterator[sizeIterator] = null;
            return result;
        }

        public void remove() {
            throw new UnsupportedOperationException();
        }
    }
}
