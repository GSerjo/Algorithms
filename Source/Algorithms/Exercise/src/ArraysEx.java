import java.util.Arrays;

public class ArraysEx {

    public static void main(String[] args) {

        System.out.println(isPermutation("tes", "set"));


        System.out.println(isUniqueChar("tes"));
    }


    private static boolean isPermutation(String a, String b) {
        if (a == null || b == null || a.length() != b.length()) {
            return false;
        }
        if (a.equals(b)) {
            return true;
        }
        char[] arrayA = a.toCharArray();
        char[] arrayB = b.toCharArray();
        Arrays.sort(arrayA);
        Arrays.sort(arrayB);

        for (int i = 0; i < arrayA.length; i++) {
            if (arrayA[i] != arrayB[i]) {
                return false;
            }
        }
        return true;
    }

    private static boolean isUniqueChar(String value) {
        if (value == null || value.equals("") || value.length() == 1) {
            return true;
        }
        char[] array = value.toCharArray();
        Arrays.sort(array);
        for (int i = 1; i < array.length; i++) {
            if (array[i] == array[i - 1]) {
                return false;
            }
        }
        return true;
    }
}
