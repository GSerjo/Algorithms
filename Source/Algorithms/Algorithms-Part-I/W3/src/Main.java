//import java.math.BigInteger;
//import java.util.HashMap;
//import java.util.Map;

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
}

