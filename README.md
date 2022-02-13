# Blazor.DownloadFileFast

[![NuGet](https://buildstats.info/nuget/BlazorDownloadFileFast)](https://www.nuget.org/packages/BlazorDownloadFileFast)

Fast download from files to the browser from Blazor without any javascript library reference or dependency.

BlazorDownloadFileFast is the solution to saving files on the client-side, and is perfect for web apps that generates files on the client.

When using this project in a NET 5.0 or 6.0 Blazor WebAssembly project, there is an additional speed increase. Read the blog post mentioned from Gérald Barré in the credits.


## Usage

### Register
```c#
builder.Services.AddBlazorDownloadFile();
```

### Inject in code-behind
``` c#
[Inject]
public IBlazorDownloadFileService BlazorDownloadFileService { get; set; }
```

### Use in your code
``` c#
byte[] bytes = ...; 
await BlazorDownloadFileService.DownloadFileAsync("example.txt", bytes);
```

## Credits

- The idea and code from this project is based on [Generating and efficiently exporting a file in a Blazor WebAssembly application](https://www.meziantou.net/generating-and-downloading-a-file-in-a-blazor-webassembly-application.htm)
- For resolving the Content-Type based on the file extension, this code is used: [MimeTypeMap](https://github.com/samuelneff/MimeTypeMap)
- This project is inspired by [BlazorDownloadFile](https://github.com/arivera12/BlazorDownloadFile)

## Demo

https://stefh.github.io/Blazor.DownloadFileFast/
