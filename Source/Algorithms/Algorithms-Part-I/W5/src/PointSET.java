import edu.princeton.cs.algs4.Point2D;
import edu.princeton.cs.algs4.Queue;
import edu.princeton.cs.algs4.RectHV;

import java.util.TreeSet;

public class PointSET {

    private TreeSet<Point2D> set = new TreeSet<>();

    public boolean isEmpty() {
        return set.isEmpty();
    }

    public int size() {
        return set.size();
    }

    public void insert(Point2D point) {
        if (point == null) {
            throw new NullPointerException();
        }
        if (set.contains(point)) {
            return;
        }
        set.add(point);
    }

    public boolean contains(Point2D point) {
        if (point == null) {
            throw new NullPointerException();
        }

        return set.contains(point);
    }

    public void draw() {
        for (Point2D point : set) {
            point.draw();
        }
    }

    public Iterable<Point2D> range(RectHV rect) {
        if (rect == null) {
            throw new NullPointerException();
        }

        Queue<Point2D> result = new Queue<>();

        for (Point2D point : set) {
            if (rect.contains(point)) {
                result.enqueue(point);
            }
        }
        return result;
    }

    public Point2D nearest(Point2D point) {
        if (point == null) {
            throw new NullPointerException();
        }
        if (set.isEmpty()) {
            return null;
        }


        double distance = Double.MAX_VALUE;
        Point2D result = null;
        for (Point2D item : set) {
            double newDistance = point.distanceSquaredTo(item);
            if (newDistance < distance) {
                distance = newDistance;
                result = item;
            }
        }
        return result;
    }

}
