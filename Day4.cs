using System.Dynamic;

class Day4 {
    private static string ln; 
    private static List<string> lines = new List<string>();
    
    public static void Solve(string filePath) {
        ReadInput(filePath);
        Part1();
        Part2();
    }

    private static void ReadInput(string filePath) {
        using (StreamReader file = new StreamReader(filePath)) {
            while ((ln = file.ReadLine()) != null) {
                lines.Add(ln); 
            }
        }
    }
    
    private static void Part1() {
        const string word = "XMAS";
        int result = 0;

        // Look for each a match of the first letter of the word
        for (int i = 0; i < lines.Count; i++) {
            for (int j = 0; j < lines[i].Length; j++) {
                if (lines[i][j] == word[0]) {
                    result += LookForWord(word, i, j);
                }
            }
        }

        Console.WriteLine("Day 4 Part 1 Solution: " + result);
    }

    private static void Part2() {
        int result = 0;

        // Look for A because pattern always has an A in the middle
        // Ignores the outside perimiter of the grid
        for (int i = 1; i < lines.Count - 1; i++) {
            for (int j = 1; j < lines[i].Length - 1; j++) {
                if (lines[i][j] == 'A') {
                    // Check topright to bottomleft OR bottomleft to topright
                    if((lines[i - 1][j - 1] == 'M' && lines[i + 1][j + 1] == 'S') || (lines[i - 1][j - 1] == 'S' && lines[i + 1][j + 1] == 'M')) {
                        // Check topleft to bottomright OR bottomright to topleft
                        if((lines[i - 1][j + 1] == 'M' && lines[i + 1][j - 1] == 'S') || (lines[i - 1][j + 1] == 'S' && lines[i + 1][j - 1] == 'M')) {
                            result++;
                        }
                    }
                }
            }
        }

        Console.WriteLine("Day 4 Part 2 Solution: " + result);
    }

    // linesYPosition is the indes of lines and linesXPosition is the index of the character in the line
    private static int LookForWord(string word, int linesYPosition, int linesXPosition) {
        int found = 0;

        // Check right 
        for (int i = 1; i < word.Length; i++) {
            if (linesXPosition + i >= lines[linesYPosition].Length) {
                break; // Out of bounds
            } else if (lines[linesYPosition][linesXPosition + i] != word[i]) {
                break; // Not a match
            } else if (i == word.Length - 1) {
                found++; // Found a match
            }
        }

        // Check left
        for (int i = 1; i < word.Length; i++) {
            if (linesXPosition - i < 0) {
                break; // Out of bounds
            } else if (lines[linesYPosition][linesXPosition - i] != word[i]) {
                break; // Not a match
            } else if (i == word.Length - 1) {
                found++; // Found a match
            }
        }

        // Check down
        for (int i = 1; i < word.Length; i++) {
            if (linesYPosition + i >= lines.Count) {
                break; // Out of bounds
            } else if (lines[linesYPosition + i][linesXPosition] != word[i]) {
                break; // Not a match
            } else if (i == word.Length - 1) {
                found++; // Found a match
            }
        }

        // Check up
        for (int i = 1; i < word.Length; i++) {
            if (linesYPosition - i < 0) {
                break; // Out of bounds
            } else if (lines[linesYPosition - i][linesXPosition] != word[i]) {
                break; // Not a match
            } else if (i == word.Length - 1) {
                found++; // Found a match
            }
        }

        // Check diagonal down right
        for (int i = 1; i < word.Length; i++) {
            if (linesYPosition + i >= lines.Count || linesXPosition + i >= lines[linesYPosition].Length) {
                break; // Out of bounds
            } else if (lines[linesYPosition + i][linesXPosition + i] != word[i]) {
                break; // Not a match
            } else if (i == word.Length - 1) {
                found++; // Found a match
            }
        }

        // Check diagonal down left
        for (int i = 1; i < word.Length; i++) {
            if (linesYPosition + i >= lines.Count || linesXPosition - i < 0) {
                break; // Out of bounds
            } else if (lines[linesYPosition + i][linesXPosition - i] != word[i]) {
                break; // Not a match
            } else if (i == word.Length - 1) {
                found++; // Found a match
            }
        }

        // Check diagonal up right
        for (int i = 1; i < word.Length; i++) {
            if (linesYPosition - i < 0 || linesXPosition + i >= lines[linesYPosition].Length) {
                break; // Out of bounds
            } else if (lines[linesYPosition - i][linesXPosition + i] != word[i]) {
                break; // Not a match
            } else if (i == word.Length - 1) {
                found++; // Found a match
            }
        }

        // Check diagonal up left
        for (int i = 1; i < word.Length; i++) {
            if (linesYPosition - i < 0 || linesXPosition - i < 0) {
                break; // Out of bounds
            } else if (lines[linesYPosition - i][linesXPosition - i] != word[i]) {
                break; // Not a match
            } else if (i == word.Length - 1) {
                found++; // Found a match
            }
        }

        return found;
    }
}