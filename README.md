# TulioPaim.Results
A Result wrapper for Result, ListResult and PaginatedResult with generic data support

- [Install](#install)
  - [CLI](#i.cli)
  - [Package Manager Console](#i.pmc)
- [Usage](#usage)
  - [Constructors, Static Methods and Structure](#constructors)
    - [Constructors](#c.constructors)
    - [Static Methods](#c.static)
    - [Structure](#c.structure)
  - [Working with Exceptions](#exceptions)
    - [Use Case](#e.use)
    - [Structure](#e.structure)
  - [Returning Data](#data)
    - [Constructors](#d.constructors)
    - [Usage and Structure](#d.usage)
  - [Returning a list](#list)
    - [Usage](#l.usage)
    - [Structure](#l.structure)
  - [Paginated result](#paginated)
    - [Parameters and Usage](#p.params)
    - [Structure](#p.structure)

## <a name="install"></a>Install
[nuget.org](https://www.nuget.org/packages/TulioPaim.Results/) 
### <a name="i.cli"></a>CLI
```
dotnet add package TulioPaim.Results
``` 
### <a name="i.pmc"></a>Package Manager Console
```
Install-Package TulioPaim.Results
``` 

## <a name="usage"></a>Usage

Checkout the [samples project](https://github.com/tuliopaim/TulioPaim.Results/tree/master/samples/TulioPaim.Results.Samples/) for examples

### <a name="constructors"></a>Constructors, Static Methods and Structure:

#### <a name="c.constructors"></a>Constructors
``` csharp
//success
public Result(bool succeeded = true, string message = null);

//error
public Result(string error, string message = null);
public Result(List<string> errors, string message = null);
public Result(Exception exception);
``` 

#### <a name="c.static"></a>Static methods
``` csharp
public static Result Success(string message = null);

public static Result Error(string error, string message = null);
public static Result Error(List<string> errors, string message = null);
public static Result Error(Exception exception);
``` 

#### <a name="c.structure"></a>Structure of a Result:

``` json
{
    "Message": null,
    "Succeeded": true,
    "Errors": []
}
```

### <a name="exceptions"></a>Working with Exceptions

#### <a name="e.use"></a>Use Case
You can create an error result based on a Exception:

``` csharp
try
{
    var zero = 0;
    var x = 1 / zero;
}
catch(Exception ex)
{
    var result = new Result(ex);
}
```

#### <a name="e.structure"></a> Structure
The exception message will be returned in Errors list
``` json
// result
{
  "Message": null,
  "Succeeded": false,
  "Errors": [
    "Attempted to divide by zero."
  ]
}
```

### <a name="data"></a>Returning Data

#### <a name="d.constructors"></a>Constructors

You can return a Data object inside the result using generics

If a result has data, it is a succeeded result
``` csharp
// succeeded
public Result(T data, string message = null);
public static Result<T> Success(T data, string message = null);

//same other error constructors and static methods...
```
#### <a name="d.usage"></a>Usage and Structure
``` csharp
var result = new Result<object>(new { Id = "1", Name = "Tulio" });
```
``` json
// result
{
    "Data": {
        "Id": "1",
        "Name": "Tulio"
    },
    "Message": null,
    "Succeeded": true,
    "Errors": []
}
```

``` csharp
var intResult = new Result<int>(10);
```
``` json 
// intResult
{
    "Data": 10,
    "Message": null,
    "Succeeded": true,
    "Errors": []
}
```
An error result returns the default value of Data type
``` csharp
var errorResult = new Result<int>("Error message");
```

``` json
// errorResult
{
    "Data": 0,
    "Message": null,
    "Succeeded": false,
    "Errors": [
        "Error message"
    ]
}
```

### <a name="list"></a>Returning a list

You can force Data property as a List using a **ListResult**

#### <a name="l.usage"></a> Usage
``` csharp
var listResult = new ListResult<int>(new List<int> { 1, 2 ,3});
var errorListResult = new ListResult<int>("Error message");
``` 
#### <a name="l.structure"></a> Structure
``` json
// listResult
{
    "Data": [ 1, 2, 3 ],
    "IsEmpty": false,
    "Message": null,
    "Succeeded": true,
    "Errors": []
}

// errorListResult
{
    "Data": [],
    "IsEmpty": true,
    "Message": null,
    "Succeeded": false,
    "Errors": [
        "Error message"
    ]
}       
``` 

### <a name="paginated"></a>Paginated result

With **PaginatedResult** you can return the paginated list, wrapped with some pagination info.

#### <a name="p.params"></a>Parameters and Usage

**Data:** The paginated list\
**Total:** The total of itens in the list you are paginating\
**CurrentPage:** The current page beeing returned (should start at 1)\
**PageSize:** The expected page **(even if data count is less then expected)**

``` csharp
var paginated = new PaginatedResult<int>(
    data: new List<int> { 10 },
    total: 10,
    currentPage: 4,
    pageSize: 3,
    message: "A 100 itens list in pages of 3 itens");
```

> For example: \
> 10 itens list to paginate in pages of 3 case will produce 4 lists,
> the last with only one item, but PageSize of 3:

```
Data: [ 1, 2, 3 ]
CurrentPage: 1
PageSize: 3

Data: [ 4, 5, 6 ]
CurrentPage: 2
PageSize: 3

Data: [ 7, 8, 9 ]
CurrentPage: 3
PageSize: 3

Data: [ 10 ]
CurrentPage: 4
PageSize: 3 // still 3
```

#### <a name="p.structure"></a>Structure

##### Success
``` json
// paginated 
{
  "Data": [ 1, 2, 3 ],
  "Total": 100,
  "CurrentPage": 1,
  "PageSize": 3,
  "TotalPages": 34,
  "HasPrevPage": false,
  "HasNextPage": true,
  "Message": "A 100 itens list in pages of 3 itens",
  "Succeeded": true,
  "Errors": []
}
```
##### Error
``` csharp
var paginatedError = new PaginatedResult<int>("Error");
``` 
``` json
// paginatedError
{
  "Data": [],
  "Total": 0,
  "CurrentPage": 0,
  "PageSize": 0,
  "TotalPages": 0,
  "HasPrevPage": false,
  "HasNextPage": false,
  "Message": null,
  "Succeeded": false,
  "Errors": [
    "Error"
  ]
}
```


    



