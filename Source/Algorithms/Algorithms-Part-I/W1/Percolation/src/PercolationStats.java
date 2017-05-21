import edu.princeton.cs.algs4.StdOut;
import edu.princeton.cs.algs4.StdRandom;
import edu.princeton.cs.algs4.StdStats;

public class PercolationStats {
    private double[] estimations;
    private int experiments;

    public PercolationStats(int n, int trials) {
        if (n <= 0 || trials <= 0) {
            throw new IllegalArgumentException("n ≤ 0 or trials ≤ 0");
        }

        experiments = trials;
        estimations = new double[experiments];

        for (int i = 0; i < experiments; i++) {
            estimations[i] = estimate(n);
        }
    }

    private double estimate(int gridSize){
        int openSites = 0;
        Percolation percolation = new Percolation(gridSize);
        while (!percolation.percolates()) {
            int row = StdRandom.uniform(1, gridSize + 1);
            int col = StdRandom.uniform(1, gridSize + 1);
            if (!percolation.isOpen(row, col) && !percolation.isFull(row, col)) {
                percolation.open(row, col);
                openSites++;
            }
        }
        return (double) openSites / (gridSize * gridSize);
    }

    public double mean() {
        return StdStats.mean(estimations);
    }

    public double stddev() {
        return StdStats.stddev(estimations);
    }

    public double confidenceLo() {
        return mean() - ((1.96 * stddev()) / Math.sqrt(experiments));
    }

    public double confidenceHi() {
        return mean() + ((1.96 * stddev()) / Math.sqrt(experiments));
    }

    public static void main(String[] args) {
        PercolationStats stats = new PercolationStats(Integer.parseInt(args[0]), Integer.parseInt(args[1]));

        String confidence = stats.confidenceLo() + ", " + stats.confidenceHi();
        StdOut.println("mean                    = " + stats.mean());
        StdOut.println("stddev                  = " + stats.stddev());
        StdOut.println("95% confidence interval = " + "[" + confidence + "]");
    }
}
