# Notes

The rules to filter out flights are all setup in the `GetFlightSelector` method in the `Program.cs` file.

Should we need to create a new filter, all we would need to do is to implement the `IFlightFilter` interface and add that rule in the `GetFlightSelector` method.

The output is displayed on the console, but it would be easy to extend the output to write to  json, xml or text files, all we would have to do is to implement the `IOutputWriter` interface and use that class instead. 
