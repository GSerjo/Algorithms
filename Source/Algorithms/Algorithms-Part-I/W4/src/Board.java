import edu.princeton.cs.algs4.Queue;

public class Board {

    private int dimension;
    private int[][] board;
    private int emptyRow;
    private int emptyColumn;

    public Board(int[][] blocks) {
        dimension = blocks.length;
        board = new int[dimension][dimension];
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                if (blocks[i][j] == 0) {
                    emptyRow = i;
                    emptyColumn = j;
                }
                board[i][j] = blocks[i][j];
            }
        }
    }

    public int dimension() {
        return dimension;
    }

    public int hamming() {
        int block;
        int total = 0;
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                block = board[i][j];
                if (block != 0) {
                    total += hammingDistance(block, i, j);
                }
            }
        }
        return total;
    }

    public int manhattan() {
        int block;
        int total = 0;
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                block = board[i][j];
                if (block != 0) {
                    total += manhattanDistance(block, i, j);
                }
            }
        }
        return total;
    }

    public boolean isGoal() {
        return this.hamming() == 0;
    }

    public Board twin() {
        Board twinBoard = new Board(this.copy());
        if (board[0][0] == 0 || board[0][1] == 0) {
            twinBoard.swap(1, 0, 1, 1);
        } else {
            twinBoard.swap(0, 0, 0, 1);
        }
        return twinBoard;
    }

    public boolean equals(Object y) {
        if (y == this) return true;
        if (y == null) return false;
        if (y.getClass() != this.getClass()) return false;
        Board that = (Board) y;
        if (that.dimension != this.dimension) return false;
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                if (that.board[i][j] != this.board[i][j]) {
                    return false;
                }
            }
        }
        return true;
    }

    public Iterable<Board> neighbors() {
        Queue<Board> result = new Queue<>();
        Board copy;
        if (emptyRow > 0) {
            copy = new Board(this.copy());
            copy.swap(emptyRow, emptyColumn, emptyRow - 1, emptyColumn);
            result.enqueue(copy);
        }
        if (emptyRow < dimension - 1) {
            copy = new Board(this.copy());
            copy.swap(emptyRow, emptyColumn, emptyRow + 1, emptyColumn);
            result.enqueue(copy);
        }
        if (emptyColumn > 0) {
            copy = new Board(this.copy());
            copy.swap(emptyRow, emptyColumn, emptyRow, emptyColumn - 1);
            result.enqueue(copy);
        }
        if (emptyColumn < dimension - 1) {
            copy = new Board(this.copy());
            copy.swap(emptyRow, emptyColumn, emptyRow, emptyColumn + 1);
            result.enqueue(copy);
        }
        return result;
    }

    public String toString() {
        StringBuilder builder = new StringBuilder();
        builder.append(dimension + "\n");
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                builder.append(String.format("%2d ", board[i][j]));
            }
            builder.append("\n");
        }
        return builder.toString();
    }

    private int hammingDistance(int block, int i, int j) {
        int goalRow = (block - 1) / dimension;
        int goalCol = (block - 1) % dimension;
        if (goalRow == i && goalCol == j)
            return 0;
        return 1;
    }

    private int manhattanDistance(int block, int i, int j) {
        int goalRow = (block - 1) / dimension;
        int goalColumn = (block - 1) % dimension;
        return Math.abs(goalRow - i) + Math.abs(goalColumn - j);
    }

    private int[][] copy() {
        int[][] copy = new int[dimension][dimension];
        for (int i = 0; i < dimension; i++)
            for (int j = 0; j < dimension; j++) {
                copy[i][j] = board[i][j];
            }
        return copy;
    }

    private void swap(int x1, int y1, int x2, int y2) {
        int temp = board[x1][y1];
        board[x1][y1] = board[x2][y2];
        board[x2][y2] = temp;
        if (board[x1][y1] == 0) {
            emptyRow = x1;
            emptyColumn = y1;
        }
        if (board[x2][y2] == 0) {
            emptyRow = x2;
            emptyColumn = y2;
        }
    }

    public static void main(String[] args) {

    }

}
