import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {

//        System.out.println ((int)'a');
//        System.out.println ((int)'z');
//        System.out.println ((int)'A');
//        System.out.println ((int)'B');
//        System.out.println ((int)'Z');
//
//        System.out.println (Convert("wrw blf hvv ozhg mrtsg'h vkrhlwv?"));

//        System.out.println(answer(10));
//        System.out.println(answer(13));
//        System.out.println(answer(143));

//        String[] input = new String[]{"1.1.2", "1.0", "1.3.3", "1.0.12", "1.0.2"};
//        String[] input1 = new String[]{"1.11", "2.0.0", "1.2", "2", "0.1", "1.2.1", "1.1.1", "2.0"};
//        answer(input);
//        answer(input1);
//        System.out.println(answer(5));
//


//        System.out.println(answer("4"));
//        System.out.println(answer("15"));


        int[][] t = {{0, 1, 0, 0, 0, 1}, {4, 0, 0, 3, 2, 0}, {0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0}};


        int[] result = answer(t);

        System.out.println(Arrays.toString(result));
    }

//    private static void print(Fraction[][] matrix) {
//        for (int i = 0; i < matrix.length; i++) {
//            for (int j = 0; j < matrix[i].length; j++) {
//                StdOut.print(String.format("%d/%d   ", matrix[i][j].getNumerator(), matrix[i][j].getDenominator()));
//            }
//            System.out.println();
//        }
//
//        System.out.println();
//    }

    private static int[] answer(int[][] m) {

        if (isTerminal(m[0])) {
            return new int[]{1, 1};
        }

        List<Fraction[][]> rq = calculateRQ(m);
        Fraction[][] f = calculateF(rq.get(1));
        Fraction[][] fr = multiplyMatrix(f, rq.get(0));
        return getResult(fr);
    }


    private static int[] getResult(Fraction[][] fr) {
        int[] result = new int[fr[0].length + 1];

        int common = fr[0][0].getDenominator();

        for (int i = 0; i < fr[0].length; i++) {
            common = lcd(common, fr[0][i].getDenominator());
        }

        for (int i = 0; i < fr[0].length; i++) {
            Fraction fraction = fr[0][i];
            int multiplier = common / fraction.getDenominator();
            result[i] = multiplier * fraction.getNumerator();
        }
        result[result.length - 1] = common;
        return result;
    }

    private static int lcd(int denominator1, int denominator2) {
        int dummy = denominator1;
        while ((denominator1 % denominator2) != 0) {
            denominator1 += dummy;
        }
        return denominator1;
    }

    private static List<Fraction[][]> calculateRQ(int[][] data) {
        Fraction[][] matrix = zeroMatrix(data.length, data.length);

        boolean[] states = new boolean[data.length];
        int terminalStates = 0;

        for (int i = 0; i < data.length; i++) {
            if (isTerminal(data[i])) {
                terminalStates++;
                states[i] = true;
            }
        }

        for (int i = 0; i < terminalStates; i++) {
            matrix[i][i] = Fraction.ONE;
        }


        int terminalRowIndex = terminalStates;
        for (int i = 0; i < states.length; i++) {
            if (states[i]) {
                continue;
            }
            int column = 0;
            for (int j = 0; j < states.length; j++) {
                if (states[j]) {
                    matrix[terminalRowIndex][column] = new Fraction(data[i][j], 1);
                    column++;
                }
            }
            terminalRowIndex++;
        }

        terminalRowIndex = terminalStates;
        for (int i = 0; i < states.length; i++) {

            if (states[i]) {
                continue;
            }

            int column = terminalStates;
            for (int j = 0; j < states.length; j++) {
                if (!states[j]) {
                    matrix[terminalRowIndex][column] = new Fraction(data[i][j], 1);
                    column++;
                }
            }
            terminalRowIndex++;
        }

        toProbabilities(matrix, states);

        List<Fraction[][]> result = new ArrayList<>();
        result.add(getR(matrix, states));
        result.add(getQ(matrix, states));

        return result;
    }


    private static Fraction[][] calculateF(Fraction[][] q) {
        Fraction[][] identity = createIdentityMatrix(q.length);
        Fraction[][] dummy = subtractMatrix(identity, q);
        return invertMatrix(dummy);
    }

    private static Fraction[][] createIdentityMatrix(int size) {
        Fraction[][] result = zeroMatrix(size, size);

        for (int i = 0; i < result.length; i++) {
            result[i][i] = Fraction.ONE;
        }
        return result;
    }

    private static void toProbabilities(Fraction[][] data, boolean[] states) {
        int terminals = terminalCount(states);

        for (int i = terminals; i < states.length; i++) {
            Fraction total = sum(data[i]);

            for (int j = 0; j < states.length; j++) {
                data[i][j] = data[i][j].divide(total);
            }
        }
    }

    private static Fraction sum(Fraction[] data) {
        Fraction result = Fraction.ZERO;

        for (int i = 0; i < data.length; i++) {
            result = result.add(data[i]);
        }
        return result;
    }

    private static Fraction[][] getR(Fraction[][] data, boolean[] states) {
        int terminals = terminalCount(states);
        int rows = states.length - terminals;

        Fraction[][] result = new Fraction[rows][terminals];

        for (int i = terminals; i < states.length; i++) {
            for (int j = 0; j < terminals; j++) {
                result[i - terminals][j] = data[i][j];
            }
        }
        return result;
    }

    private static Fraction[][] getQ(Fraction[][] data, boolean[] states) {
        int terminals = terminalCount(states);
        int rows = states.length - terminals;

        Fraction[][] result = new Fraction[rows][rows];

        for (int i = terminals; i < states.length; i++) {
            for (int j = terminals; j < states.length; j++) {
                result[i - terminals][j - terminals] = data[i][j];
            }
        }
        return result;

    }

    private static int terminalCount(boolean[] states) {
        int result = 0;
        for (boolean state : states) {
            if (state) {
                result++;
            }
        }
        return result;
    }

    private static Fraction[][] convert(int[][] data) {

        Fraction[][] result = new Fraction[data.length][data.length];

        for (int i = 0; i < data.length; i++) {
            for (int j = 0; j < data.length; j++) {
                result[i][j] = new Fraction(data[i][j], 1);
            }
        }
        return result;
    }


    private static boolean isTerminal(int[] data) {
        for (int i = 0; i < data.length; i++) {
            if (data[i] != 0) {
                return false;
            }
        }
        return true;
    }


    private static Fraction[][] subtractMatrix(Fraction[][] a, Fraction[][] b) {
        int rows = a.length;
        int columns = a[0].length;

        Fraction[][] result = new Fraction[rows][columns];

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                result[i][j] = a[i][j].subtract(b[i][j]);
            }
        }
        return result;
    }

    private static Fraction[][] multiplyMatrix(Fraction[][] a, Fraction[][] b) {
        int rows1 = a.length;
        int columns1 = a[0].length;
        int rows2 = b.length;
        int columns2 = b[0].length;
        if (columns1 != rows2) {
            throw new IllegalArgumentException();
        }

        Fraction[][] result = zeroMatrix(rows1, columns2);

        for (int i = 0; i < rows1; i++) {
            for (int j = 0; j < columns2; j++) {
                for (int k = 0; k < columns1; k++) {
                    Fraction dummy = a[i][k].multiply(b[k][j]);
                    result[i][j] = result[i][j].add(dummy);
                }
            }
        }
        return result;
    }

    private static Fraction[][] zeroMatrix(int rows, int columns) {
        Fraction[][] result = new Fraction[rows][columns];

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                result[i][j] = Fraction.ZERO;
            }
        }
        return result;
    }


    private static Fraction[][] invertMatrix(Fraction[][] matrix) {

        int rows = matrix.length;
        int columns = 2 * rows;

        Fraction[][] aux = zeroMatrix(rows, columns);

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < rows; j++) {
                aux[i][j] = matrix[i][j];
            }
            aux[i][i + rows] = Fraction.ONE;
        }

        for (int row = 0; row < rows; row++) {
            for (int j = 0; j < columns; j++) {
                if (j != row) {
                    aux[row][j] = aux[row][j].divide(aux[row][row]);
                }
            }

            aux[row][row] = Fraction.ONE;

            for (int row2 = 0; row2 < rows; row2++) {
                if (row2 != row) {
                    Fraction factor = aux[row2][row];
                    for (int j = 0; j < columns; j++) {
                        Fraction dummy = factor.multiply(aux[row][j]);
                        aux[row2][j] = aux[row2][j].subtract(dummy);
                    }
                }
            }
        }

        Fraction[][] result = new Fraction[rows][rows];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < rows; j++) {
                result[i][j] = aux[i][j + rows];
            }
        }

        return result;
    }
}

class Fraction {
    private int numerator;
    private int denominator;

    public static final Fraction ZERO = new Fraction(0, 1);
    public static final Fraction ONE = new Fraction(1, 1);


    public Fraction(int numerator, int denominator) {

        if (denominator == 0) {
            throw new IllegalArgumentException();
        }
        this.numerator = numerator;
        this.denominator = denominator;
    }

    public Fraction() {
        this(0, 1);
    }

    public int getNumerator() {
        return numerator;
    }

    public int getDenominator() {
        return denominator;
    }

    public Fraction multiply(Fraction value) {
        if (value.denominator == 0) {
            throw new IllegalArgumentException();
        }

        Fraction result = new Fraction();
        result.numerator = numerator * value.numerator;
        result.denominator = denominator * value.denominator;
        result = result.reduce();
        return result;
    }

    public Fraction divide(Fraction value) {
        if (value.numerator == 0) {
            throw new IllegalArgumentException();
        }

        Fraction result = new Fraction();
        result.numerator = numerator * value.denominator;
        result.denominator = denominator * value.numerator;
        result = result.reduce();
        return result;
    }

    public Fraction subtract(Fraction value) {
        if (value.denominator == 0) {
            throw new IllegalArgumentException();
        }

        int common = lcd(denominator, value.denominator);

        Fraction commonA = convert(common);
        Fraction commonB = value.convert(common);
        Fraction result = new Fraction();
        result.numerator = commonA.numerator - commonB.numerator;
        result.denominator = common;
        result = result.reduce();
        return result;
    }

    public Fraction add(Fraction value) {
        if (value.denominator == 0) {
            throw new IllegalArgumentException();
        }

        int common = lcd(denominator, value.denominator);

        Fraction commonA = convert(common);
        Fraction commonB = value.convert(common);
        Fraction result = new Fraction();
        result.numerator = commonA.numerator + commonB.numerator;
        result.denominator = common;
        result = result.reduce();
        return result;
    }

    private int lcd(int denominator1, int denominator2) {
        int dummy = denominator1;
        while ((denominator1 % denominator2) != 0) {
            denominator1 += dummy;
        }
        return denominator1;
    }

    private Fraction convert(int common) {
        Fraction result = new Fraction();
        int factor = common / denominator;
        result.numerator = numerator * factor;
        result.denominator = common;
        return result;
    }


    private Fraction reduce() {
        Fraction result = new Fraction();

        int common;
        int numeratorDummy = Math.abs(numerator);
        int denominatorDummy = Math.abs(denominator);

        if (numeratorDummy > denominatorDummy) {
            common = gcd(numeratorDummy, denominatorDummy);
        } else if (numeratorDummy < denominatorDummy) {
            common = gcd(denominatorDummy, numeratorDummy);
        } else {
            common = numeratorDummy;
        }

        result.numerator = numerator / common;
        result.denominator = denominator / common;
        return result;
    }

    private int gcd(int denominator1, int denominator2) {
        int dummy;
        while (denominator2 != 0) {
            dummy = denominator2;
            denominator2 = denominator1 % denominator2;
            denominator1 = dummy;
        }
        return denominator1;
    }
}


//    private static final BigInteger TWO = BigInteger.valueOf(2);
//
//    public static int answer(String n) {
//
//        Map<BigInteger, Integer> map = new HashMap<>();
//        map.put(BigInteger.ONE, 0);
//        map.put(TWO, 1);
//
//        return answer(map, new BigInteger(n));
//    }
//
//    private static int answer(Map<BigInteger, Integer> map, BigInteger n) {
//
//        if (map.containsKey(n)) {
//            return map.get(n);
//        }
//        if (n.mod(TWO).equals(BigInteger.ZERO)) {
//            map.put(n, answer(map, n.divide(TWO)) + 1);
//        } else {
//            int dummy1 = answer(map, n.add(BigInteger.ONE).divide(TWO)) + 2;
//            int dummy2 = answer(map, n.subtract(BigInteger.ONE).divide(TWO)) + 2;
//            map.put(n, Math.min(dummy1, dummy2));
//        }
//        return map.get(n);
//    }


//    public static int answer(int n) {
//        int maxN = n + 1;
//
//        int[][] matrix = new int[maxN][maxN];
//        matrix[1][1] = 1;
//        matrix[2][2] = 1;
//
//        for (int i = 3; i < maxN; i++) {
//            for (int j = 1; j <= i; j++) {
//                if (i - j == 0) {
//                    matrix[i][j] = 1 + matrix[i][j - 1];
//                } else if (i - j > j) {
//                    matrix[i][j] = matrix[i - j][j - 1] + matrix[i][j - 1];
//                } else if (i - j < j) {
//                    matrix[i][j] = matrix[i - j][i - j] + matrix[i][j - 1];
//                } else if (i - j == j) {
//                    matrix[i][j] = matrix[j][j - 1] + matrix[i][j - 1];
//                }
//            }
//        }
//        return matrix[n][n] - 1;
//    }

//    private static String[] answer(String[] input) {
//        if (input == null || input.length == 0) {
//            return new String[0];
//        }
//        String[] result = sort(input, 0, input.length - 1);
//        return result;
//    }

//    private static String[] sort(String[] input, int lo, int hi) {
//        int i = lo;
//        int j = hi;
//        int mid = lo + (hi - lo) / 2;
//        String pivot = input[mid];
//        while (i <= j) {
//            while (compare(input[i], pivot) < 0) {
//                i++;
//            }
//            while (compare(input[j], pivot) > 0) {
//                j--;
//            }
//            if (i <= j) {
//                String temp = input[i];
//                input[i] = input[j];
//                input[j] = temp;
//                i++;
//                j--;
//            }
//        }
//        if (i < hi) {
//            input = sort(input, i, hi);
//        }
//        if (j > lo) {
//            input = sort(input, lo, j);
//        }
//        return input;
//    }

//    private static int compare(String first, String second) {
//        if (first.equals(second)) {
//            return 0;
//        }
//        String[] parts1 = first.split("\\.");
//        String[] parts2 = second.split("\\.");
//
//        int item1 = Integer.parseInt(parts1[0]);
//        int item2 = Integer.parseInt(parts2[0]);
//
//        if (item1 != item2) {
//            return compare(item1, item2);
//        }
//        if (parts1.length == 1 || parts2.length == 1) {
//            return parts1.length > parts2.length ? 1 : -1;
//        }
//        item1 = Integer.parseInt(parts1[1]);
//        item2 = Integer.parseInt(parts2[1]);
//
//        if (item1 != item2) {
//            return compare(item1, item2);
//        }
//
//        if (parts1.length == 2 || parts2.length == 2) {
//            return parts1.length > parts2.length ? 1 : -1;
//        }
//        item1 = Integer.parseInt(parts1[2]);
//        item2 = Integer.parseInt(parts2[2]);
//
//        if (item1 > item2) {
//            return compare(item1, item2);
//        }
//        return 0;
//    }
//
//    private static int compare(int first, int second) {
//        if (first == second) {
//            return 0;
//        }
//        return first - second > 0 ? 1 : -1;
//    }


//    private static int answer(int total_lambs) {
//        return stingy(total_lambs) - generous(total_lambs);
//    }
//
//    private static int stingy(int totalLambs) {
//        if (totalLambs <= 2) {
//            return totalLambs;
//        }
//        int spent0 = 1;
//        int spent1 = 1;
//        int totalHenchman = 2;
//        int current = totalLambs - spent1 - spent0;
//
//        while (current > 0) {
//            int next = spent0 + spent1;
//            current -= next;
//            if (current >= 0) {
//                totalHenchman++;
//                spent0 = spent1;
//                spent1 = next;
//            }
//        }
//        return totalHenchman;
//    }
//
//    private static int generous(int totalLambs) {
//        if (totalLambs <= 1) {
//            return totalLambs;
//        }
//        int spent0 = 1;
//        int spent1 = 2;
//        int totalHenchman = 2;
//        int current = totalLambs - spent1 - spent0;
//        while (current > 0) {
//            int next = spent1 * 2;
//            current -= next;
//            if (current > 0) {
//                totalHenchman++;
//                spent0 = spent1;
//                spent1 = next;
//            } else {
//                if (current + next >= spent0 + spent1) {
//                    totalHenchman++;
//                }
//            }
//        }
//        return totalHenchman;
//    }

//    private static int answer(int totalLambs) {
//        return stingy(totalLambs) - generous(totalLambs);
//    }
//
//
//    private static int stingy(int totalLambs) {
//        if (totalLambs <= 2) {
//            return totalLambs;
//        }
//        int spent0 = 1;
//        int spent1 = 1;
//        int totalHenchman = 2;
//        int current = totalLambs - 2;
//
//        while (current > 0) {
//            int next = spent0 + spent1;
//            current -= next;
//            if (current >= 0) {
//                totalHenchman++;
//                spent0 = spent1;
//                spent1 = next;
//            }
//        }
//        return totalHenchman;
//    }
//
//    private static int generous(int totalLambs) {
//        if (totalLambs <= 1) {
//            return totalLambs;
//        }
//        int totalHenchman = 1;
//        int spent = 1;
//        int current = totalLambs - spent;
//        while (current > 0) {
//            spent *= 2;
//            current -= spent;
//            if (current > 0) {
//                totalHenchman++;
//            }
//        }
//        return totalHenchman;
//    }


//    private static String Convert(String value) {
//        if (value == null || value.isEmpty()) {
//            return "";
//        }
//        int min = 97;
//        int max = 122;
//        int base = min + max;
//        StringBuilder result = new StringBuilder();
//        for (int i = 0; i < value.length(); i++) {
//            int currentChar = value.charAt(i);
//            if (currentChar >= min && currentChar <= max) {
//                currentChar = base - currentChar;
//            }
//            result.append((char) currentChar);
//        }
//        return result.toString();
//    }
//}

