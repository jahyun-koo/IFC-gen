import java.util.UUID;

/**
 * this code is from
 * https://github.com/opensourceBIM/BIMserver/blob/master/PluginBase/src/org/bimserver/shared/GuidCompressor.java
 */
public class IfcGloballyUniqueIdGenerator {
  private static final char[] cConversionTable =
      new char[] {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
        'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
        's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '_', '$'
      };

  public static String createId() {
    String uncompressedGuidString = UUID.randomUUID().toString();
    String[] parts = uncompressedGuidString.split("-");
    long data1 = Long.parseLong(parts[0], 16);
    int data2 = Integer.parseInt(parts[1], 16);
    int data3 = Integer.parseInt(parts[2], 16);

    String temp = parts[3];
    char[] data4 = new char[8];
    data4[0] = (char) Integer.parseInt(temp.substring(0, 2), 16);
    data4[1] = (char) Integer.parseInt(temp.substring(2, 4), 16);

    temp = parts[4];
    data4[2] = (char) Integer.parseInt(temp.substring(0, 2), 16);
    data4[3] = (char) Integer.parseInt(temp.substring(2, 4), 16);
    data4[4] = (char) Integer.parseInt(temp.substring(4, 6), 16);
    data4[5] = (char) Integer.parseInt(temp.substring(6, 8), 16);
    data4[6] = (char) Integer.parseInt(temp.substring(8, 10), 16);
    data4[7] = (char) Integer.parseInt(temp.substring(10, 12), 16);

    long[] num = new long[6];
    char[][] str = new char[6][5];
    int i, j, n;
    String result = "";

    // Creation of six 32 Bit integers from the components of the GUID structure
    num[0] = data1 / 16777216; //    16. byte  (pGuid->Data1 / 16777216) is the same as (pGuid->Data1 >>// 24)
    num[1] = data1 % 16777216; // 15-13. bytes (pGuid->Data1 % 16777216) is the same as (pGuid->Data1 &// 0xFFFFFF)
    num[2] = data2 * 256L + data3 / 256; // 12-10. bytes
    num[3] = (data3 % 256) * 65536 + data4[0] * 256 + data4[1]; // 09-07. bytes
    num[4] = data4[2] * 65536L + data4[3] * 256 + data4[4]; // 06-04. bytes
    num[5] = data4[5] * 65536L + data4[6] * 256 + data4[7]; // 03-01. bytes
    //
    // Conversion of the numbers into a system using a base of 64
    //
    n = 3;
    for (i = 0; i < 6; i++) {
      if (!cv_to_64(num[i], str[i], n)) {
        return null;
      }
      for (j = 0; j < str[i].length; j++) if (str[i][j] != '\0') result += str[i][j];

      n = 5;
    }
    return result;
  }

  /**
   * Conversion of an integer into a number with base 64 using the table cConversionTable
   *
   * @param number
   * @param code
   * @param len
   * @return true if no error occurred
   */
  private static boolean cv_to_64(long number, char[] code, int len) {
    long act;
    int iDigit, nDigits;
    char[] result = new char[5];

    if (len > 5) return false;

    act = number;
    nDigits = len - 1;

    for (iDigit = 0; iDigit < nDigits; iDigit++) {
      result[nDigits - iDigit - 1] = cConversionTable[(int) (act % 64)];
      act /= 64;
    }
    result[len - 1] = '\0';

    if (act != 0) return false;

    System.arraycopy(result, 0, code, 0, result.length);

    return true;
  }
}
