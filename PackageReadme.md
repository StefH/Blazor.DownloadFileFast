## Blazor.DownloadFileFast
Fast download from files to the browser from Blazor without any javascript library reference or dependency.

BlazorDownloadFileFast is the solution to saving files on the client-side, and is perfect for web apps that generates files on the client.

When using this project in a NET 5 (and up) Blazor WebAssembly project, there is an additional speed increase. 
Read the blog post mentioned from Gérald Barré in the credits.


### Usage

#### Register
```c#
builder.Services.AddBlazorDownloadFile();
```

#### Inject in code-behind
``` c#
[Inject]
public IBlazorDownloadFileService BlazorDownloadFileService { get; set; }
```

#### Use in your code
``` c#
byte[] bytes = ...; 
await BlazorDownloadFileService.DownloadFileAsync("example.txt", bytes);
```

### Credits
- The idea and code from this project is based on [Generating and efficiently exporting a file in a Blazor WebAssembly application](https://www.meziantou.net/generating-and-downloading-a-file-in-a-blazor-webassembly-application.htm)
- For resolving the Content-Type based on the file extension, this code is used: [MimeTypeMap](https://github.com/samuelneff/MimeTypeMap)
- This project is inspired by [BlazorDownloadFile](https://github.com/arivera12/BlazorDownloadFile)

### Demo
- https://wonderful-glacier-0cf7ba303.4.azurestaticapps.net
- https://stefh.github.io/Blazor.DownloadFileFast/

### Sponsors

[Entity Framework Extensions](https://entityframework-extensions.net/?utm_source=StefH) and [Dapper Plus](https://dapper-plus.net/?utm_source=StefH) are major sponsors and proud to contribute to the development of **Blazor.DownloadFileFast**.

[![Entity Framework Extensions](https://raw.githubusercontent.com/StefH/resources/main/sponsor/entity-framework-extensions-sponsor.png)](https://entityframework-extensions.net/bulk-insert?utm_source=StefH)

[![Dapper Plus](https://raw.githubusercontent.com/StefH/resources/main/sponsor/dapper-plus-sponsor.png)](https://dapper-plus.net/bulk-insert?utm_source=StefH)

