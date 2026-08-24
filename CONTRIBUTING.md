# How to build:

1. Create a csproj user file in the project's root directory (name it ``ScaledDecorator.csproj.user``)
2. Add the following contents to the file (make sure to replace the paths with the ones on your system):
```csproj
<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <KSPRoot>[REPLACE WITH A PATH TO KSP'S ROOT]</KSPRoot>
    <RepoRootPath>[REPLACE WITH A PATH TO THE PROJECT ROOT]r</RepoRootPath>
    <BinariesOutputRelativePath>ScaledDecorator</BinariesOutputRelativePath>
  </PropertyGroup>
</Project>
```
3. Run ``dotnet build`` in the project's root folder.
