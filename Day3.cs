using System.Text.RegularExpressions;

class Day3 {
    public static void Part2(string filePath) {
        // Regex pattern to match valid mul(X,Y) instructions or do() or don't() conditions
        string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)";
        bool isEnabled = true;

        string ln;
        int result = 0;

        // Open and read file line by line
        using (StreamReader file = new StreamReader(filePath)) {

            while ((ln = file.ReadLine()) != null) {
                // Use Regex to find matches
                MatchCollection matches = Regex.Matches(ln, mulPattern);

                foreach (Match match in matches) {
                    if (match.Value == "do()") {
                        isEnabled = true;
                        continue;
                    } else if (match.Value == "don't()") {
                        isEnabled = false;
                        continue;
                    } else if (isEnabled) {
                        // Extract the two numbers X and Y from the match
                        int x = int.Parse(match.Groups[1].Value);
                        int y = int.Parse(match.Groups[2].Value);

                        // Compute their product and add it to the sum
                        result += x * y;
                    }
                }
            }
            Console.WriteLine("Day 3 Part 2 Solution: " + result);
        }
    }
}