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

### 2. Clone the repository

   
   ```bash
   - git clone git@github.com:duartepapel/challenge2_apiTesting.git <SSH> 
   or 
   - git clone https://github.com/duartepapel/challenge2_apiTesting.git <HTTPS>
   - cd challenge2_apiTesting
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


### 4. Running Your Tests

To run your tests, execute the following command in your terminal:

```bash
dotnet test
```

This will run all the tests in your project and display the results in the terminal.

## Conclusion

Happy testing!

For more information on NUnit and API testing, check the official documentation:

- [NUnit Documentation](https://nunit.org/)
- [RestSharp Documentation](https://restsharp.dev/)
- [FluentAssertions Documentation](https://fluentassertions.com/)
