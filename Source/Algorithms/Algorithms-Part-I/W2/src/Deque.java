import java.util.Iterator;
import java.util.NoSuchElementException;

public class Deque<Item> implements Iterable<Item> {

    private Node head;
    private Node tail;
    private int size;

    public Deque(){
        size = 0;
    }

    public int size(){
        return size;
    }

    public boolean isEmpty() {
        return size == 0;
    }

    public void addFirst(final Item item) {
        if(item == null){
            throw new NullPointerException();
        }

        head = new Node(){{
            value = item;
            next = head;
            previous = null;
        }};
        if(isEmpty()){
            tail = head;
        }
        else {
            head.next.previous = head;
        }
        size++;
    }

    public Item removeFirst() {
        if(isEmpty()){
            throw new NoSuchElementException();
        }
        Item result = head.value;
        head = head.next;
        size--;
        if(isEmpty()){
            head = null;
            tail = null;
        }
        else {
            head.previous = null;
        }
        return  result;
    }

    public void addLast(final Item item) {
        if(item == null){
            throw new NullPointerException();
        }
        tail = new Node(){{
           value = item;
           next = null;
           previous = tail;
        }};
        if(isEmpty()){
            head = tail;
        }
        else{
            tail.previous.next = tail;
        }
        size++;
    }

    public Item removeLast(){
        if(isEmpty()){
            throw new NoSuchElementException();
        }
        Item result = tail.value;
        tail = tail.previous;
        size--;
        if(isEmpty()){
            head = null;
            tail = null;
        }
        else {
            tail.next = null;
        }
        return result;
    }

    public Iterator<Item> iterator() {
        return new DequeIterator();
    }

    private class DequeIterator implements Iterator<Item>{

        Node current = head;

        public boolean hasNext() {
            return current != null;
        }

        public Item next() {
            if(!hasNext()){
                throw new NoSuchElementException();
            }
            Item result = current.value;
            current = current.next;
            return result;
        }

        public void remove() {
            throw new UnsupportedOperationException();
        }
    }

    private class Node {
        Item value;
        Node next;
        Node previous;
    }

}
