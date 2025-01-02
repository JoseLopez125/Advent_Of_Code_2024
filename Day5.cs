class Day5 {
    private static List<int> xNumbers = new List<int>();
    private static List<int> yNumbers = new List<int>();

    private static List<List<int>> numbersLists = new List<List<int>>();
    
    public static void Solve(string filePath) {
        ProcessInput(filePath);
        Solution();
    }

    private static void ProcessInput(string filePath) {
        string ln;
        using (StreamReader file = new StreamReader(filePath)) {
            while ((ln = file.ReadLine()) != null) {
                if (ln.Contains("|")) {
                    string[] numbers = ln.Split("|");
                    xNumbers.Add(int.Parse(numbers[0]));
                    yNumbers.Add(int.Parse(numbers[1]));
                } else if (ln.Contains(",")) {
                    string[] numbers = ln.Split(",");
                    numbersLists.Add(new List<int>(numbers.Select(int.Parse)));
                }
            }
        }
    }

    private static void Solution() {
        int result1 = 0;
        int result2 = 0;

        for (int i = 0; i < numbersLists.Count; i++) {
            int middleValue = numbersLists[i][numbersLists[i].Count / 2];
            bool inCorrectOrder = true;

            for (int j = 0; j < numbersLists[i].Count && inCorrectOrder; j++) {
                for (int k = 0; k < xNumbers.Count && inCorrectOrder; k++) {
                    if (numbersLists[i][j] == xNumbers[k]) {                        
                        for (int l = j; l >= 0; l--) {
                           if (numbersLists[i][l] == yNumbers[k]) {
                               inCorrectOrder = false;
                           }
                        }
                    }
                }
            }

            if (inCorrectOrder) {
                result1 += middleValue;
            } 
        }

        Console.WriteLine("Day 5 Part 1 Solution: " + result1);
    }
}