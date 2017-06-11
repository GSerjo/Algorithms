import edu.princeton.cs.algs4.In;
import edu.princeton.cs.algs4.MinPQ;
import edu.princeton.cs.algs4.Stack;
import edu.princeton.cs.algs4.StdOut;


public class Solver {
    private boolean solvable;
    private Node finalBoard;

    private class Node implements Comparable<Node> {
        private Board board;
        private int moves;
        private Node previous;

        public Node(Board board, int moves, Node node) {
            this.board = board;
            this.moves = moves;
            this.previous = node;
        }

        public int compareTo(Node that) {
            int thisManhattan = board.manhattan() + moves;
            int thatManhattan = that.board.manhattan() + that.moves;
            return thisManhattan - thatManhattan;
        }
    }

    public Solver(Board initial) {
        if (initial == null) {
            throw new NullPointerException();
        }
        MinPQ<Node> initPQ = new MinPQ<>();
        MinPQ<Node> twinPQ = new MinPQ<>();
        initPQ.insert(new Node(initial, 0, null));
        twinPQ.insert(new Node(initial.twin(), 0, null));
        Node initNode;
        Node twinNode;
        while (true) {
            initNode = initPQ.delMin();
            twinNode = twinPQ.delMin();

            if (initNode.board.isGoal()) {
                finalBoard = initNode;
                solvable = true;
                break;
            }
            if (twinNode.board.isGoal()) {
                finalBoard = twinNode;
                solvable = false;
                break;
            }
            for (Board initBoard : initNode.board.neighbors()) {
                if (initNode.previous == null || !initBoard.equals(initNode.previous.board)) {
                    initPQ.insert(new Node(initBoard, initNode.moves + 1, initNode));
                }
            }
            for (Board twinBoard : twinNode.board.neighbors()) {
                if (twinNode.previous == null || !twinBoard.equals(twinNode.previous.board)) {
                    twinPQ.insert(new Node(twinBoard, twinNode.moves + 1, twinNode));
                }
            }
        }
    }

    public boolean isSolvable() {
        return solvable;
    }

    public int moves() {
        if (this.solvable)
            return finalBoard.moves;
        return -1;
    }


    public Iterable<Board> solution() {
        if (!this.solvable) {
            return null;
        }

        Stack<Board> result = new Stack<>();
        Node current = finalBoard;
        while (current != null) {
            result.push(current.board);
            current = current.previous;
        }
        return result;
    }


    public static void main(String[] args) {

        // create initial board from file
        In in = new In(args[0]);
        int n = in.readInt();
        int[][] blocks = new int[n][n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                blocks[i][j] = in.readInt();
        Board initial = new Board(blocks);

        // solve the puzzle
        Solver solver = new Solver(initial);

        // print solution to standard output
        if (!solver.isSolvable())
            StdOut.println("No solution possible");
        else {
            StdOut.println("Minimum number of moves = " + solver.moves());
            for (Board board : solver.solution())
                StdOut.println(board);
        }
    }
}
