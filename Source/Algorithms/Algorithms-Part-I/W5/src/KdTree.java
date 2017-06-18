import edu.princeton.cs.algs4.Point2D;
import edu.princeton.cs.algs4.Queue;
import edu.princeton.cs.algs4.RectHV;

public class KdTree {

    private Node root;
    private int size;

    public boolean isEmpty() {
        return size == 0;
    }

    public int size() {
        return size;
    }

    public void draw() {

    }

    public void insert(Point2D point) {
        if (point == null) {
            throw new NullPointerException();
        }
        root = insert(root, point);
    }

    public boolean contains(Point2D point) {
        if (point == null) {
            throw new NullPointerException();
        }
        return contains(root, point);
    }

    public Iterable<Point2D> range(RectHV rect) {
        if (rect == null) {
            throw new NullPointerException();
        }
        Queue<Point2D> result = new Queue<>();

        if (isEmpty()) {
            return result;
        }
        Queue<Node> nodes = new Queue<>();
        nodes.enqueue(root);

        while (!nodes.isEmpty()) {
            Node node = nodes.dequeue();
            if (node == null) {
                continue;
            }
            if (rect.contains(node.value)) {
                result.enqueue(node.value);
            }
            if (node.x) {
                if (node.value.x() > rect.xmax()) {
                    nodes.enqueue(node.left);
                } else if (node.value.x() < rect.xmin()) {
                    nodes.enqueue(node.right);
                } else {
                    nodes.enqueue(node.left);
                    nodes.enqueue(node.right);
                }
            } else {
                if (node.value.y() > rect.ymax()) {
                    nodes.enqueue(node.left);
                } else if (node.value.y() < rect.ymin()) {
                    nodes.enqueue(node.right);
                } else {
                    nodes.enqueue(node.left);
                    nodes.enqueue(node.right);
                }
            }
        }

        return result;
    }

    public Point2D nearest(Point2D point) {
        if (point == null) {
            throw new NullPointerException();
        }
        if (isEmpty()) {
            return null;
        }
        return nearest(root, point, root.value);
    }

    private Point2D nearest(Node node, Point2D point, Point2D result) {
        if (node == null) {
            return result;
        }

        double distance = result.distanceSquaredTo(point);
        if (node.value.distanceSquaredTo(point) < distance) {
            result = node.value;
        }

        if (node.rect.distanceSquaredTo(point) < distance) {
            if (node.x) {
                if (point.x() < node.value.x()) {
                    result = nearest(node.left, point, result);
                    result = nearest(node.right, point, result);
                } else {
                    result = nearest(node.right, point, result);
                    result = nearest(node.left, point, result);
                }
            } else {
                if (point.y() < node.value.y()) {
                    result = nearest(node.left, point, result);
                    result = nearest(node.right, point, result);
                } else {
                    result = nearest(node.right, point, result);
                    result = nearest(node.left, point, result);
                }
            }
        }

        return result;
    }

    private boolean contains(Node root, Point2D point) {
        if (root == null) {
            return false;
        }
        Node current = root;
        boolean isX = true;
        while (true) {
            if (current == null) {
                return false;
            }
            if (point.equals(current.value)) {
                return true;
            }
            if (isX) {
                current = point.x() > current.value.x() ? current.right : current.left;
            } else {
                current = point.y() > current.value.y() ? current.right : current.left;
            }
            isX = !isX;
        }
    }

    private Node insert(Node node, Point2D point) {
        double xmin = 0;
        double ymin = 0;
        double xmax = 1;
        double ymax = 1;
        if (node == null) {
            size++;
            return new Node(point, new RectHV(xmin, ymin, xmax, ymax), true);
        }
        Node current = node;
        Node previous = null;
        boolean right = false;
        boolean isX = true;
        while (true) {
            if (current == null) {
                if (right) {
                    previous.right = new Node(point, new RectHV(xmin, ymin, xmax, ymax), isX);
                } else {
                    previous.left = new Node(point, new RectHV(xmin, ymin, xmax, ymax), isX);
                }
                size++;
                break;
            }
            if (point.x() == current.value.x() && point.y() == current.value.y()) {
                break;
            }
            previous = current;
            if (isX) {
                right = point.x() > current.value.x();
                if (right) {
                    xmin = current.value.x();
                } else {
                    xmax = current.value.x();
                }
                current = right ? current.right : current.left;
            } else {
                right = point.y() > current.value.y();
                if (right) {
                    ymin = current.value.y();
                } else {
                    ymax = current.value.y();
                }
                current = right ? current.right : current.left;
            }
            isX = !isX;
        }

        return node;
    }

    private class Node {
        private Node left;
        private Node right;
        private Point2D value;
        private boolean x;
        private RectHV rect;


        public Node(Point2D point, RectHV rect, boolean x) {
            value = point;
            this.x = x;
            this.rect = rect;
        }

    }

}
