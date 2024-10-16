# API Testing with NUnit in WSL2

This project is designed to help you set up API tests using NUnit in a WSL2 environment with Visual Studio Code. Follow the steps below to configure your development environment and create your first API tests.

## Prerequisites

Before you begin, ensure you have the following installed:

- [WSL2](https://docs.microsoft.com/en-us/windows/wsl/install)
- [Visual Studio Code](https://code.visualstudio.com/)
- A suitable Linux distribution installed in WSL2 (e.g., Ubuntu 20.04)

## Step-by-Step Setup

### 1. Install .NET SDK

Make sure you have the .NET SDK installed in your WSL2 environment. If not, you can install it using the following commands:

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install -y dotnet-sdk-6.0
```

### 2. Create a New .NET Project

Open a terminal in Visual Studio Code and run the following commands to create a new .NET project:

```bash
mkdir APITestingProject
cd APITestingProject
dotnet new nunit
```

### 3. Install Necessary NuGet Packages

Run the following commands to install the required packages for your API testing project:

```bash
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
dotnet add package RestSharp
dotnet add package FluentAssertions
```

### 4. Write Your API Tests

Once you have your project set up and the necessary packages installed, you can start writing your API tests using NUnit. 

Here’s a simple example of what your test class might look like:

```csharp
using FluentAssertions;
using NUnit.Framework;
using RestSharp;

namespace APITestingProject
{
    public class ApiTests
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://api.example.com");
        }

        [Test]
        public void GetEndpoint_Returns200()
        {
            var request = new RestRequest("endpoint", Method.Get);
            var response = client.Execute(request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
```

### 5. Running Your Tests

To run your tests, execute the following command in your terminal:

```bash
dotnet test
```

This will run all the tests in your project and display the results in the terminal.

## Conclusion

You are now set up to write and run API tests using NUnit in a WSL2 environment with Visual Studio Code. Happy testing!

For more information on NUnit and API testing, check the official documentation:

- [NUnit Documentation](https://nunit.org/)
- [RestSharp Documentation](https://restsharp.dev/)
- [FluentAssertions Documentation](https://fluentassertions.com/)
