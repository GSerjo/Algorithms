import java.util.NoSuchElementException;

public class Deque<Item> {

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
            node.next.previous = head;
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

}
