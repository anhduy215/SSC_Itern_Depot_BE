namespace DepotBackEnd.Service
{
    public class CheckDigitService
    {
        // Bảng đối chiếu ký tự và số nguyên
        private static Dictionary<char, int> letterValueMap = new Dictionary<char, int>();

        public CheckDigitService()
        {
            InitializeLetterValueMap();
        }

        // Khởi tạo bảng chuyển đổi
        private void InitializeLetterValueMap()
        {
            int value = 10;
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                while (value % 11 == 0)
                {
                    value++;
                }
                letterValueMap[letter] = value;
                value++;
            }
        }

        // Hàm kiểm tra tính hợp lệ của mã ISO
        public bool IsValidContainerNumber(string containerNumber)
        {
            if (containerNumber.Length != 11)
            {
                throw new ArgumentException("ISO code must be 11 characters.");
            }

            // Tính toán check digit từ 10 ký tự đầu
            string firstTen = containerNumber.Substring(0, 10);
            char expectedCheckDigit = CalculateCheckDigit(firstTen);

            // So sánh với ký tự thứ 11
            char actualCheckDigit = containerNumber[10];

            return expectedCheckDigit == actualCheckDigit;
        }

        // Hàm tính check digit từ 10 ký tự đầu tiên
        private char CalculateCheckDigit(string contNum)
        {
            int total = 0;

            // Dùng mảng các lũy thừa của 2 từ 2^0 tới 2^9
            for (int i = 0; i < contNum.Length; i++)
            {
                int value;

                // Nếu là chữ cái, lấy giá trị từ bảng đối chiếu
                if (char.IsLetter(contNum[i]))
                {
                    value = letterValueMap[contNum[i]];
                }
                // Nếu là chữ số, chuyển trực tiếp thành số nguyên
                else if (char.IsDigit(contNum[i]))
                {
                    value = contNum[i] - '0';
                }
                else
                {
                    throw new ArgumentException("Invalid character in ISO code.");
                }

                // Nhân giá trị với 2^i (lũy thừa của 2)
                total += value * (int)Math.Pow(2, i);
            }

            // Tính check digit
            int checkDigitValue = total % 11;

            return checkDigitValue == 10 ? 'X' : (char)(checkDigitValue + '0');
        }
    }
}
