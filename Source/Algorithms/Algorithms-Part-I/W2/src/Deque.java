import java.util.Iterator;
import java.util.NoSuchElementException;

public class Deque<Item> implements Iterable<Item> {

    @Override
    public Iterator<Item> iterator() {
        return null;
    }

    private class DequeIterator implements Iterator<Item>{

        Node current = head;

        @Override
        public boolean hasNext() {
            return current != null;
        }

        @Override
        public Item next() {
            if(!hasNext()){
                throw new NoSuchElementException();
            }
            Item result = current.value;
            current = current.next;
            return result;
        }

        @Override
        public void remove() {
            throw new UnsupportedOperationException();
        }
    }

    private class Node {
        public Item value;
        public Node next;
        public Node previous;
    }

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

    public void addFirst(Item item) {
        if(item == null){
            throw new NullPointerException();
        }
        Node node = new Node(){{
            value = item;
            next = head;
            previous = null;
        }};

        head = node;
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

    public void addLast(Item item) {
        if(item == null){
            throw new NullPointerException();
        }
        Node node = new Node(){{
           value = item;
           next = null;
           previous = tail;
        }};
        tail = node;
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

}
