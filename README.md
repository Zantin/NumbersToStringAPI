# NumbersToStringAPI

This is an API that converts numerical numbers to their corresponding written name.


*Requires dotnet*
https://dotnet.microsoft.com/

When starting the program, it outputs the portnumbers it's listening on as in the example.
![port-info-example](https://user-images.githubusercontent.com/48260537/135529470-68b5a00b-4144-4432-843b-0be8090f2e1e.png)

The API has two endpoints, one for single numbers and one for multiple numbers.

The endpoints are as follows in this example.
```
https://localhost:5001/api/NumbersToString/Convert
https://localhost:5001/api/NumbersToString/ConvertMultiple
```
Both endpoints only accepts POST with a body containing the number(s) as JSON objects.

Input (for single numbers)
```
{"input":2.05}
```

Output
```
TWO DOLLARS AND FIVE CENTS
```

Input (for multiple numbers)
```
[{"input":2.05},{"input":0.01}]
```
Output
```
TWO DOLLARS AND FIVE CENTS
ZERO DOLLARS AND ONE CENT
```

-----

How to run the program.

Open commandoprompt and go to the projects folder.

Now build the program, using the following command
```
dotnet build "NumbersToStringAPI\NumbersToStringAPI.csproj" -c Release
```
Then you can run the program using the following command
```
dotnet "NumbersToStringAPI\bin\Release\net5.0\NumbersToStringAPI.dll"
```
Alternatively you can navigate to the build folder
```
NumbersToStringAPI -> bin -> Release -> net5.0
```
and run the program using the NumbersToStringAPI.exe file

-----

How to run the tests

Open commandoprompt and go to the projects folder.

Now build the tests (and program), using the following command
```
dotnet build "NumbersToStringAPI_Test\NumbersToStringAPI_Test.csproj" -c Release
```
Then you can run the tests, using the following command
```
dotnet test "NumbersToStringAPI_Test\bin\Release\net5.0\NumbersToStringAPI_Test.dll"
```
