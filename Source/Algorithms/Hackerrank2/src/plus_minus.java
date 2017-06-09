import java.util.Scanner;

public class plus_minus {

    public static void main(String[] args){

        int positiveCount = 0;
        int negativeCount = 0;
        int zeroCount = 0;

        Scanner scanner = new Scanner(System.in);
        int arrayLength = scanner.nextInt();

        for (int i = 0; i < arrayLength; i++) {
            int value = scanner.nextInt();

            if(value > 0){
                positiveCount++;
            }
            else if( value < 0){
                negativeCount++;
            }
            else {
                zeroCount++;
            }
        }
        scanner.close();
        System.out.println(positiveCount/arrayLength);
        System.out.println(negativeCount/arrayLength);
        System.out.println(zeroCount/arrayLength);
    }
}
