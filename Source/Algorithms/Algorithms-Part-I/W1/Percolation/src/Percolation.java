import edu.princeton.cs.algs4.WeightedQuickUnionUF;

public class Percolation {

    private int length;
    private int topPoint;
    private int bottomPoint;
    private boolean[][] opened;
    private WeightedQuickUnionUF percolateUnion;
    private WeightedQuickUnionUF fullPathUnion;

    public Percolation(int n) {
        if (n <= 0) {
            throw new IllegalArgumentException("n <= 0");
        }
        length = n;
        opened = new boolean[length][length];
        percolateUnion = new WeightedQuickUnionUF(length * length + 2);
        fullPathUnion = new WeightedQuickUnionUF(length * length + 1);
        topPoint = length * length;
        bottomPoint = topPoint + 1;
    }

    public void open(int row, int col) {
        if (!areIndexesValid(row, col)) {
            throw new IndexOutOfBoundsException();
        }

        if(opened[row - 1][col - 1]){
            return;
        }

        opened[row - 1][col - 1] = true;
        if (isFirstRow(row)) {
            int p = col - 1;
            percolateUnion.union(p, topPoint);
            fullPathUnion.union(p, topPoint);
        }
        int p = (row - 1) * length + col - 1;
        if (isLastRow(row)){
            percolateUnion.union(p, bottomPoint);
        }
        if (row > 1 && isOpenCore(row - 1, col)) {
            int q = (row - 2) * length + col - 1;
            percolateUnion.union(p, q);
            fullPathUnion.union(p, q);
        }
        if (row < length && isOpenCore(row + 1, col)) {
            int q = row * length + col - 1;
            percolateUnion.union(p, q);
            fullPathUnion.union(p, q);
        }
        if (col > 1 && isOpenCore(row, col - 1)) {
            int q = (row - 1) * length + col - 2;
            percolateUnion.union(p, q);
            fullPathUnion.union(p, q);
        }
        if (col < length && isOpenCore(row, col + 1)) {
            int q = (row - 1) * length + col;
            percolateUnion.union(p, q);
            fullPathUnion.union(p, q);
        }
    }

    public boolean isOpen(int row, int col) {
        if (areIndexesValid(row, col)) {
            return isOpenCore(row, col);
        }
        throw new IndexOutOfBoundsException();
    }

    public boolean isFull(int row, int col) {
        if (areIndexesValid(row, col)) {
            int p = (row - 1) * length + col - 1;
            return fullPathUnion.connected(p, topPoint);
        }
        throw new IndexOutOfBoundsException();
    }

    public boolean percolates() {
        return percolateUnion.connected(topPoint, bottomPoint);
    }

    private boolean isOpenCore(int row, int col){
        return opened[row - 1][col - 1];
    }

    private boolean isFirstRow(int row){
        return row == 1;
    }

    private boolean isLastRow(int row){
        return  row == length;
    }

    private boolean areIndexesValid(int row, int column) {
        if (row < 1 || row > length || column < 1 || column > length) {
            return false;
        }
        return true;
    }
}
