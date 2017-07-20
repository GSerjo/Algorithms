import java.util.Arrays;

public class ArraysEx {

    public static void main(String[] args) {
        System.out.println(isUniqueChar("tes"));
    }

    private static boolean isUniqueChar(String value) {
        if (value == null || value.equals("") || value.length() == 1) {
            return true;
        }
        char[] array = value.toCharArray();
        Arrays.sort(array);
        for (int i = 1; i < array.length; i++) {
            if(array[i] == array[i-1]){
                return false;
            }
        }
        return true;
    }
}
