// See https://aka.ms/new-console-template for more information
class Program {
    // Default folder path for input files
    static readonly string folderPath = "/home/josel/Projects/dotnet/Advent_Of_Code_2024/inputs/";

    private static void Main() {
        Day3.Part2(folderPath + "day3");
        Day4.Solve(folderPath + "day4");
    }
}
