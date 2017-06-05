import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;


public class FastCollinearPoints {

    private List<LineSegment> segments = new ArrayList<>();

    public FastCollinearPoints(Point[] points) {
        if (points == null) {
            throw new NullPointerException();
        }
        Arrays.sort(points);

        validatePoints(points);

        Point[] pointsCopy = Arrays.copyOf(points, points.length);
        Arrays.sort(pointsCopy);

        for (int i = 0; i < pointsCopy.length - 3; i++) {
            Arrays.sort(pointsCopy);
            Arrays.sort(pointsCopy, pointsCopy[i].slopeOrder());

            for (int p = 0, first = 1, last = 2; last < pointsCopy.length; last++) {
                while (last < pointsCopy.length
                        && equals(pointsCopy[p].slopeTo(pointsCopy[first]), pointsCopy[p].slopeTo(pointsCopy[last]))) {
                    last++;
                }
                if (last - first >= 3 && pointsCopy[p].compareTo(pointsCopy[first]) < 0) {
                    segments.add(new LineSegment(pointsCopy[p], pointsCopy[last - 1]));
                }
                first = last;
            }
        }
    }

    private boolean equals(double a, double b) {
        return Double.compare(a, b) == 0;
    }

    private void validatePoints(Point[] points) {
        for (int i = 0; i < points.length - 1; i++) {
            if (points[i] == null) {
                throw new NullPointerException();
            }
            if (points[i].compareTo(points[i + 1]) == 0) {
                throw new IllegalArgumentException();
            }
        }
    }

    public int numberOfSegments() {
        return segments.size();
    }

    public LineSegment[] segments() {
        return segments.toArray(new LineSegment[segments.size()]);
    }
}
