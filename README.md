# Pquyquy.WebAPI

Pquyquy.WebAPI is a .NET library that forms part of the Pquyquy project group.

## Table of Contents

- [Installation](#installation)
- [Dependencies](#dependencies)
- [Usage](#usage)
- [License](#license)

## Installation

Currently, the `Pquyquy.WebAPI` NuGet package is not available in the NuGet Gallery. You will need to download the project source code and generate the NuGet package locally. Follow these steps to get started:

   ```bash
   #1. Clone the repository or download the source code:
   git clone [URL]
   #2. Navigate to the project directory:
   cd Pquyquy.WebAPI
   #3. Restore dependencies and build the project
   dotnet restore
   dotnet build
   #4. Generate the NuGet package
   dotnet pack -c Release
   #5. The NuGet package (Pquyquy.WebAPI.[version].nupkg) will be generated in the bin/Release directory of the project. You can then reference this local package in your other projects as needed.
   ```

## Dependencies
- Pquyquy.Application

## Usage

Controllers Base:
- BaseApiController
Extensions:Builders:
- UseWebAPIBuild
Extensions:Services:
- AddWebApiService
Middlewares
- ErrorHandlerMiddleware

## License

This project is licensed under the MIT License. 