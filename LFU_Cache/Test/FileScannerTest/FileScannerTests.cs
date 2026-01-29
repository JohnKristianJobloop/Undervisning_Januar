using System;
using src.Models;

namespace Test.FileScannerTest;

public class FileScannerTests
{
    [Fact]
    public void Test_ReadFile_InvalidFile_ReturnsDefaultValueOut()
    {
        //Arrange
        var invalidFilename = "someFile.txt";

        //Act
        var invalidData = FileScanner<string>.Find(Directory.GetCurrentDirectory(), invalidFilename, "key");

        //Assert
        Assert.Null(invalidData);
    }

    [Fact]
    public void Test_ReadFile_ValidTokenIn_ReturnsValidTokenOut(){
        //Arrange
        var fileName = "WordFrequencyList.txt";
        var knownWordInList = "center";
        var valueBehindWord = 371;

        //Act
        var result = FileScanner<int>.Find(Directory.GetCurrentDirectory(), fileName, knownWordInList);

        //Assert
        Assert.Equal(valueBehindWord, result);
    }

    [Fact]
    public void Test_ReadFile_InvalidTokenIn_ReturnsDefaultValueOut()
    {
        //Arrange
        var fileName = "WordFrequencyList.txt";
        var invalidWord = "groundhog";

        //Act
        var invalidresult = FileScanner<int>.Find(Directory.GetCurrentDirectory(), fileName, invalidWord);

        //Assert
        Assert.Equal(0, invalidresult);
    }


}
