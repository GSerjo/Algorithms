import java.math.BigInteger;

public class Main {

    public static void main(String[] args) {
        BigInteger x = new BigInteger("3141592653589793238462643383279502884197169399375105820974944592");
        BigInteger y = new BigInteger("2718281828459045235360287471352662497757247093699959574966967627");
        BigInteger result1 = multiply(x, y);
        System.out.println(result1);
        System.out.println(x.multiply(y));
        //8539734222673567065463550869546574495034888535765114961879601127067743044893204848617875072216249073013374895871952806582723184
    }

    /*
    http://introcs.cs.princeton.edu/java/99crypto/Karatsuba.java.html
    * */
    private static BigInteger multiply(BigInteger a, BigInteger b) {
        int n = Math.max(a.bitLength(), b.bitLength());

        if (n <= 2) {
            return a.multiply(b);
        }
        n = n / 2 + n % 2;
        BigInteger xl = a.shiftRight(n);
        BigInteger xr = a.subtract(xl.shiftLeft(n));

        BigInteger yl = b.shiftRight(n);
        BigInteger yr = b.subtract(yl.shiftLeft(n));

        BigInteger p1 = multiply(xl, yl);
        BigInteger p2 = multiply(xr, yr);
        BigInteger p3 = multiply(xl.add(xr), yl.add(yr));

        return p2.add(p3.subtract(p1).subtract(p2).shiftLeft(n)).add(p1.shiftLeft(2*n));
    }
}
