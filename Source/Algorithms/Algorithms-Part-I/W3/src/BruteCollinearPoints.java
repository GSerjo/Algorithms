import edu.princeton.cs.algs4.Quick;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class BruteCollinearPoints {

    private List<LineSegment> segments = new ArrayList<>();

    public BruteCollinearPoints(Point[] points) {
        if (points == null) {
            throw new NullPointerException();
        }

        Point[] pointsCopy = Arrays.copyOf(points, points.length);
        validatePoints(pointsCopy);

        Quick.sort(pointsCopy);

        for (int i = 0; i < pointsCopy.length; i++) {
            for (int j = i + 1; j < pointsCopy.length; j++) {
                for (int k = j + 1; k < pointsCopy.length; k++) {
                    for (int l = k + 1; l < pointsCopy.length; l++) {

                        double slopToJ = pointsCopy[i].slopeTo(pointsCopy[j]);

                        if (equals(slopToJ, pointsCopy[i].slopeTo(pointsCopy[k]))
                                && equals(slopToJ, pointsCopy[i].slopeTo(pointsCopy[l]))) {

                            segments.add(new LineSegment(pointsCopy[i], pointsCopy[l]));
                        }
                    }
                }
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
            for (int j = i + 1; j < points.length; j++) {
                if (points[j] == null) {
                    throw new NullPointerException();
                }
                if (points[i].compareTo(points[j]) == 0) {
                    throw new IllegalArgumentException();
                }
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
