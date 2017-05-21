import edu.princeton.cs.algs4.WeightedQuickUnionUF;

public class Percolation {

    private int length;
    private int topPoint;
    private int bottomPoint;
    private boolean[][] opened;
    private WeightedQuickUnionUF percolateUnion;
    private WeightedQuickUnionUF fullPathUnion;

    public Percolation(int N) {
        if (N <= 0) {
            throw new IllegalArgumentException("N <= 0");
        }
        length = N;
        opened = new boolean[length][length];
        percolateUnion = new WeightedQuickUnionUF(length * length + 2);
        fullPathUnion = new WeightedQuickUnionUF(length * length + 1);
        topPoint = length * length;
        bottomPoint = topPoint + 1;
    }

    public void open(int i, int j) {
        if (!areIndexesValid(i, j)) {
            throw new IndexOutOfBoundsException();
        }

        if(opened[i - 1][j - 1]){
            return;
        }

        opened[i - 1][j - 1] = true;
        if (isFirstRow(i)) {
            int p = j - 1;
            percolateUnion.union(p, topPoint);
            fullPathUnion.union(p, topPoint);
        }
        int p = (i - 1) * length + j - 1;
        if (isLastRow(i)){
            percolateUnion.union(p, bottomPoint);
        }
        if (i > 1 && isOpenCore(i - 1, j)) {
            int q = (i - 2) * length + j - 1;
            percolateUnion.union(p, q);
            fullPathUnion.union(p, q);
        }
        if (i < length && isOpenCore(i + 1, j)) {
            int q = i * length + j - 1;
            percolateUnion.union(p, q);
            fullPathUnion.union(p, q);
        }
        if (j > 1 && isOpenCore(i, j - 1)) {
            int q = (i - 1) * length + j - 2;
            percolateUnion.union(p, q);
            fullPathUnion.union(p, q);
        }
        if (j < length && isOpenCore(i, j + 1)) {
            int q = (i - 1) * length + j;
            percolateUnion.union(p, q);
            fullPathUnion.union(p, q);
        }
    }

    public boolean isOpen(int i, int j) {
        if (areIndexesValid(i, j)) {
            return isOpenCore(i, j);
        }
        throw new IndexOutOfBoundsException();
    }

    public boolean isFull(int i, int j) {
        if (areIndexesValid(i, j)) {
            int p = (i - 1) * length + j - 1;
            return fullPathUnion.connected(p, topPoint);
        }
        throw new IndexOutOfBoundsException();
    }

    public boolean percolates() {
        return percolateUnion.connected(topPoint, bottomPoint);
    }

    private boolean isOpenCore(int i, int j){
        return opened[i - 1][j - 1];
    }

    private boolean isFirstRow(int i){
        return i == 1;
    }

    private boolean isLastRow(int i){
        return  i == length;
    }

    private boolean areIndexesValid(int i, int j) {
        if (i < 1 || i > length || j < 1 || j > length) {
            return false;
        }
        return true;
    }
}
